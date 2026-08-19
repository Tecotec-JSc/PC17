namespace T3ACS.Model
{
    /// <summary>
    /// Tên các loại step (StepType) của một procedure.
    /// Gom về hằng số để tránh "magic string" khi điều phối hiển thị/chạy step trong UI.
    /// Giá trị chuỗi giữ NGUYÊN như dữ liệu cũ trong DB để không thay đổi hành vi.
    /// (Đặt tên StepTypeName để không trùng enum StepType sẵn có trong StepTypeViewModel.)
    /// </summary>
    public static class StepTypeName
    {
        public const string Number = "Number";
        public const string String = "String";
        public const string Boolean = "Boolean";
        public const string FileAttach = "File Attach";
        public const string AddParameter = "Add Parameter";
        public const string Correction = "Correction";
        public const string Review = "Review";
        public const string Report = "Report";
        public const string Calculate = "Calculate";
        public const string UrlConfiguration = "URL Configuration";
        public const string DeviceUnderTest = "Device Under Test";
    }
}
