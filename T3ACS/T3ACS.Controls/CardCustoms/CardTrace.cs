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

namespace T3ACS.Controls.CardCustoms
{
    public partial class CardTrace : UserControl
    {
        public CardTrace()
        {
            InitializeComponent();         
            this.DoubleBuffered = true;
            AddClickEvent(this);
        }
        #region border
        [Category("Border Advance")]
        public int RadiusTopLeft { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusTopRight { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusBottomLeft { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusBottomRight { get; set; } = 5;
        [Category("Border Advance")]
        public Color BorderColor { get; set; } = Color.DarkGray;
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColor;
            if (selected) colorDraWBorder = selectedBorderColor;
            using (Pen borderPen = new Pen(colorDraWBorder, BorderSize))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, path);
            }
        }
        private GraphicsPath GetPath(Rectangle r)
        {
            int tl = RadiusTopLeft;
            int tr = RadiusTopRight;
            int bl = RadiusBottomLeft;
            int br = RadiusBottomRight;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            // Top left
            if (tl > 0)
                path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(r.X, r.Y, r.X, r.Y);

            // Top
            path.AddLine(r.X + tl, r.Y, r.Right - tr, r.Y);

            // Top right
            if (tr > 0)
                path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90);

            // Right
            path.AddLine(r.Right, r.Y + tr, r.Right, r.Bottom - br);

            // Bottom right
            if (br > 0)
                path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90);

            // Bottom
            path.AddLine(r.Right - br, r.Bottom, r.X + bl, r.Bottom);

            // Bottom left
            if (bl > 0)
                path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            // Left
            path.AddLine(r.X, r.Bottom - bl, r.X, r.Y + tl);

            path.CloseFigure();

            return path;
        }
        #endregion
        #region hover control
        // hover 
        private Color originalColor;

        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                originalColor = item.BackColor;
                item.BackColor = DarkerColor(originalColor, 0.90f);
            }
        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                if (originalColor != null)
                    item.BackColor = originalColor;
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
        #region Highlight Selected
        private Color selectedBorderColor = Color.FromArgb(241, 89, 42);
        [Category("Selected Advance")]
        public Color SelectedBorderColor
        {
            get { return selectedBorderColor; }
            set
            {
                selectedBorderColor = value;
                if (selected)
                    lblMarkerTitle.ForeColor = value;
                else lblMarkerTitle.ForeColor = this.ForeColor ;
                Invalidate();
            }
        }
        [Category("Selected Advance")]
        public bool SelectedG
        {
            get { return selected; }
            set
            {
                selected = value;
                Invalidate();
            }
        }
        private bool selected;
        #endregion
        public int _ChannelId;
        public int _TraceId;
        public void SetValue(int channel, int traceId, string sparameter)
        {
            _ChannelId = channel;
            _TraceId = traceId;
            lblMarkerTitle.Text = sparameter;
            lblTraceId.Text = "Trace " + traceId;
            lblChannelId.Text = "CH " + channel;
            lblStatus.Text = "Actice";

        }
        private void AddClickEvent(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control ctl in parent.Controls)
            {
                ctl.Click += (s, e) => CardTrace_DoubleClick(s,e);
                AddClickEvent(ctl);
            }
        }

        public void ChangeSelect(bool value)
        {
            SelectedG = value;
            changeSelect();
        }

        private void CardTrace_DoubleClick(object sender, EventArgs e)
        {          
            SelectTrace();
        }
        public event EventHandler _EventSelectTrace;
        private void SelectTrace()
        {
            if (!SelectedG)
            {
                SelectedG = true;
                changeSelect();
                _EventSelectTrace?.Invoke(this, EventArgs.Empty);
            }
      
        }
        private void changeSelect()
        {
            Invalidate();
            if (!selected)
            {
                lblIconStatus.Image = Properties.Resources.iconActive;
                lblMarkerTitle.ForeColor = this.ForeColor;
            }
            else
            {
                lblIconStatus.Image = Properties.Resources.iconActiveSelected;
                lblMarkerTitle.ForeColor = selectedBorderColor;
            }
          
        }
    }
}
