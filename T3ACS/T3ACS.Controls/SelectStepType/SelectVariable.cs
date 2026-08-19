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
    public partial class SelectVariable : UserControl
    {
        private DropdownPopupVariableCustom popup;
        //draw
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            int radius = 4;
            int border = 1;

            Rectangle rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectangle(rect, radius))
            using (Pen pen = new Pen(Color.DarkGray, border))
            {
                g.DrawPath(pen, path);
            }
        }
        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
        //
        public string _Type;
        public List<string> _SelectedValues { get; set; }
        public List<string> _DataInputs { get; set; }
        public event EventHandler SelectedChanged;
        public SelectVariable()
        {
            InitializeComponent();
            InitHeader();

        }
        private void InitHeader()
        {
            panelSelected.WrapContents = true;              // Cho phép xuống dòng
            panelSelected.AutoSize = true;                  // Tự tăng giảm size
            panelSelected.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Click += OpenPopup;
            lblText.Click += OpenPopup;
        }
        private void OpenPopup(object sender, EventArgs e)
        {
            var p = this.PointToScreen(new Point(0, panel1.Height));
            if (popup != null)
            {
                popup.Location = p;
                if (!popup.CanFocus)
                    popup.Show();
                else popup.Focus();
                popup.BringToFront();
            }
  
        }
        public void SetData(List<string> datainput, List<string> selectValue)
        {
            _SelectedValues = selectValue;
            _DataInputs = datainput;
            if (_SelectedValues == null || _SelectedValues.Count == 0)
                lblText.Text = "Select parameters";
            else lblText.Text = _SelectedValues.Count + " parameter(s) selected";
            SetValueData();
            popup = new DropdownPopupVariableCustom(this.Width);
            popup._Remove += Popup_ItemDeSelected;
            popup._Select += Popup_ItemSelected;
            popup._AddNew += Popup__AddNew;
            popup.Deactivate += ClosePopUp;
            popup.SetData(_DataInputs, _SelectedValues);

        }

        private void Popup__AddNew(object? sender, EventArgs e)
        {
            
        }

        private void Popup_ItemSelected(object value, EventArgs e)
        {
            _SelectedValues = popup._selectData;
            if (_SelectedValues == null || _SelectedValues.Count == 0)
                lblText.Text = "Select parameters";
            else lblText.Text = _SelectedValues.Count + " parameter(s) selected";
            SelectedChanged?.Invoke(this, EventArgs.Empty);
            SetValueData();
        }
        private void Popup_ItemDeSelected(object value, EventArgs e)
        {
            _SelectedValues = popup._selectData;
            if (_SelectedValues == null || _SelectedValues.Count == 0)
                lblText.Text = "Select parameters";
            else lblText.Text = _SelectedValues.Count + " parameter(s) selected";
            SelectedChanged?.Invoke(this, EventArgs.Empty);
            SetValueData();
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
        Font fontlink = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        Color forcolorLink = Color.FromArgb(0, 120, 212);
        Label _lableShowLess;
        Label _lableShowMore;
        public void SetValueData()
        {
            panelSelected.Controls.Clear();
            if (_SelectedValues != null && _SelectedValues.Count > 0)
            {
                foreach (var item in _SelectedValues)
                {
                    ItemCheckListSelected cs = new ItemCheckListSelected();
                    cs.SetValue(item);
                    cs._Remove += itemRemove;
                    panelSelected.Controls.Add(cs);
                }
            }
            if (_lableShowLess == null)
            {
                _lableShowLess = new Label();
                _lableShowLess.AutoSize = false;
                _lableShowLess.Width = 140;
                _lableShowLess.Height = 30;
                _lableShowLess.Padding = new Padding(2, 9, 2, 3);
                _lableShowLess.Text = "Show less";
                _lableShowLess.Cursor = Cursors.Hand;
                _lableShowLess.Font = fontlink;
                _lableShowLess.ForeColor = forcolorLink;
                _lableShowLess.Click += showLess;
                _lableShowMore = new Label();
                _lableShowMore.Padding = new Padding(2, 9, 2, 3);
                _lableShowMore.AutoSize = false;
                _lableShowMore.Height = 30;
                _lableShowMore.Width = 140;
                _lableShowMore.Cursor = Cursors.Hand;
                _lableShowMore.Font = fontlink;
                _lableShowMore.ForeColor = forcolorLink;
                _lableShowMore.Click += showMore;
            }
            _lableShowMore.Text = "... Show all";
            if (_SelectedValues != null) _lableShowMore.Text += " (" + _SelectedValues.Count + ")";
            panelSelected.Controls.Add(_lableShowLess);
            panelSelected.Controls.Add(_lableShowMore);
            ShowSelectedValue();
        }
        private void showLess(object sender, EventArgs e)
        {
            _showAllSelectedValue = false;
            ShowSelectedValue();
        }
        private void showMore(object sender, EventArgs e)
        {
            _showAllSelectedValue = true;
            ShowSelectedValue();
        }
        bool _showAllSelectedValue;
        private void ShowSelectedValue()
        {
            if (_showAllSelectedValue)
            {
                if (_SelectedValues != null && _SelectedValues.Count > 0)
                {
                    foreach (System.Windows.Forms.Control control in panelSelected.Controls)
                    {
                        if (control is ItemCheckListSelected)
                        {
                            control.Visible = true;
                        }
                    }
                }
                _lableShowLess.Visible = true;
                _lableShowMore.Visible = false;
            }
            else
            {
                if (_SelectedValues != null && _SelectedValues.Count > 0)
                {
                    var firstcheck = true;
                    foreach (System.Windows.Forms.Control control in panelSelected.Controls)
                    {
                        if (control is ItemCheckListSelected)
                        {
                            if (firstcheck)
                            {
                                firstcheck = false;
                                control.Visible = true;
                            }
                            else control.Visible = false;
                        }
                    }
                }
                _lableShowLess.Visible = false;
                _lableShowMore.Visible = true;
            }
            UpdateHeight();
        }
        private void itemRemove(object sender, EventArgs e)
        {
            ItemCheckListSelected item = sender as ItemCheckListSelected;
            _SelectedValues.Remove(item._Value);
            panelSelected.Controls.Remove(item);
            item.Dispose();
            _lableShowMore.Text = "... Show all";
            if (_SelectedValues != null) _lableShowMore.Text += " (" + _SelectedValues.Count + ")";
            ShowSelectedValue();
            // select control
            if (_SelectedValues == null || _SelectedValues.Count == 0)
                lblText.Text = "Select parameters";
            else lblText.Text = _SelectedValues.Count + " parameter(s) selected";
            SelectedChanged?.Invoke(this, EventArgs.Empty);
        }
        private void UpdateHeight()
        {
            if (_SelectedValues == null || _SelectedValues.Count == 0)
            {
                panelSelected.Visible = false;
                this.Height = 40;
            }
            else
            {
                panelSelected.Visible = true;
                this.Height = 40 + panelSelected.Height;
            }
        }
        public void ClosePopUp(object sender, EventArgs e)
        {
            popup.Hide();
        }
    }

}
