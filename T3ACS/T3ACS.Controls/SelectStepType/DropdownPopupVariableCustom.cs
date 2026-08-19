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
    public partial class DropdownPopupVariableCustom : Form
    {
        bool formReady = false;
        public DropdownPopupVariableCustom(int width)
        {
            InitializeComponent();
            this.Width = width;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            panelSearch.AutoScroll = true;
            //panelSearch.WrapContents = false;   // Không cho nhảy sang cột mới
            //panelSearch.AutoSize = true;        // Cho panel tự tăng kích thước
            //panelSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelSearch.HorizontalScroll.Enabled = false;
            panelSearch.HorizontalScroll.Visible = false;
        }

        int borderRadius = 6;
        int borderSize = 1;
        Color borderColor = Color.FromArgb(138, 136, 134);
        public event EventHandler _Select;
        public event EventHandler _AddNew;
        public event EventHandler _Remove;
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(pathSurface);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;

            using (Pen pen = new Pen(borderColor, 1))
            {
                // Viền trên
                e.Graphics.DrawLine(pen, 0, 0, p.Width, 0);

            }
        }
        public List<string> _data;
        public List<string> _dataShow;
        public List<string> _selectData;
        ItemListAction _itemSearch;
        ItemListAction _itemAddNew;
        #region SetValue
        public void DeselectValue(string value)
        {
            if (panelSearch.Controls != null && panelSearch.Controls.Count > 0)
            {
                foreach (object control in panelSearch.Controls)
                {
                    if (control is itemCheckListControl)
                    {
                        var item = control as itemCheckListControl;
                        if (item.Name == value)
                        {
                            item.SetChangeSelect(false);
                        }
                    }
                }
                _selectData.Remove(value);
            }
        }
        public void SetData(List<string> datas, List<string> selectData)
        {
            panelSearch.Controls.Clear();
            _data = datas;
            _dataShow = new List<string>();
            _selectData = selectData;

            if (datas != null && datas.Count > 0)
            {
                foreach (string data in datas)
                {
                    _dataShow.Add(data);
                    itemCheckListControl item = new itemCheckListControl();
                    item.Name = data;
                    bool check = false;
                    if (selectData != null && selectData.Count > 0)
                    {
                        check = selectData.Contains(data);
                    }
                    item.SetValue(data, check);
                    item.Width = panelSearch.Width - 17;
                    item._ChangeSelect += changeSelectItem;
                    panelSearch.Controls.Add(item);
                }
            }
            if (_itemSearch == null)
            {
                _itemSearch = new ItemListAction();
                _itemSearch.Name = "ItemSearched";
                _itemSearch.Width = panelSearch.Width - 17;
                _itemSearch._ChangeSelect += addNewSeachItem;
            }
            panelSearch.Controls.Add(_itemSearch);
            if (_itemAddNew == null)
            {
                _itemAddNew = new ItemListAction();
                _itemAddNew.Name = "ItemAddNew";
                _itemAddNew.SetValue("Add New Parameter...");
                _itemAddNew.Width = panelSearch.Width - 17;
                _itemSearch._ChangeSelect += addNewItem;
            }
            panelSearch.Controls.Add(_itemAddNew);
            _itemSearch.Visible = false;
            updateHeigh();
        }


        private void changeWidth(int width)
        {
            if (panelSearch.Controls != null && panelSearch.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control item in panelSearch.Controls)
                {
                    item.Width = width;
                }
            }
        }
        private void updateHeigh()
        {
            int heith = 37;
            if (_dataShow != null && _dataShow.Count > 0)
                heith += _dataShow.Count * 37;
            if (_itemSearch.Visible)
                heith += 37;



            if (heith >= 185)
            {
                this.Height = 245;
                panel1.Height = 187;
                panelSearch.Height = 185;
                changeWidth(panelSearch.Width - 17);
            }
            else
            {
                this.Height = 60 + heith;
                panel1.Height = 2 + heith;
                panelSearch.Height = heith;
                changeWidth(panelSearch.Width - 2);
            }
            Invalidate();
        }

        #endregion
        private void changeSelectItem(object sender, EventArgs e)
        {
            itemCheckListControl item = sender as itemCheckListControl;
            if (item != null)
            {
                if (!item._Select)
                {
                    item.SetChangeSelect(true);
                    if (_selectData == null) _selectData = new List<string>();
                    _selectData.Add(item.Name);
                    if (_Select != null)
                        _Select.Invoke(item.Name, new EventArgs());
                }
                else
                {
                    item.SetChangeSelect(false);
                    _selectData.Remove(item.Name);
                    if (_Remove != null)
                        _Remove.Invoke(item.Name, new EventArgs());
                }
            }
        }
        private void addNewSeachItem(object sender, EventArgs e)
        {
            if (_AddNew != null)
                _AddNew.Invoke(rjTextSeach1.Text, new EventArgs());
        }
        private void addNewItem(object sender, EventArgs e)
        {           
                _AddNew?.Invoke(string.Empty, new EventArgs());
        }



        private void DropdownPopupVariableCustom_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            formReady = true;
        }

        private void rjTextSeach1__TextChanged(object sender, EventArgs e)
        {
            if (formReady)
            {
                var text = rjTextSeach1.Text;
                _dataShow = new List<string>();
                if (!string.IsNullOrEmpty(text))
                {
                    if (_data != null && _data.Count > 0)
                    {
                        var lst = _data.Where(t => t.Contains(text));
                        if (lst != null && lst.Count() > 0)
                            _dataShow.AddRange(lst.ToList());
                    }
                }
                else
                {
                    if (_data != null && _data.Count > 0)
                    {
                        _dataShow = new List<string>();
                        if (_data != null && _data.Count > 0)
                        {
                            foreach (string data in _data)
                            {
                                _dataShow.Add(data);
                            }
                        }
                    }
                }
                ShowAfterSearch(text);
            }

        }
        private void ShowAfterSearch(string strSearch)
        {
            if ((_dataShow == null || _dataShow.Count == 0) && !string.IsNullOrEmpty(strSearch))
            {
                _itemSearch.Visible = true;
                _itemSearch.SetValue(strSearch);
            }
            else
            {
                _itemSearch.Visible = false;
            }
            if (_data != null && _data.Count > 0)
            {
                foreach (object control in panelSearch.Controls)
                {
                    if (control is itemCheckListControl)
                    {
                        itemCheckListControl item = control as itemCheckListControl;
                        if (item != null)
                        {
                            if (_dataShow != null && _dataShow.Count > 0 && _dataShow.Contains(item.Name))
                            {
                                item.Visible = true;
                            }
                            else item.Visible = false;
                        }

                    }
                }
            }
            updateHeigh();
        }


        private void rjTextSeach1_Load(object sender, EventArgs e)
        {

        }
    }
}
