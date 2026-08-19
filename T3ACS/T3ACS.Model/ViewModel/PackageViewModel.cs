using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
        public string DateCreate { get; set; }

        public int? UserCreate { get; set; }
    }
    public class RowTableExtensionViewModel
    {
        public int Id { get; set; }
        public bool Action { get; set; }
        public string PackageName { get; set; }
        //public int Type { get; set; }
        public string TypeName { get;set; }
        public string Version { get; set; }

        public string Description { get; set; }
        public string Model { get; set; }

        //public string HashTag { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public string DateCreate { get; set; }
        //public int? UserCreate { get; set; }
        //public string MetaData { get; set; }
        //public string PathDll { get; set; }
        //public string PackageId { get; set; }
    }
    public class ExtensionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }     
        public int Type {  get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateCreate { get; set; }
        public int? UserCreate { get; set; }
        public string MetaData {  get; set; }
        public string PathDll { get; set; }
        public string PackageId { get; set; }
        public int TypeFrame { get; set; }
        public List<ExtensionDetailViewModel> ExDetails { get; set; }
    }
    public class ExtensionDetailViewModel
    {
        public int ExtensionId { get; set; }
        public int ExtensionDetailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathFile { get; set; }
        public string HagTag { get; set; }
        public string Content { get; set; }
    }
    public class FunctionCallViewModel
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public int ExtensionId { get; set; }
        public string Name { get; set; }
        public string MetaData { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Assembly { get; set; }
        public string AssemblyType { get; set; }
        public string FunctionName { get; set; }
        public bool SetType { get; set; }
        public List<FunctionValueViewModel> FunctionValues { get; set; }
    }
    public class FunctionValueViewModel
    {
        public int Id { get; set; }
        public int FunctionCallId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeValue { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
        public double? Min {  get; set; }
        public double? Max { get; set; } 
        public bool Required { get; set; }
     
    }


    public class ToolsViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string TypeFrame { get; set; }
        public int Type {  get; set; }
        public string Content { get; set; }
    }


    public class FileExtensionInputViewModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      
        public int Type { get; set; }
        public string PathDll { get; set; }
        public string MetaData { get; set; }
        public int TypeFrame { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public List<FunctionCallViewModel> FunctionCalls { get; set; }
        public List<FileExtensionInputViewModel> Extensions { get; set; }
        public List<TemplateViewModel> Procedures { get; set; }
    }
    public enum EnumTypeExtension
    {
        Solution=0,
        Driver = 1,
        Procedure=2,
        StepType=3,
        Tool=4
    }
}
