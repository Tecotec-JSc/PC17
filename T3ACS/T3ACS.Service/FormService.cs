using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using T3.CallDevices;
using T3ACS.Model;
using T3ACS.Util;

namespace T3ACS.Service
{
    public class FormService:IFormService
    {
        #region properties
        ProcedureModel _model;
        IT3Call _t3Call;
        #endregion
        public FormService()
        {
            _model = new ProcedureModel();
            _t3Call = T3Call.Instance;
        }
        public object CallFunction(string pathDll, string assembly, string assemblyType, string function, object[] vars)
        {
            if (pathDll.StartsWith("\\")) pathDll = AppDomain.CurrentDomain.BaseDirectory + pathDll.Substring(1);

            return _t3Call.CallFunction(pathDll, function, assembly + "." + assemblyType, vars);
        }
        public string ExportReport(string ext, TemplateViewModel vm)
        {
            ExcelModel model = new ExcelModel();
            var newFileName = vm.ReportOutputPath + "\\" + vm.ReportName + ext;
            int newId = 0;

            while (File.Exists(newFileName))
            {
                newId++;
                newFileName = vm.ReportOutputPath + "\\" + vm.ReportName + "(" + newId + ")" + ext;

            }
            var path = AppDomain.CurrentDomain.BaseDirectory + "TemplateExcel.xlsx";
            if (ext == ".PDF")
            {
                var newpathexl = AppDomain.CurrentDomain.BaseDirectory + vm.ReportName;
                if (newId > 0) newpathexl += "(" + newId + ")";
                newpathexl += ".xlsx";
                if (File.Exists(newpathexl)) { File.Delete(newpathexl); }
                if (model.DrawTemplateExcel(vm, path, newpathexl, out string mess))
                {

                    if (FileServices.ConvertExcelToPdf2(newpathexl, vm.ReportOutputPath, out mess))
                    {
                        File.Delete(newpathexl);
                        return "Export file successful.";
                    }
                }
                return mess;

            }
            else
            {
                if (model.DrawTemplateExcel(vm, path, newFileName, out string mess))
                {
                    return "Export file successful.";
                }
                else
                {
                    return mess;
                }
            }
        }
        public bool CallFunctionStop(TemplateViewModel vm, out string mess)
        {
            mess = "";        
            var currentSetp = vm.TableProcedures[vm.CurrentStep - 1];           
            var functionStop = currentSetp.Functions
     .FirstOrDefault(t => t.FunctionName == StepFunctionName.Stop);
            if (functionStop == null) return true;
            object[] var = null;

                if (functionStop.FunctionVariables?.Count > 0)
                {
                    var = ConvertFromVariable(functionStop.FunctionVariables, currentSetp.Variables, vm.Variables);
                }
                object[] inputs = new object[2] { var, mess };
                return (bool)CallFunction(
          functionStop.PathDll,
          functionStop.Assembly,
          functionStop.AssemblyType,
          functionStop.Value,
           inputs);
        }
        public  bool CallFunctionSave(TemplateViewModel vm,string function, out string mess,out TemplateViewModel outResult)
        {
            mess = "";
            outResult = vm;
            var currentSetp = vm.TableProcedures[vm.CurrentStep - 1];
            if (!currentSetp.Done.HasValue || !currentSetp.Done.Value)
            {
                var functionSave = currentSetp.Functions
     .FirstOrDefault(t => t.FunctionName == function);
                object[] var = null;

                if (functionSave.FunctionVariables?.Count > 0)
                {
                    var = ConvertFromVariable(functionSave.FunctionVariables, currentSetp.Variables,vm.Variables);
                }
                object[] inputs = new object[2] { var[0], mess };
                List<object> result = (List<object>)CallFunction(
          functionSave.PathDll,
          functionSave.Assembly,
          functionSave.AssemblyType,
          functionSave.Value,
           inputs);
                if (result != null && result.Count > 0)
                {                
                    for (int i = 1; i < functionSave.FunctionVariables.Count; i++)
                    {
                        var itemSelect = functionSave.FunctionVariables[i];
                        var item = vm.Variables.Where(t => t.Name == itemSelect.VariableName).FirstOrDefault();
                        if (item != null)
                        {
                            var itemdata = currentSetp.Variables.Where(t => t.ProcedureVariableId == item.ProcedureVariableId).FirstOrDefault();
                            if (itemdata != null && result.Count >= i && result[i - 1] != null)
                                switch (item.Type)
                                {
                                    case VariableType.Float:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<float>)result[i - 1]);
                                        // Ghi số theo InvariantCulture để nhất quán với lúc đọc.
                                        else itemdata.Value = Convert.ToString(result[i - 1], CultureInfo.InvariantCulture);
                                        break;
                                    case VariableType.String:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<float>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                    case VariableType.Integer:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<int>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                    case VariableType.Double:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<double>)result[i - 1]);
                                        // Ghi số theo InvariantCulture để nhất quán với lúc đọc.
                                        else itemdata.Value = Convert.ToString(result[i - 1], CultureInfo.InvariantCulture);
                                        break;
                                    case VariableType.Uint:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<uint>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                    case VariableType.Short:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<short>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                    case VariableType.Long:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<long>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                    case VariableType.Boolean:
                                        if (itemSelect.IsList)
                                            itemdata.Value = JsonConvert.SerializeObject((List<long>)result[i - 1]);
                                        else itemdata.Value = result[i - 1].ToString();
                                        break;
                                }
                        }

                    }                
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public object CallFunctionLoad(TemplateViewModel vm,string function, out string mess)
        {
            try
            {
                mess = "";
                var currentStep = vm.TableProcedures[vm.CurrentStep-1];
                var functionload = currentStep.Functions
               .FirstOrDefault(t => t.FunctionName == function);

                object[] var = null;

                if (functionload.FunctionVariables?.Count > 0)
                {
                    var = ConvertFromVariable(functionload.FunctionVariables, currentStep.Variables,vm.Variables);
                }
                try
                {
                    return CallFunction(
                                   functionload.PathDll,
                                   functionload.Assembly,
                                   functionload.AssemblyType,
                                   functionload.Value,
                                   var);
                }
                catch
                {
                    object[] obj = new object[1] { var };
                    return CallFunction(
                              functionload.PathDll,
                              functionload.Assembly,
                              functionload.AssemblyType,
                              functionload.Value,
                              obj);
                }
           
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return null;
            }
        }

