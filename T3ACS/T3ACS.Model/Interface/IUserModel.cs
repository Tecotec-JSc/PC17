using System.Collections.Generic;

namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho người dùng (User): thêm, sửa, xoá, tra cứu và xác thực đăng nhập.
    /// </summary>
    public interface IUserModel
    {
        /// <summary>
        /// Thêm mới người dùng (mật khẩu được băm trước khi lưu).
        /// </summary>
        /// <returns>Id người dùng vừa tạo; 0 nếu thất bại.</returns>
        int InsertUser(string userName, string passWord, string email, string phone, string fullName, string department, string permission);

        /// <summary>
        /// Xoá người dùng theo Id.
        /// </summary>
        bool Delete(int userId);

        /// <summary>
        /// Kiểm tra người dùng có được phép xoá hay không (ràng buộc nghiệp vụ).
        /// </summary>
        bool Check2Delete(int userId);

        /// <summary>
        /// Lấy thông tin người dùng theo Id.
        /// </summary>
        /// <returns>ViewModel người dùng; null nếu không tìm thấy.</returns>
        UserViewModel GetById(int userId);

        /// <summary>
        /// Kiểm tra tên đăng nhập đã tồn tại chưa (loại trừ chính người dùng đang sửa).
        /// </summary>
        bool CheckIsExistUserName(string userName, int userId);

        /// <summary>
        /// Cập nhật thông tin người dùng (tự băm mật khẩu mới nếu chưa được băm).
        /// </summary>
        bool Update(string userName, string password, string fullName, string permission, int userId);

        /// <summary>
        /// Xác thực mật khẩu người dùng nhập với giá trị đã lưu trong DB.
        /// </summary>
        bool VerifyPassword(string input, string stored);

        /// <summary>
        /// Lấy danh sách người dùng.
        /// </summary>
        List<RowsUserViewModel> Gets();

        /// <summary>
        /// Xác thực đăng nhập theo tên đăng nhập và mật khẩu.
        /// </summary>
        /// <returns>Thông tin người dùng nếu hợp lệ; null nếu sai tên hoặc mật khẩu.</returns>
        UserViewModel GetBy(string userName, string password);
    }
}
