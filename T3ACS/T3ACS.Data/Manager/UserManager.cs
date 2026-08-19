
using T3ACS.Data;
using T3.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public class UserManager:IUserManager
    {
        SQLiteDataBase _sqlite;
        public UserManager() {
            _sqlite = new SQLiteDataBase();
        }
        public int InsertUser(string userName, string passWord, string email, string phone, string fullName, string department, string permission)
        {
            try
            {
                // Tham số hoá toàn bộ giá trị người dùng nhập để chống SQL injection.
                var str = "INSERT INTO User(UserName,PassWord,Email,Phone,FullName,Department,Permission) VALUES (@UserName,@PassWord,@Email,@Phone,@FullName,@Department,@Permission)";
                var parameters = new Dictionary<string, object>
                {
                    { "@UserName", userName },
                    { "@PassWord", passWord },
                    { "@Email", email },
                    { "@Phone", phone },
                    { "@FullName", fullName },
                    { "@Department", department },
                    { "@Permission", permission }
                };
                return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
            }
            catch (Exception ex)
            {
                Logger.Log("UserManager.InsertUser", ex);
                return 0;
            }
        }
        public bool Check2Delete(int userId)
        {
            return true;
        }
        public bool Delete(int userId)
        {
            try
            {
                // userId là int nên an toàn, vẫn tham số hoá cho nhất quán.
                var str = "Delete FROM [User] where UserId = @UserId";
                var parameters = new Dictionary<string, object> { { "@UserId", userId } };
                if (_sqlite.ExecuteNonQuery(str, parameters) > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("UserManager.Delete", ex);
                return false;
            }
        }

        public DataTable GetById(int userId)
        {
            try
            {
                string query = "select * from [User] where userId = @UserId";
                var parameters = new Dictionary<string, object> { { "@UserId", userId } };
                return _sqlite.GetDataTableParam(query, parameters);
            }
            catch (Exception ex)
            {
                Logger.Log("UserManager.GetById", ex);
                return null;

            }
        }
        public bool CheckIsExistUserName(string userName, int userId)
        {
            // Tham số hoá userName (dữ liệu người dùng nhập).
            string query = "Select userId from [User] where UserName = @UserName and UserId != @UserId";
            var parameters = new Dictionary<string, object>
            {
                { "@UserName", userName },
                { "@UserId", userId }
            };
            var table = _sqlite.GetDataTableParam(query, parameters);
            if (table != null && table.Rows.Count > 0) return true;
            return false;
        }
        public bool Update(string userName, string password, string fullName, string permission, int userId)
        {
            try
            {
                string query = "Update User Set UserName=@UserName, PassWord=@PassWord, FullName=@FullName, Permission=@Permission Where UserId = @UserId";
                var parameters = new Dictionary<string, object>
                {
                    { "@UserName", userName },
                    { "@PassWord", password },
                    { "@FullName", fullName },
                    { "@Permission", permission },
                    { "@UserId", userId }
                };
                if(_sqlite.ExecuteNonQuery(query, parameters) > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("UserManager.Update", ex);
                return false;
            }
        }
        public DataTable Gets()
        {
            var str = "select * from [User] Order by FullName";
            return _sqlite.GetDataTable(str);
        }
    }
}
