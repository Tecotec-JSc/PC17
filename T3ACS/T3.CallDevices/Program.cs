namespace T3.CallDevices
{
    // ==========================================================================
    // LƯU Ý KIẾN TRÚC: Đây là entry point TEST cho cơ chế gọi thiết bị OUT-OF-PROCESS
    // (qua named-pipe tới tiến trình T3.ServerHost chạy .NET Framework 4.8).
    // App thật T3ACS KHÔNG dùng đường này — nó gọi thiết bị IN-PROCESS qua T3Call
    // (xem T3ACS.Service.FormService). Cơ chế pipe được GIỮ LÀM DỰ PHÒNG cho tình
    // huống cần nạp DLL thiết bị .NET Framework cũ ngoài tiến trình.
    // ==========================================================================
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            StartSeverT3 startSeverT3 = new StartSeverT3();
            // Truyền đúng tên tiến trình server. Tham số này hiện không còn được dùng để dò
            // tiến trình (StartServer đã dò theo tên exe), giữ lại chỉ để tương thích lời gọi cũ.
            startSeverT3.StartServer("T3.ServerHost");
            Application.Run(new Form1());
        }
    }
}