        private object[] ConvertFromVariable(List<ProcedureDetailFunctionVariable> varis, List<ProcedureDetaiVariableViewModel> stepvaris,List<ProcedureVariableViewModel> variables)
        {
           

            object[] result = new object[varis.Count];
            int index = 0;
            foreach (ProcedureDetailFunctionVariable var in varis)
            {
                var item = variables.Where(t => t.Name == var.VariableName).FirstOrDefault();
                var obj = stepvaris.Where(t => t.Name == var.VariableName).FirstOrDefault();
                switch (item.Type)
                {
                    case VariableType.Float:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<float>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = float.Parse(item.Value, CultureInfo.InvariantCulture);
                            else result[index] = float.Parse(obj.Value, CultureInfo.InvariantCulture);
                        }
                        break;
                    case VariableType.Integer:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<int>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = int.Parse(item.Value);
                            else result[index] = int.Parse(obj.Value);
                        }
                        break;
                    case VariableType.Double:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<double>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                            {
                                if (string.IsNullOrEmpty(item.Value)) result[index] = 0;
                                else
                                    result[index] = double.Parse(item.Value, CultureInfo.InvariantCulture);
                            }
                            else {
                                if (string.IsNullOrEmpty(obj.Value)) result[index] = 0;
                                else
                                result[index] = double.Parse(obj.Value, CultureInfo.InvariantCulture);
                            
                            }

                        }
                        break;
                    case VariableType.String:
                        if (obj == null || string.IsNullOrEmpty(obj.Value))
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                    case VariableType.Boolean:
                        if (string.IsNullOrEmpty(item.Value)) result[index] = false;
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = bool.Parse(item.Value);
                            else result[index] = bool.Parse(obj.Value);
                        }
                        break;
                    case VariableType.PathFile:
                        if (obj == null)
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                }
                index++;
            }
            return result;
        }

    }
}
