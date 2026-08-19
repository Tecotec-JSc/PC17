using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    public partial class TableVariableControl : UserControl
    {
        public TableVariableControl()
        {
            InitializeComponent();
        }
        public int _MaxHeight { get; set; } = 300;
        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            panelTableBody.Controls.Clear();
            if (values != null && values.Count > 0)
            {
                foreach (var item in values)
                {
                    AddNewRow(false, item.ProcedureVariableId, item.Name, item.Title, item.Value,item.Items, item.Unit, item.Min + "", item.Max + "", item.Type, item.TypeInput, item.Required, item.Report, false);
                }
            }
            ResizeC();
            ChangeColorRow();
        }

        public void ResizeC()
        {
            var height = 01;
            if (panelTableBody.Controls.Count > 0)
            {

                foreach (System.Windows.Forms.Control control in panelTableBody.Controls)
                {
                    height += control.Height;
                }
            }
            if (height > _MaxHeight)
            {
                panel1.AutoScroll = true;
                panelTableBody.Width = this.Width - 19;
                foreach (RowVariableControl c in panelTableBody.Controls)
                {
                    c.Width = panelTableBody.Width-1;
                }
                panelTableBody.Height = height;
                panel1.Width = this.Width+0;
                panel1.Height = _MaxHeight;
            
            }
            else
            {
                panel1.AutoScroll = false;
                panelTableBody.Width = this.Width+0;
                foreach (RowVariableControl c in panelTableBody.Controls)
                {
                    c.Width = panelTableBody.Width;
                }
                panelTableBody.Height = height;
                panel1.Height = height;
            }
            this.Height = panel1.Height + 43;
            panel1.Invalidate();
        }
     

        private void Row__UpdateHeight(object? sender, EventArgs e)
        {
            ResizeC();
        }

        public void AddNewRow(bool checkv, int id, string name, string title, string value,string items, string unit, string min, string max, string type, string typeInpuit, bool required, bool report, bool editrow)
        {
            RowVariableControl row = new RowVariableControl();
            row.Width = this.Width;
            row.LoadData(checkv, id, name, title, value, items, unit, min, max, type, typeInpuit, required, report, editrow);
            row._UpdateHeight += Row__UpdateHeight;
            row._SaveClick += Row__SaveClick;
            row._DeleteClick += Row__DeleteClick;
            row._CheckChange += Row__CheckChange;
            row.Margin = new Padding(0, -1, 0,-1);
            panelTableBody.Controls.Add(row);
            ChangeColorRow();
        }
        private void Row__CheckChange(object? sender, EventArgs e)
        {
            _ChangeNumberRow?.Invoke(null, EventArgs.Empty);
        }
        private void Row__DeleteClick(object? sender, EventArgs e)
        {
            var row = sender as RowVariableControl;
            panelTableBody.Controls.Remove(row);
            ChangeColorRow();
            _ChangeNumberRow?.Invoke(this,EventArgs.Empty);
            ResizeC();
        }
        public void DeleteRowWithName(string name)
        {
            if (panelTableBody.Controls.Count > 0)
            {
                // Tìm trước, xóa sau — tránh modify collection trong khi foreach đang iterate
                var toRemove = panelTableBody.Controls
                    .OfType<RowVariableControl>()
                    .FirstOrDefault(item => item.GetName() == name);

                if (toRemove != null)
                {
                    panelTableBody.Controls.Remove(toRemove);
                }
                ChangeColorRow();
                ResizeC();
            }
        }


        public string _StrError;
        public event EventHandler _ShowError;
        public event EventHandler _ChangeNumberRow;
        private void Row__SaveClick(object? sender, EventArgs e)
        {
            var row = sender as RowVariableControl;
            if (row != null) {
                _StrError = row._StrError;
                if (!string.IsNullOrEmpty(_StrError))
                    _ShowError.Invoke(null, e);
            }
       

        }
        public void DeleteRowSelect()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                List<RowVariableControl> lstRemove = new List<RowVariableControl>();

                foreach (RowVariableControl item in panelTableBody.Controls)
                {
                    if (item._Checked)
                    {
                        lstRemove.Add(item);                      
                    }
                }
                if(lstRemove.Count > 0)
                {
                    foreach (var item in lstRemove)
                    {
                        panelTableBody.Controls.Remove(item);
                    }
                    ChangeColorRow();
                    _ChangeNumberRow?.Invoke(null, EventArgs.Empty);
                }
                ResizeC();
            }
        }
        public bool CheckSave( out string mess)
        {
            mess = "";
            var result = true;
            if (panelTableBody.Controls.Count == 0)
            {
                mess = "You must enter at least one parameter before saving.";
                result = false;
            }else
            {
                var count = 0;
                foreach(RowVariableControl row in panelTableBody.Controls)
                {
                    if (row != null)
                    {
                        if (row.Editor)
                        {
                            mess = "You must complete all parameter rows before saving.";
                            return result;
                        }
                        count++;
                    }
                }
                if(count==0)
                {
                    mess = "You must enter at least one parameter before saving.";
                    result = false;
                }
            }

            return result;

        }
        public List<ProcedureVariableViewModel> GetVariables()
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowVariableControl item in panelTableBody.Controls)
                {
                    result.Add(item.GetData());
                }
            }
            return result;
        }
        bool _checkAll;
        private void lblbtnCheckAll_Click(object sender, EventArgs e)
        {
            if (_checkAll)
                _checkAll = false;
            else _checkAll = true;
            CheckAll();
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
                foreach (RowVariableControl item in panelTableBody.Controls)
                {
                    item._Checked = _checkAll;
                    item.ResetImageCheck();
                }
            }
        }
        public int CountRowSelected()
        {
            int result = 0;
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowVariableControl item in panelTableBody.Controls)
                {
                    if (item._Checked) result++;
                }
            }
            return result;
        }
        public void ChangeColorRow()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                int i = 1;
                foreach(RowVariableControl row in panelTableBody.Controls)
                {
                    if (i % 2 == 0)
                    {
                        row.ChangeBackColor(BackColorRow1);
                    }
                    else
                    {
                        row.ChangeBackColor(BackColorRow2);
                    }
                    i++;
                }
            }
        }




        public Color BackColorRow1 { get; set; } = Color.FromArgb(250, 250, 250);
        public Color BackColorRow2 { get; set; } = Color.White;
    }
}
