using T3ACS.Model;

namespace T3ACS.Controls
{
    public partial class RowReview : UserControl
    {
        public RowReview()
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

        public event EventHandler _CheckChange;

        public void LoadData(int no, int id, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report)
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
            lblDefaultTitle.Text = title;
            lblDefaultValue.Text = value;
            lblUnit.Text = unit;
            lblMin.Text = min;
            lblMax.Text = max;
            lblType.Text = type;
            lblTypeInput.Text = typeInput;
            lblRequired.Text = required ? "YES" : "NO";
            chkReport.Checked = report;

            if (no % 2 != 0)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 247, 250);
            }

            panelBorderRadiusCustom1.BackColor = this.BackColor;
            panelBorderRadiusCustom1.BackColorG = this.BackColor;
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(220, 224, 230);

            SetRowColors(Color.Black, Color.FromArgb(100, 100, 110));
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
        }

        public ProcedureVariableViewModel GetData()
        {
            ProcedureVariableViewModel result = new ProcedureVariableViewModel();
            result.ProcedureVariableId = _idVariable;
            result.Name = lblDefaultName.Text;
            result.Title = lblDefaultTitle.Text;
            result.Value = lblDefaultValue.Text;
            result.Unit = lblUnit.Text;
            result.Min = lblMin.Text;
            result.Max = lblMax.Text;
            result.Type = _type;
            result.TypeInput = lblTypeInput.Text;
            result.Required = _Required;
            result.Report = chkReport.Checked;
            return result;
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
            if (_no % 2 == 0)
            {
                using (SolidBrush borderBrush = new SolidBrush(Color.FromArgb(220, 224, 230)))
                {
                    e.Graphics.FillRectangle(borderBrush, 0, this.Height - 1, this.Width, 1);
                }
            }
        }
    }
}
