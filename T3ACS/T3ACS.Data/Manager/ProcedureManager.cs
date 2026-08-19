
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using System.Transactions;
using System.Xml;
using T3.Configuration;

namespace T3ACS.Data
{
    public class ProcedureManager : IProcedureManager
    {
        SQLiteDataBase _sqlite;
        public ProcedureManager()
        {
            _sqlite = new SQLiteDataBase();
        }
        // Cho phép dùng chung một SQLiteDataBase (để tham gia cùng transaction với manager khác).
        public ProcedureManager(SQLiteDataBase sqlite)
        {
            _sqlite = sqlite;
        }
        #region Insert

        public int InsertStepType(string stepType, string description, string category, string version,string GroupName,int repeat, string content)
        {
            // Tham số hoá toàn bộ giá trị chuỗi để chống SQL injection.
            var str = "INSERT INTO StepType (StepTypeName,Description,Category,Version,GroupName,RepeatCount,Content) VALUES(@StepTypeName,@Description,@Category,@Version,@GroupName,@RepeatCount,@Content)";
            var parameters = new Dictionary<string, object>
            {
                { "@StepTypeName", stepType },
                { "@Description", description },
                { "@Category", category },
                { "@Version", version },
                { "@GroupName", GroupName },
                { "@RepeatCount", repeat },
                { "@Content", content }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }

        public int InsertProcedure(string procedureName, string description, string uniqueId, string version, byte type, int? createBy, string category, string duration, string metaData)
        {
            try
            {
                if (description == null) description = "";
                if (version == null) version = "1.0";
                string datestr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
                var str = "INSERT INTO Procedure(ProcedureName,Type,Description,CreateBy,DateCreate,LastModified,UserLastModified,UniqueId,Version,Category,Duration,MetaData) VALUES (@ProcedureName,@Type,@Description,@CreateBy,@DateCreate,@LastModified,@UserLastModified,@UniqueId,@Version,@Category,@Duration,@MetaData)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureName", procedureName },
                    { "@Type", type },
                    { "@Description", description },
                    { "@CreateBy", createBy },
                    { "@DateCreate", datestr },
                    { "@LastModified", datestr },
                    { "@UserLastModified", createBy },
                    { "@UniqueId", uniqueId },
                    { "@Version", version },
                    { "@Category", category },
                    { "@Duration", duration },
                    { "@MetaData", metaData }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertProcedure", ex);
                return 0;
            }
        }

        public int InsertProcedureVariable(int procedureId, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report,string items)
        {
            try
            {
                var str = "INSERT INTO ProcedureVariable (ProcedureId,VariableName,VariableTitle,VariableValue,VariableUnit,VariableMin,VariableMax,VariableType,VariableTypeImport,VariableRequired,VariableReport,Items) VALUES (@ProcedureId,@VariableName,@VariableTitle,@VariableValue,@VariableUnit,@VariableMin,@VariableMax,@VariableType,@VariableTypeImport,@VariableRequired,@VariableReport,@Items)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureId", procedureId },
                    { "@VariableName", name },
                    { "@VariableTitle", title },
                    { "@VariableValue", value },
                    { "@VariableUnit", unit },
                    { "@VariableMin", min },
                    { "@VariableMax", max },
                    { "@VariableType", type },
                    { "@VariableTypeImport", typeInput },
                    { "@VariableRequired", required },
                    { "@VariableReport", report },
                    { "@Items", items }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertProcedureVariable", ex);
                return 0;
            }
        }

        public int InsertProcedureDetailVariable(int procedureDetailId,int variableId)
        {
            try
            {
                // Chỉ có tham số kiểu int nhưng vẫn tham số hoá cho nhất quán.
                var str = "INSERT INTO ProcedureDetailVariable (ProcedureDetailId,ProcedureVariableId) VALUES (@ProcedureDetailId,@ProcedureVariableId)";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureDetailId", procedureDetailId },
                    { "@ProcedureVariableId", variableId }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertProcedureDetailVariable", ex);
                return 0;
            }
        }




