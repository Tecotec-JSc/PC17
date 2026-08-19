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
    public partial class TableVariableDUT : UserControl
    {
        public TableVariableDUT()
        {
            InitializeComponent();
        }
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
        }

        public void ResizeC()
        {
            var height = 30;
            if (panelTableBody.Controls.Count > 0)
            {

                foreach (System.Windows.Forms.Control control in panelTableBody.Controls)
                {
                    height += control.Height;
                }
            }
            panelTableBody.Height = height;
            this.Height = panelTableBody.Height + 43;
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
            panelTableBody.Controls.Add(row);
            ChangeColorRow();
        }

        private void Row__DeleteClick(object? sender, EventArgs e)
        {
            var row = sender as RowVariableControl;
            panelTableBody.Controls.Remove(row);
            ChangeColorRow();

        }

        public string _StrError;
        public event EventHandler _ShowError;
        public event EventHandler _ChangeNumberRow;
        private void Row__SaveClick(object? sender, EventArgs e)
        {
            var row = sender as RowVariableControl;
            if (row != null) {
                _StrError = row._StrError;
                if (_ShowError != null)
                    _ShowError.Invoke(null, e);
            }
       

        }
        public void DeleteRowSelect()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowVariableControl item in panelTableBody.Controls)
                {
                    if (item._Checked)
                    {
                        panelTableBody.Controls.Remove(item);
                    }
                }
                ChangeColorRow();

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
                        if (!row.Editor)
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
      
        public void ChangeColorRow()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                int i = 1;
                foreach(RowVariableControl row in panelTableBody.Controls)
                {
                    if (i % 2 == 0)
                    {
                        row.BackColor = BackColorRow1;
                    }
                    else
                    {
                        row.BackColor = BackColorRow2;
                    }
                }
            }
        }




        public Color BackColorRow1 { get; set; }
        public Color BackColorRow2 { get; set; }
    }
}
