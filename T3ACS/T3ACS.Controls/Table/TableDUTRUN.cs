using T3ACS.Model;
namespace T3ACS.Controls.Table
{
    public partial class TableDUTRUN : UserControl
    {
        public bool AutoHeight { get; set; } = false;

        public TableDUTRUN()
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

        public bool ReadOnly
        {
            get
            {
                if (panelcontent.Controls.Count > 0 && panelcontent.Controls[0] is RowDUTRUN row)
                {
                    return row.ReadOnly;
                }
                return false;
            }
            set
            {
                foreach (System.Windows.Forms.Control ctrl in panelcontent.Controls)
                {
                    if (ctrl is RowDUTRUN row)
                    {
                        row.ReadOnly = value;
                    }
                }
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
                    AddNewRow(
                        count++,
                        item.Name,
                        item.Title,
                        item.Value,
                        item.Unit,
                        item.Min,
                        item.Max,
                        item.Type,
                        item.TypeInput,
                        item.Required,
                        item.Report
                    );
                }
            }
            ResizeC();
        }

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

        public void AddNewRow(int no, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report)
        {
            RowDUTRUN row = new RowDUTRUN();
            int clientWidth = panel1.ClientSize.Width;
            if (clientWidth < 100) clientWidth = this.Width;
            row.Width = clientWidth - 2;
            row.LoadData(no, name, title, value, unit, min, max, type, typeInput, required, report);
            panelcontent.Controls.Add(row);
        }

        public List<ProcedureVariableViewModel> GetVariables()
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (panelcontent.Controls.Count > 0)
            {
                foreach (RowDUTRUN item in panelcontent.Controls)
                {
                    result.Add(item.GetData());
                }
            }
            return result;
        }

        public void SetVariableValue(string name, string value)
        {
            if (panelcontent.Controls.Count > 0)
            {
                foreach (RowDUTRUN item in panelcontent.Controls)
                {
                    if (item._name != null && item._name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        item.MeasuredValue = value;
                        break;
                    }
                }
            }
        }

        public bool ValidateInputs(out string errorMessage)
        {
            errorMessage = "";
            if (panelcontent.Controls.Count > 0)
            {
                int index = 1;
                foreach (RowDUTRUN item in panelcontent.Controls)
                {
                    if (!item.ValidateInput(out string rowError))
                    {
                        errorMessage = $"Row {index}: {rowError}";
                        return false;
                    }
                    index++;
                }
            }
            return true;
        }
    }
}
