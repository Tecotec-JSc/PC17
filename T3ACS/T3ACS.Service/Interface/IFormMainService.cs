using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3ACS.Model;

namespace T3ACS.Service
{
    public interface IFormMainService
    {
        List<ToolsViewModel> GetTools();
        object CallTool(int toolId, out string mess);
    }
}
