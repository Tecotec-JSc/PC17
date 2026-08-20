using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;


namespace T3.CallDevices
{
    public class T3Call : IT3Call
    {
        List<AssembyViewModel> _Assemblys;
        private static T3Call _instance;

        // Khóa dùng chung cho toàn bộ thao tác nạp/cache assembly (singleton dùng đa luồng).
        private static readonly object _sync = new object();

        // Tập thư mục của mọi driver đã nạp, để resolver dò dependency (giống TapAssemblyResolver của OpenTAP).
        private static readonly HashSet<string> _probeDirs =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Chỉ đăng ký resolver một lần cho cả tiến trình.
        private static bool _resolverRegistered;

        public static T3Call Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T3Call();

                return _instance;
            }
        }

        public object CallFunction(string pathDll, string functionName, string functionType, object[] var)
        {
            Type typec; object objc;
            AssembyViewModel vm; TypeViewModel typev;

            // Chuẩn hoá đường dẫn tuyệt đối để cache không bị nạp trùng do khác cách viết path
            // (ví dụ "C:\a\x.dll" vs "c:\a\x.dll" hoặc dấu gạch chéo khác nhau).
            pathDll = Path.GetFullPath(pathDll.Replace("\\\\", "\\"));

            // Vùng nạp + cache phải khóa để tránh 2 luồng cùng nạp một DLL (double-load -> lệch identity type).
            lock (_sync)
            {
                if (_Assemblys != null &&
                    _Assemblys.Count(t => string.Equals(t.PathFile, pathDll, StringComparison.OrdinalIgnoreCase)) > 0)
                {
                    vm = _Assemblys.First(t => string.Equals(t.PathFile, pathDll, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    vm = new AssembyViewModel();
                    vm.Assembly = LoadPluginAssembly(pathDll);
                    vm.PathFile = pathDll;
                    AddAssembly(vm.Assembly, pathDll);
                }

                if (vm.Types != null && vm.Types.Count(t => t.Name == functionType) > 0)
                {
                    typev = vm.Types.First(t => t.Name == functionType);
                    typec = typev.Type;
                    objc = typev.Object;
                }
                else
                {
                    if (vm.Types == null) vm.Types = new List<TypeViewModel>();
                    typec = vm.Assembly.GetType(functionType);
                    if (typec == null)
                        throw new TypeLoadException(
                            $"Không tìm thấy type '{functionType}' trong DLL: {pathDll}");
                    objc = Activator.CreateInstance(typec);
                    typev = new TypeViewModel() { Name = functionType, Type = typec, Object = objc };
                    vm.Types.Add(typev);
                    AddType(typec, objc, pathDll, typev.Name);
                }
            }

            // Gọi hàm thiết bị NGOÀI khóa: tránh chặn các lời gọi khác và tránh deadlock nếu hàm gọi lại vào đây.
            MethodInfo method = typec.GetMethod(functionName);
            if (method == null)
                throw new MissingMethodException(
                    $"Không tìm thấy method '{functionName}' trên type '{functionType}' (DLL: {pathDll})");
            return method.Invoke(objc, var);
        }

        // Nạp assembly driver theo phong cách PluginManager của OpenTAP:
        // - nạp vào AssemblyLoadContext.Default (xác định, một assembly/một path, không lệch identity),
        // - ghi nhớ thư mục để resolver trung tâm dò các dependency đi kèm.
        private static Assembly LoadPluginAssembly(string fullPath)
        {
            EnsureResolver();

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Không tìm thấy DLL thiết bị: {fullPath}", fullPath);

            string dir = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(dir))
                _probeDirs.Add(dir);

            try
            {
                return AssemblyLoadContext.Default.LoadFromAssemblyPath(fullPath);
            }
            catch (Exception ex)
            {
                // Bọc lỗi kèm ngữ cảnh để dễ truy vết DLL/dependency nào hỏng.
                throw new InvalidOperationException(
                    $"Nạp DLL thiết bị thất bại: {fullPath}. Chi tiết: {ex.Message}", ex);
            }
        }

        // Đăng ký resolver trung tâm một lần: khi runtime cần một dependency, tự tìm trong
        // các thư mục driver đã nạp và trả về assembly đã nạp sẵn nếu trùng tên (dedup theo danh tính).
        private static void EnsureResolver()
        {
            if (_resolverRegistered) return;
            // Đang được gọi bên trong lock(_sync) từ CallFunction, nhưng kiểm tra lại cho chắc.
            AssemblyLoadContext.Default.Resolving += (ctx, name) => ResolveDependency(name);
            AppDomain.CurrentDomain.AssemblyResolve += (s, args) => ResolveDependency(new AssemblyName(args.Name));
            _resolverRegistered = true;
        }

        private static Assembly ResolveDependency(AssemblyName name)
        {
            // 1) Nếu đã nạp sẵn trong tiến trình thì tái dùng, tránh nạp 2 bản cùng tên.
            var loaded = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => string.Equals(a.GetName().Name, name.Name, StringComparison.OrdinalIgnoreCase));
            if (loaded != null) return loaded;

            // 2) Dò file <tên>.dll trong các thư mục driver đã biết.
            string[] dirs;
            lock (_sync) { dirs = _probeDirs.ToArray(); }
            foreach (var dir in dirs)
            {
                string candidate = Path.Combine(dir, name.Name + ".dll");
                if (File.Exists(candidate))
                {
                    try { return AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(candidate)); }
                    catch { /* thử thư mục kế tiếp */ }
                }
            }
            return null; // Không tìm được -> để runtime báo lỗi gốc.
        }

        private void AddAssembly(Assembly assembly, string pathfile)
        {
            if (_Assemblys == null) _Assemblys = new List<AssembyViewModel>();
            _Assemblys.Add(new AssembyViewModel() { Assembly = assembly, PathFile = pathfile });
        }
        private void AddType(Type type, object obj, string pathfile, string name)
        {
            var asem = _Assemblys.Where(t => t.PathFile == pathfile).FirstOrDefault();
            if (asem != null)
            {
                if (asem.Types == null) asem.Types = new List<TypeViewModel>();
                asem.Types.Add(new TypeViewModel() { Type = type, Object = obj, Name = name });
            }
        }
    }
}
