using System;
using System.IO;

namespace T3.Configuration
{
    /// <summary>
    /// Logger dùng CHUNG cho mọi layer (Data/Model/UI...).
    /// Đặt ở T3.Configuration vì đây là project cấp thấp nhất mà tất cả các layer đều tham chiếu được,
    /// nhờ đó lớp Data có thể ghi log lỗi thay vì "nuốt" exception âm thầm.
    /// Ghi vào cùng file CrashLog&lt;ngày&gt;.txt tại thư mục chạy ứng dụng, an toàn đa luồng qua lock.
    /// </summary>
    public static class Logger
    {
        private static readonly object _lock = new object();

        // Tên file log theo ngày, đặt cạnh file thực thi (giống Logger cũ ở lớp UI).
        private static string LogFile =>
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "CrashLog" + DateTime.Now.ToString("dd-MM-yy") + ".txt");

        /// <summary>
        /// Ghi một dòng log. Bản thân việc ghi log không được phép làm hỏng luồng nghiệp vụ,
        /// nên mọi lỗi khi ghi file đều được bỏ qua.
        /// </summary>
        public static void Log(string? msg)
        {
            try
            {
                lock (_lock)
                {
                    File.AppendAllText(
                        LogFile,
                        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {msg}\r\n");
                }
            }
            catch
            {
                // Không để lỗi ghi log lan ra ngoài.
            }
        }

        /// <summary>
        /// Ghi log kèm ngữ cảnh và toàn bộ thông tin exception (message + stack trace).
        /// Dùng ở các khối catch để không mất dấu vết lỗi.
        /// </summary>
        public static void Log(string context, Exception ex)
        {
            Log(context + " | " + ex);
        }
    }
}
