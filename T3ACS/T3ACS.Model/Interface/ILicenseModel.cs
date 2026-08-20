namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho bản quyền (License): kiểm tra và lưu khoá kích hoạt.
    /// </summary>
    public interface ILicenseModel
    {
        /// <summary>
        /// Kiểm tra khoá bản quyền hiện tại có hợp lệ hay không.
        /// </summary>
        bool CheckKeyLicense();

        /// <summary>
        /// Lưu khoá bản quyền nếu khoá nhập vào hợp lệ.
        /// </summary>
        bool SaveKeyLicense(string key);
    }
}
