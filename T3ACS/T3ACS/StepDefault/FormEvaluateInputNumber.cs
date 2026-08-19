using T3.Configuration;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace T3ACS
{
    public partial class FormEvaluateInputNumber : Form
    {
        IMain _main;
        public FormEvaluateInputNumber(IMain main)
        {
            InitializeComponent();
            LoadButtonBot();
            _main = main;
            rtbNote.PlaceholderText = "Notes";
            rtbNote.PlaceholderColor = Color.DarkGray;
        }
        public string GetNote()
        {
            return rtbNote.Texts;
        }
        public List<ProcedureDetailValueViewModel> _Data;
        public void LoadData(TableProcedureViewModel vm)
        {
            _Maskdone = vm.MaskDone;
            MaskDone();
            _Data = vm.ProcedureDetailValue2s;
            if (string.IsNullOrEmpty(vm.Comment)) rtbNote.Texts = vm.Comment;
            int ik = 1;
            resetForm();
            foreach (var item in vm.ProcedureDetailValue2s)
            {
                setValueToForm(ik, item.Value, item.Title);
                ik++;
            }
            
        }
        private void resetForm()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
        }
        public bool _CheckValue;
        public string _Note;
        private string getValueFrom(int indexV)
        {
            string result = "";
            switch (indexV)
            {
                case 1:
                    result = rjTextBox1.Text;
                    break;
                case 2:
                    result = rjTextBox2.Text;
                    break;
                case 3:
                    result = rjTextBox3.Text;
                    break;
                case 4:
                    result = rjTextBox4.Text;
                    break;
                case 5:
                    result = rjTextBox5.Text;
                    break;
                case 6:
                    result = rjTextBox6.Text;
                    break;
                case 7:
                    result = rjTextBox7.Text;
                    break;
                case 8:
                    result = rjTextBox8.Text;
                    break;
                case 9:
                    result = rjTextBox9.Text;
                    break;
                case 10:
                    result = rjTextBox10.Text;
                    break;
            }
            return result;
        }
        public void SaveValue()
        {
            _Note = rtbNote.Text;
            if (_Note == "Notes") _Note = "";
            int ik = 1;
            foreach (var item in _Data)
            {
                item.Value = getValueFrom(ik);
            }
        }
        public bool CheckSaveValue( out string messError)
        {
            messError = "";
            int ik = 1;
            foreach (var item in _Data)
            {
                var strmin = "";
                // Ghi số theo InvariantCulture để khớp với lúc parse (cũng invariant).
                if (item.Min != null) strmin = item.Min.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
                var strmax = "";
                if (item.Max != null) strmax = item.Max.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
           
                if (!CheckValue(item.Title, getValueFrom(ik), strmin, strmax, item.StrValueType, out messError))
                {                  
                    return false;
                }
            }
            return true;
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
        private void setValueToForm(int indexV, string value, string title)
        {
            switch (indexV)
            {
                case 1:
                    panel1.Visible = true;
                    rjTextBox1.Text = value;
                    label1.Text = title;
                    break;
                case 2:
                    panel2.Visible = true;
                    rjTextBox2.Text = value;
                    label2.Text = title;
                    break;
                case 3:
                    panel3.Visible = true;
                    rjTextBox3.Text = value;
                    label3.Text = title;
                    break;
                case 4:
                    panel4.Visible = true;
                    rjTextBox4.Text = value;
                    label4.Text = title;
                    break;
                case 5:
                    panel5.Visible = true;
                    rjTextBox5.Text = value;
                    label5.Text = title;
                    break;
                case 6:
                    panel6.Visible = true;
                    rjTextBox6.Text = value;
                    label6.Text = title;
                    break;
                case 7:
                    panel7.Visible = true;
                    rjTextBox7.Text = value;
                    label7.Text = title;
                    break;
                case 8:
                    panel8.Visible = true;
                    rjTextBox8.Text = value;
                    label8.Text = title;
                    break;
                case 9:
                    panel9.Visible = true;
                    rjTextBox9.Text = value;
                    label9.Text = title;
                    break;
                case 10:
                    panel10.Visible = true;
                    rjTextBox10.Text = value;
                    label10.Text = title;
                    break;
            }
        }
        //
        public void LoadButtonBot()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            //btnPass
            btnPass._ImageDefault = Image.FromFile(pathApp + "PassDefault.png");
            btnPass._ImageSelect = Image.FromFile(pathApp + "PassActive.png");
            btnPass._ImageDisable = Image.FromFile(pathApp + "PassDisable.png");
            btnPass._ClickControl += btnPassClick;
            btnPass.SetEnalbe(true);
            //btnFailed
            btnFailed._ImageDefault = Image.FromFile(pathApp + "FailedDefault.png");
            btnFailed._ImageSelect = Image.FromFile(pathApp + "FailedActive.png");
            btnFailed._ImageDisable = Image.FromFile(pathApp + "FailedDisable.png");
            btnFailed._ClickControl += btnFailedClick;
            btnFailed.SetEnalbe(true);
            //btnExport
            btnExport._ImageDefault = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageSelect = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageDisable = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport.Cursor = Cursors.No;
            btnExport.SetEnalbe(false);

            //btnExport
            btnQuit.Texts = "Quit";
            btnQuit.BorderColor = Color.FromArgb(0, 112, 203);
            btnQuit.ForeColor = Color.FromArgb(0, 112, 203);

        }
        private void btnPassClick(object sender, EventArgs e)
        {

        }
        private void btnFailedClick(object sender, EventArgs e)
        {

        }
        private void btnBackClick(object sender, EventArgs e)
        {

        }
        private void btnQuitClick(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

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
                    else
                    {
                        str.AppendLine(title + " value must be a number");
                        mess1 = str.ToString();
                        return false;
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
        public bool? _Maskdone;
        private void MaskDone()
        {
            if (_Maskdone.HasValue)
            {
                btnPass.SetValue(_Maskdone.Value);
                btnFailed.SetValue(!_Maskdone.Value);
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            _Maskdone = true;
            MaskDone();
        }

        private void btnFailed_Click(object sender, EventArgs e)
        {
            _Maskdone = false;
            MaskDone();
        }
    }
}
