using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace T3.CallDevices
{
    public class AssembyViewModel
    {
        public Assembly Assembly { get; set; }
        public string PathFile { get; set; }
        public List<TypeViewModel> Types { get; set; }
    }
    public class TypeViewModel
    {
        public Type Type { get; set; }
        public string Name { get; set; }
        public object Object { get; set; }
        public List<MethodInfoViewModel> MethodInfos { get; set; }
    }
    public class MethodInfoViewModel
    {
        public MethodInfo MethodInfo { get; set; }
        public string FunctionName { set; get; }
    }
}
