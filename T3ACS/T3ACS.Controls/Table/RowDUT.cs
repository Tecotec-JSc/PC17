using T3ACS.Model;
using System.Text;

namespace T3ACS.Controls
{
    public partial class RowDUT : UserControl
    {
        public RowDUT()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public int _idVariable;
        public int _no;
        public string _name = "";
        public string _title = "";
        public string _value = "";
        public string _unit = "";
        public string _min = "";
        public string _max = "";
        public string _type = "";
        public string _typeInput = "";
        public bool _Required;
        public bool _Report;

        public bool Editor;
        public string _StrError = "";

        public event EventHandler _SaveClick;
        public event EventHandler _DeleteClick;
        public event EventHandler _UpdateHeight;
        public event EventHandler _CheckChange;
        /// <summary>Fired khi user thay Ä‘á»•i ná»™i dung textbox (Name/Title/Value) trong lÃºc Edit mode</summary>
        public event EventHandler _TextChanged;

        public void LoadData(int no, int id, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report, bool edit)
        {
            _no = no;
            _idVariable = id;
            _name = name;
            _title = title;
            _value = value;
            _unit = unit;
            _min = min;
            _max = max;
            _type = type;
            _typeInput = typeInput;
            _Required = required;
            _Report = report;

            lblNo.Text = no.ToString();

            lblDefaultName.Text = name;
            txtTbVName.Text = name;

            lblDefaultTitle.Text = title;
            txtTbVTitle.Text = title;

            lblDefaultValue.Text = value;
            txtTbVValue.Text = value;

            lblUnit.Text = unit;
            lblMin.Text = min;
            lblMax.Text = max;
            lblType.Text = type;
            lblTypeInput.Text = typeInput;
            lblRequired.Text = required ? "YES" : "NO";
            chkReport.Checked = report;

            Editor = edit;
            EditAction(edit);

            // Configure colors based on row index (odd/even)
            if (no % 2 != 0) // Odd rows: darker Color.FromArgb(6, 16, 20)
            {
                this.BackColor = Color.FromArgb(6, 16, 20);
            }
            else // Even rows: lighter Color.FromArgb(15, 32, 39)
            {
                this.BackColor = Color.FromArgb(15, 32, 39);
            }

            panelBorderRadiusCustom1.BackColor = this.BackColor;
            panelBorderRadiusCustom1.BackColorG = this.BackColor;
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(14, 82, 98); // Matches the border line color of rows

            SetRowColors(Color.White, Color.FromArgb(153, 166, 184));
        }

        private void SetRowColors(Color mainColor, Color secondaryColor)
        {
            lblNo.ForeColor = mainColor;
            lblDefaultName.ForeColor = mainColor;
            lblDefaultTitle.ForeColor = mainColor;
            lblDefaultValue.ForeColor = mainColor;
            lblUnit.ForeColor = mainColor;
            lblMin.ForeColor = mainColor;
            lblMax.ForeColor = mainColor;
            lblType.ForeColor = mainColor;
            lblTypeInput.ForeColor = mainColor;
            lblRequired.ForeColor = mainColor;

            // Set TextBox styles
            txtTbVName.BackColor = this.BackColor;
            txtTbVName.ForeColor = mainColor;
            txtTbVName.BorderColor = Color.FromArgb(14, 82, 98);

            txtTbVTitle.BackColor = this.BackColor;
            txtTbVTitle.ForeColor = mainColor;
            txtTbVTitle.BorderColor = Color.FromArgb(14, 82, 98);

            txtTbVValue.BackColor = this.BackColor;
            txtTbVValue.ForeColor = mainColor;
            txtTbVValue.BorderColor = Color.FromArgb(14, 82, 98);
        }

        private void EditAction(bool edit)
        {
            txtTbVName.Visible = edit;
            txtTbVTitle.Visible = edit;
            txtTbVValue.Visible = edit;

            lblDefaultName.Visible = !edit;
            lblDefaultTitle.Visible = !edit;
            lblDefaultValue.Visible = !edit;

            lblbtnEdit.Visible = !edit;
            lblbtnSave.Visible = edit;

            if (edit)
            {
                // Subscribe textbox Leave Ä‘á»ƒ fire _TextChanged khi user rá»i Ã´
                txtTbVName.Leave += TextBox_LeaveOrChanged;
                txtTbVTitle.Leave += TextBox_LeaveOrChanged;
                txtTbVValue.Leave += TextBox_LeaveOrChanged;
            }
            else
            {
                txtTbVName.Leave -= TextBox_LeaveOrChanged;
                txtTbVTitle.Leave -= TextBox_LeaveOrChanged;
                txtTbVValue.Leave -= TextBox_LeaveOrChanged;
            }
        }

