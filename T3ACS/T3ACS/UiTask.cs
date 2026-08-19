using System;
using System.Threading.Tasks;

namespace T3ACS
{
    /// <summary>
    /// Tiện ích đẩy các thao tác NẶNG và THUẦN DỮ LIỆU (đọc/ghi DB, đọc/ghi file, gọi thiết bị
    /// trả về dữ liệu) ra thread nền để UI không bị treo ("Not Responding").
    ///
    /// LƯU Ý QUAN TRỌNG:
    /// - KHÔNG được tạo/đụng control WinForms bên trong 'work' (control chỉ được thao tác trên UI thread).
    ///   Mọi cập nhật UI phải làm SAU khi await (lúc đó đã quay lại UI thread).
    /// - Chỉ dùng cho việc thuần dữ liệu; những việc tạo Form/UserControl phải chạy trực tiếp trên UI thread.
    /// </summary>
    public static class UiTask
    {
        /// <summary>
        /// Chạy 'work' trên thread nền và trả kết quả (dùng cho việc có giá trị trả về).
        /// </summary>
        public static Task<T> RunAsync<T>(Func<T> work) => Task.Run(work);

        /// <summary>
        /// Chạy 'work' trên thread nền (dùng cho việc không có giá trị trả về).
        /// </summary>
        public static Task RunAsync(Action work) => Task.Run(work);
    }
}
