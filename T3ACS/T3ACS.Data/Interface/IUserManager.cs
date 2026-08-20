using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public interface IUserManager
    {
        int InsertUser(string userName, string passWord, string email, string phone, string fullName, string department, string permission);
        bool Check2Delete(int userId);
        bool Delete(int userId);
        DataTable GetById(int userId);
        DataTable GetByUserName(string userName);
        bool CheckIsExistUserName(string userName, int userId);
        bool Update(string userName, string password, string fullName, string permission, int userId);
        DataTable Gets();
    }
}
