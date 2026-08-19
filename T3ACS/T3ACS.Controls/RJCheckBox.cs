using System.ComponentModel;

namespace T3ACS.Controls
{
    public partial class RJCheckBox : UserControl
    {
        public RJCheckBox()
        {
            InitializeComponent();
        }
        public bool _Checked;
        public string _textTrue = "Pass (On)";
        public string _textFalse = "False (Off)";
        private void lblIcon_Click(object sender, EventArgs e)
        {
            ClickChange();
        }

        [Category("RJ Code Advance")]
        public event EventHandler _clickChange;
        private void ClickChange()
        {

            _clickChange?.Invoke(this, new EventArgs());

            //_Checked = !_Checked;
            //SetImage();
        }
        public void SetValue(bool value)
        {
            _Checked = value;
            SetImage();
        }
        public void SetImage()
        {
            //if (_Checked)
            //{
            //    lblIcon.Image = Properties.Resources.Checked;
            //    lblTextContent.Text = _textTrue;
            //}
            //else
            //{
            //    lblIcon.Image = Properties.Resources.NotChecked;
            //    lblTextContent.Text = _textFalse;
            //}

        }
        public void SetValue(bool value, string textTrue, string textFalse)
        {
            _Checked = value;
            if (!string.IsNullOrEmpty(textTrue)) _textTrue = textTrue;
            if (!string.IsNullOrEmpty(textFalse)) _textFalse = textFalse;
            SetImage();
        }

        private void lblTextContent_Click(object sender, EventArgs e)
        {
            ClickChange();
        }

        private void RJCheckBox_Click(object sender, EventArgs e)
        {
            ClickChange();
        }
    }
}
