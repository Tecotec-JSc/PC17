using System;
using System.Windows.Forms;

using T3.Configuration;
using T3ACS.Model;

namespace T3ACS
{
    public partial class FormLogin : Form
    {
        // Mã ký tự phím Enter (thay cho số "trần" 13 trong xử lý phím).
        private const char EnterKeyChar = (char)13;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                FormNotiAll frmNoti = new FormNotiAll();
                frmNoti.LoadData("Notification", "UserName and Password is not null.", 2);
                frmNoti.ShowDialog();
                return;
            }
            IUserModel model = new UserModel();
            var vm = model.GetBy(userName, password);
            if (vm != null)
            {
                Main.Permission = vm.Permission;
                // Lưu người dùng đang đăng nhập vào Session để tầng Data tự ghi audit (người tạo/sửa).
                Session.CurrentUserId = vm.UserId;
                Session.CurrentUserName = vm.UserName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                FormNotiAll frmNoti = new FormNotiAll();
                frmNoti.LoadData("Notification", "Wrong username or password", 2);
                frmNoti.ShowDialog();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == EnterKeyChar)
            {
                Login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == EnterKeyChar)
            {
                Login();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
