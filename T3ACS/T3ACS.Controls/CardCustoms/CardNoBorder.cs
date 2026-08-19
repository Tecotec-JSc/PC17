using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3
{
    public partial class CardNoBorder : UserControl
    {
        public CardNoBorder()
        {
            InitializeComponent();
            originalColor = this.BackColor;
            this.MouseEnter += UserControl_MouseEnter;
            this.MouseLeave += UserControl_MouseLeave;
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
    }
}
