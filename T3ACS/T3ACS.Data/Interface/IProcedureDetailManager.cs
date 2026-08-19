using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public interface IProcedureDetailManager
    {
        DataTable GetsByProcedureId(int procedureId);
        DataTable GetDetailValuesBy(int procedureDetailId);
        DataTable GetProcedureDetailVariable(int procedureDetailId);
        int InsertProcedureDetail(int procedureId, string name, int cycle, int orderNumber, string type, string des, bool required, string jsonString,string url, string pathFileDll, string pathFileCalibration);
        int InsertProcedureDetailValue(int proceDureDetailId, int numberOrder, string name, string title, string unit, string type, string value, string TypeValue, double? min, double? max, string content);
        int InsertProcedureDetailVariable(int procedureDetailId, int variableId,string value, int oderNumber, string name, string title, string typeInput, bool report, bool required);
        bool DeleteProcedureDetailsByProcedureId(int procedureId);
        int InsertResultProcedureStep(int ResultProcedureId, string name, int cycle, int StepNumber, string des, bool required, int status);
        int InsertOrUpdateResultProcedureDetailValue(int ResultProcedureStepId, int numberOrder, string name, string title, string unit);
        int InsertResultProcedureDetailValueInput(int ResultProcedureStepValueId, string value, string numberCycle);
        bool Delete(int id);

        int InsertProcedureDetailFunction(int proceDureDetailId, int numberOrder, string functionName, string pathDll, string Assembly, string AssemblyType, string value);
        int InsertProcedureDetailFunctionVariable(int procedureDetaiId, int variableId, string type, bool isList, string value, string name);
    }
}
