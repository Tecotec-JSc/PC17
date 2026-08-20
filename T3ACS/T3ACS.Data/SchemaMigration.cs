using System;
using System.Collections.Generic;
using System.Data;

namespace T3ACS.Data
{
    /// <summary>
    /// Tự động bổ sung các cột audit (CreatedBy/CreatedAt/ModifiedBy/ModifiedAt) cho các bảng
    /// thực thể chính khi khởi động. Idempotent: chỉ ALTER các cột còn thiếu, vì SQLite không
    /// hỗ trợ cú pháp ADD COLUMN IF NOT EXISTS.
    /// </summary>
    internal static class SchemaMigration
    {
        // Danh sách bảng thực thể chính cần gắn audit (bỏ qua bảng liên kết/junction).
        private static readonly string[] AuditedTables =
        {
            "Procedure",
            "ProcedureDetail",
            "ProcedureVariable",
            "StepType",
            "ResultProcedure",
            "DUT",
            "User",
            "Packages"
        };

        // Cột audit và kiểu SQLite tương ứng (User là INTEGER khoá tới bảng User, thời gian là TEXT).
        private static readonly (string Name, string Type)[] AuditColumns =
        {
            ("CreatedBy", "INTEGER"),
            ("CreatedAt", "TEXT"),
            ("ModifiedBy", "INTEGER"),
            ("ModifiedAt", "TEXT")
        };

        /// <summary>
        /// Đảm bảo mọi bảng thực thể chính đã có đủ 4 cột audit; thêm cột còn thiếu.
        /// </summary>
        /// <param name="sqlite">Đối tượng truy cập DB dùng để đọc schema và ALTER.</param>
        public static void EnsureAuditColumns(SQLiteDataBase sqlite)
        {
            foreach (string table in AuditedTables)
            {
                // Bỏ qua bảng không tồn tại trong file DB hiện tại.
                if (!sqlite.TableExists(table))
                {
                    continue;
                }

                HashSet<string> existing = GetColumns(sqlite, table);
                foreach ((string Name, string Type) column in AuditColumns)
                {
                    if (!existing.Contains(column.Name))
                    {
                        sqlite.ExecuteNonQuery($"ALTER TABLE \"{table}\" ADD COLUMN {column.Name} {column.Type}");
                    }
                }
            }
        }

        // Lấy tập tên cột hiện có của một bảng (so sánh không phân biệt hoa thường).
        private static HashSet<string> GetColumns(SQLiteDataBase sqlite, string table)
        {
            HashSet<string> result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            DataTable dt = sqlite.ColumnList(table);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    result.Add(row["name"].ToString() ?? string.Empty);
                }
            }
            return result;
        }
    }
}
