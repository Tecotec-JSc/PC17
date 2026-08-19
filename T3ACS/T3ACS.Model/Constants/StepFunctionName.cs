namespace T3ACS.Model
{
    /// <summary>
    /// Tên các loại hàm (function) của một step trong procedure.
    /// Gom về hằng số để tránh "magic string" khi điều phối chạy step.
    /// </summary>
    public static class StepFunctionName
    {
        public const string LoadView = "LoadView";
        public const string SaveData = "SaveData";
        public const string Stop = "Stop";
        public const string Prepare = "Prepare";
        public const string Run = "Run";
    }
}
