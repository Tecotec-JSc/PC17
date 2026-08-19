using System.ComponentModel;

namespace T3ACS.Controls.RadioCustoms
{
    public class RelayRadioCustom : Label
    {
        public RelayRadioCustom()
        {
            this.DoubleBuffered = true;
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(40, 20);
            this.Margin = new Padding(0);
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Padding = new Padding(0);
        }
        [Category("Selected Advance")]
        public bool SelectedG
        {
            get { return selected; }
            set
            {
                selected = value;
                ChangeImage();
                Invalidate();
            }
        }
        [Category("Selected Advance")]
        public Image _imageNoSelect { get; set; } = Properties.Resources.RadioNoSelect;
        [Category("Selected Advance")]
        public Image _imageSelect { get; set; } = Properties.Resources.RadioSelected;
        private bool selected;
        public event EventHandler LabelClick;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //selected = !selected;
            ChangeImage();
            LabelClick?.Invoke(this, e);
        }
        private void ChangeImage()
        {
            if (selected) this.Image = _imageSelect;
            else this.Image = _imageNoSelect;
            Invalidate();
        }
        public void CheckImage()
        {
            if (selected) this.Image = _imageSelect;
            else this.Image = _imageNoSelect;
            Invalidate();
        }
    }
}
