using System;
using System.Threading;
using System.Windows.Forms;

using T3ACS.Model;

namespace T3ACS
{
    public partial class FormLicense : Form
    {
        // Số ký tự tối đa của mỗi đoạn key bản quyền.
        private const int MaxSegmentLength = 5;

        // Cờ chống đệ quy khi tự phân bổ text giữa các ô nhập key.
        private bool _textChanging;

        public FormLicense()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var str = txt1.Text + "-" + txt2.Text + "-" + txt3.Text + "-" + txt4.Text + "-" + txt5.Text;
            ILicenseModel model = new LicenseModel();
            if (model.SaveKeyLicense(str))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ShowMess("Notification", "Key license isvalid.", 2);
            }
        }

        /// <summary>
        /// Hiển thị thông báo trên nền mờ.
        /// </summary>
        /// <param name="title">Tiêu đề thông báo.</param>
        /// <param name="strmess">Nội dung thông báo.</param>
        /// <param name="status">Trạng thái: 1 success, 2 warning, 3 error.</param>
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
            blur.Close();
            blur.Dispose();
        }

        // Cắt/phân bổ chuỗi key dán vào từ ô thứ txtIndex sang các ô kế tiếp.
        private void FillKeySegments(int txtIndex, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }
            switch (txtIndex)
            {
                case 1:
                    if (content.IndexOf("-") != -1)
                    {
                        var col = content.Split('-');
                        if (col.Length > 0)
                            txt1.Text = Truncate(col[0]);
                        if (col.Length > 1)
                            txt2.Text = Truncate(col[1]);
                        if (col.Length > 2)
                            txt3.Text = Truncate(col[2]);
                        if (col.Length > 3)
                            txt4.Text = Truncate(col[3]);
                        if (col.Length > 4)
                            txt5.Text = Truncate(col[4]);
                    }
                    else
                        txt1.Text = Truncate(content);
                    break;
                case 2:
                    if (content.IndexOf("-") != -1)
                    {
                        var col = content.Split('-');
                        if (col.Length > 0)
                            txt2.Text = Truncate(col[0]);
                        if (col.Length > 1)
                            txt3.Text = Truncate(col[1]);
                        if (col.Length > 2)
                            txt4.Text = Truncate(col[2]);
                        if (col.Length > 3)
                            txt5.Text = Truncate(col[3]);
                    }
                    else
                        txt2.Text = Truncate(content);
                    break;
                case 3:
                    if (content.IndexOf("-") != -1)
                    {
                        var col = content.Split('-');
                        if (col.Length > 0)
                            txt3.Text = Truncate(col[0]);
                        if (col.Length > 1)
                            txt4.Text = Truncate(col[1]);
                        if (col.Length > 2)
                            txt5.Text = Truncate(col[2]);
                    }
                    else
                        txt3.Text = Truncate(content);
                    break;
                case 4:
                    if (content.IndexOf("-") != -1)
                    {
                        var col = content.Split('-');
                        if (col.Length > 0)
                            txt4.Text = Truncate(col[0]);
                        if (col.Length > 1)
                            txt5.Text = Truncate(col[1]);
                    }
                    else
                        txt4.Text = Truncate(content);
                    break;
                case 5:
                    txt5.Text = Truncate(content);
                    break;
            }
        }

        // Cắt chuỗi về tối đa MaxSegmentLength ký tự.
        private static string Truncate(string value)
        {
            return value.Length > MaxSegmentLength ? value.Substring(0, MaxSegmentLength) : value;
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                FillKeySegments(1, txt1.Text);
                Thread.Sleep(10);
                _textChanging = false;
            }
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                FillKeySegments(2, txt2.Text);
                Thread.Sleep(10);
                _textChanging = false;
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                FillKeySegments(3, txt3.Text);
                Thread.Sleep(10);
                _textChanging = false;
            }
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                FillKeySegments(4, txt4.Text);
                Thread.Sleep(10);
                _textChanging = false;
            }
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (!_textChanging)
            {
                _textChanging = true;
                FillKeySegments(5, txt5.Text);
                Thread.Sleep(10);
                _textChanging = false;
            }
        }
    }
}
