using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class DUTViewModel
    {
        public int DUTId { get; set; }
        public bool Select { get; set; }
        public string DUTName { get; set; }
        public string DUTModel{ get; set; }
        public string Category { get; set; }
        public string SensorNumber { get; set; }
        public string Brand { get; set; }
        public string CalibrationDate { get; set; }
        public string CalibrationDue { get; set; }
        public string ShipmentDate { get; set; }
        public string UserUnit { get; set; }

        public string strOption { get; set; }
        public List<ProcedureVariableViewModel> Options { get; set; }
    }
    public class TenDUTViewModel
    {
        public int DUTId { get; set; }
        public string DUTName { get; set; }
        public string ModelDUT { get; set; }
        public string Brand { get; set; }
    }
    public class TableDUTViewModel
    {
        public int Id { get; set; }
        public bool Action { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
}
