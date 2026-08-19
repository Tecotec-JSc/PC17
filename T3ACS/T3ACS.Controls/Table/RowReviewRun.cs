namespace T3ACS.Controls
{
    public partial class RowReviewRun : UserControl
    {
        public int _no;
        public string _title = "";
        public string _value = "";
        public string _unit = "";
        public string _range = "";

        public RowReviewRun()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void LoadData(int no, string title, string value, string unit, string range)
        {
            _no = no;
            _title = title;
            _value = value;
            _unit = unit;
            _range = range;

            lblNo.Text = no.ToString();
            lblTitle.Text = title;
            lblValue.Text = value;
            lblUnit.Text = unit;
            lblRange.Text = range;

            // Configure colors based on row index (odd/even)
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
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(220, 224, 230); // Matches row border line

            SetRowColors(Color.Black);
        }

        private void SetRowColors(Color mainColor)
        {
            lblNo.ForeColor = mainColor;
            lblTitle.ForeColor = mainColor;
            lblValue.ForeColor = mainColor;
            lblUnit.ForeColor = mainColor;
            lblRange.ForeColor = mainColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_no % 2 == 0) // Even row: bottom border 1px solid Color.FromArgb(220, 224, 230)
            {
                using (SolidBrush borderBrush = new SolidBrush(Color.FromArgb(220, 224, 230)))
                {
                    e.Graphics.FillRectangle(borderBrush, 0, this.Height - 1, this.Width, 1);
                }
            }
        }
    }
}
