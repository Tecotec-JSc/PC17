
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using T3.Configuration;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T3ACS.Data
{
    public class ProcedureDetailManager: IProcedureDetailManager
    {
        SQLiteDataBase _sqlite;
        public ProcedureDetailManager()
        {
            _sqlite = new SQLiteDataBase();
        }
        // Cho phép dùng chung một SQLiteDataBase (để tham gia cùng transaction với manager khác).
        public ProcedureDetailManager(SQLiteDataBase sqlite)
        {
            _sqlite = sqlite;
        }
        #region Insert
        public int InsertProcedureDetail(int procedureId, string name, int cycle, int orderNumber, string type, string des, bool required,string jsonString,string url,string pathFileDll, string pathFileCalibration)
        {
            try
            {
                if (des == null) des = "";
                // Tham số hoá toàn bộ giá trị chuỗi để chống SQL injection.
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureId", procedureId },
                    { "@Name", name },
                    { "@Cycle", cycle },
                    { "@NumberOrder", orderNumber },
                    { "@Description", des },
                    { "@Type", type },
                    { "@RequiredStep", required },
                    { "@JsonString", jsonString },
                    { "@URL", url },
                    { "@PathFileDll", pathFileDll },
                    { "@PathFileCalibration", pathFileCalibration }
                };
                // Gắn audit (người tạo/sửa + thời điểm) từ Session.
                var audit = AuditStamp.ForInsert(parameters);
                var str = "INSERT INTO ProcedureDetail(ProcedureId,Name,Cycle,NumberOrder,Description,Type,RequiredStep,JsonString,URL,PathFileDll,PathFileCalibration" + audit.Columns + ") VALUES (@ProcedureId,@Name,@Cycle,@NumberOrder,@Description,@Type,@RequiredStep,@JsonString,@URL,@PathFileDll,@PathFileCalibration" + audit.Values + ")";
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.InsertProcedureDetail", ex);
                return 0;
            }
        }
        public int InsertProcedureDetailFunction(int proceDureDetailId, int numberOrder, string functionName, string pathDll, string Assembly, string AssemblyType, string value)
        {
            try
            {
                var str = "INSERT into ProcedureDetailFunction(ProcedureDetailId,NumberOrder,FunctionName,PathDll,Assembly, AssemblyType,Value) VALUES (@ProcedureDetailId,@NumberOrder,@FunctionName,@PathDll,@Assembly,@AssemblyType,@Value)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureDetailId", proceDureDetailId },
                    { "@NumberOrder", numberOrder },
                    { "@FunctionName", functionName },
                    { "@PathDll", pathDll },
                    { "@Assembly", Assembly },
                    { "@AssemblyType", AssemblyType },
                    { "@Value", value }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.InsertProcedureDetailFunction", ex);
                return 0;
            }
        }
        public int InsertProcedureDetailFunctionVariable(int procedureDetaiId, int variableId,string type,bool isList, string value, string name)
        {
            try
            {
                var str = "INSERT into ProcedureDetailFunctionVariable(ProcedureDetaiFunctionId,ProcedureVariableId,Type,IsList,Value) VALUES (@ProcedureDetaiFunctionId,@ProcedureVariableId,@Type,@IsList,@Value)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureDetaiFunctionId", procedureDetaiId },
                    { "@ProcedureVariableId", variableId },
                    { "@Type", type },
                    { "@IsList", isList },
                    { "@Value", value }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.InsertProcedureDetailFunctionVariable", ex);
                return 0;
            }
        }
        public int InsertProcedureDetailValue(int proceDureDetailId, int numberOrder, string name, string title, string unit, string type, string value, string TypeValue, double? min, double? max, string content)
        {
            try
            {
                var str = "INSERT INTO ProcedureDetailValue(ProcedureDetailId,NumberOrder,Name,Title,Unit,Type,Value,TypeValue,Min,Max,Content) VALUES (@ProcedureDetailId,@NumberOrder,@Name,@Title,@Unit,@Type,@Value,@TypeValue,@Min,@Max,@Content)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureDetailId", proceDureDetailId },
                    { "@NumberOrder", numberOrder },
                    { "@Name", name },
                    { "@Title", title },
                    { "@Unit", unit },
                    { "@Type", type },
                    { "@Value", value },
                    { "@TypeValue", TypeValue },
                    { "@Min", min },
                    { "@Max", max },
                    { "@Content", content }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.InsertProcedureDetailValue", ex);
                return 0;
            }
        }
        public int InsertResultProcedureStep(int ResultProcedureId, string name, int cycle, int StepNumber, string des, bool required, int status)
        {
            string datestr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            if (des == null) des = "";
            var str = "INSERT INTO ResultProcedureStep(ResultProcedureId,Title,StepNumber,Cycle,Description,Required,DateCreate,Status) VALUES (@ResultProcedureId,@Title,@StepNumber,@Cycle,@Description,@Required,@DateCreate,@Status)";
            var parameters = new Dictionary<string, object>
            {
                { "@ResultProcedureId", ResultProcedureId },
                { "@Title", name },
                { "@StepNumber", StepNumber },
                { "@Cycle", cycle },
                { "@Description", des },
                { "@Required", required },
                { "@DateCreate", datestr },
                { "@Status", status }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }
        public int InsertOrUpdateResultProcedureDetailValue(int ResultProcedureStepId, int numberOrder, string name, string title, string unit)
        {
            var str = "INSERT INTO ResultProcedureStepValue(ResultProcedureStepId,NumberOrder,Name,Title,Unit) VALUES (@ResultProcedureStepId,@NumberOrder,@Name,@Title,@Unit)";
            var parameters = new Dictionary<string, object>
            {
                { "@ResultProcedureStepId", ResultProcedureStepId },
                { "@NumberOrder", numberOrder },
                { "@Name", name },
                { "@Title", title },
                { "@Unit", unit }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }
        public int InsertResultProcedureDetailValueInput(int ResultProcedureStepValueId, string value, string numberCycle)
        {
            var str = "INSERT INTO ResultProcedureStepValueDetails(ResultProcedureStepValueId,Value,NumberCycle) VALUES (@ResultProcedureStepValueId,@Value,@NumberCycle)";
            var parameters = new Dictionary<string, object>
            {
                { "@ResultProcedureStepValueId", ResultProcedureStepValueId },
                { "@Value", value },
                { "@NumberCycle", numberCycle }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }

        #region Variable
        public int InsertProcedureDetailVariable(int procedureDetailId, int variableId, string value,int oderNumber,string name, string title, string typeInput,bool report, bool required)
        {
            try
            {
                var str = "INSERT INTO ProcedureDetailVariable(ProcedureDetailId,ProcedureVariableId,Value,OrderNumber,Name,Title,TypeInput,Report,Required) VALUES (@ProcedureDetailId,@ProcedureVariableId,@Value,@OrderNumber,@Name,@Title,@TypeInput,@Report,@Required)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureDetailId", procedureDetailId },
                    { "@ProcedureVariableId", variableId },
                    { "@Value", value },
                    { "@OrderNumber", oderNumber },
                    { "@Name", name },
                    { "@Title", title },
                    { "@TypeInput", typeInput },
                    { "@Report", report },
                    { "@Required", required }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.InsertProcedureDetailVariable", ex);
                return 0;
            }
        }

        #endregion

        #endregion
        #region Get
        public DataTable GetsByProcedureId(int procedureId)
        {
            var str = "SELECT * from ProcedureDetail where ProcedureId = @ProcedureId";
            return _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@ProcedureId", procedureId } });
        }
        public DataTable GetDetailValuesBy(int procedureDetailId)
        {
            var str = "SELECT * from ProcedureDetailValue where ProcedureDetailId = @ProcedureDetailId";
            return _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@ProcedureDetailId", procedureDetailId } });
        }

        public DataTable GetProcedureDetailVariable(int procedureDetailId)
        {
            var str = "SELECT * from ProcedureDetailVariable where ProcedureDetailId = @ProcedureDetailId";
            return _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@ProcedureDetailId", procedureDetailId } });
        }
        #endregion
        #region Update

        #endregion
        #region Delete
        // Xoá toàn bộ dữ liệu con của 1 procedure. Nếu chưa nằm trong transaction nào thì
        // tự mở một transaction để đảm bảo hoặc xoá hết, hoặc không xoá gì (tránh dữ liệu dở dang).
        // Nếu đang nằm trong transaction ngoài (vd lúc lưu procedure) thì tham gia luôn transaction đó.
        public bool DeleteProcedureDetailsByProcedureId(int procedureId)
        {
            bool ownTx = !_sqlite.InTransaction;
            try
            {
                if (ownTx) _sqlite.BeginTransaction();

                var pid = new Dictionary<string, object> { { "@ProcedureId", procedureId } };
                var dtdetailId = _sqlite.GetDataTableParam(
                    "Select ProcedureDetailId From ProcedureDetail where ProcedureId = @ProcedureId", pid);
                if (dtdetailId != null)
                {
                    foreach (DataRow row in dtdetailId.Rows)
                    {
                        var id = int.Parse(row[0].ToString());
                        var idParam = new Dictionary<string, object> { { "@id", id } };

                        // Xoá biến của từng function thuộc step.
                        var dtFunc = _sqlite.GetDataTableParam(
                            "Select ProcedureDetailFunctionId From ProcedureDetailFunction where ProcedureDetailId = @id", idParam);
                        if (dtFunc != null)
                        {
                            foreach (DataRow rowF in dtFunc.Rows)
                            {
                                var fid = int.Parse(rowF[0].ToString());
                                _sqlite.ExecuteNonQuery(
                                    "DELETE FROM ProcedureDetailFunctionVariable where ProcedureDetaiFunctionId = @id",
                                    new Dictionary<string, object> { { "@id", fid } });
                            }
                        }
                        // Xoá function của step.
                        _sqlite.ExecuteNonQuery("DELETE FROM ProcedureDetailFunction where ProcedureDetailId = @id", idParam);
                        // Xoá biến của step.
                        _sqlite.ExecuteNonQuery("DELETE FROM ProcedureDetailVariable where ProcedureDetailId = @id", idParam);
                    }
                }

                // Xoá các step của procedure.
                _sqlite.ExecuteNonQuery("DELETE FROM ProcedureDetail where ProcedureId = @ProcedureId", pid);
                // Xoá biến toàn cục của procedure.
                _sqlite.ExecuteNonQuery("DELETE FROM ProcedureVariable where ProcedureId = @ProcedureId", pid);

                if (ownTx) _sqlite.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.DeleteProcedureDetailsByProcedureId", ex);
                if (ownTx) _sqlite.Rollback();
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var str = "DELETE FROM ProcedureDetail WHERE ProcedureDetailId = @ProcedureDetailId";
                if (_sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ProcedureDetailId", id } }) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureDetailManager.Delete", ex);
                return true;
            }
        }
        #endregion
    }
}
