using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace T3ACS.Controls
{
    public partial class RowVariableControl : UserControl
    {
        public RowVariableControl()
        {
            InitializeComponent();
            SetupData();
        }
        private void RowVariableControl_Load(object sender, EventArgs e)
        {

        }
        public List<string> _LstName;
        public int _idVariable;
        private void SetupData()
        {
            cboType.SetData(new List<string>() { "Boolean", "Double", "Integer", "Float", "String", "Ushor" }, "Type");
           // cboTypeInput.SetData(new List<string>() { "Input", "ListInput", "Output", "ListOutput" }, "TypeInput");
            cboTypeInput.SetData(new List<string>() { "Input", "Output" }, "TypeInput");
        }

        public void ChangeBackColor(Color cl)
        {
            this.BackColor = cl;
            panelCustomBorder1.BackColor = cl;
        foreach(Control c in panelCustomBorder1.Controls)
            {
                c.BackColor = cl;
            }
        }

        public event EventHandler _SaveClick;
        public event EventHandler _DeleteClick;
        public event EventHandler _UpdateHeight;
        public event EventHandler _CheckChange;
        public bool Editor;
        public bool _Checked, _Required, _Report;
        public bool _ValidateData;
        public string _StrError;
        public string _items;
        List<string> _list;
        public string _typeA;
        public string GetName()
        {
            return lblDefaultName.Text;
        }
        public void LoadData(bool checkv, int id, string name, string title, string value, string items, string unit, string min, string max, string type, string typeInput, bool required, bool report, bool edit)
        {
            _Checked = checkv;
            _idVariable = id;
            _items = items;
            _typeA = type;
            if (!string.IsNullOrEmpty(items))
            {
                var col = items.Split(',');
                _list = new List<string>();
                foreach (var item in col)
                {
                    _list.Add(item);
                }
                selectValue.SetData(_list, "Value");
                selectValue.Visible = true;
                txtTbVName.Visible = false;
            }
            else
            {
                selectValue.Visible = false;
                txtTbVName.Visible = true;
            }
            if (type == "Boolean")
            {
                _list = new List<string>() { "True", "False" };
                selectValue.SetData(_list, "Value");
                selectValue.Visible = true;
                txtTbVName.Visible = false;
            }
            if (checkv) chkRow.Image = Properties.Resources.Checked;
            else chkRow.Image = Properties.Resources.NotChecked;
            lblDefaultName.Text = name;
            txtTbVName.Text = name;
            var strtitle = title + "";
            if (strtitle.Length > 25) strtitle = title.Substring(0, 22) + "...";
            lblDefaultTitle.Text = strtitle;
            txtTbVTitle.Text = title;
            lblDefaultValue.Text = value;
            txtTbVValue.Text = value;
            lblDefaultUnit.Text = unit;
            txtTbVUnit.Text = unit;
            lblDefaultMin.Text = min;
            txtTbVMin.Text = min;
            lblDefaultMax.Text = max;
            txtTbVMax.Text = max;

            _Required = required;
            _Report = report;
            if (required)
                lblDefaultRequired.Text = "Yes";
            else lblDefaultRequired.Text = "No";
            if (report) lblDefaultReport.Text = "Yes";
            else lblDefaultReport.Text = "No";
            lblType.Text = type;
            cboType.Texts = type;
            lblTypeInput.Text = typeInput;
            cboTypeInput.Texts = typeInput;
            Editor = edit;
            EditAction(edit);
            ResetImageCheck();
            ResetImageReport();
            ResetImageRequired();
        }
        private void EditAction(bool edit)
        {
            txtTbVName.Visible = edit;
            txtTbVTitle.Visible = edit;
            if (lblType.Text == "Boolean")
            {
                txtTbVValue.Visible = false;
                selectValue.Visible = edit;
            }
            else
            {
                txtTbVValue.Visible = edit;
                selectValue.Visible = false;
            }
     
            txtTbVUnit.Visible = edit;
            txtTbVMin.Visible = edit;
            txtTbVMax.Visible = edit;
            cboType.Visible = edit;
            cboTypeInput.Visible = edit;
       
            lblChkReport.Visible = edit;
            lblChkRequired.Visible = edit;
            lblDefaultName.Visible = !edit;
            lblDefaultTitle.Visible = !edit;
            lblDefaultValue.Visible = !edit;
            lblDefaultUnit.Visible = !edit;
            lblDefaultMin.Visible = !edit;
            lblDefaultMax.Visible = !edit;
            lblDefaultReport.Visible = !edit;
            lblDefaultRequired.Visible = !edit;
            lblType.Visible = !edit;
            lblTypeInput.Visible = !edit;
            lblbtnEdit.Visible = !edit;
            lblbtnSave.Visible = edit;
        }
        private void lblbtnSave_Click(object sender, EventArgs e)
        {
            if (!CheckSaveData(out string error))
            {
                _StrError = error;
                if (_SaveClick != null)
                    _SaveClick.Invoke(this, e);
            }
            else
            {
                SaveData();
                Editor = false;
                EditAction(false);
                if (_UpdateHeight != null)
                    _UpdateHeight.Invoke(sender, e);
            }
        }

        private void SaveData()
        {
            lblDefaultName.Text = txtTbVName.Text;
            var strTitle = txtTbVTitle.Text;
            if (strTitle.Length > 25) { strTitle = strTitle.Substring(0, 22) + "..."; }
            lblDefaultTitle.Text = strTitle;
            lblType.Text = cboType.Texts;
            if (lblType.Text == "Boolean")
                lblDefaultValue.Text = selectValue.Texts;
            else
                lblDefaultValue.Text = txtTbVValue.Text;
            lblDefaultUnit.Text = txtTbVUnit.Text;
            lblDefaultMax.Text = txtTbVMax.Text;
            lblDefaultMin.Text = txtTbVMin.Text;

            lblTypeInput.Text = cboTypeInput.Texts;
            if (_Report) lblDefaultReport.Text = "Yes";
            else lblDefaultReport.Text = "No";
            if (_Required) lblDefaultRequired.Text = "Yes";
            else lblDefaultRequired.Text = "No";

            ResetImageCheck();
        }

        private bool CheckSaveData(out string strError)
        {
            strError = "";
            var result = true;
            var strType = cboType.Texts;
            if (string.IsNullOrEmpty(strType))
            {
                result = false;
                strError = "You need to select a type.";
                return result;
            }
            var strTypeInput = cboTypeInput.Texts;
            if (string.IsNullOrEmpty(strTypeInput))
            {
                result = false;
                strError = "You need to select a TypeInput.";
                return result;
            }
            var strName = txtTbVName.Text;
            if (!ValidateName(strName, "ID", _LstName, 1, 15, out strError)) return false;
            var strTitle = txtTbVTitle.Text;
            if (!ValidateTitle("Name", strTitle, 1, 250, null, out strError)) return false;
            var strValue = txtTbVValue.Text;
            if (strType == "Boolean") strValue = selectValue.Texts;
            var strMin = txtTbVMin.Text;
            var strMax = txtTbVMax.Text;

            return ValidateValue(strTitle, strValue, strMin, strMax, strType, out strError);
        }

        private void lblbtnEdit_Click(object sender, EventArgs e)
        {
            Editor = true;
            EditAction(Editor);
        }

        private void lblCheckItem_Click(object sender, EventArgs e)
        {
            if (_Checked) _Checked = false;
            else _Checked = true;
            ResetImageCheck();
        }

        public void ResetImageCheck()
        {
            if (_Checked)
                chkRow.Image = Properties.Resources.Checked;
            else chkRow.Image = Properties.Resources.NotChecked;


        }
        public void ResetImageRequired()
        {
            if (_Required)
                lblChkRequired.Image = Properties.Resources.Checked;
            else lblChkRequired.Image = Properties.Resources.NotChecked;
        }
        public void ResetImageReport()
        {
            if (_Report)
                lblChkReport.Image = Properties.Resources.Checked;
            else lblChkReport.Image = Properties.Resources.NotChecked;
        }

        public ProcedureVariableViewModel GetData()
        {
            ProcedureVariableViewModel result = new ProcedureVariableViewModel();
            result.ProcedureVariableId = _idVariable;
            result.Name = lblDefaultName.Text;
            result.Title = txtTbVTitle.Text;
            result.Value = lblDefaultValue.Text;
            result.Unit = lblDefaultUnit.Text;
            result.Min = lblDefaultMin.Text;
            result.Max = lblDefaultMax.Text;
            result.Type = lblType.Text;
            result.TypeInput = lblTypeInput.Text;
            if (lblDefaultRequired.Text == "Yes")
                result.Required = true;
            if (lblDefaultReport.Text == "Yes")
                result.Report = true;
            return result;
        }
        private void UpdateControlHeight()
        {
            var Height = 51;
            var heighN = 0;
            Size textSize;
            //Name
            lblDefaultName.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultName.Font,
    new Size(lblDefaultName.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultName.Height = textSize.Height;
            heighN = 29 + lblDefaultName.Height;
            if (heighN > Height) Height = heighN + 0;
            //Title
            lblDefaultTitle.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultTitle.Font,
    new Size(lblDefaultTitle.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultTitle.Height = textSize.Height;
            heighN = 29 + lblDefaultTitle.Height;
            if (heighN > Height) Height = heighN + 0;
            //Value
            lblDefaultValue.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultValue.Font,
    new Size(lblDefaultValue.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultValue.Height = textSize.Height;
            heighN = 29 + lblDefaultValue.Height;
            if (heighN > Height) Height = heighN + 0;
            //Unit
            lblDefaultUnit.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultUnit.Font,
    new Size(lblDefaultUnit.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultUnit.Height = textSize.Height;
            heighN = 29 + lblDefaultUnit.Height;
            if (heighN > Height) Height = heighN + 0;
            //Min
            lblDefaultMin.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultMin.Font,
    new Size(lblDefaultMin.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultMin.Height = textSize.Height;
            heighN = 29 + lblDefaultMin.Height;
            if (heighN > Height) Height = heighN + 0;
            //Max
            lblDefaultMax.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultMax.Font,
    new Size(lblDefaultMax.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultMax.Height = textSize.Height;
            heighN = 29 + lblDefaultMax.Height;
            if (heighN > Height) Height = heighN + 0;
            //Type
            lblType.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblType.Font,
    new Size(lblType.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblType.Height = textSize.Height;
            heighN = 29 + lblType.Height;
            if (heighN > Height) Height = heighN + 0;
            //TypeInput
            lblTypeInput.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblTypeInput.Font,
    new Size(lblTypeInput.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblTypeInput.Height = textSize.Height;
            heighN = 29 + lblTypeInput.Height;
            if (heighN > Height) Height = heighN + 0;
            //Report
            lblDefaultReport.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultReport.Font,
    new Size(lblDefaultReport.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultReport.Height = textSize.Height;
            heighN = 29 + lblDefaultReport.Height;
            if (heighN > Height) Height = heighN + 0;
            //Required
            lblDefaultRequired.Width = 80;
            textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultRequired.Font,
    new Size(lblDefaultRequired.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );
            lblDefaultRequired.Height = textSize.Height;
            heighN = 29 + lblDefaultRequired.Height;
            if (heighN > Height) Height = heighN + 0;
            this.Height = Height;
        }
        private void lblDefaultTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateControlHeight();
            if (_UpdateHeight != null)
                _UpdateHeight.Invoke(sender, e);
        }

        private void lblDefaultValue_TextChanged(object sender, EventArgs e)
        {
            UpdateControlHeight();
            if (_UpdateHeight != null)
                _UpdateHeight.Invoke(sender, e);
        }

        public bool ValidateName(
            string name,
            string title,
            List<string> nameExists,
            int minLength,
            int maxLength,
            out string mess)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                mess = $"{title} is required.";
                return false;
            }

            if (name.Length < minLength || name.Length > maxLength)
            {
                mess = $"{title} must be {minLength}–{maxLength} characters long.";
                return false;
            }

            // Phải bắt đầu bằng chữ cái, các ký tự còn lại chỉ được là A-Z, 0-9 hoặc _
            if (!Regex.IsMatch(name, @"^[A-Za-z][A-Za-z0-9_]*$"))
            {
                mess = $"{title} must start with a letter (A–Z) and can only contain letters (A–Z), numbers (0–9), and underscore (_).";
                return false;
            }

            if (nameExists != null && nameExists.Contains(name))
            {
                mess = $"{title} already exists.";
                return false;
            }

            mess = string.Empty;
            return true;
        }

        public bool ValidateTitle(
     string title,
     string input,
     int minLength,
     int maxLength,
     IEnumerable<string> existingTitles,
     out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = title + " is required.";
                return false;
            }

            input = input.Trim();

            if (input.Length < minLength || input.Length > maxLength)
            {
                errorMessage = $"{title} must be between {minLength} and {maxLength} characters.";
                return false;
            }

            // Cho phép Unicode (tiếng Việt), số, khoảng trắng, - _
            if (!Regex.IsMatch(input, @"^[\p{L}\p{N}\s_\-\.,/\\()&+#]+$"))
            {
                errorMessage = title + " contains invalid characters.";
                return false;
            }

            // Không trùng (không phân biệt hoa thường)
            if (existingTitles != null &&
                existingTitles.Any(t =>
                    string.Equals(t?.Trim(), input, StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = title + " already exists.";
                return false;
            }

            return true;
        }
        public bool ValidateValue(string title, string input, string strmin, string strmax, string type, out string mess1)
        {
            try
            {

                bool check = true;
                double? valuecheck = null;
                double? min = null;
                double? max = null;
                StringBuilder str = new StringBuilder();
                //Integer Double String Boolean
                if (type == "Integer")
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
                else if (type == "Boolean")
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        bool valuep = false;
                        if (!bool.TryParse(input, out valuep))
                        {
                            str.AppendLine(title + " value must be true or false.");
                            check = false;
                        }
                    }
                }
                else if (type == "Float")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                  
                        try
                        {
                            valuecheck = float.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
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
                            min = float.Parse(strmin, System.Globalization.CultureInfo.InvariantCulture);
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
                            max = float.Parse(strmax, System.Globalization.CultureInfo.InvariantCulture);
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
                else if (type == "Ushor")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = ushort.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number from 0 to 65535");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = ushort.Parse(strmin);
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
                            max = ushort.Parse(strmax);
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

        private void lblCheckItem_Click_1(object sender, EventArgs e)
        {
            if (_Checked) _Checked = false;
            else _Checked = true;
            ResetImageCheck();
            _CheckChange?.Invoke(this, EventArgs.Empty);
        }

        private void lblChkRequired_Click(object sender, EventArgs e)
        {
            if (_Required) _Required = false;
            else _Required = true;
            ResetImageRequired();
        }

        private void lblChkReport_Click(object sender, EventArgs e)
        {
            if (_Report) _Report = false;
            else _Report = true;
            ResetImageReport();
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            _DeleteClick?.Invoke(this, EventArgs.Empty);
        }

        private void cboType_SelectedChanged(object sender, EventArgs e)
        {
            var type = cboType.Texts;
            if (type == "Boolean")
            {
                _list = new List<string>() { "True", "False" };
                selectValue.SetData(_list, "Select");
                selectValue.Visible = true;
                txtTbVValue.Visible = false;
            }
            else
            {
                if (type == _typeA && !string.IsNullOrEmpty(_items))
                {
                    var col = _items.Split(',');
                    _list = new List<string>();
                    foreach (var item in col)
                    {
                        _list.Add(item);
                    }
                    selectValue.SetData(_list, "Select");
                    selectValue.Visible = true;
                    txtTbVValue.Visible = false;
                }
                else
                {
                    selectValue.Visible = false;
                    txtTbVValue.Visible = true;
                    txtTbVMax.BringToFront();
                }
            }
        }
    }
}
