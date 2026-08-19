using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.CallDevices
{
    public class InvokeRequest
    {
        public string DllPath { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public object[] Parameters { get; set; }
    }
}
