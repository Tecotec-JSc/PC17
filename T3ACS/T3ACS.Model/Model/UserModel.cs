using T3ACS.Data;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace T3ACS.Model
{
    public class UserModel
    {
        IUserManager _manager;
        public UserModel()
        {
            _manager = new UserManager();
        }

        public int InsertUser(string userName, string passWord, string email, string phone, string fullName, string department, string permission)
        {
            // Băm mật khẩu trước khi lưu (không lưu plaintext).
            return _manager.InsertUser(userName, PasswordHasher.Hash(passWord), email, phone, fullName, department, permission);
        }

        //public List<RowsUserViewModel> Gets()
        //{
        //    return _manager.GetS();
        //}
        public bool Delete(int userId)
        {
            return _manager.Delete(userId);
        }
        public bool Check2Delete(int userId)
        {
            return _manager.Check2Delete(userId);
        }
        public UserViewModel GetById(int userId)
        {
            UserViewModel result;
            var dt= _manager.GetById(userId);
            if (dt != null&&dt.Rows.Count>0)
            {        
                result = ConvertDt2Vm(dt.Rows[0]);
            }
            else result = null;
            return result;
        }
        public bool CheckIsExistUserName(string userName, int userId)
        {
            return _manager.CheckIsExistUserName(userName, userId);
        }
        private UserViewModel ConvertDt2Vm(DataRow row)
        {
            var result = new UserViewModel();
            result.UserId = int.Parse(row["UserId"].ToString());
            result.FullName = row["FullName"].ToString();
            result.UserName = row["UserName"].ToString();
            result.PassWord = row["PassWord"].ToString();
            result.Permission = row["Permission"].ToString();
            return result;
        }
        private RowsUserViewModel ConvertDr2Vm(DataRow row)
        {
            var result = new RowsUserViewModel();
            result.UserId = int.Parse(row["UserId"].ToString());
            result.FullName = row["FullName"].ToString();
            result.UserName = row["UserName"].ToString();        
            result.Permission = row["Permission"].ToString();
            return result;
        }
        public bool Update(string userName, string password, string fullName, string permission, int userId)
        {
            // Nếu giá trị truyền vào đã là hash (ví dụ bị nạp lại từ DB) thì giữ nguyên,
            // ngược lại băm mật khẩu mới trước khi lưu (tránh double-hash).
            var storedPassword = PasswordHasher.IsHashed(password) ? password : PasswordHasher.Hash(password);
            return _manager.Update(userName, storedPassword, fullName, permission, userId);
        }

        /// <summary>
        /// Xác thực mật khẩu người dùng nhập với giá trị đã lưu trong DB.
        /// Hỗ trợ migration mềm cho mật khẩu cũ dạng plaintext (xem PasswordHasher.Verify).
        /// </summary>
        public bool VerifyPassword(string input, string stored)
        {
            return PasswordHasher.Verify(input, stored);
        }
        public List<RowsUserViewModel> Gets()
        {
            List<RowsUserViewModel> lstToReturn = new List<RowsUserViewModel>();
           var dt =_manager.Gets();
            if (dt != null && dt.Rows.Count > 0)
            {
               foreach (DataRow row in dt.Rows)
                {
                    lstToReturn.Add(ConvertDr2Vm(row)); ;
                }
            }
            return lstToReturn;
        }
        //public UserViewModel GetBy(string userName, string password)
        //{
        //    return _manager.GetBy(userName, password);
        //}
    }
}
