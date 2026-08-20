using System.Data;

namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho thao tác Excel: xuất báo cáo theo template và đọc dữ liệu từ file.
    /// </summary>
    public interface IExcelModel
    {
        /// <summary>
        /// Vẽ/điền dữ liệu kết quả quy trình vào file Excel theo template rồi lưu ra file đích.
        /// </summary>
        /// <param name="error">Thông báo lỗi nếu có.</param>
        bool DrawTemplateExcel(TemplateViewModel vm1, string pathTemplate, string fileExport, out string error);

        /// <summary>
        /// Đọc dữ liệu từ file Excel thành DataTable, bắt đầu từ dòng chỉ định.
        /// </summary>
        DataTable GetDataFormFile(string filePath, int rowStart);
    }
}
