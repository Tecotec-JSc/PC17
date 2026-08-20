using System.Collections.Generic;

namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho gói mở rộng (Package/Extension): cài đặt, tra cứu và gỡ bỏ.
    /// </summary>
    public interface IPackageModel
    {
        /// <summary>
        /// Cài đặt một gói mở rộng từ file (tool/procedure/step type/solution/driver).
        /// </summary>
        /// <returns>Id gói vừa tạo; 0 nếu thất bại.</returns>
        int InsertPackage(FileExtensionInputViewModel vm, string filepack);

        /// <summary>
        /// Kiểm tra gói (theo tên + phiên bản) đã tồn tại chưa.
        /// </summary>
        bool CheckIsExist(string packageName, string version);

        /// <summary>
        /// Lấy danh sách gói mở rộng để hiển thị bảng.
        /// </summary>
        List<RowTableExtensionViewModel> Gets();

        /// <summary>
        /// Lấy danh sách gói dạng Tool.
        /// </summary>
        List<ToolsViewModel> GetTools();

        /// <summary>
        /// Xoá gói theo Id (kèm xoá chi tiết và thư mục nguồn).
        /// </summary>
        bool Delete(int packageId);

        /// <summary>
        /// Kiểm tra gói có được phép xoá hay không.
        /// </summary>
        bool CheckDelete(int packageId);
    }
}
