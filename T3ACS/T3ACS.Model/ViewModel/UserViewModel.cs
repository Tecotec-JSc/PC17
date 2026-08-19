using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Permission { get; set; }

    }
    public class RowsUserViewModel
    {
        public int UserId { get; set; }
        public bool Action { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Permission { get; set; }

    }
}
