using T3ACS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace T3ACS.Model
{
    public class DUTModel : IDUTModel
    {
        IDUTManager _manager;
        public DUTModel()
        {
            _manager = new DUTManager();
        }
        public int InsertDUT(DUTViewModel vm)
        {
            // Manager đã dùng parameterized query nên KHÔNG escape thủ công (.Q()) nữa,
            // tránh double-escape làm hỏng dữ liệu (ví dụ O'Brien -> O''Brien).
            return _manager.InsertDUT(vm.DUTName, vm.DUTModel, vm.Category, vm.SensorNumber, vm.Brand, vm.CalibrationDate, vm.CalibrationDue, vm.ShipmentDate, vm.UserUnit);
        }
        public bool UpdateDUT(DUTViewModel vm)
        {
            return _manager.Update(vm.DUTId, vm.DUTName, vm.DUTModel, vm.Category, vm.SensorNumber, vm.Brand, vm.CalibrationDate, vm.CalibrationDue, vm.ShipmentDate, vm.UserUnit);
        }
        public List<TenDUTViewModel> GetTenDUTs()
        {
            List<TenDUTViewModel> rs = new List<TenDUTViewModel>(); 
            var dt = _manager.GetTenDUTs();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    TenDUTViewModel vm = new TenDUTViewModel();
                    vm.DUTId = int.Parse(row["DUTId"].ToString());
                    vm.DUTName = row["DUTName"].ToString();
                    vm.ModelDUT = row["Model"].ToString();
                    vm.Brand = row["Brand"].ToString();
                    rs.Add(vm);
                }
            }
            return rs;
        }
        public List<TableDUTViewModel> Gets(string filter)
        {
            List<TableDUTViewModel> rs = new List<TableDUTViewModel>();
            var dt = _manager.GetDUTsBy(filter,null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    TableDUTViewModel vm = new TableDUTViewModel();
                    vm.Id = int.Parse(row["DUTId"].ToString());
                    vm.Name = row["DUTName"].ToString();
                    vm.Model = row["Model"].ToString();
                    vm.Manufacturer = row["Brand"].ToString();
                    vm.SerialNumber = row["SenSorNumber"].ToString();
                    vm.Category = row["Category"].ToString();
                    rs.Add(vm);
                }
            }
            return rs;
        }


        public bool UpdateDUTOption(int dutId,string strDUTOption)
        {
            return _manager.UpdateDUTOption(dutId,strDUTOption);
        }

        public int GetIdBy(string name, string model, string brand)
        {
            return _manager.GetDUTIdBy(name, model, brand);
        }
        public DUTViewModel GetByID(int dutID)
        {
            DUTViewModel result = new DUTViewModel();
            var dt = _manager.GetById(dutID);
            if(dt!=null&&dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                result.DUTId = int.Parse(row["DUTID"].ToString());
                result.DUTName = row["DUTName"].ToString();
                result.DUTModel = row["Model"].ToString();
                result.Brand = row["Brand"].ToString();
                result.Category = row["Category"].ToString();
                result.ShipmentDate = row["ShipmentDate"].ToString();
                result.UserUnit = row["UserUnit"].ToString();
                result.SensorNumber = row["SensorNumber"].ToString();
                result.CalibrationDate = row["CalibrationDate"].ToString();
                result.CalibrationDue= row["CalibrationDue"].ToString();
                if (!string.IsNullOrEmpty(row["Options"].ToString()))
                {
                    var objs = JsonConvert.DeserializeObject<List<ProcedureVariableViewModel>>(row["Options"].ToString());
                    result.Options = objs;
                    result.strOption = row["Options"].ToString();
                }
            }
            return result;
        }
        public bool Duplicate(List<int> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                foreach (var id in ids)
                {
                    var vm = GetByID(id);
                    if (vm != null)
                    {
                        vm.DUTName = vm.DUTName + " (duplicate)";
                        var newDutId = InsertDUT(vm);
                        if (newDutId == 0) return false;
                        else
                        {
                            UpdateDUTOption(newDutId, vm.strOption);
                        }
                    }
                }
            }
            return true;
        }

        public bool checkDelete(int id)
        {
            return _manager.CheckDelete(id);
        }
        public bool Delete(int id)
        {
            return _manager.Delete(id);
        }

    }
}
