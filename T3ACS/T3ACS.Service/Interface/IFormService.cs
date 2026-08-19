using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3.CallDevices;
using T3ACS.Model;

namespace T3ACS.Service
{
    public interface IFormService
    {
        object CallFunction(string pathDll, string assembly, string assemblyType, string function, object[] vars);
        string ExportReport(string ext, TemplateViewModel vm);
        bool CallFunctionSave(TemplateViewModel vm, string function, out string mess, out TemplateViewModel outResult);
        bool CallFunctionStop(TemplateViewModel vm, out string mess);
        object CallFunctionLoad(TemplateViewModel vm, string function, out string mess);
    }
}
