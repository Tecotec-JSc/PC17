using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public interface IProcedureManager
    {

        int InsertStepType(string stepType, string description, string category, string version, string GroupName, int repeat, string content);
        int InsertProcedure(string procedureName, string description, string uniqueId, string version, byte type, int? createBy, string category, string duration,string metaData);
        int InsertProcedureVariable(int procedureId, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool report, bool required,string items);
        bool InsertLKProcedureDevide(int procedureId, List<int> devideIds);
        bool InsertLKProcedureVessel(int procedureId, List<int> VesselIds);
        int InsertResultProcedure(string title, string description, int status, int procedureId, string Logreport, int percent, int? createBy, string startTime, string endTime);
        bool InsertDUTResultProcedure(int resultProcedureId, List<int> DUTIds);
        bool InsertVesselResultProcedure(int resultProcedureId, List<int> VesselIds);
     
        #region Get
        string LoadId();
        DataTable GetBy(string steptype);
        DataTable GetStepTypes();
        bool CheckIsExistStepType(string steptype);
        DataTable GetTemplates();
        DataTable GetById(int id);
        DataTable GetResultProcedureById(int resultProcedureId);
        DataTable GetSBy(int dutId);
        DataTable GetResultsBy(int dutId);
        string GetLogBy(int resultProcedureId);
        List<int> GetDUTIds(int procedureId);
        List<int> GetVesselIds(int procedureId);
        List<int> GetIdsFormPackage(int packageId);
        #endregion
        bool UpdateProcessId(string value, string name);
        bool UpdateProcedure(int procedureId, string procedureName, string description, string version, string category, string duration, string metaData, string url, string reportDate, string reportName, string outputPath, bool exportPDF);
        bool CheckToDelete(int id);
        bool Delete(int id);
        bool DeleteResult(int resultID);
        bool DeleteProcedureVariable(int procedureId);
        DataTable GetVariable(int procedureId);
    }
}
