using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T3ACS.Controls
{
    public partial class SelectControl : UserControl
    {
        private DropdownPopup popup;
        public string SelectedValue { get; private set; }

        public event EventHandler SelectedChanged;

        public SelectControl()
        {
            InitializeComponent();
            InitHeader();
            popup = new DropdownPopup(this.Width);
            popup.ItemSelected += Popup_ItemSelected;
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
                Invalidate();
            }
        }

        private Color backColor = Color.White;

        private void InitHeader()
        {
            this.Height = 34;       
            lblText.Click += OpenPopup;       
        }
        private void OpenPopup(object sender, EventArgs e)
        {
            //var p = this.PointToScreen(new Point(0, this.Height));
            //popup.Location = p;
            //popup.Show();
            //popup.BringToFront();

            Rectangle screen = Screen.FromControl(this).WorkingArea;

            Point p = this.PointToScreen(new Point(0, this.Height));

            // Nếu phía dưới không đủ chỗ thì hiển thị lên trên
            if (p.Y + popup.Height > screen.Bottom)
            {
                p.Y = this.PointToScreen(Point.Empty).Y - popup.Height;
            }

            // Nếu phía trên cũng không đủ thì ép sát mép trên màn hình
            if (p.Y < screen.Top)
            {
                p.Y = screen.Top;
            }

            popup.Location = p;
            popup.Width = this.Width;
            popup.Show();
            popup.BringToFront();



        }
        public void SetData(List<string> datainput)
        {
            popup.SetData(datainput);
        }
        private void Popup_ItemSelected(string value)
        {
            SelectedValue = value;
            lblText.Text = value;
            SelectedChanged?.Invoke(this, EventArgs.Empty);
        }
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
        public void SetValue(string value)
        {
            lblText.Text = value;
            SelectedValue= value;
        }

        public void ClosePopUp()
        {
            popup.Hide();
        }
    }
    public class DropdownPopup : Form
    {
        private RJTextSeach txtSearch;
        private ListBox lstItems;
        private List<string> _data = new();

        public event Action<string> ItemSelected;
       
        public DropdownPopup(int width)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Width = 498;
            Height = 220;

            txtSearch = new RJTextSeach
            {            
                Dock = DockStyle.Top,
                BackColor
                = Color.White,
                
            };

            lstItems = new ListBox
            {
                Dock = DockStyle.Fill,
                DrawMode = DrawMode.OwnerDrawFixed
            };
            Controls.Add(lstItems);
            Controls.Add(txtSearch);
            txtSearch.TextChanged += Filter;
            lstItems.Click += SelectItem;
            lstItems.DrawItem += DrawItem;
            lstItems.ItemHeight = 34;   // chiều cao mỗi item
            lstItems.Font = new Font("Segoe UI", 10f);
        
        }
        public void SetData(List<string> data)
        {
            _data = data;
            lstItems.DataSource = _data.ToList();
        }
        private void Filter(object sender, EventArgs e)
        {
            var key = txtSearch.Text.ToLower();
            lstItems.DataSource = _data
                .Where(x => x.ToLower().Contains(key))
                .ToList();
        }
        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Brush brush = new SolidBrush(Color.FromArgb(0, 82, 130));
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            e.Graphics.FillRectangle(
                selected ? brush : Brushes.White, e.Bounds
                
                );

            e.Graphics.DrawString(
                lstItems.Items[e.Index].ToString(),
                e.Font,
                selected ? Brushes.White : Brushes.Black,
                e.Bounds);
        }
        private void SelectItem(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem == null) return;
            ItemSelected?.Invoke(lstItems.SelectedItem.ToString());
            this.Hide();
        }
       
    }
}
