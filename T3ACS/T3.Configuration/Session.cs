namespace T3.Configuration
{
    /// <summary>
    /// Lưu thông tin người dùng đang đăng nhập ở phạm vi toàn ứng dụng, để tầng Data
    /// tự động ghi (stamp) audit "ai tạo/sửa" lên mỗi bản ghi mà không phải truyền userId
    /// qua từng lời gọi. Set giá trị này ngay sau khi đăng nhập thành công.
    /// </summary>
    public static class Session
    {
        /// <summary>
        /// Id người dùng đang đăng nhập; null nếu chưa đăng nhập (khi đó cột User audit ghi null).
        /// </summary>
        public static int? CurrentUserId { get; set; }

        /// <summary>
        /// Tên người dùng đang đăng nhập; dùng để hiển thị/log. Null nếu chưa đăng nhập.
        /// </summary>
        public static string? CurrentUserName { get; set; }
    }
}
