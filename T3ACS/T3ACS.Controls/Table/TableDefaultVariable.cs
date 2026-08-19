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
using System.Diagnostics;

namespace T3ACS.Controls
{
    public partial class TableDefaultVariable : UserControl
    {
        public TableDefaultVariable()
        {
            InitializeComponent();
        }
        public int _MaxHeight { get; set; } = 300;
        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            panelTableBody.Controls.Clear();
            if (values != null && values.Count > 0)
            {
                int count = 1;
                foreach (var item in values)
                {
                    AddNewRow(count, item.Name, item.Title, item.Value, item.Items, item.Unit, item.Min + "", item.Max + "", item.Type, item.TypeInput, item.Required, item.Report, false);
                    count++;
                }
            }
            ResizeC();
            ChangeColorRow();
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
            if (height > _MaxHeight) {

                panelTableBody.Width = this.Width - 15;
                foreach (RowDefaultVariable c in panelTableBody.Controls)
                {
                    c.Width = panelTableBody.Width;
                }
                panelTableBody.Height = height;
                panel1.Width = this.Width;
                panel1.Height = _MaxHeight;       
            }
            else
            {
                panelTableBody.Width = this.Width;
                foreach (RowDefaultVariable c in panelTableBody.Controls)
                {
                    c.Width = panelTableBody.Width;
                }
                panelTableBody.Height = height;
                panel1.Height = height;
            }
            this.Height = panel1.Height + 43;       
        }

        private void Row__UpdateHeight(object? sender, EventArgs e)
        {
            ResizeC();
        }

        public void AddNewRow(int id, string name, string title, string value, string items, string unit, string min, string max, string type, string typeInpuit, bool required, bool report, bool editrow)
        {
            RowDefaultVariable row = new RowDefaultVariable();
            row.Width = panelTableBody.Width;
            row.LoadData( id, name, title, value, items, unit, min, max, type, typeInpuit, required, report, editrow);
            row._UpdateHeight += Row__UpdateHeight;
            row._SaveClick += Row__SaveClick;
            row._DeleteClick += Row__DeleteClick;
            row._CheckChange += Row__CheckChange;
            panelTableBody.Controls.Add(row);
            ChangeColorRow();
        }
        private void Row__CheckChange(object? sender, EventArgs e)
        {
            _ChangeNumberRow?.Invoke(null, EventArgs.Empty);
        }
        private void Row__DeleteClick(object? sender, EventArgs e)
        {
            var row = sender as RowDefaultVariable;
            panelTableBody.Controls.Remove(row);
            ChangeColorRow();
            _ChangeNumberRow?.Invoke(this,EventArgs.Empty);
        }
        public void DeleteRowWithName(string name)
        {
            if (panelTableBody.Controls.Count > 0)
            {
                foreach (RowDefaultVariable item in panelTableBody.Controls)
                {
                    if (item.GetName()==name)
                    {
                        panelTableBody.Controls.Remove(item);
                    }
                }
                ChangeColorRow();
            }
        }


        public string _StrError;
        public event EventHandler _ShowError;
        public event EventHandler _ChangeNumberRow;
        private void Row__SaveClick(object? sender, EventArgs e)
        {
            var row = sender as RowDefaultVariable;
            if (row != null) {
                _StrError = row._StrError;
                if (!string.IsNullOrEmpty(_StrError))
                    _ShowError?.Invoke(null, e);
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
                foreach(RowDefaultVariable row in panelTableBody.Controls)
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
         
                foreach (RowDefaultVariable item in panelTableBody.Controls)
                {
               
                
                    result.Add(item.GetData());
               
                }
            }
            return result;
        }
        bool _checkAll;
        private void lblbtnCheckAll_Click(object sender, EventArgs e)
        {
    
        }
      
      
        public void ChangeColorRow()
        {
            if (panelTableBody.Controls.Count > 0)
            {
                int i = 1;
                foreach (RowDefaultVariable row in panelTableBody.Controls)
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




        public Color BackColorRow1 { get; set; }
        public Color BackColorRow2 { get; set; }
    }
}
