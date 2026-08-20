using System.Collections.Generic;

namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho thiết bị kiểm thử (DUT — Device Under Test).
    /// </summary>
    public interface IDUTModel
    {
        /// <summary>
        /// Thêm mới một DUT.
        /// </summary>
        /// <returns>Id DUT vừa tạo; 0 nếu thất bại.</returns>
        int InsertDUT(DUTViewModel vm);

        /// <summary>
        /// Cập nhật thông tin một DUT.
        /// </summary>
        bool UpdateDUT(DUTViewModel vm);

        /// <summary>
        /// Lấy danh sách rút gọn (tên/model/brand) của các DUT.
        /// </summary>
        List<TenDUTViewModel> GetTenDUTs();

        /// <summary>
        /// Lấy danh sách DUT cho bảng hiển thị, có lọc theo từ khoá.
        /// </summary>
        List<TableDUTViewModel> Gets(string filter);

        /// <summary>
        /// Cập nhật cấu hình Option (chuỗi JSON) cho DUT.
        /// </summary>
        bool UpdateDUTOption(int dutId, string strDUTOption);

        /// <summary>
        /// Lấy Id của DUT theo tên, model và hãng sản xuất.
        /// </summary>
        int GetIdBy(string name, string model, string brand);

        /// <summary>
        /// Lấy chi tiết một DUT theo Id (kèm danh sách Option đã giải mã JSON).
        /// </summary>
        DUTViewModel GetByID(int dutID);

        /// <summary>
        /// Nhân bản (duplicate) các DUT theo danh sách Id.
        /// </summary>
        bool Duplicate(List<int> ids);

        /// <summary>
        /// Kiểm tra DUT có được phép xoá hay không.
        /// </summary>
        bool checkDelete(int id);

        /// <summary>
        /// Xoá DUT theo Id.
        /// </summary>
        bool Delete(int id);
    }
}
