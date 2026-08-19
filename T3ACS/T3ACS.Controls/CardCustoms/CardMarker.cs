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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T3ACS.Controls
{
    public partial class CardMarker : UserControl
    {
        public event Action<int> OnRemoveMarker;
        public CardMarker()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
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
        public int _ChannelId;
        public int _TraceId;
        public int _markerId;
        public void SetValue(int channel, int traceId, int markerId, string MarkerTitle, string point, string value)
        {
            _ChannelId = channel;
            _TraceId = traceId;
            _markerId = markerId;
            if (lblMarkerTitle.IsHandleCreated)
                lblMarkerTitle.BeginInvoke(new Action(() =>
            {
                lblMarkerTitle.Text = MarkerTitle;
            }));
            if (lblPosition.IsHandleCreated)
                lblPosition.BeginInvoke(new Action(() =>
            {
                lblPosition.Text = point;
            }));
            if (lblValue.IsHandleCreated)
            {
                lblValue.BeginInvoke(new Action(() =>
                {
                    lblValue.Text = value;
                }));
            }
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
                Invalidate();
            }
        }
        [Category("Selected Advance")]
        public bool SelectedG { get { return selected; } set { selected = value;
                Invalidate();
            } }
        private bool selected;
        #endregion
        public event EventHandler _EventRemove;
        public event EventHandler _EventSelect;
        private void lblClose_Click(object sender, EventArgs e)
        {
            _EventRemove?.Invoke(this, EventArgs.Empty);
        }
        public void SetValue(int channel, int traceId, string traceTitle, string point, string value)
        {
            _ChannelId = channel;
            _TraceId = traceId;
            lblMarkerTitle.Text = traceTitle;
            lblPosition.Text = point;
            lblValue.Text = value;
        }
        private void CardMarker_Click(object sender, EventArgs e)
        {
            Selected();
        }
        public void SetSeleted(bool selected)
        {
            SelectedG = selected;
            if (selected)
            {
                lblMarkerTitle.ForeColor = selectedBorderColor;
            }
            else
            {
                lblMarkerTitle.ForeColor = this.ForeColor;
            }
        }
        private void Selected()
        {
            
            if (!SelectedG)
            {
                
                SetSeleted(true);
              
                _EventSelect?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
