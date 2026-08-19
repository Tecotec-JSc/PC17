using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls.CardCustoms
{
    public partial class CardTitleCollape : UserControl
    {
        public CardTitleCollape()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            originalColor = this.BackColor;
            originalForceColor = this.ForeColor;
            HighlightColor = Color.FromArgb(49, 102, 156);
            this.MouseEnter += UserControl_MouseEnter;
            this.MouseLeave += UserControl_MouseLeave;
            label1.MouseEnter += UserControl_MouseEnter;
            label1.MouseLeave += UserControl_MouseLeave;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        public bool _Select;
        // hover 
        private Color originalColor;
        public Color HighlightColor;
        private Color originalForceColor;
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (!_Select)
            {
                this.BackColor = DarkerColor(originalColor, 0.90f); // giảm 15%
                label1.BackColor = DarkerColor(originalColor, 0.90f);
            }

        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (!_Select)
            {
                this.BackColor = originalColor;
                label1.BackColor = originalColor;
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
        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                return label1.Text;

            }
            set
            {
                label1.Text = value;
            }
        }
        public event EventHandler _EventSelect;
        private void label1_Click(object sender, EventArgs e)
        {
            ChangeSelectCard(!_Select);
            if (_EventSelect != null)
                _EventSelect.Invoke(this, e);
        }
        public void ChangeSelectCard(bool select)
        {
            _Select = select;
            ReloadCard();
        }
        private void ReloadCard()
        {
            if (_Select)
            {
                this.BackColor = HighlightColor;
                label2.Image = Properties.Resources.iconCollape;
                label1.ForeColor = Color.White;
                label1.BackColor = HighlightColor;
            }
            else
            {
                this.BackColor = originalColor;
                label1.BackColor = originalColor;
                label2.Image = Properties.Resources.iconSpan;
                label1.ForeColor = originalForceColor;
            }
        }








        public bool BorderTop { get; set; } = true;
        public bool BorderBottom { get; set; } = false;
        public bool BorderLeft { get; set; } = false;
        public bool BorderRight { get; set; } = false;

        public Color BorderColor { get; set; } = Color.DarkGray;
        public int BorderSize { get; set; } = 1;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                if (BorderTop)
                    e.Graphics.DrawLine(pen, 0, 0, Width - 1, 0);

                if (BorderBottom)
                    e.Graphics.DrawLine(pen, 0, Height - 1, Width - 1, Height - 1);

                if (BorderLeft)
                    e.Graphics.DrawLine(pen, 0, 0, 0, Height - 1);

                if (BorderRight)
                    e.Graphics.DrawLine(pen, Width - 1, 0, Width - 1, Height - 1);
            }
        }
    }
}
