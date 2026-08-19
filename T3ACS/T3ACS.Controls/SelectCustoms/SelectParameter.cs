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

namespace T3ACS.Controls.SelectCustoms
{
    public partial class SelectParameter : UserControl
    {
        public SelectParameter()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
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
        public Color BorderColorG { get; set; } = Color.DarkGray;
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColorG;
            //if (selected) colorDraWBorder = selectedBorderColor;
            var backcolorfill = backColor;
            if (hovered) backcolorfill = DarkerColor(backColor, 0.85f);
            using (SolidBrush brush = new SolidBrush(backcolorfill))
            {

                g.FillPath(brush, path);
            }
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
        [Category("Code Advance")]
        public Color BackColorG
        {
            get { return backColor; }
            set
            {
                backColor = value;
                lblIcon.BackColor = backColor;
                lblText.BackColor = backColor;
                Invalidate();
            }
        }
        private Color backColor = Color.White;

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
                lblIcon.BackColor = DarkerColor(backColor, 0.85f); // giảm 15%
                lblText.BackColor = DarkerColor(backColor, 0.85f); // giảm 15%

                Invalidate();
            }

        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hovered = false;
                //    this.BackColor = backColor;
                lblIcon.BackColor = backColor;
                lblText.BackColor = backColor;

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
        #region Properties
        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
        public event EventHandler _EventSelect;
        [Category("Code Advance")]
        public ContentAlignment TextAlign { get { return lblText.TextAlign; } set { lblText.TextAlign = value; } }
        [Category("Code Advance")]
        public Color ForeColorG { get { return lblText.ForeColor; } set { lblText.ForeColor = value; } }
        [Category("Code Advance")]
        public Font FontG { get { return lblText.Font; } set { lblText.Font = value; } }

        [Category("Code Advance")]
        public Image ImageAd { get { return lblIcon.Image; } set { lblIcon.Image = value; } }


        [Category("Code Advance")]
        public Point TextLocation
        {
            get { return lblText.Location; }
            set
            {
                lblText.Location = value;
                lblText.Width = this.Width - value.X - 6;
            }
        }

        [Category("Code Advance")]
        public Point iConLocation
        {
            get { return lblIcon.Location; }
            set { lblIcon.Location = value; }
        }
        private bool _selected;


        #endregion
        #region select
        FormPopUpMultiAdd _formPopUpAdd;
        public List<string> _datas;
        public List<string> _SelectedValues { get; set; }
        public event EventHandler _eventSelected;
        public event EventHandler _eventDeselect;
        public event EventHandler _eventAddnew;
        private void All_Click(object sender, EventArgs e)
        {
            var p = this.PointToScreen(new Point(this.Width-347, this.Height));
            _formPopUpAdd = new FormPopUpMultiAdd(Texts, TextAdd);
            _formPopUpAdd.SetWidth(347);
            _formPopUpAdd.SetData(_datas, _SelectedValues);
            _formPopUpAdd._Selected += Popup_ItemSelected;
            _formPopUpAdd._Deselect += Popup_ItemDeselect;
            _formPopUpAdd._AddNew += Popup__AddNew;
            _formPopUpAdd.Deactivate += ClosePopUp;
            _formPopUpAdd.Location = p;
            _formPopUpAdd.Owner = this.FindForm();
            _formPopUpAdd.Show();
            //_formPopUpAdd.Show(this.FindForm());    
        }
        public void ClosePopUp(object sender, EventArgs e)
        {
            _formPopUpAdd.Hide();
        }
        public void Popup__AddNew(object sender, EventArgs e)
        {
            _eventAddnew?.Invoke(null, e);
        }
        public void Popup_ItemSelected(object sender, EventArgs e)
        {        
            _eventSelected?.Invoke(sender, e);
        }
        public void Popup_ItemDeselect(object sender, EventArgs e)
        {
            _eventDeselect?.Invoke(sender, e);
        }
        public string TextAdd { get; set; } = "Add New DUT...";
        #endregion
    }
}
