using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using T3.Configuration;
using T3ACS.Model;

namespace T3ACS
{
    public partial class FormUsers : Form
    {
        private readonly IUserModel _model;

        public FormUsers()
        {
            InitializeComponent();
            _model = new UserModel();
            LoadDataTable();
        }

        // Cho phép kéo di chuyển form khi nhấn giữ thanh tiêu đề.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormBlur blur = new FormBlur();
            blur.Size = this.Size;
            blur.Location = this.Location;
            blur.Show();
            FormInsertNewUser frmUser = new FormInsertNewUser(0);
            if (frmUser.ShowDialog() == DialogResult.OK)
            {
                LoadDataTable();
            }
            frmUser.Dispose();
            // Đóng lớp mờ khi popup đóng.
            blur.Close();
            blur.Dispose();
        }

        /// <summary>
        /// Hiển thị thông báo trên nền mờ.
        /// </summary>
        /// <param name="title">Tiêu đề thông báo.</param>
        /// <param name="strmess">Nội dung thông báo.</param>
        /// <param name="status">Trạng thái: 1 success, 2 warning, 3 error.</param>
        private void ShowNoti(string title, string strmess, int status)
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
            blur.Close();
            blur.Dispose();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            List<int> lstId = new List<int>();
            var dt = (List<RowsUserViewModel>)dgvUsers.DataSource;
            if (dt != null && dt.Count > 0 && dt.Count(t => t.Action == true) > 0)
            {
                lstId = dt.Where(t => t.Action == true).Select(t => t.UserId).ToList();
            }
            if (lstId != null && lstId.Count > 0)
            {
                if (cboActionHistory.Text == "Edit")
                {
                    if (lstId.Count > 1)
                    {
                        ShowNoti("Notification", "You need to select only one user to edit.", 2);
                    }
                    else
                    {
                        FormInsertNewUser frmInsert = new FormInsertNewUser(lstId[0]);
                        if (frmInsert.ShowDialog() == DialogResult.OK)
                        {
                            LoadDataTable();
                        }
                    }
                }
                else if (cboActionHistory.Text == "Delete")
                {
                    FormOKCancelAll frmok = new FormOKCancelAll();
                    frmok.LoadData("Confirm action", "Click OK to confirm user deletation! User will be deleted permanently!", "Cancel", "OK", 2);
                    if (frmok.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var id in lstId)
                        {
                            if (_model.Check2Delete(id))
                            {
                                if (!_model.Delete(id))
                                {
                                    ShowNoti("Notification", "Error to detele user.", 3);
                                    LoadDataTable();
                                    return;
                                }
                            }
                            else
                            {
                                ShowNoti("Notification", "User has been used. Do not delete.", 2);
                                LoadDataTable();
                                return;
                            }
                        }
                        ShowNoti("Notification", "Delete User successfully.", 1);
                        LoadDataTable();
                    }
                }
            }
            else
            {
                ShowNoti("Notification", "You need to select a User.", 2);
            }
        }

        private void LoadDataTable()
        {
            var dt = _model.Gets();
            dgvUsers.DataSource = dt;
            dgvUsers.Refresh();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
