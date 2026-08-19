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
    public partial class FormAddNumberInputValue : Form
    {
        public FormAddNumberInputValue()
        {
            InitializeComponent();
        }
        List<string> _values;
        List<string> _title;
        public void LoadData(List<string> values,List<string> title)
        {
            if (values == null) values = new List<string>();
            _values = values;
            if (title == null) title = new List<string>();
            _title = title;
        }

        public void EditPara(string name, string title, string value, string min, string max, string unit)
        {           
            txtMax.Text = max;
            txtMin.Text = min;
            txtName.Text= name;
            txtValue.Text = value;
            txtTitle.Text = title;
            txtUnit.Text = unit;
            lblHugeTitle.Text
                = "Edit number input";
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
            string mess="";
            if(!Validate(out mess))
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
            return new List<string>() { txtName.Text,txtValue.Text,txtMin.Text,txtMax.Text,txtUnit.Text,txtTitle.Text };
        }
        private bool Validate(out string error)
        {
            var strName = txtName.Text;
            bool isvalid = true;
            error = "";
            isvalid = MeasurementValidator.ValidateName(strName, "Parameter Name", _values,3,20,out error);
            if(!isvalid ) {
                return isvalid;
            }
            var strTitle = txtTitle.Text;
            if(!MeasurementValidator.ValidateTitle("Title",strTitle,3,100,_title, out  error))
            {
                return false;
            }
            var strValue = txtValue.Text;
            var strMin = txtMin.Text;
            var strMax = txtMax.Text;
            if (!string.IsNullOrEmpty(strValue) ) {
                if (!CheckValue("Value input", strValue, strMin, strMax, "Double", out error)) return false;
            }
            return isvalid;
        }
        private void ShowNoti(string mess)
        {
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData("Validate User Input", mess, 2);
            frmNoti.ShowDialog();
        }
       

        private bool CheckValue(string title, string input, string strmin, string strmax, string type, out string mess1)
        {
            try
            {

                bool check = true;
                double? valuecheck = null;
                double? min = null;
                double? max = null;
                StringBuilder str = new StringBuilder();
                //Integer Double String Boolean
                if (type == "Interger")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = int.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = int.Parse(strmin);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = int.Parse(strmax);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a integer");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Min");
                        check = false;
                    }

                }
                else if (type == "Double")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = double.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = double.Parse(strmin, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = double.Parse(strmax, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }

                mess1 = str.ToString();
                return check;
            }
            catch
            {
                mess1 = "Error.";
                return false;
            }

        }
    }
}
