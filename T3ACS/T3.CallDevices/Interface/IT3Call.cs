using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.CallDevices
{
    public interface IT3Call
    {
        object CallFunction(string pathDll, string functionName, string functionType, object[] var);
    }
}
