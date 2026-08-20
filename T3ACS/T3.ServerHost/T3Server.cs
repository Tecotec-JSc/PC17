using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Threading.Tasks;

namespace T3.ServerHost
{


    public static class T3Server
    {
        private static readonly Dictionary<string, Assembly>
            _assemblies =
            new Dictionary<string, Assembly>();

        private static readonly Dictionary<string, object>
            _instances =
            new Dictionary<string, object>();

        public static void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        using (var pipe =
                            new NamedPipeServerStream(
                                "T3.ServerHost",
                                PipeDirection.InOut))
                        {
                            pipe.WaitForConnection();
                            using (var reader =
                           new StreamReader(pipe))
                            using (var writer =
                                new StreamWriter(pipe))
                            {
                                writer.AutoFlush = true;

                                string json =
                                    reader.ReadLine();

                                string result =
                                    ProcessRequest(json);

                                writer.WriteLine(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    File.WriteAllText(
                        @"D:\T3Error.txt",
                        ex.ToString());
                }
            });




        }

        public static string ProcessRequest(
            string json)
        {
            try
            {
                var request =
                    JsonConvert.DeserializeObject
                    <InvokeRequest>(json);

                var response =
                    Execute(request);

                return JsonConvert.SerializeObject(
                    response);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(
                    new InvokeResponse
                    {
                        Success = false,
                        Error = ex.ToString()
                    });
            }
        }

        private static InvokeResponse Execute(
            InvokeRequest request)
        {
            try
            {
                // Chuẩn hoá path tuyệt đối để cache không nạp trùng do khác cách viết đường dẫn.
                string dllPath = PluginLoader.Normalize(request.DllPath);

                Assembly assembly;

                if (!_assemblies.TryGetValue(
                    dllPath,
                    out assembly))
                {
                    assembly = PluginLoader.Load(dllPath);

                    _assemblies.Add(
                        dllPath,
                        assembly);
                }

                Type type =
                    assembly.GetType(
                        request.ClassName);
                if (type == null)
                    throw new TypeLoadException(
                        "Không tìm thấy type '" + request.ClassName + "' trong DLL: " + dllPath);

                string key =
                    dllPath +
                    "|" +
                    request.ClassName;

                object instance;

                if (!_instances.TryGetValue(
                    key,
                    out instance))
                {
                    instance =
                        Activator.CreateInstance(
                            type);

                    _instances.Add(
                        key,
                        instance);
                }

                MethodInfo method =
                    type.GetMethod(
                        request.MethodName);

                object result =
                    method.Invoke(
                        instance,
                        request.Parameters);

                return new InvokeResponse
                {
                    Success = true,
                    ResultJson = result == null
          ? null
          : JsonConvert.SerializeObject(result)
                };
            }
            catch (Exception ex)
            {
                return new InvokeResponse
                {
                    Success = false,
                    Error = ex.ToString()
                };
            }
        }
    }

    /// <summary>
    /// Nạp assembly plugin ổn định theo phong cách PluginManager của OpenTAP (bản .NET Framework 4.8):
    /// resolver trung tâm dò dependency theo thư mục driver, chuẩn hoá path, an toàn đa luồng.
    /// (.NET Framework không có AssemblyLoadContext nên dùng AppDomain.AssemblyResolve.)
    /// </summary>
    internal static class PluginLoader
    {
        private static readonly object _sync = new object();

        // Tập thư mục của mọi driver đã nạp, để resolver dò dependency đi kèm.
        private static readonly HashSet<string> _probeDirs =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static bool _resolverRegistered;

        // Chuẩn hoá thành đường dẫn tuyệt đối để cache không nạp trùng.
        public static string Normalize(string path)
        {
            return Path.GetFullPath((path ?? string.Empty).Replace("\\\\", "\\"));
        }

        public static Assembly Load(string fullPath)
        {
            EnsureResolver();

            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Không tìm thấy DLL thiết bị: " + fullPath, fullPath);

            string dir = Path.GetDirectoryName(fullPath);
            lock (_sync)
            {
                if (!string.IsNullOrEmpty(dir))
                    _probeDirs.Add(dir);
            }

            try
            {
                return Assembly.LoadFrom(fullPath);
            }
            catch (Exception ex)
            {
                // Bọc lỗi kèm ngữ cảnh để dễ truy vết DLL/dependency nào hỏng.
                throw new InvalidOperationException(
                    "Nạp DLL thiết bị thất bại: " + fullPath + ". Chi tiết: " + ex.Message, ex);
            }
        }

        // Đăng ký resolver trung tâm một lần cho cả tiến trình.
        private static void EnsureResolver()
        {
            if (_resolverRegistered) return;
            lock (_sync)
            {
                if (_resolverRegistered) return;
                AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
                _resolverRegistered = true;
            }
        }

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var requested = new AssemblyName(args.Name);

            // 1) Đã nạp sẵn trong tiến trình -> tái dùng, tránh nạp 2 bản cùng tên (lệch identity type).
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (string.Equals(a.GetName().Name, requested.Name, StringComparison.OrdinalIgnoreCase))
                    return a;
            }

            // 2) Dò file <tên>.dll trong các thư mục driver đã biết.
            string[] dirs;
            lock (_sync)
            {
                dirs = new string[_probeDirs.Count];
                _probeDirs.CopyTo(dirs);
            }
            foreach (var dir in dirs)
            {
                string candidate = Path.Combine(dir, requested.Name + ".dll");
                if (File.Exists(candidate))
                {
                    try { return Assembly.LoadFrom(candidate); }
                    catch { /* thử thư mục kế tiếp */ }
                }
            }
            return null; // Không tìm được -> để runtime báo lỗi gốc.
        }
    }
}