        public bool InsertLKProcedureDevide(int procedureId, List<int> devideIds)
        {
            var parameters = new Dictionary<string, object> { { "@ProcedureId", procedureId } };
            var dt = _sqlite.GetDataTableParam("select * From DUTProcedure where ProcedureId = @ProcedureId", parameters);
            if (dt == null || dt.Rows.Count == 0)
            {
                foreach (var id in devideIds)
                {
                    var str1 = "INSERT INTO DUTProcedure(ProcedureId,DUTId) VALUES (@ProcedureId,@DUTId)";
                    _sqlite.ExecuteInsert(str1, new Dictionary<string, object> { { "@ProcedureId", procedureId }, { "@DUTId", id } });
                    return true;
                }
                return true;
            }
            else
            {
                if(devideIds!=null&& devideIds.Count > 0)
                {
                    var str1 = "Update DUTProcedure Set DUTId = @DUTId Where ProcedureId = @ProcedureId";
                    _sqlite.ExecuteNonQuery(str1, new Dictionary<string, object> { { "@DUTId", devideIds[0] }, { "@ProcedureId", procedureId } });
                }
                return true;
            }
        }
        public bool InsertLKProcedureVessel(int procedureId, List<int> VesselIds)
        {
            try
            {
                //DeleteAllRelationShip
                try
                {
                    var str = "Delete From VesselProcedure where ProcedureId = @ProcedureId";
                    _sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ProcedureId", procedureId } });
                }
                catch (Exception ex)
                {
                    Logger.Log("ProcedureManager.InsertLKProcedureVessel (xoa VesselProcedure)", ex);
                }


                //Insert All ProcedureDetailValue
                if (VesselIds != null && VesselIds.Count > 0)
                {
                    foreach (var id in VesselIds)
                    {
                        var str1 = "INSERT INTO VesselProcedure(ProcedureId,VesselId) VALUES (@ProcedureId,@VesselId)";
                        _sqlite.ExecuteNonQuery(str1, new Dictionary<string, object> { { "@ProcedureId", procedureId }, { "@VesselId", id } });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertLKProcedureVessel", ex);
                return false;
            }
        }
        public int InsertResultProcedure(string title, string description, int status, int procedureId, string Logreport, int percent, int? createBy, string startTime, string endTime)
        {
            try
            {
                string datestr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
                var str = "INSERT INTO ResultProcedure (Title,UserId,Description,ProcedureId,DateCreate,Status,LogReport,Percent,StartTime,EndTime) VALUES(@Title,@UserId,@Description,@ProcedureId,@DateCreate,@Status,@LogReport,@Percent,@StartTime,@EndTime)";
                var parameters = new Dictionary<string, object>
                {
                    { "@Title", title },
                    { "@UserId", createBy },
                    { "@Description", description },
                    { "@ProcedureId", procedureId },
                    { "@DateCreate", datestr },
                    { "@Status", status },
                    { "@LogReport", Logreport },
                    { "@Percent", percent },
                    { "@StartTime", startTime },
                    { "@EndTime", endTime }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertResultProcedure", ex);
                return 0;
            }
        }
        public bool InsertDUTResultProcedure(int resultProcedureId, List<int> DUTIds)
        {
            try
            {
                if (DUTIds != null && DUTIds.Count > 0)
                {
                    foreach (var id in DUTIds)
                    {
                        var str = "INSERT INTO DUTResultProcedure(ResultProcedureId,DUTId) VALUES (@ResultProcedureId,@DUTId)";
                        _sqlite.ExecuteInsert(str, new Dictionary<string, object> { { "@ResultProcedureId", resultProcedureId }, { "@DUTId", id } });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertDUTResultProcedure", ex);
                return false;
            }
        }
        public bool InsertVesselResultProcedure(int resultProcedureId, List<int> VesselIds)
        {
            try
            {
                //Insert All ProcedureDetailValue
                if (VesselIds != null && VesselIds.Count > 0)
                {
                    foreach (var id in VesselIds)
                    {
                        var str = "INSERT INTO VesselResultProcedure(ResultProcedureId,VesselId) VALUES (@ResultProcedureId,@VesselId)";
                        _sqlite.ExecuteInsert(str, new Dictionary<string, object> { { "@ResultProcedureId", resultProcedureId }, { "@VesselId", id } });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.InsertVesselResultProcedure", ex);
                return false;
            }
        }
        #endregion
        #region Get
        public DataTable GetStepTypes()
        {
            var str = " SELECT * FROM StepType Order by GroupName";
            return _sqlite.GetDataTable(str);
        }
        public DataTable GetBy(string steptype)
        {
            var str = "SELECT * FROM StepType WHERE StepTypeName = @StepTypeName";
            var parameters = new Dictionary<string, object> { { "@StepTypeName", steptype } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public bool CheckIsExistStepType(string steptype)
        {
            var str = "SELECT StepTypeName FROM StepType WHERE StepTypeName = @StepTypeName";
            var parameters = new Dictionary<string, object> { { "@StepTypeName", steptype } };
            var dt= _sqlite.GetDataTableParam(str, parameters);
            if(dt!=null&&dt.Rows.Count>0)
                 return true;
            return false;
        }

        public DataTable GetTemplates()
        {
            var str = "SELECT p.ProcedureId, p.ProcedureName,p.Description,p.Category,p.ShortDescription,p.Duration , count( pd.ProcedureDetailId ) as CountSteps From Procedure as p INNER JOIN ProcedureDetail as pd on p.ProcedureId=pd.ProcedureId WHERE p.Type=2 GROUP by p.ProcedureId";
            return _sqlite.GetDataTable(str);
        }

        public string LoadId()
        {
            var str = "select ConfigValue from Config where ConfigName ='UNIQUEID'";
            var tb = _sqlite.GetObject(str);
            if (tb != null && !string.IsNullOrEmpty(tb.ToString()))
            {
                return tb.ToString();
            }
            return "";
        }
        public DataTable GetVariable(int procedureId)
        {
            var str = "SELECT * from ProcedureVariable where ProcedureId = @ProcedureId";
            var parameters = new Dictionary<string, object> { { "@ProcedureId", procedureId } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetById(int id)
        {
            var str = "SELECT * from Procedure where ProcedureId = @ProcedureId";
            var parameters = new Dictionary<string, object> { { "@ProcedureId", id } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetResultProcedureById(int resultProcedureId)
        {
            var str = "SELECT * from ResultProcedure WHERE ResultProcedureId = @ResultProcedureId";
            var parameters = new Dictionary<string, object> { { "@ResultProcedureId", resultProcedureId } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetSBy(int dutId)
        {
            var str = "SELECT P.ProcedureId as Id,P.uniqueId as uniId,P.ProcedureName As Name,(SELECT DUTName from DUT as D INNER join DUTProcedure as dp on D.DUTId=dp.DUTId WHERE dp.ProcedureId=P.ProcedureId) as DUTNames,u.UserName as Author,P.Version as Version FROM Procedure as P LEFT JOIN User as u on P.CreateBy = u.UserId";
            var parameters = new Dictionary<string, object>();
            if (dutId > 0)
            {
                str += " LEFT JOIN DUTProcedure as DP on P.ProcedureId= dp.ProcedureId WHERE P.Type=1 And DP.DUTId = @DUTId";
                parameters.Add("@DUTId", dutId);
            }
            else
            {
                str += " WHERE P.Type=1";
            }
            str += " ORDER BY P.ProcedureId DESC";
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetResultsBy(int dutId)
        {
            var str = "SELECT R.ResultProcedureId as ResultProcedureId,R.Title as RUN,R.Percent as PROGRESS,(SELECT DUTName from DUT as D INNER join DUTResultProcedure as dp on D.DUTId=dp.DUTId WHERE dp.ResultProcedureId=R.ResultProcedureId) as DUTNames,u.UserName as Author,R.STARTTIME as STARTTIME, R.ENDTIME as ENDTIME FROM ResultProcedure as R LEFT JOIN User as u on R.UserId = u.UserId";
            var parameters = new Dictionary<string, object>();
            if (dutId > 0)
            {
                str += " LEFT JOIN DUTResultProcedure as DP on R.ResultProcedureId= dp.ResultProcedureId WHERE DP.DUTId = @DUTId";
                parameters.Add("@DUTId", dutId);
            }
            str += " ORDER BY R.ResultProcedureId DESC";
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public string GetLogBy(int resultProcedureId)
        {
            try
            {
                var str = "select LogReport from ResultProcedure where ResultProcedureId = @ResultProcedureId";
                var result = _sqlite.GetObject(str, new Dictionary<string, object> { { "@ResultProcedureId", resultProcedureId } });
                if (result != null)
                {
                    return result.ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.GetLogBy", ex);
                return "";
            }
        }

        public List<int> GetDUTIds(int procedureId)
        {
            List<int> lstToReturn = new List<int>();
            var str = "SELECT DUTId From DUTProcedure where ProcedureId = @ProcedureId";
            var dt = _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@ProcedureId", procedureId } });
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] != null)
                    {
                        var id = row[0].ToString();
                        if (!string.IsNullOrEmpty(id)) lstToReturn.Add(int.Parse(id));
                    }
                }
            }
            return lstToReturn;
        }
        public List<int> GetVesselIds(int procedureId)
        {
            List<int> lstToReturn = new List<int>();
            var str = "SELECT VesselId From VesselProcedure where ProcedureId = @ProcedureId";
            var dt = _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@ProcedureId", procedureId } });
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] != null)
                    {
                        var id = row[0].ToString();
                        if (!string.IsNullOrEmpty(id)) lstToReturn.Add(int.Parse(id));
                    }
                }
            }
            return lstToReturn;
        }

        public List<int> GetIdsFormPackage(int packageId)
        {
            List<int> lstToReturn = new List<int>();
            var str = "SELECT ProcedureID From Procedure where PackageId = @PackageId";
            var dt = _sqlite.GetDataTableParam(str, new Dictionary<string, object> { { "@PackageId", packageId } });
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var id = row[0].ToString();
                    if (!string.IsNullOrEmpty(id)) lstToReturn.Add(int.Parse(id));
                }
            }
            return lstToReturn;
        }
        #endregion
        #region Update
        public bool UpdateProcessId(string value, string name)
        {
            try
            {
                var str = "UPDATE Config set ConfigValue = @ConfigValue WHERE ConfigName = @ConfigName";
                var parameters = new Dictionary<string, object>
                {
                    { "@ConfigValue", value },
                    { "@ConfigName", name }
                };
                if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.UpdateProcessId", ex);
                return false;
            }
        }
        public bool UpdateProcedure(int procedureId, string procedureName, string description, string version, string category, string duration, string metaData, string strurl,string reportDate, string reportName, string outputPath, bool exportPDF)
        {
            try
            {
                var str = "UPDATE Procedure set ProcedureName=@ProcedureName,Description=@Description,Version=@Version,Category=@Category,Duration=@Duration,MetaData=@MetaData,URL=@URL,ReportName=@ReportName,ReportDate=@ReportDate,OutputPath=@OutputPath,ExportPDF=@ExportPDF WHERE ProcedureId=@ProcedureId";
                var parameters = new Dictionary<string, object>
                {
                    { "@ProcedureName", procedureName },
                    { "@Description", description ?? "" },
                    { "@Version", version },
                    { "@Category", category },
                    { "@Duration", duration },
                    { "@MetaData", metaData },
                    { "@URL", strurl },
                    { "@ReportName", reportName },
                    { "@ReportDate", reportDate },
                    { "@OutputPath", outputPath },
                    { "@ExportPDF", exportPDF },
                    { "@ProcedureId", procedureId }
                };
                if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.UpdateProcedure", ex);
                return false;
            }
        }
        #endregion
        #region Delete
        public bool DeleteProcedureVariable(int procedureId)
        {
            try
            {
                var str = "DELETE FROM ProcedureVariable WHERE ProcedureId = @ProcedureId";
                if (_sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ProcedureId", procedureId } }) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.DeleteProcedureVariable", ex);
                return false;
            }
        }

        public bool CheckToDelete(int id)
        {
            try
            {
                var str = "Select count(ResultProcedureId) from ResultProcedure where ProcedureId = @ProcedureId";
                var obj = _sqlite.GetObject(str, new Dictionary<string, object> { { "@ProcedureId", id } });
                if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                {
                    if (obj.ToString() != "0")
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.CheckToDelete", ex);
                return true;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                //Delete DUT
                var str = "DELETE FROM DUTProcedure WHERE ProcedureId = @ProcedureId";
                _sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ProcedureId", id } });
                //
                str = "DELETE FROM Procedure WHERE ProcedureId = @ProcedureId";
                if (_sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ProcedureId", id } }) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.Delete", ex);
                return true;
            }
        }
        public bool DeleteResult(int resultID)
        {
            try
            {
                //Delete DUT
                var str = "DELETE FROM ResultProcedureStep WHERE ResultProcedureId = @ResultProcedureId";
                _sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ResultProcedureId", resultID } });
                //
                str = "DELETE FROM ResultProcedure WHERE ResultProcedureId = @ResultProcedureId";
                if (_sqlite.ExecuteNonQuery(str, new Dictionary<string, object> { { "@ResultProcedureId", resultID } }) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("ProcedureManager.DeleteResult", ex);
                return true;
            }
        }
        #endregion
    }
}
