using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using T3.Configuration;
namespace T3ACS.Data
{
    public class SQLiteDataBase : IDataBase
    {
        public SQLiteDataBase()
        {
            _connectionString = "Data Source=" + Main.ConnectionStringSQLite;
        }

        #region Field-Member
        private string _password = "";
        public string DatabasePassword
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
            }
        }
        #endregion

        #region Method
        public DataTable TableList()
        {
            return GetDataTable("SELECT NAME FROM sqlite_master WHERE type = 'table' ORDER BY name");
        }

        public DataTable ViewList()
        {
            return GetDataTable("SELECT NAME FROM sqlite_master WHERE type = 'view' ORDER BY name");
        }

        public DataTable ColumnList(string TableName)
        {
            return GetDataTable(string.Format("PRAGMA table_info('{0}')", TableName));
        }

        public DataTable ForeignKeyList(string TableName)
        {
            return GetDataTable(string.Format("PRAGMA foreign_key_list('{0}')", TableName));
        }

        public bool TableExists(string TableName)
        {
            return GetDataTable("SELECT name FROM sqlite_master WHERE type = 'table' And name = '" + TableName + "'").Rows.Count > 0;
        }

        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public object ExecuteInsert(string SQL)
        {
            SQL += ";    SELECT last_insert_rowid();";
            object obj = null;
            using (var connSQL = new SqliteConnection(_connectionString))
            {
                try
                {
                    SqliteCommand cmd = new SqliteCommand(SQL, connSQL);
                    if (connSQL.State != ConnectionState.Open) connSQL.Open();
                    obj = cmd.ExecuteScalar();

                }
                catch (Exception exInsert)
                {
                    throw exInsert;
                }
                finally
                {
                    connSQL.Close();
                }
            }

            if (obj != null)
                return obj;
            else
                return 0;
        }

        public int ExecuteNonQuery(string SQL)
        {
            int iResult = 0;
            using (var connSQL = new SqliteConnection(_connectionString))
            {
                try
                {
                    SqliteCommand cmd = new SqliteCommand(SQL, connSQL);
                    cmd.Connection = connSQL;
                    if (connSQL.State != ConnectionState.Open)
                        connSQL.Open();
                    iResult = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connSQL.Close();
                }
                return iResult;
            }
        }

        // ===================================================================
        // Các overload CÓ THAM SỐ HOÁ (chống SQL injection).
        // Manager nên dùng những hàm này thay cho việc nối chuỗi SQL trực tiếp.
        // ===================================================================

        // Gắn tham số vào command: null -> DBNull, Guid -> binary, còn lại AddWithValue.
        private static void AddParameters(SqliteCommand cmd, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;
            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                // Cho phép truyền key có hoặc không có tiền tố '@'
                string key = kvp.Key.StartsWith("@") ? kvp.Key : "@" + kvp.Key;
                if (kvp.Value == null || kvp.Value == DBNull.Value)
                {
                    cmd.Parameters.AddWithValue(key, DBNull.Value);
                }
                else if (kvp.Value is Guid)
                {
                    SqliteParameter para = new SqliteParameter(key, DbType.Binary);
                    para.Value = ((Guid)kvp.Value).ToByteArray();
                    cmd.Parameters.Add(para);
                }
                else
                {
                    cmd.Parameters.AddWithValue(key, kvp.Value);
                }
            }
        }

        // ---- Ambient transaction ----
        // Khi một transaction đang mở, mọi lệnh param bên dưới sẽ chạy trên CÙNG connection
        // này (để các bước phụ thuộc nhau đọc/ghi thấy dữ liệu chưa commit), thay vì mỗi
        // lệnh tự mở/đóng connection riêng.
        private SqliteConnection _txConn;
        private SqliteTransaction _tx;

        // Có đang trong một transaction hay không.
        public bool InTransaction => _tx != null;

        // Mở một transaction dùng chung cho instance này.
        public void BeginTransaction()
        {
            if (_tx != null) return; // đã có transaction đang mở
            _txConn = new SqliteConnection(_connectionString);
            _txConn.Open();
            _tx = _txConn.BeginTransaction();
        }

        // Commit transaction hiện tại (nếu có).
        public void Commit()
        {
            if (_tx == null) return;
            try { _tx.Commit(); }
            finally { CleanupTransaction(); }
        }

        // Rollback transaction hiện tại (nếu có).
        public void Rollback()
        {
            if (_tx == null) return;
            try { _tx.Rollback(); }
            finally { CleanupTransaction(); }
        }

        private void CleanupTransaction()
        {
            _tx?.Dispose();
            _txConn?.Dispose();
            _tx = null;
            _txConn = null;
        }

        // Tạo command trên đúng connection (ambient nếu đang trong transaction, ngược lại
        // mở connection tạm) rồi thực thi qua delegate. Bảo đảm đóng connection tạm sau khi xong.
        private T ExecWithCommand<T>(string sql, Dictionary<string, object> parameters, Func<SqliteCommand, T> exec)
        {
            if (_tx != null)
            {
                SqliteCommand cmd = new SqliteCommand(sql, _txConn, _tx);
                AddParameters(cmd, parameters);
                return exec(cmd);
            }
            using (var connSQL = new SqliteConnection(_connectionString))
            {
                SqliteCommand cmd = new SqliteCommand(sql, connSQL);
                AddParameters(cmd, parameters);
                connSQL.Open();
                return exec(cmd);
            }
        }

        // INSERT có tham số hoá, trả về last_insert_rowid().
        public object ExecuteInsert(string SQL, Dictionary<string, object> parameters)
        {
            SQL += ";    SELECT last_insert_rowid();";
            return ExecWithCommand(SQL, parameters, cmd => cmd.ExecuteScalar() ?? 0);
        }

        // Câu lệnh ghi (UPDATE/DELETE/INSERT) có tham số hoá.
        public int ExecuteNonQuery(string SQL, Dictionary<string, object> parameters)
        {
            return ExecWithCommand(SQL, parameters, cmd => cmd.ExecuteNonQuery());
        }

        // Truy vấn trả về DataTable có tham số hoá.
        public DataTable GetDataTableParam(string SQL, Dictionary<string, object> parameters)
        {
            return ExecWithCommand(SQL, parameters, cmd =>
            {
                DataTable dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                return dt;
            });
        }

        // Truy vấn trả về 1 giá trị vô hướng có tham số hoá.
        public object GetObject(string SQL, Dictionary<string, object> parameters)
        {
            return ExecWithCommand(SQL, parameters, cmd => cmd.ExecuteScalar());
        }

        #endregion

        #region Select
        public object GetObject(string SQL)
        {
            object iResult = null;
            using (var connSQL = new SqliteConnection(_connectionString))
            {
                try
                {
                    SqliteCommand cmd = new SqliteCommand(SQL, connSQL);
                    cmd.Connection = connSQL;
                    if (connSQL.State != ConnectionState.Open)
                        connSQL.Open();
                    iResult = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connSQL.Close();
                }
                return iResult;
            }
        }
        public DataTable GetDataTable(string SQL)
        {
            string Temp = SQL.ToLower();
            if (Temp.Contains("update") || Temp.Contains("insert") ||
                Temp.Contains("delete") || Temp.Contains("call") || Temp.Contains("drop")) return null;

            DataTable dt = new DataTable();
            SqliteDataReader reader = null;
            using (var connSQL = new SqliteConnection(_connectionString))
            {
                try
                {
                    SqliteCommand cmd = new SqliteCommand(SQL, connSQL);
                    if (connSQL.State != ConnectionState.Open) connSQL.Open();
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    // Không ném lỗi ra ngoài (giữ nguyên hành vi cũ) nhưng phải ghi log để không mất dấu vết.
                    Logger.Log("SQLiteDataBase.GetDataTable | SQL=" + SQL, ex);
                }
                finally
                {
                    if(reader!= null)
                    reader.Close();
                    connSQL.Close();
                }
            }
            return dt;
        }

        #endregion

    }
}
