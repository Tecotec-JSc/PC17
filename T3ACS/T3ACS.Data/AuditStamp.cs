using System;
using System.Collections.Generic;

using T3.Configuration;

namespace T3ACS.Data
{
    /// <summary>
    /// Tiện ích gắn (stamp) thông tin audit "người tạo/sửa + thời điểm" vào câu lệnh
    /// INSERT/UPDATE. Giá trị người dùng lấy từ <see cref="Session.CurrentUserId"/> nên
    /// Manager không phải tự truyền userId. Dùng chung một định dạng thời gian với các cột
    /// ngày sẵn có trong DB.
    /// </summary>
    internal static class AuditStamp
    {
        /// <summary>Định dạng thời gian audit, đồng bộ với các cột ngày sẵn có (vd DateCreate).</summary>
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss.ffff";

        /// <summary>Mảnh cột thêm vào phần danh sách cột của INSERT.</summary>
        private const string InsertColumns = ",CreatedBy,CreatedAt,ModifiedBy,ModifiedAt";

        /// <summary>Mảnh tham số thêm vào phần VALUES của INSERT.</summary>
        private const string InsertValues = ",@CreatedBy,@CreatedAt,@ModifiedBy,@ModifiedAt";

        /// <summary>Mảnh gán thêm vào phần SET của UPDATE.</summary>
        private const string UpdateSet = ",ModifiedBy=@ModifiedBy,ModifiedAt=@ModifiedAt";

        /// <summary>
        /// Bổ sung tham số audit cho một câu INSERT và trả về mảnh SQL cần chèn.
        /// </summary>
        /// <param name="parameters">Bộ tham số của câu lệnh; sẽ được thêm các khoá audit.</param>
        /// <returns>Cặp (mảnh cột, mảnh giá trị) để nối vào INSERT.</returns>
        public static (string Columns, string Values) ForInsert(Dictionary<string, object> parameters)
        {
            string now = DateTime.Now.ToString(DateFormat);
            object userId = GetCurrentUserIdOrDbNull();

            parameters["@CreatedBy"] = userId;
            parameters["@CreatedAt"] = now;
            parameters["@ModifiedBy"] = userId;
            parameters["@ModifiedAt"] = now;

            return (InsertColumns, InsertValues);
        }

        /// <summary>
        /// Bổ sung tham số audit cho một câu UPDATE và trả về mảnh SQL "SET" cần chèn.
        /// Chỉ cập nhật ModifiedBy/ModifiedAt (không đụng CreatedBy/CreatedAt).
        /// </summary>
        /// <param name="parameters">Bộ tham số của câu lệnh; sẽ được thêm các khoá audit.</param>
        /// <returns>Mảnh gán để nối vào phần SET của UPDATE.</returns>
        public static string ForUpdate(Dictionary<string, object> parameters)
        {
            parameters["@ModifiedBy"] = GetCurrentUserIdOrDbNull();
            parameters["@ModifiedAt"] = DateTime.Now.ToString(DateFormat);

            return UpdateSet;
        }

        // Trả về userId hiện tại, hoặc DBNull nếu chưa đăng nhập (để tham số hoá ghi null).
        private static object GetCurrentUserIdOrDbNull()
        {
            return Session.CurrentUserId.HasValue ? Session.CurrentUserId.Value : DBNull.Value;
        }
    }
}
