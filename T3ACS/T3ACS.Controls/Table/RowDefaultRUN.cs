using System.ComponentModel;
using System.Text;
using T3ACS.Model;

namespace T3ACS.Controls
{
    public partial class RowDefaultRUN : UserControl
    {
        public string _range;
        public string _inputType;
        public bool _Required, _Report;
        public int _no;
        public string _displayName;
        public string _typeInput;

        public RowDefaultRUN()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public string MeasuredValue
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MeasuredRange
        {
            get => "";
            set { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TargetValue
        {
            get => "";
            set { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TargetRange
        {
            get => "";
            set { }
        }

        public void LoadData(int no, string displayName, string value, string unit, string range, string type, string typeInput, bool required, bool report)
        {
            _range = range;         
            _inputType = type;
            _Required = required;
            _Report = report;
            _no = no;
            _displayName = displayName;
            _typeInput = typeInput;
            if (typeInput!=null&&typeInput.ToLower().Contains("input"))
            {
                lblValue.Visible = false;
                txtValue.Visible = true;
                txtValue.Text = value;
            }
            else
            {
                lblValue.Visible = true;
                txtValue.Visible = false;
                lblValue.Text = value;
            }
            lblNo.Text = no.ToString();
            lblTitle.Text = displayName;
            lblUnit.Text = unit;
           
            lblMin.Text = range;       
            lblType.Text = type;
            lblTypeImport.Text = typeInput;
            lblRequired.Text = required ? "YES" : "NO";
            lblReport.Text = report ? "YES" : "NO";

            // Configure colors and styles based on row index (even/odd)
            if (no % 2 == 0)
            {
                this.BackColor = Color.FromArgb(6, 16, 20);

                lblNo.ForeColor = Color.White;       
                lblTitle.ForeColor = Color.White;
                lblUnit.ForeColor = Color.White;
                lblMin.ForeColor = Color.White;     
                lblType.ForeColor = Color.White;
                lblTypeImport.ForeColor = Color.White;
                lblRequired.ForeColor = Color.White;
                lblReport.ForeColor = Color.White;
                txtValue.BackColor = Color.FromArgb(6, 16, 20);
                txtValue.BorderColor = Color.FromArgb(14, 82, 98); // Blue border for dark rows
                txtValue.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(15, 32, 39);

                lblNo.ForeColor = Color.White;         
                lblTitle.ForeColor = Color.White;
                lblUnit.ForeColor = Color.White;
                lblMin.ForeColor = Color.White;            
                lblType.ForeColor = Color.White;
                lblTypeImport.ForeColor = Color.White;
                lblRequired.ForeColor = Color.White;
                lblReport.ForeColor = Color.White;
                txtValue.BackColor = Color.FromArgb(6, 16, 20);
                txtValue.BorderColor = Color.FromArgb(14, 82, 98); // Blue border for dark rows
                txtValue.ForeColor = Color.White;
            }

            this.Invalidate();
        }

        public ProcedureVariableViewModel GetData()
        {
            ProcedureVariableViewModel result = new ProcedureVariableViewModel();       
            result.Title = lblTitle.Text;
            if(lblTypeImport.Text == "Input") result.Value=txtValue.Text;
            else 
            result.Value = lblValue.Text;
            result.Unit = lblUnit.Text;
            result.Min = lblMin.Text;
      
            result.Type = _inputType;
            result.TypeInput = lblTypeImport.Text;
            result.Required = _Required;
            result.Report = _Report;
            return result;
        }

        public bool ValidateInput(out string errorMessage)
        {
            errorMessage = "";
            if (_Required && string.IsNullOrWhiteSpace(txtValue.Text))
            {
                errorMessage = $"{lblTitle.Text} is required.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtValue.Text))
            {
                string min = "";
                string max = "";
                if (!string.IsNullOrEmpty(_range)&&_range!="N/A")
                {
                    var col= _range.Split("to");
                    min = col[0];
                    if(col.Length > 1)
                    {
                        max = col[1];
                    }
                }
                return ValidateValue(lblTitle.Text, txtValue.Text, min, max, _inputType, out errorMessage);
            }

            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_no % 2 == 0) // Even row (No = 2, 4, 6...): bottom border 1px solid Color.FromArgb(15, 32, 39)
            {
                using (SolidBrush borderBrush = new SolidBrush(Color.FromArgb(15, 32, 39)))
                {
                    e.Graphics.FillRectangle(borderBrush, 0, this.Height - 1, this.Width, 1);
                }
            }
        }

        private bool ValidateValue(string title, string input, string strmin, string strmax, string type, out string mess1)
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
