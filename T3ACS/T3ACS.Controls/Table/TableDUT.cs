using T3ACS.Model;
namespace T3ACS.Controls.Table
{
    public partial class TableDUT : UserControl
    {
        public TableDUT()
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
                    AddNewRow(count++, item.ProcedureVariableId, item.Name, item.Title, item.Value, item.Unit, item.Min, item.Max, item.Type, item.TypeInput, item.Required, item.Report, false);
                }
            }
            ResizeC();
        }

        public bool AutoHeight { get; set; } = false;

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

        public void AddNewRow(int no, int id, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report, bool editrow)
        {
            RowDUT row = new RowDUT();
            int clientWidth = panel1.ClientSize.Width;
            if (clientWidth < 100) clientWidth = this.Width;
            row.Width = clientWidth - 2;
            row.LoadData(no, id, name, title, value, unit, min, max, type, typeInput, required, report, editrow);
            row._UpdateHeight += Row__UpdateHeight;
            row._SaveClick += Row__SaveClick;
            row._DeleteClick += Row__DeleteClick;
            row._CheckChange += Row__CheckChange;
            row._TextChanged += Row__CheckChange; // bubble lên _EventChange để form cha auto-save
            panelcontent.Controls.Add(row);
        }

        public int CountRowSelected()
        {
            int result = 0;
            if (panelcontent.Controls.Count > 0)
            {
                foreach (RowDUT item in panelcontent.Controls)
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

        private void Row__DeleteClick(object? sender, EventArgs e)
        {
            var row = sender as RowDUT;
            if (row != null)
            {
                panelcontent.Controls.Remove(row);
                ResizeC();
            }
        }

        public string _StrError = "";
        public event EventHandler _ShowError;
        public event EventHandler _EventChange;

        private void Row__SaveClick(object? sender, EventArgs e)
        {
            var row = sender as RowDUT;
            if (row != null)
            {
                _StrError = row._StrError;
                _ShowError?.Invoke(null, e);
            }
        }

        public void DeleteRowSelect()
        {
            if (panelcontent.Controls.Count > 0)
            {
                var toRemove = new List<RowDUT>();
                foreach (RowDUT item in panelcontent.Controls)
                {
                    if (item.chkReport.Checked)
                    {
                        toRemove.Add(item);
                    }
                }
                foreach (var item in toRemove)
                {
                    panelcontent.Controls.Remove(item);
                }
                ResizeC();
            }
        }

        public bool OverwriteVariableNames { get; set; } = true;

        public List<ProcedureVariableViewModel> GetVariables()
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (panelcontent.Controls.Count > 0)
            {
                var dutvId = 1;
                foreach (RowDUT item in panelcontent.Controls)
                {
                    var newv = item.GetData();
                    if (OverwriteVariableNames)
                    {
                        if (string.IsNullOrEmpty(newv.Title) || newv.Title == "N/A")
                        {
                            newv.Title = newv.Name;
                        }
                        newv.Name = "DUTVariable" + dutvId;
                    }
                    result.Add(newv);
                    dutvId++;
                }
            }
            return result;
        }

        //bool _checkAll;




        public bool CheckSave(out string mess)
        {
            mess = "";
            if (panelcontent.Controls.Count > 0)
            {
                int count = 1;
                foreach (RowDUT item in panelcontent.Controls)
                {
                    if (item.Editor)
                    {
                        mess = "Row " + count + " is being edited. Please complete the edit before proceeding to the next step.";
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }
    }
}
