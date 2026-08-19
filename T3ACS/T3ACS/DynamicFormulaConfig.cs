namespace VSat.Spectrum
{
    public class DynamicVariable
    {
        public string Name { get; set; } = "";
        public string Title { get; set; } = "";
        public string Value { get; set; } = "";
        public string Unit { get; set; } = "";
        public double? Min { get; set; }
        public double? Max { get; set; }
        public string Type { get; set; } = "Double";        // "Double", "String"
        public string TypeImport { get; set; } = "Input";    // "Input", "Output"
        public bool Required { get; set; } = true;
        public bool Report { get; set; } = false;
    }

    public class DynamicFormulaConfig
    {
        public string DllPath { get; set; } = "";
        public string FormulaFilePath { get; set; } = "";   // đường dẫn file công thức (.txt)
        public List<DynamicVariable> Variables { get; set; } = new List<DynamicVariable>();
    }
}
