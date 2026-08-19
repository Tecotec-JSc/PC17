using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public interface IDUTManager
    {
        int InsertDUT(string dutName, string model, string category, string sensorNumber, string brand, string calibrationDate, string calibrationDue, string shipmentDate, string userUnit);
        int GetDUTIdBy(string name, string model, string brand);
        DataTable GetDUTs();
        DataTable GetTenDUTs();
        DataTable GetDUTsBy(string textSearch, List<int> idsExcapse);
        DataTable GetDUTsByIn(string textSearch, List<int> idsIn);
        int GetDUTIdFromModel(string shortName);
        DataTable GetById(int DUTId);
        bool Delete(int DUTId);
        bool CheckExistLK(int DUTId);
        DataTable Gets();
        bool Update(int dutId, string DUTName, string model, string category, string sensorNumber, string brand, string calibrationDate, string calibrationDue, string shipmentDate, string userUnit);
        bool CheckDelete(int dutId);
        bool UpdateDUTOption(int dutId, string options);
        DataTable GetNameDUTByProcedureId(int procedureId);
    }
}
