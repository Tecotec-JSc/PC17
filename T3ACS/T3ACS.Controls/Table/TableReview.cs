using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls.Table
{
    public partial class TableReview : UserControl
    {
        public TableReview()
        {
            InitializeComponent();
            panelcontent.Width = this.Width;
            panelcontent.Height = 0;
            panelcontent.FlowDirection = FlowDirection.TopDown;
            panelcontent.WrapContents = false;
            panelcontent.AutoSize = true;
            panelcontent.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.SizeChanged += (s, e) => UpdateWidths();
            panel1.Resize += (s, e) => UpdateWidths();
        }

        private void UpdateWidths()
        {
            int clientWidth = panel1.ClientSize.Width;
            if (clientWidth < 100) clientWidth = this.Width;
            panelcontent.Width = clientWidth;
            foreach (System.Windows.Forms.Control control in panelcontent.Controls)
            {
                control.Width = clientWidth - 2;
            }
        }

        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            panelcontent.Controls.Clear();
            if (values != null && values.Count > 0)
            {
                int count = 1;
                foreach (var item in values)
                {
                    AddNewRow(count++, item.ProcedureVariableId, item.Name, item.Title, item.Value, item.Unit, item.Min, item.Max, item.Type, item.TypeInput, item.Required, item.Report);
                }
            }
            ResizeC();
        }

        public bool AutoHeight { get; set; } = true;

        public void ResizeC()
        {
            var height = 45;
            if (panelcontent.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control control in panelcontent.Controls)
                {
                    height += control.Height;
                }
            }
            panelcontent.Height = height;
            if (AutoHeight)
            {
                this.Height = panelcontent.Height + 48;
            }
        }

        private void Row__UpdateHeight(object? sender, EventArgs e)
        {
            ResizeC();
        }

        public void AddNewRow(int no, int id, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report)
        {
            RowReview row = new RowReview();
            int clientWidth = panel1.ClientSize.Width;
            if (clientWidth < 100) clientWidth = this.Width;
            row.Width = clientWidth ;
            row.LoadData(no, id, name, title, value, unit, min, max, type, typeInput, required, report);
            row._CheckChange += Row__CheckChange;
            row.Margin = new Padding(0, -1, 0, 0);
            panelcontent.Controls.Add(row);
        }

        public int CountRowSelected()
        {
            int result = 0;
            if (panelcontent.Controls.Count > 0)
            {
                foreach (RowReview item in panelcontent.Controls)
                {
                    if (item.chkReport.Checked) result++;
                }
            }
            return result;
        }

        private void Row__CheckChange(object? sender, EventArgs e)
        {
            _EventChange?.Invoke(null, EventArgs.Empty);
        }

        public event EventHandler _EventChange;

        public bool OverwriteVariableNames { get; set; } = true;

        public List<ProcedureVariableViewModel> GetVariables()
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (panelcontent.Controls.Count > 0)
            {
                var reviewvId = 1;
                foreach (RowReview item in panelcontent.Controls)
                {
                    var newv = item.GetData();
                    if (OverwriteVariableNames)
                    {
                        if (string.IsNullOrEmpty(newv.Title) || newv.Title == "N/A")
                        {
                            newv.Title = newv.Name;
                        }                  
                    }
                    result.Add(newv);
                    reviewvId++;
                }
            }
            return result;
        }
    }
}
