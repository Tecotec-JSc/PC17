using Newtonsoft.Json;
using T3ACS.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace T3ACS.Model
{
    public class ProcedureModel
    {
        IProcedureManager _manager;
        IProcedureDetailManager _detailManager;
        // Dùng CHUNG một SQLiteDataBase cho cả 2 manager để có thể bọc chuỗi lưu trong 1 transaction.
        SQLiteDataBase _db;

        public ProcedureModel()
        {
            _db = new SQLiteDataBase();
            _manager = new ProcedureManager(_db);
            _detailManager = new ProcedureDetailManager(_db);
        }

        #region Get
        #region Result Procedure
        public string GetLogBy(int resultProcedureId)
        {
            return _manager.GetLogBy(resultProcedureId);
        }
        #endregion


        public StepTypeViewModel GetStepTypeBy(string steptype)
        {
            StepTypeViewModel result = new StepTypeViewModel();
            var dt = _manager.GetBy(steptype);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                result.StepType = steptype;
                result.RepeatCount = dr["RepeatCount"].ToString();
                result.Description = dr["description"].ToString();
                result.Content = dr["Content"].ToString();
                result.GroupName = dr["GroupName"].ToString();
            }
            return result;
        }

        public List<StepTypeViewModel> GetSteptypes()
        {
            var result = new List<StepTypeViewModel>();
            var dt = _manager.GetStepTypes();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    result.Add(new StepTypeViewModel()
                    {
                        StepType = row["StepTypeName"].ToString(),
                        Category = row["Category"].ToString(),
                        Description = row["Description"].ToString(),
                        Version = row["Version"].ToString(),
                        GroupName = row["GroupName"].ToString(),
                        RepeatCount = row["RepeatCount"].ToString()
                    });
                }
            }
            return result;
        }

        public int InsertStepType(string stepType, string description, string category, string version, string GroupName, int repeat, string content)
        {
            return _manager.InsertStepType(stepType, description, category, version, GroupName, repeat, content);
        }

        public bool CheckIsExist(string steptype)
        {
            if (steptype == "Boolean" || steptype == "Number" || steptype == "String" || steptype == "PathFile") return true;

            return _manager.CheckIsExistStepType(steptype);

        }
        public TemplateViewModel GetProcedureById(int procedureId)
        {
            TemplateViewModel result = new TemplateViewModel();
            var dt = _manager.GetById(procedureId);
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                result.ProcedureId = int.Parse(row["ProcedureId"].ToString());
                result.Subject = row["ProcedureName"].ToString();
                result.Type = int.Parse(row["Type"].ToString());
                result.Description = row["Description"].ToString();
                result.Id = row["UniqueId"].ToString();
                result.Version = row["Version"].ToString();
                result.Category = row["Category"].ToString();
                result.Duration = row["Duration"].ToString();
                result.MetaData = row["MetaData"].ToString();
                result.ReportName = row["ReportName"].ToString();
                result.ReportDate = row["ReportDate"].ToString();
                result.ReportOutputPath = row["OutputPath"].ToString();
                result.ExportPDF = bool.Parse(row["ExportPDF"].ToString());
                IDUTManager dutM = new DUTManager();
                var dt2 = dutM.GetNameDUTByProcedureId(procedureId);
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    var row2 = dt2.Rows[0];
                    result.DUTName = row2["DUTName"].ToString() + ";" + row2["Model"].ToString() + ";" + row2["Brand"].ToString();
                    result.DUTNames = row2["DUTName"].ToString();
                    result.DUTModels = row2["Model"].ToString();
                    result.DUTBrand = row2["Brand"].ToString();
                    result.DUTIds = new List<int>() { int.Parse(row2["DUTId"].ToString()) };
                }
                var dtvariables = _manager.GetVariable(procedureId);
                result.Variables = convertDt2VMProcedureVariable(dtvariables);
                result.TableProcedures = GetsByProcedureId(procedureId);
            }

            return result;
        }
        private List<ProcedureVariableViewModel> convertDt2VMProcedureVariable(DataTable dt)
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ProcedureVariableViewModel vm = new ProcedureVariableViewModel();
                    vm.ProcedureId = int.Parse(row["ProcedureId"].ToString());
                    vm.ProcedureVariableId = int.Parse(row["ProcedureVariableId"].ToString());
                    vm.Name = row["VariableName"].ToString();
                    vm.Title = row["VariableTitle"].ToString();
                    vm.Value = row["VariableValue"].ToString();
                    vm.Unit = row["VariableUnit"].ToString();
                    vm.Min = row["VariableMin"].ToString();
                    vm.Items = row["Items"].ToString();
                    vm.Max = row["VariableMax"].ToString();
                    if (row["VariableReport"].ToString() == "1")
                        vm.Report = true;
                    else vm.Report = false;
                    if (row["VariableRequired"].ToString() == "1")
                        vm.Required = true;
                    else vm.Required = false;
                    vm.Type = row["VariableType"].ToString();
                    vm.TypeInput = row["VariableTypeImport"].ToString();
                    result.Add(vm);
                }
            }
            return result;
        }
        public List<TableInspectionViewModel> GetsBy(int dutId)
        {
            var dt = _manager.GetSBy(dutId);
            return ConvertDt2TbInspect(dt);
        }
        public List<TemplateProcedureViewModel> GetTemplates()
        {
            var dt = _manager.GetTemplates();
            return ConvertDt2TemplateProcedure(dt);
        }
        public string GetNewId()
        {
            var newId = _manager.LoadId();
            if (string.IsNullOrEmpty(newId))
            {
                newId = "MIPL-" + DateTime.Now.Year + "1";
            }
            return newId;
        }
        public bool UpdateNewId(string strId)
        {
            int year = int.Parse(strId.Substring(5, 4));
            var number = int.Parse(strId.Substring(9));
            var newId = "MIPL-" + DateTime.Now.Year + "1";
            if (year == DateTime.Now.Year)
            {
                newId = "MIPL-" + year + (number + 1);
            }
            return _manager.UpdateProcessId(newId, "UNIQUEID");
        }
        public List<TableResultInspectionViewModel> GetResultsBy(int dutId)
        {
            return ConvertDt2ResultTbInspect(_manager.GetResultsBy(dutId));
        }

        /// <summary>
        /// Get all steps of procedure
        /// </summary>
        /// <param name="procedureId"></param>
        /// <returns></returns>
        public List<TableProcedureViewModel> GetsByProcedureId(int procedureId)
        {
            var tb = _manager.GetVariable(procedureId);
            var variable1 = convertDt2VMProcedureVariable(tb);
            var variable = variable1.Where(t => !string.IsNullOrEmpty(t.Name)).ToList();
            List<TableProcedureViewModel> lstToReturn = new List<TableProcedureViewModel>();
            var dt = _detailManager.GetsByProcedureId(procedureId);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var vm = new TableProcedureViewModel();
                    vm.ProcedureDetailId = int.Parse(row["ProcedureDetailId"].ToString());
                    vm.Title = row["Name"].ToString();
                    var a = row["RequiredStep"].ToString();
                    if (a == "1" || a.ToUpper() == "TRUE")
                        vm.Required = true;
                    else vm.Required = false;
                    vm.LoopInput = int.Parse(row["Cycle"].ToString());
                    vm.Description = row["Description"].ToString();
                    vm.StepType = row["Type"].ToString();
                    vm.PathDll = row["PathFileDll"].ToString();
                    vm.PathSource = row["PathFileCalibration"].ToString();
                    vm.NumberOder = int.Parse(row["NumberOrder"].ToString());
                    vm.ProcedureDetailValue2s = getDetailValuesBy(vm.ProcedureDetailId);
                    var strURL = row["URL"].ToString();
                    if (!string.IsNullOrEmpty(strURL))
                    {
                        vm.strURL = strURL;
                        vm.ListURL = JsonConvert.DeserializeObject<List<URLViewModel>>(strURL);

                    }
                    var str = row["JsonString"].ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        vm.Functions = JsonConvert.DeserializeObject<List<ProcedureDetailFunction>>(str);
                    }
                    // ProcedureDetailVariable
                    var dtDetailVariable = _detailManager.GetProcedureDetailVariable(vm.ProcedureDetailId);
                    if (dtDetailVariable != null && dtDetailVariable.Rows.Count > 0)
                    {
                        vm.Variables = new List<ProcedureDetaiVariableViewModel>();
                        foreach (DataRow rowv in dtDetailVariable.Rows)
                        {
                            var newvr = new ProcedureDetaiVariableViewModel();
                            newvr.ProcedureDetailId = vm.ProcedureDetailId;
                            newvr.Name = rowv["Name"].ToString();
                            newvr.Value = rowv["Value"].ToString();
                            newvr.Title = rowv["Title"].ToString();
                            newvr.TypeInput = rowv["TypeInput"].ToString();
                            if (rowv["Report"] != null && !string.IsNullOrEmpty(rowv["Report"].ToString()))
                                newvr.Report = bool.Parse(rowv["Report"].ToString());
                            if (rowv["Required"] != null && !string.IsNullOrEmpty(rowv["Required"].ToString()))
                                newvr.Required = bool.Parse(rowv["Required"].ToString());
                            if (!string.IsNullOrEmpty(rowv["OrderNumber"].ToString()))
                                newvr.NumberOrder = int.Parse(rowv["OrderNumber"].ToString());
                            if (rowv["GetDataFromFreStep"] != null && rowv["GetDataFromFreStep"].ToString() == "1")
                            {
                                newvr.GetDataFromFreStep = true;
                            }
                            newvr.ProcedureVariableId = int.Parse(rowv["ProcedureVariableId"].ToString());
                            vm.Variables.Add(newvr);
                        }
                    }
                    lstToReturn.Add(vm);
                }
            }
            return lstToReturn;
        }
        #endregion
        #region private
        private List<ProcedureDetailValueViewModel> getDetailValuesBy(int procedureDetailId)
        {
            List<ProcedureDetailValueViewModel> lstToReturn = new List<ProcedureDetailValueViewModel>();
            try
            {

                var dt = _detailManager.GetDetailValuesBy(procedureDetailId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var vm = new ProcedureDetailValueViewModel();
                        vm.ProcedureDetailValueId = int.Parse(row["ProcedureDetailValueId"].ToString());
                        vm.ProcedureDetailId = procedureDetailId;
                        vm.NumberOder = int.Parse(row["NumberOrder"].ToString());
                        vm.Name = row["Name"].ToString();
                        vm.FunctionNumber = row["Content"].ToString();
                        vm.Value = row["Value"].ToString();
                        vm.Title = row["Title"].ToString();
                        vm.Unit = row["Unit"].ToString();
                        vm.Type = row["Type"].ToString();
                        vm.StrValueType = row["TypeValue"].ToString();
                        var strmin = row["Min"].ToString();
                        var strmax = row["Max"].ToString();
                        if (!string.IsNullOrEmpty(strmin))
                            vm.Min = double.Parse(strmin, System.Globalization.CultureInfo.InvariantCulture);
                        if (!string.IsNullOrEmpty(strmax))
                            vm.Max = double.Parse(strmax, System.Globalization.CultureInfo.InvariantCulture);
                        lstToReturn.Add(vm);
                    }
                }

            }
            catch
            {

            }
            return lstToReturn;
        }
        private List<TableInspectionViewModel> ConvertDt2TbInspect(DataTable dt)
        {
            List<TableInspectionViewModel> result = new List<TableInspectionViewModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new TableInspectionViewModel { };
                    item.Action = false;
                    item.ProcedureId = int.Parse(dr["Id"].ToString());
                    item.Name = dr["Name"].ToString();
                    item.Id = dr["uniId"].ToString();
                    item.DUT = dr["DUTNames"].ToString();
                    item.Version = dr["Version"].ToString();
                    result.Add(item);
                }
            }
            return result;
        }

        private List<TableResultInspectionViewModel> ConvertDt2ResultTbInspect(DataTable dt)
        {
            List<TableResultInspectionViewModel> result = new List<TableResultInspectionViewModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new TableResultInspectionViewModel { };
                    item.Action = false;
                    item.ResultProcedureId = int.Parse(dr["ResultProcedureId"].ToString());
                    item.RUN = dr["RUN"].ToString();
                    item.DUT = dr["DUTNames"].ToString();
                    item.STARTTIME = dr["STARTTIME"].ToString();
                    item.ENDTIME = dr["ENDTIME"].ToString();
                    item.Author = dr["Author"].ToString();
                    if (string.IsNullOrEmpty(item.Author)) item.Author = "Admin";

                    result.Add(item);
                }
            }
            return result;
        }
        private List<TemplateProcedureViewModel> ConvertDt2TemplateProcedure(DataTable dt)
        {
            List<TemplateProcedureViewModel> result = new List<TemplateProcedureViewModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new TemplateProcedureViewModel { };
                    item.ProcedureId = int.Parse(dr["ProcedureId"].ToString());
                    item.Name = dr["ProcedureName"].ToString();
                    item.Description = dr["Description"].ToString();
                    item.CountSteps = int.Parse(dr["CountSteps"].ToString());
                    item.ShortDescription = dr["ShortDescription"].ToString() ?? "";
                    item.Duration = dr["Duration"].ToString();
                    item.Category = dr["Category"].ToString() ?? "";
                    result.Add(item);
                }
            }
            return result;
        }
        public bool UpdateProcedureDetail(TemplateViewModel vm)
        {
            // Bọc toàn bộ (xoá detail cũ + insert variable + insert detail) trong MỘT transaction
            // để tránh trường hợp đã xoá nhưng insert lỗi -> mất dữ liệu.
            bool ownTx = !_db.InTransaction;
            try
            {
                if (ownTx) _db.BeginTransaction();

                // Delete All ProcedureDetail
                _detailManager.DeleteProcedureDetailsByProcedureId(vm.ProcedureId);
                //
                if (vm.Variables != null && vm.Variables.Count > 0)
                {
                    foreach (var variable in vm.Variables)
                    {
                        _manager.InsertProcedureVariable(vm.ProcedureId, variable.Name, variable.Title, variable.Value, variable.Unit, variable.Min, variable.Max, variable.Type, variable.TypeInput, variable.Required, variable.Report,variable.Items);
                    }
                }
                //Insert
                InsertProcedetail(vm.TableProcedures, vm.ProcedureId);

                if (ownTx) _db.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (ownTx) _db.Rollback();
                return false;
            }
        }
        public void InsertProcedetail(List<TableProcedureViewModel> steps, int newId)
        {
            List<ProcedureVariableViewModel> listVariable = new List<ProcedureVariableViewModel>();
            var dtVariable = _manager.GetVariable(newId);
            if (dtVariable != null && dtVariable.Rows.Count > 0)
            {
                listVariable = convertDt2VMProcedureVariable(dtVariable);
            }
            foreach (var step in steps)
            {

                string jsons = "";
                if (step.Functions != null && step.Functions.Count > 0)
                {
                    List<ProcedureDetailFunction> procedureDetailFunctions = new List<ProcedureDetailFunction>();
                    foreach (var function in step.Functions)
                    {
                        var str = JsonConvert.SerializeObject(function);
                        var newf = JsonConvert.DeserializeObject<ProcedureDetailFunction>(str);

                    }
                    jsons = JsonConvert.SerializeObject(step.Functions);

                }

                if (step.ListURL != null && step.ListURL.Count > 0) step.strURL = JsonConvert.SerializeObject(step.ListURL);
                var newstepId = _detailManager.InsertProcedureDetail(newId, step.Title, step.LoopInput, step.NumberOder, step.StepType, step.Description, step.Required, jsons, step.strURL,step.PathDll,step.PathSource);
                if (newstepId > 0)
                {
                    if (listVariable.Count > 0 && step.Variables != null && step.Variables.Count > 0)
                    {
                        // Insert ProcedureDetailVariable
                        int numberOrder = 1;
                        foreach (var variable in step.Variables)
                        {

                            if (listVariable.Count(t => t.Name == variable.Name) > 0)
                            {
                                if (variable.NumberOrder == 0) variable.NumberOrder = numberOrder;
                                var variableId = listVariable.Where(t => t.Name == variable.Name).Select(t => t.ProcedureVariableId).FirstOrDefault();
                                var newID = _detailManager.InsertProcedureDetailVariable(newstepId, variableId, variable.Value, variable.NumberOrder,variable.Name,variable.Title,variable.TypeInput, variable.Report,variable.Required);
                                numberOrder++;
                            }
                        }
                        int number = 0;
                        // Insert function
                        if (step.Functions != null)
                            foreach (var function in step.Functions)
                            {
                                var functionId = _detailManager.InsertProcedureDetailFunction(newstepId, number, function.FunctionName, function.PathDll, function.Assembly, function.AssemblyType, function.Value);
                                if (functionId > 0 && function.FunctionVariables != null && function.FunctionVariables.Count > 0)
                                {
                                    foreach (var variable in function.FunctionVariables)
                                    {
                                        var vitem = listVariable.Where(t => t.Name == variable.VariableName).FirstOrDefault();
                                        if(vitem != null)
                                        _detailManager.InsertProcedureDetailFunctionVariable(newstepId, vitem.ProcedureVariableId, vitem.Type, false, vitem.Value,vitem.Name);
                                    }
                                }
                                number++;
                            }
                    }



                    //if (step.ProcedureDetailValue2s != null && step.ProcedureDetailValue2s.Count > 0)
                    //{
                    //    foreach (var item in step.ProcedureDetailValue2s)
                    //    {
                    //        _detailManager.InsertProcedureDetailValue(newstepId, item.NumberOder, item.Name, item.Title, item.Unit, item.Type, item.Value, item.StrValueType, item.Min, item.Max, item.FunctionNumber);
                    //    }
                    //}

                }
            }
        }

        #endregion
        #region Insert
        public int InsertProcedure(string name, string newstrId, string description, string version, string category, string duration, string dut, Dictionary<string, string> metaData, List<ProcedureVariableViewModel> variables)
        {
            // Bọc chuỗi insert (procedure + cập nhật UNIQUEID + liên kết DUT + biến) trong MỘT transaction.
            bool ownTx = !_db.InTransaction;
            try
            {
                if (ownTx) _db.BeginTransaction();
            var strmetadata = "";
            if (metaData != null) strmetadata = JsonConvert.SerializeObject(metaData);
            var newId = _manager.InsertProcedure(name, description, newstrId, version, 1, 0, category, duration, strmetadata);
            if (newId > 0)
            {
                var newIDpr = "";
                var cols = newstrId.Split('-');
                if (cols != null && cols.Count() > 0)
                {
                    if (cols[0] != DateTime.Now.Year.ToString())
                    {
                        newIDpr = DateTime.Now.Year + "-1";
                    }
                    else
                    {
                        var idodl = int.Parse(cols[1]) + 1;
                        newIDpr = cols[0] + "-" + idodl;
                    }
                }
                else
                {
                    newIDpr = DateTime.Now.Year + "-1";

                }
                _manager.UpdateProcessId(newIDpr, "UNIQUEID");



                if (!string.IsNullOrEmpty(dut))
                {
                    var bran = dut.Substring(dut.LastIndexOf(";") + 1);
                    dut = dut.Substring(0, dut.LastIndexOf(";"));
                    var model = dut.Substring(dut.LastIndexOf(";") + 1);
                    var namedut = dut.Substring(0, dut.LastIndexOf(";"));
                    DUTModel dUTModel = new DUTModel();

                    var idDUT = dUTModel.GetIdBy(namedut, model, bran);
                    if (idDUT > 0)
                    {
                        _manager.InsertLKProcedureDevide(newId, new List<int>() { idDUT });
                    }
                }
                if (variables != null && variables.Count > 0)
                {
                    foreach (var variable in variables)
                    {
                        _manager.InsertProcedureVariable(newId, variable.Name, variable.Title, variable.Value, variable.Unit, variable.Min, variable.Max, variable.Type, variable.TypeInput, variable.Required, variable.Report,variable.Items);
                    }
                }


            }



                if (ownTx) _db.Commit();
                return newId;
            }
            catch
            {
                if (ownTx) _db.Rollback();
                return 0;
            }
        }
        public int InsertResultProcedure(TemplateViewModel vm)
        {
            // Bọc chuỗi insert kết quả chạy (result + step + value + liên kết DUT/Vessel) trong MỘT transaction.
            bool ownTx = !_db.InTransaction;
            try
            {
                if (ownTx) _db.BeginTransaction();
            vm = CheckTemplate(vm);
            var id = _manager.InsertResultProcedure(vm.Subject, vm.Description, vm.Type, vm.ProcedureId, vm.Log, vm.Percent, vm.UserId, vm.StartTime.ToString(), vm.EndTime.ToString());
            if (id > 0)
            {
                //var lstDetail = Convert4Table2Procedure(vm.TableProcedures, id, vm.UserId, (byte)vm.Type);
                if (vm.TableProcedures.Count > 0)
                {
                    foreach (var detail in vm.TableProcedures)
                    {
                        var detailId = _detailManager.InsertResultProcedureStep(id, detail.Title, detail.LoopInput, detail.NumberOder, detail.Description, detail.Required, detail.Status);
                        //_detailManager.InsertOrUpdateResultProcedureDetailValue(detailId, detail.ProcedureDetailValue2s);
                        if (detail.ProcedureDetailValue2s != null && detail.ProcedureDetailValue2s.Count > 0)
                        {
                            foreach (var variable in detail.ProcedureDetailValue2s)
                            {
                                var variableId = _detailManager.InsertOrUpdateResultProcedureDetailValue(detailId, variable.NumberOder, variable.Name, variable.Title, variable.Unit);
                                if (variableId > 0 && variable.ValueInputFromDetails != null && variable.ValueInputFromDetails.Count > 0)
                                {
                                    foreach (var valueInput in variable.ValueInputFromDetails)
                                    {
                                        _detailManager.InsertResultProcedureDetailValueInput(variableId, valueInput.value, valueInput.Cycle.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                // insert refe procedure and devide
                if (vm.DUTIds != null && vm.DUTIds.Count > 0)
                    _manager.InsertDUTResultProcedure(id, vm.DUTIds);
                if (vm.VesselIds != null && vm.VesselIds.Count > 0)
                    _manager.InsertVesselResultProcedure(id, vm.VesselIds);
                // Insert FileAttach
                //FileManager fileM = new FileManager();
                //if (vm.FileAttachs != null && vm.FileAttachs.Count > 0)
                //{
                //    foreach (var item in vm.FileAttachs)
                //    {
                //        if (item.FileAttachId == 0)
                //        {
                //            item.FileAttachId = fileM.InsertFile(item.FileName, item.FilePath, item.FileName.Substring(item.FileName.LastIndexOf(".") + 1), 0);
                //        }
                //    }
                //    var lstId = vm.FileAttachs.Select(t => t.FileAttachId).ToList();

                //    fileM.InsertListFile(lstId, id.ToString(), (int)EnumItemType.ResultProcedure);
                //}
            }
                if (ownTx) _db.Commit();
                return id;
            }
            catch
            {
                if (ownTx) _db.Rollback();
                return 0;
            }
        }
        public TemplateViewModel CheckTemplate(TemplateViewModel vm)
        {
            TemplateViewModel result = vm;
            int percent = 0;
            if (result.TableProcedures != null && result.TableProcedures.Count > 0)
            {
                int total = 0;
                int intputNum = 0;
                foreach (var step in vm.TableProcedures)
                {
                    if (step.Done.HasValue && step.Done.Value)
                    {
                        intputNum++;
                    }
                    total++;
                    //int cycleInStep = step.LoopInput;
                    //if (step.Cycles != null && step.Cycles.Count > 0)
                    //{
                    //    var countSave = step.Cycles.Count(t => t.StatusSave);
                    //    if (countSave > cycleInStep) cycleInStep = countSave;
                    //    intputNum += step.Cycles.Count(t => t.StatusSave && t.Status == "SAVE");
                    //    total += countSave;
                    //    if (countSave > 0)
                    //    {
                    //        step.Status = 1;
                    //    }
                    //    else step.Status = 0;
                    //}
                }
                percent = intputNum * 100 / total;
            }
            vm.Percent = percent;
            return result;
        }

        //public bool UpdateProcedure(TemplateViewModel vm, out string error)
        //{
        //    error = "";
        //    try
        //    {
        //        if (_manager.UpdateProcedure(vm.ProcedureId, vm.Subject, vm.Description))
        //        {
        //            // update lk devide, vessel
        //            if (_manager.InsertLKProcedureDevide(vm.ProcedureId, vm.DUTIds))
        //            {
        //                _manager.InsertLKProcedureVessel(vm.ProcedureId, vm.VesselIds);
        //                FileModel fileM = new FileModel();

        //                fileM.InsertListFileToProcedure(vm.ProcedureId, vm.FileAttachs);

        //                ProcedureDetailManager detailM = new ProcedureDetailManager();
        //                return detailM.InsertOrUpdateProcedureDetail(vm);
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //        return false;
        //    }

        //}
        //public string GetLogById(int id)
        //{
        //    return _manager.GetLogBy(id);
        //}

        //public bool CheckToDelete(int id)
        //{
        //    return _manager.CheckToDelete(id);
        //}

        #endregion
        #region Update
        public bool UpdateProcedure(TemplateViewModel vm, out string error)
        {
            error = "";
            try
            {
                if (_manager.UpdateProcedure(vm.ProcedureId, vm.Subject, vm.Description, vm.Version, vm.Category, vm.Duration, vm.MetaData, vm.strURL,vm.ReportDate,vm.ReportName,vm.ReportOutputPath,vm.ExportPDF))
                {
                    if (!string.IsNullOrEmpty(vm.DUTName))
                    {
                        var bran = "";
                        var model = "";
                        var namedut = "";
                        var dut = vm.DUTName;
                        if (vm.DUTName.IndexOf(";") != -1)
                        {

                            bran = dut.Substring(dut.LastIndexOf(";") + 1);
                            dut = dut.Substring(0, dut.LastIndexOf(";"));
                            model = dut.Substring(dut.LastIndexOf(";") + 1);
                            namedut = dut.Substring(0, dut.LastIndexOf(";"));

                        }
                        else
                        {
                            bran = dut.Substring(dut.LastIndexOf("-") + 1);
                            dut = dut.Substring(0, dut.LastIndexOf("-"));
                            model = dut.Substring(dut.LastIndexOf("-") + 1);
                            namedut = dut.Substring(0, dut.LastIndexOf("-"));
                        }
                        DUTModel dUTModel = new DUTModel();

                        var idDUT = dUTModel.GetIdBy(namedut, model, bran);
                        if (idDUT > 0)
                        {
                            _manager.InsertLKProcedureDevide(vm.ProcedureId, new List<int>() { idDUT });
                        }
                    }




                    // update lk devide, vessel                   
                    _manager.InsertLKProcedureVessel(vm.ProcedureId, vm.VesselIds);
                    //FileModel fileM = new FileModel();


                    //fileM.InsertListFileToProcedure(vm.ProcedureId, vm.FileAttachs);

                    UpdateProcedureDetail(vm);
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }
        #endregion
        #region Delete
        public bool CheckToDelete(int id)
        {
            return _manager.CheckToDelete(id);
        }
        public bool Delete(int id, out string mess)
        {
            ProcedureDetailManager detailM = new ProcedureDetailManager();
            try
            {
                mess = "";
                if (detailM.DeleteProcedureDetailsByProcedureId(id))
                {

                    return _manager.Delete(id);
                }
                mess = "Errot to delete this procedure.";
                return false;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return false;
            }

        }
        public bool DeleteResult(int resultId)
        {
            
            return _manager.DeleteResult(resultId);
        }
       
        #endregion
    }
}
