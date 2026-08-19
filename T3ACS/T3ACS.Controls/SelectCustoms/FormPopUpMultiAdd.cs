using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls.SelectCustoms
{
    public partial class FormPopUpMultiAdd : Form
    {
        string _textFirst;
        string _textAdd;
        public FormPopUpMultiAdd(string text, string textAdd)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            _textFirst = text;
            _textAdd = textAdd;
            lblAddDUT.Text = _textAdd;
        }
        public void SetWidth(int width)
        {
            this.Width = width;
            flowPanelBorderRadius1.Width = width;
            panel1.Width = width;
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

        private void lblAddDUT_Click(object sender, EventArgs e)
        {
            _AddNew?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
        public EventHandler _AddNew;
        public EventHandler _Selected;
        public EventHandler _Deselect;
        public List<string> _Data;
        public List<string> _SelectedValues { get; set; }
        public void SetData(List<string> duts, List<string> dutselected)
        {
            _Data = duts;
            _SelectedValues = dutselected;
            ShowWithData(duts);
        }
        private void ShowWithData(List<string> duts)
        {
            if (duts != null && duts.Count > 0)
            {

                flowPanelBorderRadius1.Visible = true;
                if (duts.Count > 8)
                {
                    this.Height = 434;

                }
                else
                {
                    this.Height = panelTitle.Height + panelBottom.Height + ((duts.Count) * 38);
                }

                flowPanelBorderRadius1.Height = ((duts.Count) * 38);
                flowPanelBorderRadius1.Controls.Clear();
                var width = this.Width + 0;
                if (duts.Count > 8) width = this.Width - 18;
                flowPanelBorderRadius1.Width = width;
                foreach (var str in duts)
                {
                    ItemCheckBoxSelect item = new ItemCheckBoxSelect();
                    item.Width = width;
                    item.Margin = new Padding(0);
                    var checkv = false;
                    if (_SelectedValues != null && _SelectedValues.Count(t => t == str) > 0)
                        checkv = true;
                    item.SetValue(str, checkv);
                    item._eventSelect += eventSelectItem;
                    item._ready = true;
                    flowPanelBorderRadius1.Controls.Add(item);
                }
            }
            else
            {
                flowPanelBorderRadius1.Controls.Clear();
                flowPanelBorderRadius1.Visible = false;
                this.Height = panelTitle.Height + panelBottom.Height;
            }
        }
        private void eventSelectItem(object sender, EventArgs e)
        {
            if (sender != null && sender is ItemCheckBoxSelect item)
            {
                if (item._Checked)
                {
                    _Selected?.Invoke(item.Texts, EventArgs.Empty);
                    _SelectedValues.Add(item.Texts);
                }
                else if (!item._Checked)
                {
                    _SelectedValues.Remove(item.Texts);
                    _Deselect?.Invoke(item.Texts, EventArgs.Empty);
                }
              

            }
        }

        private void acsTextSearch1__TextChanged(object sender, EventArgs e)
        {
            var strSearch = acsTextSearch1.Texts;
            if (_Data != null && _Data.Count > 0)
            {
                List<string> list = new List<string>();
                if (string.IsNullOrEmpty(strSearch)) list = _Data;
                else
                {
                    list = _Data.Where(t => t.ToLower().Contains(strSearch.ToLower())).ToList();
                }
                ShowWithData(list);
            }

        }

        public Color HoverColorG { get; set; } = Color.FromArgb(250, 250, 250);
        private void FormPopUpMultiAdd_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void panelBottom_Leave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hovered = false;
                hoverNow = false;

                lblAddDUT.BackColor = BackColor;
                panelBottom.BackColor = BackColor;
                Invalidate();
            }
        }
        public bool hovered;
        public bool hoverNow;
        private void panelBottom_Enter(object sender, EventArgs e)
        {
            if (!hovered)
            {
                hovered = true;
                hoverNow = true;
                lblAddDUT.BackColor = HoverColorG;
                panelBottom.BackColor = HoverColorG;
                Invalidate();
            }
        }
    }
}
