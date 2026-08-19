using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace T3ACS.Controls.CardCustoms
{
    public partial class CardTitle : UserControl
    {
        public CardTitle()
        {
            InitializeComponent();
 
            originalColor = this.BackColor;          
            label1.MouseEnter += UserControl_MouseEnter;
            label1.MouseLeave += UserControl_MouseLeave;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        // hover 
        private Color originalColor;
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {

            this.BackColor = DarkerColor(originalColor, 0.90f); // giảm 15%
            label1.BackColor = DarkerColor(originalColor, 0.90f);
        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {

            this.BackColor = originalColor;
            label1.BackColor = originalColor;
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
            if (_EventSelect != null)
                _EventSelect.Invoke(this, e);
        }


        public bool BorderTop { get; set; } = true;
        public bool BorderBottom { get; set; } = true;
        public bool BorderLeft { get; set; } = true;
        public bool BorderRight { get; set; } = true;

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
