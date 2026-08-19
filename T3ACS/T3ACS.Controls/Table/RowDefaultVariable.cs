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
using T3ACS.Controls.PanelCustoms;

namespace T3ACS.Controls
{
    public partial class RowDefaultVariable : UserControl
    {
        public RowDefaultVariable()
        {
            InitializeComponent();
        }
        private void RowDefaultVariable_Load(object sender, EventArgs e)
        {

        }
        public List<string> _LstName;
        public int _idVariable; 
        public event EventHandler _SaveClick;
        public event EventHandler _DeleteClick;
        public event EventHandler _UpdateHeight;
        public event EventHandler _CheckChange;
        public bool Editor;
        public bool  _Required, _Report;
        public bool _ValidateData;
        public string _StrError;
        List<string> _list;
        public string GetName()
        {
            return lblDefaultName.Text;
        }
        public string _items;
        public string _typeA;
        public void LoadData( int id, string name, string title, string value,string items, string unit, string min, string max, string type, string typeInput, bool required, bool report, bool edit)
        {
         
            _idVariable = id;
            lblNo.Text = id.ToString();
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
                selectValue.SetData(_list,"Select");
                if(_list.Contains(value)) selectValue.Texts = value;
                selectValue.Visible = edit;
                txtTbVName.Visible = false;
            }
            else
            {
                selectValue.Visible= false;
                txtTbVName.Visible= edit;
            }
            if (type == "Boolean")
            {
                _list = new List<string>() { "True", "False" };
                selectValue.SetData(_list, "Select");
                if (_list.Contains(value)) selectValue.Texts = value;
                selectValue.Visible = true;
                txtTbVName.Visible = false;
            }
            lblDefaultName.Text = name;
            txtTbVName.Text = name;
            var strtitle = title + "";
            if (strtitle.Length > 25) strtitle = title.Substring(0, 22) + "...";
            lblDefaultTitle.Text = strtitle;
            txtTbVTitle.Text = title;
            lblDefaultValue.Text = value;
            txtTbVValue.Text = value;
            lblDefaultUnit.Text = unit;          
            lblDefaultMin.Text = min;        
            lblDefaultMax.Text = max;        
            _Required = required;
            _Report = report;

            if (required)
                lblDefaultRequired.Text = "Yes";
            else lblDefaultRequired.Text = "No";
            if (report) lblDefaultReport.Text = "Yes";
            else lblDefaultReport.Text = "No";
            lblType.Text = type;           
            lblTypeInput.Text = typeInput;        
            Editor = edit;
            EditAction(edit);  
            ResetImageReport();
        }

        public void ChangeBackColor(Color cl)
        {
            this.BackColor = cl;
            panelBorderControl1.BackColor = cl;
            foreach (Control c in panelBorderControl1.Controls)
            {
                c.BackColor = cl;
            }
        }
        private void EditAction(bool edit)
        {
            if (_typeA == "Boolean"||!string.IsNullOrEmpty(_items))
            {
                txtTbVValue.Visible = false;
                selectValue.Visible = edit;
            }
            else 
            {
                txtTbVValue.Visible = edit;
                selectValue.Visible = false;
            }
            txtTbVTitle.Visible = edit;
        
            txtTbVName.Visible = edit;
            lblChkReport.Visible = edit;           
            lblDefaultName.Visible = !edit;
            lblDefaultTitle.Visible = !edit;
            lblDefaultValue.Visible = !edit;
            //lblDefaultUnit.Visible = !edit;
            //lblDefaultMin.Visible = !edit;
            //lblDefaultMax.Visible = !edit;
            lblDefaultReport.Visible = !edit;
            //lblDefaultRequired.Visible = !edit;
            //lblType.Visible = !edit;
            //lblTypeInput.Visible = !edit;
            lblbtnEdit.Visible = !edit;
            lblbtnSave.Visible = edit;
        }
        private void lblbtnSave_Click(object sender, EventArgs e)
        {
            var vals = CheckSaveData(out string error);
            {
                _StrError = error;
                if (_SaveClick != null)
                    _SaveClick.Invoke(this, e);
            }
            if (vals)
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
            var strTitle= txtTbVTitle.Text;
            if(strTitle.Length > 25) { strTitle = strTitle.Substring(0, 22) + "..."; }
            lblDefaultTitle.Text = strTitle;
            if (txtTbVValue.Visible)
                lblDefaultValue.Text = txtTbVValue.Text;
            else if (selectValue.Visible)
                lblDefaultValue.Text = selectValue.Texts;
            if (!string.IsNullOrEmpty(_items)) lblDefaultValue.Text = selectValue.Texts;
            if (_Report) lblDefaultReport.Text = "Yes";
            else lblDefaultReport.Text = "No";
            if (_Required) lblDefaultRequired.Text = "Yes";
            else lblDefaultRequired.Text = "No";      
        }
        private bool CheckSaveData(out string strError)
        {
            strError = "";
            var result = true;
            var strName = txtTbVName.Text;
            result = ValidateName(strName, "ID", _LstName, 1, 15, out strError);
            if (!result) return result;
            var strTitle = txtTbVTitle.Text;
            result = ValidateTitle("Name", strTitle, 1, 100, null, out strError); if (!result) return result;
            var strValue = txtTbVValue.Text;
            if (!string.IsNullOrEmpty(_items)) strValue = selectValue.Texts;
            var strMin = lblDefaultMin.Text;
            var strMax = lblDefaultMax.Text;
            var strType =lblType.Text;
            result = ValidateValue(strTitle, strValue, strMin, strMax, strType, out strError);
            return result;
        }
        private void lblbtnEdit_Click(object sender, EventArgs e)
        {
            Editor = true;
            EditAction(Editor);
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
            //result.ProcedureVariableId = _idVariable;
            result.Name = lblDefaultName.Text;
            result.Title = txtTbVTitle.Text;
            result.Value = lblDefaultValue.Text;
            result.Items = _items;
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
                else if (type == "Boolean")
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        bool valuep = false;
                        if (!bool.TryParse(input, out valuep))
                        {
                            str.AppendLine(title + " value must be true or false.");
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
                else if (type == "Ushort")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = ushort.Parse(input);
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
    }
}
