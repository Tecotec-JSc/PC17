using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using T3.CallDevices;
using T3ACS.Model;

namespace T3ACS.Service
{
    public class FormMainService :IFormMainService
    {
        
        public FormMainService()
        {
            _pModel = new PackageModel();
            _t3Call = T3Call.Instance;
        }
        public List<ToolsViewModel> GetTools()
        {
            return _pModel.GetTools();
        }
        #region properties
        PackageModel _pModel;
        IT3Call _t3Call;
        List<ToolsViewModel> _tools;

        #endregion

        public object CallTool(int toolId, out string mess)
        {
            mess = "";
            if (_tools != null && _tools.Count(t => t.Id == toolId) > 0)
            {
                try
                {
                    var item = _tools.Where(t => t.Id == toolId).FirstOrDefault();
                    if (item.Path.StartsWith("\\")) item.Path = AppDomain.CurrentDomain.BaseDirectory + item.Path.Substring(1);
                    if (File.Exists(item.Path))
                    {
                        item.Path = item.Path.Replace("\\\\", "\\");
                        var col = item.Content.Split(',');
                        var typeName = col[0] + "." + col[1];
                        var functionName = col[3];
                        return _t3Call.CallFunction(item.Path, functionName, typeName, null);  
                    }
                    else
                    {
                        mess=item.Path + " is not exists.";
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    mess=ex.ToString();
                    return null;
                }
            }
            return null;
        }
    }
}
