using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace T3.CallDevices
{
    public class T3Call:IT3Call
    {
        List<AssembyViewModel> _Assemblys;
        private static T3Call _instance;

        public static T3Call Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T3Call();

                return _instance;
            }
        }
        public object CallFunction(string pathDll,string functionName, string functionType, object[] var)
        {
            Assembly asc; Type typec; object objc; MethodInfo mi;
            AssembyViewModel vm; TypeViewModel typev;
            pathDll = pathDll.Replace("\\\\", "\\");
            if (_Assemblys != null && _Assemblys.Count(t => t.PathFile == pathDll) > 0)
            {
                vm = _Assemblys.Where(t => t.PathFile == pathDll).FirstOrDefault();
                asc = vm.Assembly;
            }
            else
            {
                vm = new AssembyViewModel();
                asc = Assembly.LoadFrom(pathDll);
                vm.Assembly = asc;
                vm.PathFile = pathDll;
                AddAssembly(asc, pathDll);
            }         
            if (vm.Types != null && vm.Types.Count(t => t.Name == functionType) > 0)
            {
                typev = vm.Types.Where(t => t.Name == functionType).FirstOrDefault();
                typec = typev.Type;
                objc = typev.Object;
            }
            else
            {
                if (vm.Types == null) vm.Types = new List<TypeViewModel>();
                typec = asc.GetType(functionType);
                objc = Activator.CreateInstance(typec);
                typev = new TypeViewModel() { Name = functionType, Type = typec, Object = objc };
                vm.Types.Add(typev);
                AddType(typec, objc, pathDll, typev.Name);
            }
            MethodInfo method = typec.GetMethod(functionName);
            return method.Invoke(objc, var);

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
