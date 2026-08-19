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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T3ACS.Controls.SelectCustoms
{
    public partial class SelectCustomAdd : UserControl
    {
        public SelectCustomAdd()
        {
            InitializeComponent();
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
        public Color BorderColor { get; set; } = Color.FromArgb(14, 82, 98);
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
            using (SolidBrush brush = new SolidBrush(BackColor))
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
        public event EventHandler _eventClick;
        public event EventHandler _eventSelected;
        public event EventHandler _eventAddnew;
        private void lblContent_Click(object sender, EventArgs e)
        {
            OpenPopup();
        }
        private void OpenPopup()
        {
            var p = this.PointToScreen(new Point(0, this.Height));
            _formPopUpAdd = new FormPopUpAdd(Texts, TextAdd);
            _formPopUpAdd.SetWidth(this.Width);         
            _formPopUpAdd.SetData(_datas);
            _formPopUpAdd._Selected += Popup_ItemSelected;
            _formPopUpAdd._AddNew += Popup__AddNew;
            _formPopUpAdd.Deactivate += ClosePopUp;
            _formPopUpAdd.Location = p;
            _formPopUpAdd.Show(this.FindForm());
            _formPopUpAdd.BringToFront();

        }
        FormPopUpAdd _formPopUpAdd;
        List<string> _datas;
        public void SetData(List<string> datas)
        {
            _datas = datas;          
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
            lblContent.Text=sender.ToString();
            _eventSelected?.Invoke(sender, e);
        }
        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                return lblContent.Text;
            }
            set
            {
                lblContent.Text = value;
            }
        }


        public string TextAdd { get; set; } = "Add New DUT...";


    }
}
