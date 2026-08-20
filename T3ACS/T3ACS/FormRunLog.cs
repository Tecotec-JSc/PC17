namespace T3ACS
{
    public partial class FormRunLog : Form
    {
        public FormRunLog()
        {
            InitializeComponent();
        }

        #region hover control
        private Color _originalColor;
        public bool _hover;

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                _originalColor = item.BackColor;
                item.BackColor = DarkerColor(_originalColor, 0.90f);
            }
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                item.BackColor = _originalColor;
            }
        }

        private Color DarkerColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }
        #endregion

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportReport_btnClick(object sender, EventArgs e)
        {
        }
    }
}
