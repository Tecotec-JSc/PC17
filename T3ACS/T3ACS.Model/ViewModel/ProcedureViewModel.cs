using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class ProcedureViewModel
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        /// <summary>
        /// 0: Template, 1: procedure
        /// </summary>
        public byte Type { get; set; }
        public int? ParentId { get; set; }
        public int CreateBy { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime LastModified { get; set; }
        public int UserLastModified { get; set; }
        public int? Packgage { get; set; }
        public string Version { get; set; }
        public List<ProcedureInfoViewModel> ProcedureInfo { get; set; }
        public List<ProcedureDetailViewModel> ProcedureDetails { get; set; }

    }
    public class ProcedureDetailViewModel
    {
        public int ProcedureDetailId { get; set; }
        public int ProcedureId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int NumberOrder { get; set; }
        public string Comment { get; set; }
        public bool Required { get; set; }
        public int LoopInputMax { get; set; }
        public bool? MaskDone { get; set; }
        public bool? Pass { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime DateCreate { get; set; }
        public int UserCreate { get; set; }
        public string Name { get; set; }
        public string Cycle { get; set; }
        public List<ProcedureDetailValueViewModel> ProcedureDetailValue2s { get; set; }
        public int? Packgage { get; set; }
        public bool IsTemplate { get; set; }
    }   
    public class ProcedureInfoViewModel
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureValue { get; set; }
        public int ProcedureType { get; set; }
    }
    public class ProcedureVariableViewModel
    {
        public int ProcedureVariableId { get; set; }
        public int ProcedureId { get; set; }
        public string Name {  get; set; }
        public string OldName { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }   
        public string ValueRun { get; set; }
        public string Unit { get; set; }
        public string Min {  get; set; }
        public string Max { get; set; }
        public string Rank { get; set; }
        public bool Report {  get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public string TypeInput { get; set; }
        public string Description { get; set; }
        public string Items { get; set; }
        public string StepUse { get; set; }
    }
    public class ProcedureDetaiVariableViewModel
    {
        public int ProcedureDetailId { get; set; }
        public int ProcedureVariableId { get; set; }
        public string Value { get; set; }
        public string ValueRun { get; set; }
        public bool GetDataFromFreStep { get; set; }
        public string Name { get; set; }

        public int NumberOrder { get; set; }
        public string Title { get; set; }
        public string TypeInput { get; set; }
        public bool Required { get; set; }
        public bool Report { get; set; }
    }
    public class ProcedureDetailFunctionVariable
    {
        public int ProcedureDetailFunctionId { get; set; }
        public string FunctionName { get; set; }
        public int VariableId { get; set; }
        public string VariableName { get; set; }
        public string Title { get; set; }       
        public string Value { get; set; }
        public bool IsList { get; set; }
    }

    public class ProcedureDetailValueViewModel
    {
        public int NumberOder { get; set; }
        public int ProcedureDetailValueId { get; set; }
        public int ProcedureDetailId { get; set; }
        public string Title { get; set; }
        public string TypeInput { get; set; }
        public string Unit { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public bool Required { get; set; }
        public int ValueType { get; set; }
        /// <summary>
        /// Number,String,Boolean,Hashtag
        /// </summary>
        public string Type { get; set; }
        public string StrValueType { get; set; }
        public double? Start { get; set; }
        public double? RampUP { get; set; }
        public bool CanNext { get; set; }
        public string Value { get; set; }
        public string ValueFromPreStep { get; set; }
        public List<ValueInputFromDetailViewModel> ValueInputFromDetails { get; set; }
        public double? Averate { get; set; }
        public string Name { get; set; }
        public bool Report { get; set; }
        public bool ShowLogInRun { get; set; }
        public string Group { get; set; }
        public int ColExcel { get; set; }
        public int RowExcel { get; set; }
        /// <summary>
        /// variable from group function
        /// </summary>
        public string FunctionNumber { get; set; }
    }
    public class ValueInputFromDetailViewModel
    {
        public string value { get; set; }
        public int NumberCol { get; set; }
        public int Cycle { get; set; }
    }
    public enum EnumProcedureDetaiValue
    {
        Interger = 1, Decimal = 2, Percel = 3
    }
    public class ValueInputViewModel
    {
        public int RowIndex { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeFunction { get; set; }
        public List<string> Values { get; set; }
    }
    public class ProcedureDetailFunction
    {
      public string Name { get; set; }
        public int ProcedureDetailFunctionId { get; set; }
        public int NumberOrder { get; set; }
        public int ProcedureDetailId { get; set; }
        public string FunctionName { get; set; }
        public string PathDll { get; set; }
        public string Assembly { get; set; }
        public string AssemblyType { get; set; }
        public string Value { get; set; }
        public bool Default { get; set; }
        public List<ProcedureDetailFunctionValue> ValueDetails { get; set; }
        public List<ProcedureDetailFunctionVariable> FunctionVariables { get; set; }

    }
    public class ProcedureDetailFunctionViewModel
    {
        public int ProcedureDetailFunctionId { get; set; }
        public int NumberOrder { get; set; }
        public int ProcedureDetailId { get; set; }
        /// <summary>
        /// Type: LoadViewSetup,LoadViewRun, Prepare, Run, 
        /// </summary>
        public string Type { get; set; }
        public string FunctionName { get; set; }
        public string Extesnion { get; set; }
        public string Hagtag { get; set; }
        public string FuonctionName { get; set; }
        public string Version { get; set; }
        public string Model { get; set; }
        public string Value { get; set; }
      public List<ProcedureDetailFunctionVariable> FunctionVariables { get; set; }
    }
    public class ProcedureDetailFunctionValue
    {
        public int ProcedureDetailFunctionValueId { get; set; }

        public int ProcedureDetailFunctionId { get; set; }

        public int ProcedureDetailValueId { get; set; }

        public string ProcedureDetailValueName { get; set; }
        // Input, OutPut....
        public string Type { get; set; }

        public bool IsList { get; set; }
    }
}
