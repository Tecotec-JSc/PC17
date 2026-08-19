using System;
using System.Diagnostics;
using System.Threading;

namespace T3.CallDevices
{
    /// <summary>
    /// Khởi chạy tiến trình host thiết bị (T3.ServerHost) nếu chưa chạy.
    /// </summary>
    public class StartSeverT3
    {
        // Tên tiến trình đúng bằng tên file exe (không có phần mở rộng).
        private const string ServerProcessName = "T3.ServerHost";

        // Tên file thực thi của server host.
        private const string ServerExeName = "T3.ServerHost.exe";

        // Thời gian chờ cho server khởi động xong trước khi dùng (ms).
        private const int StartupWaitMs = 2000;

        /// <summary>
        /// Đảm bảo tiến trình <see cref="ServerProcessName"/> đang chạy; nếu chưa thì khởi chạy.
        /// </summary>
        /// <param name="serverName">Tham số giữ để tương thích lời gọi cũ; không còn dùng để dò tiến trình.</param>
        public void StartServer(string serverName)
        {
            // Trước đây dò theo tên "T3" nên không bao giờ khớp tiến trình "T3.ServerHost".
            // Sửa lại dò đúng theo tên exe để tránh khởi chạy trùng lặp.
            var process = Process.GetProcessesByName(ServerProcessName);
            if (process.Length == 0)
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + ServerExeName);
                Thread.Sleep(StartupWaitMs);
            }
        }
    }
}
