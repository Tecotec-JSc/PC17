namespace T3ACS.Model
{
    /// <summary>
    /// Tên các kiểu dữ liệu biến dùng trong procedure/step.
    /// Gom về hằng số để tránh "magic string" rải rác trong Service và UI.
    /// </summary>
    public static class VariableType
    {
        public const string Float = "Float";
        public const string Integer = "Integer";
        public const string Double = "Double";
        public const string String = "String";
        public const string Boolean = "Boolean";
        public const string Uint = "Uint";
        public const string Short = "Short";
        public const string Long = "Long";
        public const string PathFile = "PathFile";
    }
}
