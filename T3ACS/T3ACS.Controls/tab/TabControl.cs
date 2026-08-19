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
using System.Xml;
using T3.Configuration;

namespace T3ACS.Controls.tab
{
    public partial class TabControl : UserControl
    {
        public void ApplyTheme(ThemeViewModel themeDefault, ThemeViewModel theme)
        {
            //BackColorG = GetColorBy(BackColorG, 0, themeDefault, theme);
            //BackColor = GetColorBy(BackColor, 0, themeDefault, theme);
            //BorderColorG = GetColorBy(BorderColorG, 2, themeDefault, theme);
            //HoverColor = GetColorBy(HoverColor, 3, themeDefault, theme);
            //ForeColorG = GetColorBy(ForeColorG, 1, themeDefault, theme);
            //var imag = GetImageBy(this.Name, theme);
            //if (imag != null) ImageAd = imag;
            Invalidate();
        }
        public TabControl()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ShowBottomLine)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(BottomLineColor, BottomLineSize))
            {
                pen.Alignment = PenAlignment.Inset;

                int y = ClientSize.Height - BottomLineSize;

                g.DrawLine(
                    pen,
                    0,
                    y,
                    ClientSize.Width - 1,
                    y);
            }
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
        [Category("Code Advance")]
        public Color ForeColorG { get { return foreColor; } set { foreColor = value; } }
        public Color foreColor;
        public Color foreColorNoSelect;
        [Category("Code Advance")]
        public Font FontG { get { return label1.Font; } set { label1.Font = value; } }

        [Category("Code Advance")]
        public Color ForeColorNoSelect { get { return foreColorNoSelect; } set { foreColorNoSelect = value; } }
        [Category("Code Advance")]
        public Color BackColorG
        {
            get { return backColor; }
            set
            {
                backColor = value;
                label1.BackColor = backColor;
                Invalidate();
            }
        }
        private Color backColor = Color.White;
        [Category("Border Advance")]
        public Color BottomLineColor { get; set; } = Color.Empty;

        [Category("Border Advance")]
        public int BottomLineSize { get; set; } = 1;
        [Category("Code Advance")]
        public Point TextLocation
        {
            get { return label1.Location; }
            set
            {
                label1.Location = value;
                label1.Width = this.Width - value.X - 6;
            }
        }
        [Category("Appearance")]
        public bool ShowBottomLine
        {
            get
            {
                return showBottomLine;
            }
            set
            {
                showBottomLine = value;
                if (value) label1.ForeColor = foreColor;
                else label1.ForeColor = foreColorNoSelect;
                Invalidate();
            }

        }
        private bool showBottomLine;

        private void label1_Click(object sender, EventArgs e)
        {      
            this.OnClick(e);
        }
        #region hover    
        public bool HoverG { get { return hovered; } set { hovered = value; } }
        private Color originalColor;
        private bool hoverNow;
        private bool hovered;
        public Color HoverColor { get; set; }
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (!hovered)
            {
                hovered = true;
                //  this.BackColor = DarkerColor(backColor, 0.85f);
                this.BackColor = DarkerColor(backColor, 0.85f); // giảm 15%
                label1.BackColor = DarkerColor(backColor, 0.85f); // giảm 15%

                Invalidate();
            }

        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hovered = false;
                this.BackColor = backColor;
                label1.BackColor = backColor;    
                Invalidate();
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
    }
}
