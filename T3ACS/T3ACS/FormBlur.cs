namespace T3ACS
{
    public partial class FormBlur : Form
    {
        public FormBlur()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.Opacity = 0.5;  // Độ mờ 50%
            this.ShowInTaskbar = false;
            this.TopMost = false;
        }
    }
}
