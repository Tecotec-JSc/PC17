using T3ACS.Util;
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

namespace T3ACS
{
    public partial class FormAddFileInputValue : Form
    {
        public FormAddFileInputValue()
        {
            InitializeComponent();
           
        }
        List<string> _values;
        List<string> _title;
        public void LoadData(List<string> values, List<string> title)
        {
            if (values == null) values = new List<string>();
            _values = values;
            if (title == null) title = new List<string>();
            _title = title;
        }

        public void EditPara(string name, string title, string value)
        {

            txtName.Text = name;
            if(!string.IsNullOrEmpty(value))
            {
                rjSelectFileControl1.SetValue(value);
            }
            txtTitle.Text = title;
            lblHugeTitle.Text
                = "Edit String Input";
        }

        // Click title to move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        //End click title to move
        private void lblbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mess = "";
            if (!Validate(out mess))
            {
                ShowNoti(mess);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public List<string> GetValueInput()
        {
            return new List<string>() { txtName.Text, rjSelectFileControl1._fileInput, txtTitle.Text };
        }
        private bool Validate(out string error)
        {
            var strName = txtName.Text;
            bool isvalid = true;
            error = "";
            isvalid = MeasurementValidator.ValidateName(strName, "Parameter Name", _values, 3, 20, out error);
            if (!isvalid)
            {
                return isvalid;
            }
            var strTitle = txtTitle.Text;
            if (!MeasurementValidator.ValidateTitle("Title", strTitle, 3, 100, _title, out error))
            {
                return false;
            }           

            return isvalid;
        }
        private void ShowNoti(string mess)
        {
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData("Validate User Input", mess, 2);
            frmNoti.ShowDialog();
        }

    }
}
