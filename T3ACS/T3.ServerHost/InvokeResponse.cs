using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.ServerHost
{
    public class InvokeResponse
    {
        public bool Success { get; set; }

        public string ResultJson { get; set; }

        public string Error { get; set; }
    }
}