        private void TextBox_LeaveOrChanged(object sender, EventArgs e)
        {
            _TextChanged?.Invoke(this, EventArgs.Empty);
        }

        private void lblbtnSave_Click(object sender, EventArgs e)
        {
            if (CheckSaveData(out string error))
            {
                SaveData();
                Editor = false;
                EditAction(false);
                _StrError = "";
                _SaveClick?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                _StrError = error;
                _SaveClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SaveData()
        {
            _name = txtTbVName.Text;
            _title = txtTbVTitle.Text;
            _value = txtTbVValue.Text;

            lblDefaultName.Text = _name;
            lblDefaultTitle.Text = _title;
            lblDefaultValue.Text = _value;
        }

        private bool CheckSaveData(out string strError)
        {
            strError = "";
            var strName = txtTbVName.Text;
            if (string.IsNullOrWhiteSpace(strName))
            {
                strError = "Name is required.";
                return false;
            }

            var strTitle = txtTbVTitle.Text;
            if (string.IsNullOrWhiteSpace(strTitle))
            {
                strError = "Title is required.";
                return false;
            }

            var strValue = txtTbVValue.Text;
            return ValidateValue(strTitle, strValue, _min, _max, _type, out strError);
        }

        private void lblbtnEdit_Click(object sender, EventArgs e)
        {
            Editor = true;
            EditAction(Editor);
        }

        public ProcedureVariableViewModel GetData()
        {
            ProcedureVariableViewModel result = new ProcedureVariableViewModel();
            result.ProcedureVariableId = _idVariable;
            // Khi Ä‘ang á»Ÿ edit mode, Ä‘á»c tháº³ng tá»« textbox Ä‘á»ƒ khÃ´ng máº¥t dá»¯ liá»‡u
            // ngay cáº£ khi user chÆ°a nháº¥n nÃºt âœ“ Save cá»§a row
            result.Name = Editor ? txtTbVName.Text : lblDefaultName.Text;
            result.Title = Editor ? txtTbVTitle.Text : lblDefaultTitle.Text;
            result.Value = Editor ? txtTbVValue.Text : lblDefaultValue.Text;
            result.Unit = lblUnit.Text;
            result.Min = lblMin.Text;
            result.Max = lblMax.Text;
            result.Type = _type;
            result.TypeInput = lblTypeInput.Text;
            result.Required = _Required;
            result.Report = chkReport.Checked;
            return result;
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

                if (type == "Integer" || type == "Interger")
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                  
                        try
                        {
                            valuecheck = int.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be an integer");
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
                            str.AppendLine(title + " min must be an integer");
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
                            str.AppendLine(title + " max must be an integer");
                            check = false;
                        }
                    }
                    if (min != 0 || max != 0)
                    {
                        if (min != null && max != null && min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
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

                }
                else if (type == "Double" || type == "Float")
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
                            str.AppendLine(title + " min must be a number");
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
                    if (min != 0 || max != 0)
                    {
                        if (min != null && max != null && min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
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
                            str.AppendLine(title + " min must be a number");
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
                    if (min != null && max != null && min > max)
                    {
                        str.AppendLine(title + " min must be less than Max");
                        check = false;
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

        public void Checked(bool check)
        {
            chkReport.Checked = check;
            _Report = check;
        }

        private void chkReport_CheckedChanged(object sender, EventArgs e)
        {
            _Report = chkReport.Checked;
            _CheckChange?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_no % 2 == 0) // Even row: bottom border 1px solid Color.FromArgb(15, 32, 39)
            {
                using (SolidBrush borderBrush = new SolidBrush(Color.FromArgb(15, 32, 39)))
                {
                    e.Graphics.FillRectangle(borderBrush, 0, this.Height - 1, this.Width, 1);
                }
            }
        }
    }
}
