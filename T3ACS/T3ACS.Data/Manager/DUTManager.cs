using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using T3.Configuration;

namespace T3ACS.Data
{
    public class DUTManager :IDUTManager
    {
        SQLiteDataBase _sqlite;
        public DUTManager()
        {
            _sqlite = new SQLiteDataBase();
        }
        public int InsertDUT(string dutName, string model, string category, string sensorNumber, string brand, string calibrationDate, string calibrationDue, string shipmentDate, string userUnit)
        {
            // Tham số hoá toàn bộ giá trị chuỗi để chống SQL injection.
            var str = "INSERT INTO DUT(DUTName,Model,Category,SensorNumber,Brand,CalibrationDate,CalibrationDue,ShipmentDate,UserUnit) VALUES (@DUTName,@Model,@Category,@SensorNumber,@Brand,@CalibrationDate,@CalibrationDue,@ShipmentDate,@UserUnit)";
            var parameters = new Dictionary<string, object>
            {
                { "@DUTName", dutName },
                { "@Model", model },
                { "@Category", category },
                { "@SensorNumber", sensorNumber },
                { "@Brand", brand },
                { "@CalibrationDate", calibrationDate },
                { "@CalibrationDue", calibrationDue },
                { "@ShipmentDate", shipmentDate },
                { "@UserUnit", userUnit }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }
        public DataTable GetDUTs()
        {
            return _sqlite.GetDataTable("select * from DUT order by DUTName ASC");
        }
        public DataTable GetDUTsBy(string textSearch, List<int> idsExcapse)
        {
            var str = "select * from DUT";
            var parameters = new Dictionary<string, object>();
            var check = true;
            if (!string.IsNullOrEmpty(textSearch))
            {
                check = false;
                // Tham số hoá chuỗi tìm kiếm (dùng chung 1 tham số cho mọi cột LIKE).
                str += " Where ( DUTName like @Search or Model like @Search or Category like @Search or Brand like @Search or SensorNumber like @Search)";
                parameters.Add("@Search", "%" + textSearch + "%");
            }
            if (idsExcapse != null && idsExcapse.Count > 0)
            {
                if (check) str += " Where ";
                else str += " and ";
                // idsExcapse là List<int> nên nối chuỗi số vẫn an toàn với injection.
                str += "DUTId not in (" + string.Join(",", idsExcapse) + ")";
            }
            str += " order by DUTName ASC";
            return _sqlite.GetDataTableParam(str, parameters);
        }

        public DataTable GetDUTsByIn(string textSearch, List<int> idsIn)
        {
            var str = "select * from DUT";
            var parameters = new Dictionary<string, object>();
            var check = true;
            if (!string.IsNullOrEmpty(textSearch))
            {
                check = false;
                str += " Where ( DUTName like @Search or Model like @Search or Category like @Search or Brand like @Search or SensorNumber like @Search)";
                parameters.Add("@Search", "%" + textSearch + "%");
                if (idsIn != null && idsIn.Count > 0)
                {
                    if (check) str += " Where ";
                    else str += " or ";
                    // idsIn là List<int> nên an toàn.
                    str += "DUTId in (" + string.Join(",", idsIn) + ")";
                }
            }

            str += " order by DUTName ASC";
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetNameDUTByProcedureId(int procedureId)
        {
            var str = "SELECT DUT.DUTID, DUT.DUTName,DUT.Model,DUT.Brand from DUT INNER JOIN DUTProcedure on DUT.DUTID = DUTProcedure.DUTId where DUTProcedure.ProcedureId = @ProcedureId";
            var parameters = new Dictionary<string, object> { { "@ProcedureId", procedureId } };
            return _sqlite.GetDataTableParam(str, parameters);
        }

        public DataTable GetById(int dutId)
        {
            var str = "select * from DUT Where DUTID = @DUTId";
            var parameters = new Dictionary<string, object> { { "@DUTId", dutId } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public int GetDUTIdFromModel(string shortName)
        {
            // Tham số hoá tên model (dữ liệu người dùng nhập).
            string query = "select DUTID from DUT where Model = @Model";
            var parameters = new Dictionary<string, object> { { "@Model", shortName } };
            var table = _sqlite.GetDataTableParam(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return int.Parse(table.Rows[0][0].ToString());
            }
            return 0;
        }
        public int GetDUTIdBy(string name, string model, string brand)
        {
            string query = "select DUTID from DUT where Model = @Model and DUTName = @Name and Brand = @Brand";
            var parameters = new Dictionary<string, object>
            {
                { "@Model", model },
                { "@Name", name },
                { "@Brand", brand }
            };
            var table = _sqlite.GetDataTableParam(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return int.Parse(table.Rows[0][0].ToString());
            }
            return 0;
        }

        public DataTable GetTenDUTs()
        {
            string query = "SELECT DUTId,DUTName,Model,Brand FROM DUT";
            return _sqlite.GetDataTable(query);
        }

        public bool Delete(int DUTId)
        {
            var str = "Delete FROM DUT where DUTID = @DUTId";
            var parameters = new Dictionary<string, object> { { "@DUTId", DUTId } };
            if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                return true;
            return false;
        }
        public bool CheckExistLK(int DUTId)
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "@DUTId", DUTId } };
                var table = _sqlite.GetDataTableParam("select DUTId from ProcedureRefDevide where DUTId = @DUTId", parameters);
                if (table != null && table.Rows.Count > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("DUTManager.CheckExistLK", ex);
                return false;
            }
        }
        public DataTable Gets()
        {
            var str = "select DUTName, DUTID from DUT";
            return _sqlite.GetDataTable(str);
        }

        public bool Update(int dutId, string DUTName, string model,string category, string sensorNumber, string brand, string calibrationDate,string calibrationDue, string shipmentDate, string userUnit)
        {
            try
            {
                string str = "Update DUT Set DUTName=@DUTName,Model=@Model,Category=@Category,SensorNumber=@SensorNumber,Brand=@Brand,CalibrationDate=@CalibrationDate,CalibrationDue=@CalibrationDue,ShipmentDate=@ShipmentDate,UserUnit=@UserUnit Where DUTID = @DUTId";
                var parameters = new Dictionary<string, object>
                {
                    { "@DUTName", DUTName },
                    { "@Model", model },
                    { "@Category", category },
                    { "@SensorNumber", sensorNumber },
                    { "@Brand", brand },
                    { "@CalibrationDate", calibrationDate },
                    { "@CalibrationDue", calibrationDue },
                    { "@ShipmentDate", shipmentDate },
                    { "@UserUnit", userUnit },
                    { "@DUTId", dutId }
                };
                if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("DUTManager.Update", ex);
                return false;
            }
        }
        public bool UpdateDUTOption(int dutId, string options)
        {
            try
            {
                string str = "Update DUT Set Options=@Options Where DUTID = @DUTId";
                var parameters = new Dictionary<string, object>
                {
                    { "@Options", options },
                    { "@DUTId", dutId }
                };
                if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("DUTManager.UpdateDUTOption", ex);
                return false;
            }
        }

        public bool CheckDelete(int dutId)
        {
            var str = "Select count(DUTId) from DUTProcedure where DUTId = @DUTId";
            var parameters = new Dictionary<string, object> { { "@DUTId", dutId } };
            var obj = _sqlite.GetObject(str, parameters);
            var check=false;
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                if (obj.ToString() != "0")
                    check= false;
                return true;
            }
            else return true;
        }
    }
}
