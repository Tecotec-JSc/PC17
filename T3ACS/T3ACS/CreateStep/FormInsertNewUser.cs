using T3.Configuration;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace T3ACS
{
    public partial class FormInsertNewUser : Form
    {
        int _id;
        UserModel _model;
        public FormInsertNewUser(int userId)
        {
            InitializeComponent();
            _id = userId;
            _model = new UserModel();
            loadData();
        }
        public void loadData()
        {
            UserViewModel vm = new UserViewModel();
            if (_id > 0)
            {
                vm = _model.GetById(_id);
            }
            if (vm == null) vm = new UserViewModel();
            if (vm != null && vm.UserId > 0) lblTitle.Text = "Update User";
            else lblTitle.Text = "New User";
            txtFullName.Text = vm.FullName;
            // Không hiển thị mật khẩu đã lưu (đã băm) ra ô nhập vì lý do bảo mật.
            // Khi sửa user, người dùng phải nhập lại mật khẩu mới để cập nhật.
            txtPassword.Text = "";
            txtUserName.Text = vm.UserName;
            cboPermission.Text = vm.Permission;
        }
        // Click title to move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        //End click title to move
        private void btnSave_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;
            var fullName = txtFullName.Text;
            var permission = cboPermission.Text;
            string strError = "";
            bool isValid = true;
            (isValid, strError) = ValidateUserName(userName);
            if (!isValid)
            {
                ShowMess("Validate User Input", strError,2);
                return;
            }
            (isValid, strError) = ValidatePassword(password);
            if (!isValid)
            {
                ShowMess("Validate User Input", strError, 2);
                return;
            }
            (isValid, strError) = ValidateFullName(fullName);
            if (!isValid)
            {
                ShowMess("Validate User Input", strError, 2);
                return;
            }
            (isValid, strError) = ValidatePermission(permission);
            if (!isValid)
            {
                ShowMess("Validate User Input", strError,2);
                return;
            }
            if (_model.CheckIsExistUserName(userName, _id))
            {
                ShowMess("Validate User Input", "UserName is exist.", 2);         
                return;
            }
            //if (Main.Permission == "Admin"&& permission=="Admin")
            //{
            //    FormNotification frmNoti = new FormNotification("You do not have access.");
            //    frmNoti.ShowDialog();
            //    return;
            //}

            if (_id == 0)
            {
                if (_model.InsertUser(userName, password, "", "", fullName, "", permission) > 0)
                {
                    ShowMess("Notification", "Add new user: " + fullName + " is susscessfully.", 1);            
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMess("Notification", "Error to insert new user : " + fullName + ".", 3);             
                }
            }
            else
            {
                if (_model.Update(userName, password, fullName, permission, _id))
                {
                    ShowMess("Notification", "Update user: " + fullName + " is susscessfully.", 1);                  
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowMess("Notification", "Error to update user : " + fullName + ".", 3);                   
                }

            }
        }
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>
        private void ShowMess(string title, string strmess, int status)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            frmNoti.ShowDialog();
            frmNoti.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
        }

        private (bool IsValid, string Error) ValidateUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return (false, "Username is required.");

            if (username.Length < 3 || username.Length > 20)
                return (false, "Username must be 3–20 characters long.");

            if (!char.IsLetter(username[0]))
                return (false, "Username must start with a letter.");
            for (int i = 0; i < username.Length; i++)
            {
                char c = username[i];
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '-'))
                    return (false, "Username may only contain letters, digits, underscore, dot or hyphen.");
            }

            // no consecutive special chars
            string specials = "._-";
            for (int i = 1; i < username.Length; i++)
            {
                if (specials.Contains(username[i]) && specials.Contains(username[i - 1]))
                    return (false, "Username cannot contain consecutive special characters like '..' or '._'.");
            }

            if (username.EndsWith(".") || username.EndsWith("-"))
                return (false, "Username cannot end with '.' or '-'.");

            return (true, string.Empty);
        }
        private (bool IsValid, string Error) ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return (false, "Password is required.");

            if (password.Length < 8)
                return (false, "Password must be at least 8 characters.");

            if (password.Length > 32)
                return (false, "Password cannot exceed 32 characters.");

            if (!password.Any(char.IsLower))
                return (false, "Password must contain at least one lowercase letter.");

            if (!password.Any(char.IsUpper))
                return (false, "Password must contain at least one uppercase letter.");

            if (!password.Any(char.IsDigit))
                return (false, "Password must contain at least one digit.");

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                return (false, "Password must contain at least one special character.");

            if (password.Any(char.IsWhiteSpace))
                return (false, "Password must not contain spaces.");

            return (true, string.Empty);
        }
        private (bool IsValid, string Error) ValidateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return (false, "Full name is required.");

            fullName = fullName.Trim();

            if (fullName.Length < 2)
                return (false, "Full name must be at least 2 characters.");

            if (fullName.Contains("  "))
                return (false, "Full name cannot contain double spaces.");

            // Allowed characters: letters, space, hyphen, apostrophe
            foreach (char c in fullName)
            {
                if (!(char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                    return (false, "Full name contains invalid characters.");
            }

            return (true, string.Empty);
        }
        private (bool IsValid, string Error) ValidatePermission(string permission)
        {
            if (string.IsNullOrWhiteSpace(permission))
                return (false, "Permissions is required.");
            if (permission != "Admin" && permission != "Operator" && permission != "Reviewer" && permission != "QA")
            {
                return (false, "You need to select a permission.");
            }
            return (true, string.Empty);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }    

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
