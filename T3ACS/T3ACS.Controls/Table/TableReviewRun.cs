using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls.Table
{
    public partial class TableReviewRun : UserControl
    {
        public TableReviewRun()
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
                    string rangeText = "N/A";
                    string cleanMin = item.Min?.Trim() ?? "";
                    string cleanMax = item.Max?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(cleanMin) && !string.IsNullOrEmpty(cleanMax) &&
                        cleanMin.ToUpper() != "N/A" && cleanMax.ToUpper() != "N/A" &&
                        !(cleanMin == "0" && cleanMax == "0"))
                    {
                        rangeText = $"{cleanMin} - {cleanMax}";
                    }

                    AddNewRow(count++, item.Title, item.Value, item.Unit, rangeText);
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

        public void AddNewRow(int no, string title, string value, string unit, string range)
        {
            RowReviewRun row = new RowReviewRun();
            int clientWidth = panel1.ClientSize.Width;
            if (clientWidth < 100) clientWidth = this.Width;
            row.Width = clientWidth - 2;
            row.LoadData(no, title, value, unit, range);
            panelcontent.Controls.Add(row);
        }
    }
}
