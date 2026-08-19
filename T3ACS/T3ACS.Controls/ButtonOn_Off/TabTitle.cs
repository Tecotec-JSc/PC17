using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  T3ACS.Controls
{
    public partial class TabTitle : UserControl
    {
        public TabTitle()
        {
            InitializeComponent();
        }
        public event EventHandler _ChangeSelect;
        public bool _Selected;
        private Color TextSelect= Color.FromArgb(0, 120, 212);
        private Color TextDefault = Color.FromArgb(90, 138, 187);
        int BorderSize = 1;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color BorderColor;
            if (_Selected)
                BorderColor = TextSelect;
            else BorderColor = Color.White;
            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                e.Graphics.DrawLine(
                    pen,
                    0,
                    this.Height - 1,
                    this.Width,
                    this.Height - 1
                );
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            _Selected = !_Selected;
            ChangeImage();
            if (_ChangeSelect != null)
                _ChangeSelect.Invoke(this, e);
        }
        private void ChangeImage()
        {
            if (!_Selected)
                label1.ForeColor = TextDefault;
            else
                label1.ForeColor = TextSelect;
            Invalidate();
        }
        public void SetSelect(bool select)
        {
            _Selected = select;
            ChangeImage();
        }
        [Category("RJ Code Advance")]
        public string TextS
        {
            get
            {

                return label1.Text;

            }
            set
            {
                label1.Text = value;
                updateWidth();
            }
        }
        [Category("RJ Code Advance")]
        public bool SelectedTab
        {
            get
            {

                return _Selected;

            }
            set
            {
                _Selected = value;
                ChangeImage();
            }
        }
        private void updateWidth()
        {
            var texta = label1.Text;
            if (!string.IsNullOrEmpty(texta))
            {
                Size size = TextRenderer.MeasureText(texta, label1.Font);
                label1.Width = size.Width;
                this.Width = 20 + size.Width;
            }
            else
            {
                label1.Width = 0;
                this.Width = 22 + 0;
            }

            Invalidate();
        }
    }
}
