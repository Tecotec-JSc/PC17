using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class TableProcedureViewModel
    {
        public int ProcedureDetailId { get; set; }
        public int NumberOder { get; set; }   
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public List<ProcedureDetaiVariableViewModel> Variables { get; set; }
        public List<ProcedureDetailValueViewModel> ProcedureDetailValue2s { get; set; }
        public bool MaskDone { get; set; }
        public bool? MaskDoneValue { get; set; }
        public int LoopInput { get; set; }
        public bool Required { get; set; }
        public bool? Done { get; set; }
        public string PathDll { get; set; }
        public string PathSource { get; set; }
        public List<CycleViewModel> Cycles { get; set; }    
        public string StepType { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// 0: todo, 1: needRun, 2: running, 3: run Error, 4. runDone. 
        /// </summary>
        public int Status { get; set; }

        public List<ProcedureDetailFunction> Functions { get; set; }
        public List<URLViewModel> ListURL { get; set; }
        public string strURL { get; set; }
    }
    public class URLViewModel 
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class CycleViewModel
    {
        public int CycleNumber { get; set; }
        public string Status { get; set; }
        public bool StatusSave { get; set; }
    }

    public class MetaDataViewModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool CreateNewPath { get; set; }
        public string ShowAction { get { return "Open"; } }
    }
    
    public class TemplateViewModel
    {
        public List<TableProcedureViewModel> TableProcedures { get; set; }
        public List<ProcedureVariableViewModel> Variables { get; set; }
        public List<URLViewModel > Urls { get; set; }
        public string strURL { get; set; }
        public string Description { get; set; }
        public string ProcedureJson { get; set; }
        public string Id { get; set; }
        public int ProcedureId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int Type { get; set; }  
        public int CurrentStep { get; set; }
        public string Subject { get; set; }
        public string UserWork { get; set; } 
        public string MetaData { get; set; }
        public string Version { get; set; }
        public string LinkModem { get; set; }
        public string LinkACU { get; set; }

        public string Category { get; set; }
        public string Duration { get; set; }
        public List<int> DUTIds { get; set; }
        public string DUTName { get; set; }
        public string DevicesName { get; set; }
        public string DUTNames { get; set; }
        public string DUTModels { get; set; }
        public string DUTBrand { get; set; }
        public List<int> VesselIds { get; set; }
        public string Log { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Percent { get; set; }
        public int Status { get; set; }   

        public int PackageId;
        /// <summary>
        /// 
        /// </summary>
        public string ReportName { get; set; }
        public string ReportDate {  get; set; }
        public string ReportOutputPath { get; set; }
        public bool ExportPDF { get; set; }
    }
    public class DllToRunViewModel
    {
        public string FullPathDll { get; set; }
        public string DllName { get; set; }
        public List<AssemblyDllViewModel> AssemblyDlls { get; set; }
    }
    public class AssemblyDllViewModel
    {
        public string AssemblyName { get; set; }
        public List<FunctionDllViewModel> FunctionDlls { get; set; }
    }
    public class FunctionDllViewModel
    {
        public string FunctionName { get; set; }
        public List<ValueDllViewModel> ValueDlls { get; set; }
    }
    public class ValueDllViewModel
    {
        public string ValueName { get; set; }
        public string ValueTitle { get; set; }
        public string ValueType { get; set; }
        public string ValueInput { get; set; }
    }
    public class FileExportViewModel
    {
        public string OldPath { get; set; }
        public string NewPath { get; set; }
    }
}
