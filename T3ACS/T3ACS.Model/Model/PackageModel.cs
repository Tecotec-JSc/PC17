
using Newtonsoft.Json;
using OfficeOpenXml.Drawing.Chart;
using T3ACS.Data;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class PackageModel
    {
        IPackageManager _manager;
        public PackageModel()
        {
            _manager = new PackageManager();
        }
        public int InsertPackage(FileExtensionInputViewModel vm, string filepack)
        {
            var newDirection = "";
            if (vm.Type == (int)EnumTypeExtension.Tool)
            {

                //Tools
                newDirection = AppDomain.CurrentDomain.BaseDirectory + vm.Name + "\\Tools\\" + vm.Version + "\\";
                while (newDirection.IndexOf(" ") != -1)
                {
                    newDirection = newDirection.Replace(" ", "");
                }
                if (Directory.Exists(newDirection))
                {
                    Directory.Delete(newDirection, true);
                }
                Directory.CreateDirectory(newDirection);
                var oldDirection = filepack.Substring(0, filepack.LastIndexOf("\\") + 1);
                // CopyFile
                var sourf = oldDirection + vm.PathDll.Substring(0, vm.PathDll.LastIndexOf("\\"));
                FileXML.DirectoryCopy(sourf, newDirection, true);
                var newId2vz = _manager.InsertPackage(vm.Name, vm.Description, vm.Description, vm.Category, vm.Version, vm.Type, newDirection, vm.Model, vm.TypeFrame, null);
                if (newId2vz > 0)
                {

                    _manager.InsertPackageDetails(newId2vz, vm.Name, vm.Type, vm.Description, vm.Name, vm.Category, newDirection + vm.PathDll.Substring(vm.PathDll.LastIndexOf("\\")), vm.FunctionCalls[0].Assembly + "," + vm.FunctionCalls[0].AssemblyType + "," + vm.FunctionCalls[0].Name + "," + vm.FunctionCalls[0].FunctionName);
                }
                return newId2vz;
            }
            else if (vm.Type == (int)EnumTypeExtension.Procedure)
            {
                if (!string.IsNullOrEmpty(vm.PathDll))
                {
                    //Tools
                    newDirection = AppDomain.CurrentDomain.BaseDirectory + vm.Name + "\\Procedure\\" + vm.Version + "\\";
                    while (newDirection.IndexOf(" ") != -1)
                    {
                        newDirection = newDirection.Replace(" ", "");
                    }
                    if (Directory.Exists(newDirection))
                    {
                        Directory.Delete(newDirection, true);
                    }
                    Directory.CreateDirectory(newDirection);
                    var oldDirection = filepack.Substring(0, filepack.LastIndexOf("\\") + 1);
                    // CopyFile
                    var sourf = oldDirection + vm.PathDll.Substring(0, vm.PathDll.LastIndexOf("\\"));
                    FileXML.DirectoryCopy(sourf, newDirection, true);
                }
                var newId2vz = _manager.InsertPackage(vm.Name, vm.Description, vm.Description, vm.Category, vm.Version, vm.Type, newDirection, vm.Model, vm.TypeFrame, null);
                if (newId2vz > 0)
                {
                    var newstr = "";
                    if (!string.IsNullOrEmpty(vm.PathDll))
                    {
                        newstr = newDirection + vm.PathDll.Substring(vm.PathDll.LastIndexOf("\\"));
                    }
                    var strValue = "";
                    if (vm.FunctionCalls != null && vm.FunctionCalls.Count > 0)
                    {
                        strValue = vm.FunctionCalls[0].Assembly + "," + vm.FunctionCalls[0].AssemblyType + "," + vm.FunctionCalls[0].Name;
                    }
                    _manager.InsertPackageDetails(newId2vz, vm.Name, vm.Type, vm.Description, vm.Name, vm.Category, newstr, strValue);
                    ProcedureModel pm = new ProcedureModel();
                    if (vm.Procedures != null && vm.Procedures.Count > 0)
                    {
                        foreach (var procedure in vm.Procedures)
                        {
                            // CheckStepType
                            if (procedure.TableProcedures != null && procedure.TableProcedures.Count > 0)
                            {
                                foreach (var step in procedure.TableProcedures)
                                {
                                    if (!pm.CheckIsExist(step.StepType))
                                    {
                                        //
                                        TemplateViewModel newVm = new TemplateViewModel();
                                        newVm.TableProcedures = new List<TableProcedureViewModel>() { step };
                                        var variable = procedure.Variables.Where(t => step.Variables.Select(i => i.Name).ToList().Contains(t.Name)).ToList();
                                        newVm.Variables = variable;
                                        step.GroupName = "Configuration & Parameters";
                                        var checkId= pm.InsertStepType(step.StepType, step.Description, procedure.Category, procedure.Version, step.GroupName, step.LoopInput, JsonConvert.SerializeObject(newVm));
                                    }
                                }
                                //




                                var newId = pm.InsertProcedure(procedure.Subject, pm.GetNewId(), procedure.Description, procedure.Version, procedure.Category, procedure.Duration, "", null, procedure.Variables);
                                procedure.ProcedureId = newId;
                                pm.UpdateProcedure(procedure, out string error);
                            }
                        }
                    }
                }
                    return newId2vz;
                }
            else if (vm.Type == (int)EnumTypeExtension.StepType)
            {
                if (!string.IsNullOrEmpty(vm.PathDll))
                {
                    //Tools
                    newDirection = AppDomain.CurrentDomain.BaseDirectory + vm.Name + "\\Procedure\\" + vm.Version + "\\";
                    while (newDirection.IndexOf(" ") != -1)
                    {
                        newDirection = newDirection.Replace(" ", "");
                    }
                    if (Directory.Exists(newDirection))
                    {
                        Directory.Delete(newDirection, true);
                    }
                    Directory.CreateDirectory(newDirection);
                    var oldDirection = filepack.Substring(0, filepack.LastIndexOf("\\") + 1);
                    // CopyFile
                    var sourf = oldDirection + vm.PathDll.Substring(0, vm.PathDll.LastIndexOf("\\"));
                    FileXML.DirectoryCopy(sourf, newDirection, true);
                }
                var newId2vz = _manager.InsertPackage(vm.Name, vm.Description, vm.Description, vm.Category, vm.Version, vm.Type, newDirection, vm.Model, vm.TypeFrame, null);
                if (newId2vz > 0)
                {
                    var newstr = "";
                    if (!string.IsNullOrEmpty(vm.PathDll))
                    {
                        newstr = newDirection + vm.PathDll.Substring(vm.PathDll.LastIndexOf("\\"));
                    }
                    var strValue = "";
                    if (vm.FunctionCalls != null && vm.FunctionCalls.Count > 0)
                    {
                        strValue = vm.FunctionCalls[0].Assembly + "," + vm.FunctionCalls[0].AssemblyType + "," + vm.FunctionCalls[0].Name;
                    }
                    _manager.InsertPackageDetails(newId2vz, vm.Name, vm.Type, vm.Description, vm.Name, vm.Category, newstr, strValue);
                    ProcedureModel pm = new ProcedureModel();
                    if (vm.Procedures != null && vm.Procedures.Count > 0)
                    {
                        foreach (var procedure in vm.Procedures)
                        {
                            // CheckStepType
                            if (procedure.TableProcedures != null && procedure.TableProcedures.Count > 0)
                            {
                                foreach (var step in procedure.TableProcedures)
                                {
                                    if (!pm.CheckIsExist(step.StepType))
                                    {
                                        //
                                        TemplateViewModel newVm = new TemplateViewModel();
                                        newVm.TableProcedures = new List<TableProcedureViewModel>() { step };
                                        var variable = procedure.Variables.Where(t => step.Variables.Select(i => i.Name).ToList().Contains(t.Name)).ToList();
                                        newVm.Variables = variable;
                                        step.GroupName = "Configuration & Parameters";
                                        var checkId = pm.InsertStepType(step.StepType, step.Description, procedure.Category, procedure.Version, step.GroupName, step.LoopInput, JsonConvert.SerializeObject(newVm));
                                    }
                                }
                              
                            }
                        }
                    }
                }
                return newId2vz;
            }
            else
                {
                    var newId = _manager.InsertPackage(vm.Name, vm.Description, vm.Description, vm.Category, vm.Version, vm.Type, newDirection, vm.Model, vm.TypeFrame, null);
                    if (newId > 0)
                    {
                        if (vm.Type == (int)EnumTypeExtension.Solution)
                        {
                            if (vm.Extensions != null && vm.Extensions.Count > 0)
                            {
                                // Procedure
                                if (vm.Extensions.Where(t => t.Type == (int)EnumTypeExtension.Procedure).Count() > 0)
                                {
                                    //ProcedureModel model = new ProcedureModel();
                                    //var Exprocedures = vm.Extensions.Where(t => t.Type == (int)EnumTypeExtension.Procedure).ToList();
                                    //foreach (var eprocedure in Exprocedures)
                                    //{
                                    //    var procredure = eprocedure.Procedure;
                                    //    var newDirectionProcedure = "";
                                    //    newDirectionProcedure = AppDomain.CurrentDomain.BaseDirectory + vm.Name + vm.Version +
                                    //        "_" + vm.Type + "\\";
                                    //    if (Directory.Exists(newDirectionProcedure))
                                    //    {
                                    //        Directory.Delete(newDirectionProcedure, true);
                                    //    }
                                    //    Directory.CreateDirectory(newDirectionProcedure);
                                    //    procredure = changeFileToImport(procredure, newDirectionProcedure);
                                    //    Dictionary<string, string> metadata = new Dictionary<string, string>();
                                    //    if (!string.IsNullOrEmpty(procredure.MetaData)) metadata = JsonConvert.DeserializeObject<Dictionary<string, string>>(procredure.MetaData);
                                    //    var newprocedureId = model.InsertProcedure(procredure.Subject, model.GetNewId(), procredure.Description, procredure.Version, procredure.Category, procredure.Duration, procredure.DUTName, metadata, procredure.Variables);
                                    //    if (newprocedureId > 0)
                                    //    {
                                    //        procredure.ProcedureId = newprocedureId;
                                    //        model.UpdateProcedure(procredure, out string error);
                                    //    }
                                    //}
                                }
                                // Devices
                                if (vm.Extensions.Where(t => t.Type == (int)EnumTypeExtension.Driver).Count() > 0)
                                {
                                    var exDrivers = vm.Extensions.Where(t => t.Type == (int)EnumTypeExtension.Driver).ToList();
                                    foreach (var exDriver in exDrivers)
                                    {
                                        var newDirectionDriver = AppDomain.CurrentDomain.BaseDirectory + exDriver.Name + exDriver.Model + exDriver.Version + "\\";
                                        if (Directory.Exists(newDirectionDriver))
                                        {
                                            Directory.Delete(newDirectionDriver, true);
                                        }
                                        Directory.CreateDirectory(newDirectionDriver);
                                        var oldDirection = filepack.Substring(0, filepack.LastIndexOf("\\") + 1);

                                        // CopyFile
                                        var sourf = oldDirection + exDriver.PathDll.Substring(0, exDriver.PathDll.LastIndexOf("\\"));
                                        FileXML.DirectoryCopy(sourf, newDirectionDriver, true);

                                        var newId2vz = _manager.InsertPackage(exDriver.Name, exDriver.Description, vm.Description, vm.Category, vm.Version, vm.Type, newDirection, vm.Model, vm.TypeFrame, null);
                                    }
                                }
                                // Tools

                            }


                        }
                        else if (vm.Type == 1 && vm.FunctionCalls != null && vm.FunctionCalls.Count > 0)
                        {
                            foreach (var call in vm.FunctionCalls)
                            {
                                int type = 0;
                                if (call.SetType) type = 1;
                                _manager.InsertPackageDetails(newId, call.Name, type, call.Description, call.Assembly + "." + call.AssemblyType, call.MetaData, newDirection + vm.PathDll.Substring(vm.PathDll.LastIndexOf("\\") + 1), JsonConvert.SerializeObject(call.FunctionValues));
                            }
                        }



                        //}

                    }
                    return newId;
                }
            }
      
        private TemplateViewModel changeFileToImport(TemplateViewModel vm, string currentFolder)
        {
            InsertFileFromDescription(vm.Description, currentFolder);
            foreach (var step in vm.TableProcedures)
            {
                if (!string.IsNullOrEmpty(step.Description))
                    InsertFileFromDescription(vm.Description, currentFolder);
                if (!string.IsNullOrEmpty(step.PathDll) && step.PathDll.IndexOf("\\") == 0)
                {
                    step.PathDll = currentFolder + step.PathDll;
                }
                if (!string.IsNullOrEmpty(step.PathSource) && step.PathSource.IndexOf("\\") == 0)
                {
                    step.PathSource = currentFolder + step.PathSource;
                }
            }
            return vm;
        }
        private void InsertFileFromDescription(string des, string currentFolder)
        {
            List<string> lstDes = splitDescription(des);
            if (lstDes != null && lstDes.Count > 0)
            {
                if (lstDes != null && lstDes.Count > 0)
                {
                    foreach (var strdes in lstDes)
                    {
                        if (strdes.IndexOf("<linkimg>") != -1)
                        {
                            var str1 = strdes.Substring(strdes.IndexOf("path=\"") + 6);
                            var shortpathFile = str1.Substring(0, str1.IndexOf("\""));
                            var olFile = currentFolder + "\\" + shortpathFile;
                            var newFile = AppDomain.CurrentDomain.BaseDirectory + shortpathFile;
                            try
                            {
                                File.Copy(olFile, newFile, true);
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                }
            }
        }
        private List<string> splitDescription(string des)
        {

            List<string> result = new List<string>();
            if (!string.IsNullOrEmpty(des))
            {
                string needsplit = des;
                var a = needsplit.IndexOf("<linkimg>");
                var b = needsplit.IndexOf("</linkimg>");
                if (needsplit.IndexOf("<linkimg>") != -1 && needsplit.IndexOf("</linkimg>") != -1)
                {
                    while (needsplit.IndexOf("<linkimg>") != -1 && needsplit.IndexOf("</linkimg>") != -1)
                    {
                        if (needsplit.IndexOf("<linkimg>") > 0)
                        {
                            result.Add(needsplit.Substring(0, needsplit.IndexOf("<linkimg>")));
                            needsplit = needsplit.Substring(needsplit.IndexOf("<linkimg>"));
                        }
                        result.Add(needsplit.Substring(0, needsplit.IndexOf("</linkimg>") + 11));
                        if (needsplit.Length > needsplit.IndexOf("</linkimg>") + 11)
                        {
                            needsplit = needsplit.Substring(needsplit.IndexOf("</linkimg>") + 11);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else result.Add(des);
            }

            return result;
        }
        public bool CheckIsExist(string packageName, string version)
        {
            return _manager.CheckIsExist(packageName, version);
        }
        public List<RowTableExtensionViewModel> Gets()
        {
            List<RowTableExtensionViewModel> result = new List<RowTableExtensionViewModel>();
            var dt = _manager.Gets();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    RowTableExtensionViewModel item = new RowTableExtensionViewModel();
                    item.Id = int.Parse(row["PackageId"].ToString());
                    item.PackageName = row["PackageName"].ToString();
                    item.Description = row["PackageTitle"].ToString();
                    item.Version = row["Version"].ToString();
                    item.Model = row["Model"].ToString();
                    var str = row["Type"].ToString();
                    if (string.IsNullOrEmpty(str) || str == "1")
                    {
                        item.TypeName = "Devices";
                    }
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ToolsViewModel> GetTools()
        {
            var result = new List<ToolsViewModel>();
            var dt = _manager.GetsBy(4, "");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ToolsViewModel();
                    item.Id = int.Parse(row["PackageId"].ToString());
                    item.Name = row["PackageName"].ToString();
                    item.TypeFrame = row["TypeFrame"].ToString();

                    var dt2 = _manager.GetDetailsBy(item.Id);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        DataRow row2 = dt2.Rows[0];

                        item.Type = int.Parse(row2["Type"].ToString());
                        item.Content = row2["Content"].ToString();
                        item.Path = row2["PathFile"].ToString();
                    }
                    result.Add(item);
                }
            }
            return result;
        }

        public bool Delete(int packageId)
        {
            var dataTable = _manager.GetById(packageId);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                var path = row["PathSource"].ToString();
                if (Directory.Exists(path)) Directory.Delete(path, true);
            }
            if (_manager.DeletePackageDetailByPackageId(packageId) && _manager.Delete(packageId))
            {
                return true;
            }
            return false;
        }
        public bool CheckDelete(int packageId)
        {
            return true;
        }
        //public List<ToolInsertViewModel> GetToolInserts()
        //{
        //    ToolInsertManager manager = new ToolInsertManager();
        //    return manager.Gets();
        //}
    }
}
