using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.FormService
{
    public class FormMainService
    {
        //List<ToolsViewModel> _tools;
        //public Form CallTool(int toolId)
        //{
        //    if (_tools != null && _tools.Count(t => t.Id == toolId) > 0)
        //    {
        //        try
        //        {
        //            var item = _tools.Where(t => t.Id == toolId).FirstOrDefault();
        //            if (item.Path.StartsWith("\\")) item.Path = AppDomain.CurrentDomain.BaseDirectory + item.Path.Substring(1);
        //            if (File.Exists(item.Path))
        //            {
        //                Assembly asc; Type typec; object objc; MethodInfo mi;
        //                AssembyViewModel vm; TypeViewModel typev;
        //                item.Path = item.Path.Replace("\\\\", "\\");
        //                if (_Assemblys != null && _Assemblys.Count(t => t.PathFile == item.Path) > 0)
        //                {
        //                    vm = _Assemblys.Where(t => t.PathFile == item.Path).FirstOrDefault();
        //                    asc = vm.Assembly;
        //                }
        //                else
        //                {
        //                    vm = new AssembyViewModel();
        //                    asc = Assembly.LoadFrom(item.Path);
        //                    vm.Assembly = asc;
        //                    vm.PathFile = item.Path;
        //                    AddAssembly(asc, item.Path);
        //                }
        //                var col = item.Content.Split(',');
        //                var typeName = col[0] + "." + col[1];
        //                var functionName = col[3];
        //                if (vm.Types != null && vm.Types.Count(t => t.Name == typeName) > 0)
        //                {
        //                    typev = vm.Types.Where(t => t.Name == typeName).FirstOrDefault();
        //                    typec = typev.Type;
        //                    objc = typev.Object;
        //                }
        //                else
        //                {
        //                    if (vm.Types == null) vm.Types = new List<TypeViewModel>();
        //                    typec = asc.GetType(typeName);
        //                    objc = Activator.CreateInstance(typec);
        //                    typev = new TypeViewModel() { Name = typeName, Type = typec, Object = objc };
        //                    vm.Types.Add(typev);
        //                    AddType(typec, objc, item.Path, typev.Name);
        //                }
        //                MethodInfo mia = typec.GetMethod(functionName);
        //                Form frm = (Form)mia.Invoke(objc, null);
        //                frm.TopLevel = true;
        //                frm.Show();
        //            }
        //            else
        //            {
        //                MessageBox.Show(item.Path + " is not exists.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //    }
        //}
    }
}
