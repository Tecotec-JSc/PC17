using System.Collections.Generic;

namespace T3ACS.Model
{
    /// <summary>
    /// Hợp đồng nghiệp vụ cho quy trình đo/kiểm (Procedure), gồm cả loại bước (StepType),
    /// chi tiết bước và kết quả chạy quy trình.
    /// </summary>
    public interface IProcedureModel
    {
        /// <summary>
        /// Lấy nội dung log của một lần chạy quy trình (result procedure).
        /// </summary>
        string GetLogBy(int resultProcedureId);

        /// <summary>
        /// Lấy thông tin một loại bước (StepType) theo tên.
        /// </summary>
        StepTypeViewModel GetStepTypeBy(string steptype);

        /// <summary>
        /// Lấy danh sách toàn bộ loại bước (StepType).
        /// </summary>
        List<StepTypeViewModel> GetSteptypes();

        /// <summary>
        /// Thêm mới một loại bước (StepType).
        /// </summary>
        /// <returns>Id vừa tạo; 0 nếu thất bại.</returns>
        int InsertStepType(string stepType, string description, string category, string version, string GroupName, int repeat, string content);

        /// <summary>
        /// Kiểm tra một loại bước đã tồn tại chưa (các kiểu cơ bản luôn coi là tồn tại).
        /// </summary>
        bool CheckIsExist(string steptype);

        /// <summary>
        /// Lấy chi tiết đầy đủ của một quy trình theo Id (kèm biến, DUT và các bước).
        /// </summary>
        TemplateViewModel GetProcedureById(int procedureId);

        /// <summary>
        /// Lấy danh sách quy trình liên quan tới một DUT để hiển thị bảng kiểm tra.
        /// </summary>
        List<TableInspectionViewModel> GetsBy(int dutId);

        /// <summary>
        /// Lấy danh sách quy trình mẫu (template).
        /// </summary>
        List<TemplateProcedureViewModel> GetTemplates();

        /// <summary>
        /// Sinh mã Id mới cho quy trình theo năm hiện tại.
        /// </summary>
        string GetNewId();

        /// <summary>
        /// Cập nhật (tăng) mã Id quy trình dùng chung.
        /// </summary>
        bool UpdateNewId(string strId);

        /// <summary>
        /// Lấy danh sách kết quả chạy quy trình theo DUT.
        /// </summary>
        List<TableResultInspectionViewModel> GetResultsBy(int dutId);

        /// <summary>
        /// Lấy toàn bộ các bước của một quy trình theo Id.
        /// </summary>
        List<TableProcedureViewModel> GetsByProcedureId(int procedureId);

        /// <summary>
        /// Cập nhật chi tiết (biến + các bước) của quy trình, bọc trong một transaction.
        /// </summary>
        bool UpdateProcedureDetail(TemplateViewModel vm);

        /// <summary>
        /// Chèn danh sách bước chi tiết vào quy trình.
        /// </summary>
        void InsertProcedetail(List<TableProcedureViewModel> steps, int newId);

        /// <summary>
        /// Thêm mới một quy trình (kèm cập nhật mã, liên kết DUT và biến), bọc trong một transaction.
        /// </summary>
        /// <returns>Id quy trình vừa tạo; 0 nếu thất bại.</returns>
        int InsertProcedure(string name, string newstrId, string description, string version, string category, string duration, string dut, Dictionary<string, string> metaData, List<ProcedureVariableViewModel> variables);

        /// <summary>
        /// Thêm mới một kết quả chạy quy trình (kèm bước và giá trị), bọc trong một transaction.
        /// </summary>
        /// <returns>Id kết quả vừa tạo; 0 nếu thất bại.</returns>
        int InsertResultProcedure(TemplateViewModel vm);

        /// <summary>
        /// Tính phần trăm hoàn thành của quy trình dựa trên các bước đã thực hiện.
        /// </summary>
        TemplateViewModel CheckTemplate(TemplateViewModel vm);

        /// <summary>
        /// Cập nhật một quy trình (kèm liên kết DUT/Vessel và chi tiết bước).
        /// </summary>
        /// <param name="error">Thông báo lỗi nếu có.</param>
        bool UpdateProcedure(TemplateViewModel vm, out string error);

        /// <summary>
        /// Kiểm tra quy trình có được phép xoá hay không.
        /// </summary>
        bool CheckToDelete(int id);

        /// <summary>
        /// Xoá một quy trình theo Id (xoá cả chi tiết bước).
        /// </summary>
        /// <param name="mess">Thông báo lỗi nếu có.</param>
        bool Delete(int id, out string mess);

        /// <summary>
        /// Xoá một kết quả chạy quy trình theo Id.
        /// </summary>
        bool DeleteResult(int resultId);
    }
}
