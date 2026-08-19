using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3.Configuration;
using T3ACS.Model;

namespace T3ACS
{
    public partial class FormLicense : Form
    {

        public FormLicense()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = txt1.Text + "-" + txt2.Text + "-" + txt3.Text + "-" + txt4.Text + "-" + txt5.Text;
            LicenseModel model = new LicenseModel();
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
        private void textChange(int txtIndex, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                switch (txtIndex)
                {
                    case 1:
                        if (content.IndexOf("-") != -1)
                        {
                            var col = content.Split('-');
                            if (col.Length > 0)
                                txt1.Text = col[0].Length > 5 ? col[0].Substring(0, 5) : col[0];
                            if (col.Length > 1)
                                txt2.Text = col[1].Length > 5 ? col[1].Substring(0, 5) : col[1];
                            if (col.Length > 2)
                                txt3.Text = col[2].Length > 5 ? col[2].Substring(0, 5) : col[2];
                            if (col.Length > 3)
                                txt4.Text = col[3].Length > 5 ? col[3].Substring(0, 5) : col[3];
                            if (col.Length > 4)
                                txt5.Text = col[4].Length > 5 ? col[4].Substring(0, 5) : col[4];
                        }
                        else
                            txt1.Text = content.Length > 5 ? content.Substring(0, 5) : content;
                        break;
                    case 2:
                        if (content.IndexOf("-") != -1)
                        {
                            var col = content.Split('-');
                            if (col.Length > 0)
                                txt2.Text = col[0].Length > 5 ? col[0].Substring(0, 5) : col[0];
                            if (col.Length > 1)
                                txt3.Text = col[1].Length > 5 ? col[1].Substring(0, 5) : col[1];
                            if (col.Length > 2)
                                txt4.Text = col[2].Length > 5 ? col[2].Substring(0, 5) : col[2];
                            if (col.Length > 3)
                                txt5.Text = col[3].Length > 5 ? col[3].Substring(0, 5) : col[3];
                        }
                        else
                            txt2.Text = content.Length > 5 ? content.Substring(0, 5) : content;
                        break;
                    case 3:
                        if (content.IndexOf("-") != -1)
                        {
                            var col = content.Split('-');
                            if (col.Length > 0)
                                txt3.Text = col[0].Length > 5 ? col[0].Substring(0, 5) : col[0];
                            if (col.Length > 1)
                                txt4.Text = col[1].Length > 5 ? col[1].Substring(0, 5) : col[1];
                            if (col.Length > 2)
                                txt5.Text = col[2].Length > 5 ? col[2].Substring(0, 5) : col[2];
                        }
                        else
                            txt3.Text = content.Length > 5 ? content.Substring(0, 5) : content;
                        break;
                    case 4:
                        if (content.IndexOf("-") != -1)
                        {
                            var col = content.Split('-');
                            if (col.Length > 0)
                                txt4.Text = col[0].Length > 5 ? col[0].Substring(0, 5) : col[0];
                            if (col.Length > 1)
                                txt5.Text = col[1].Length > 5 ? col[1].Substring(0, 5) : col[1];
                        }
                        else
                            txt4.Text = content.Length > 5 ? content.Substring(0, 5) : content; ;
                        break;
                    case 5:
                        txt5.Text = content.Length > 5 ? content.Substring(0, 5) : content; ;
                        break;
                }
            }

        }



        bool textChanging = false;

        private void txt1_TextChanged_1(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                textChange(1, txt1.Text);
                Thread.Sleep(10);
                textChanging = false;
            }

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                textChange(2, txt2.Text);
                Thread.Sleep(10);
                textChanging = false;
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                textChange(3, txt3.Text);
                Thread.Sleep(10);
                textChanging = false;
            }
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                textChange(4, txt4.Text);
                Thread.Sleep(10);
                textChanging = false;
            }
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            if (!textChanging)
            {
                textChanging = true;
                textChange(5, txt5.Text);
                Thread.Sleep(10);
                textChanging = false;
            }
        }
    }
}
