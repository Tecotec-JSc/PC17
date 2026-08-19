using T3ACS.Controls.Table;
using T3ACS.Model;
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

namespace T3ACS.Controls
{
    public partial class TableVariableSelect : UserControl
    {
        public TableVariableSelect()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            // thêm nhiều line dọc
            panelTitleTop.VerticalPoints.Add(168);
            panelTitleTop.VerticalPoints.Add(314);
            panelTitleTop.VerticalPoints.Add(463);
            panelTitleTop.VerticalPoints.Add(579);
            panelTitleTop.VerticalPoints.Add(697);
            panelTitleTop.VerticalPoints.Add(807);
            panelTitleTop.VerticalPoints.Add(918);
            panelContent.Controls.Clear();
          
        }
        RowNodata row;
        public void ShowDataSelect()
        {
            if (panelContent.Controls.Count == 1)
            {
                row.Visible=true;
            }
            else
            {
                row.Visible = false;
            }
            ResizeT();
        }
        public List<ProcedureDetailFunctionVariable> _Data;
        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            row = new RowNodata();
            row.Width = panelContent.Width;
            row.Margin = new Padding(0);
            panelContent.Controls.Add(row);
            if (values != null && values.Count > 0)
            {
                foreach (var item in values)
                {
                    AddNewRow(item.ProcedureVariableId, item.Name, item.Title, item.Value, item.Unit, item.Min + "", item.Max + "", item.Type, item.TypeInput, item.Required, item.Report, false);
                }
            }
            ResizeT();
        }
        public void ResizeT()
        {
            this.Height = panelContent.Height + 38;
        }
        private void Row__UpdateHeight(object? sender, EventArgs e)
        {
            ResizeT();
        }
        public string _StrError;
        public event EventHandler _ShowError;
        public event EventHandler _UpdateHeight;
        private void Row__SaveClick(object? sender, EventArgs e)
        {
            var row = sender as RowVariableControl;
            if (row != null)
            {
                _StrError = row._StrError;
                if (_ShowError != null)
                    _ShowError.Invoke(null, e);
            }
        }
        public void DeleteRow(object? sender, EventArgs e)
        {
            RowVariableSelected obj = sender as RowVariableSelected;
            if (panelContent.Controls.Count > 0)
            {
                foreach (RowVariableSelected item in panelContent.Controls)
                {
                    if (item.Name==obj.Name)
                    {
                        panelContent.Controls.Remove(item);
                    }
                }
            }
            ShowDataSelect();
        }
        public void AddNewRow(int id, string name, string title, string value, string unit, string min, string max, string type, string typeInpuit, bool required, bool report, bool editrow)
        {
            RowVariableSelected row = new RowVariableSelected();
            row.Width = this.Width;
            row.Margin = new Padding(0);
            row.LoadData(id, name, title, value, unit, min, max, type, typeInpuit, required, report, editrow);
            row._UpdateHeight += Row__UpdateHeight;
            row._SaveClick += Row__SaveClick;
            row._RemoveRow += DeleteRow;
            if (panelContent.Controls.Count > 1)
            {
                foreach (System.Windows.Forms.Control item in panelContent.Controls)
                {
                    if(item is RowVariableSelected)
                    {
                        var controlb= item as RowVariableSelected;
                        controlb.SetBorder(0, 0, 0, 0);
                    }
                }
            }
            row.SetBorder(0,0,5,5);
            panelContent.Controls.Add(row);
        }
        public List<ProcedureDetailFunctionVariable> GetVariables()
        {
            List<ProcedureDetailFunctionVariable> result = new List<ProcedureDetailFunctionVariable>();
            if (panelContent.Controls.Count > 0)
            {
                foreach (RowVariableSelected item in panelContent.Controls)
                {
                    result.Add(item.GetData());
                }
            }
            return result;
        }
    }
}
