using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T3ACS.Controls
{
    public partial class TableMetaData : UserControl
    {
        private bool _checkAll;
        public event EventHandler _UpdateHeight;
        public TableMetaData()
        {
            InitializeComponent();
            panelTableBody.Width = this.Width;
            panelTableBody.Height = 0;
            panelTableBody.FlowDirection = FlowDirection.TopDown;
            panelTableBody.WrapContents = false;
            panelTableBody.AutoSize = true;
            panelTableBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        public void LoadData(Dictionary<string, string> metaDatas)
        {

            panelTableBody.Controls.Clear();
            if (metaDatas != null && metaDatas.Count > 0)
            {
                foreach (var item in metaDatas)
                {
                    AddNewRow(false, item.Key, item.Value, false);
                }
            }
            ResizeC();
        }
        public void ResizeC()
        {
            this.Height = panelTableBody.Height + 43;
            if (_UpdateHeight != null)
                _UpdateHeight.Invoke(null, new EventArgs());
        }
        public void AddNewRow(bool checkv, string title, string value, bool editrow)
        {
            RowMetaData row = new RowMetaData();
            row.LoadData(checkv, title, value, editrow);
            row.Width = this.Width;
            row._UpdateHeight += Row__UpdateHeight;     
            panelTableBody.Controls.Add(row);
        }
        private void Row__UpdateHeight(object? sender, EventArgs e)
        {
            ResizeC();
        }
        public void DeleteRowSelect()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowMetaData item in panelTableBody.Controls)
                {
                    if (item._Checked)
                    {
                        panelTableBody.Controls.Remove(item);
                    }
                }
            }
        }
        public void CheckAll()
        {
            if (_checkAll)
            {
                lblbtnCheckAll.Image = Properties.Resources.Checked;
            }
            else
            {
                lblbtnCheckAll.Image = Properties.Resources.NotChecked;
            }
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowMetaData item in panelTableBody.Controls)
                {
                    item._Checked = _checkAll;
                    item.ResetImageCheck();
                }
            }
        }
        public Dictionary<string, string> GetValue()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowMetaData item in panelTableBody.Controls)
                {
                    var va = item.GetData();
                    if (va != null && va.Count > 0)
                    {
                        result.Add(va[0], va[1]);
                    }
                }
            }
            return result;
        }
        private void lblbtnCheckAll_Click(object sender, EventArgs e)
        {
            if (_checkAll)
                _checkAll = false;
            else _checkAll = true;
            CheckAll();
        }
    }
}
