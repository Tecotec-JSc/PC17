using T3ACS.Model;

namespace T3ACS.Controls.Table
{
    public partial class TableDefaultRUN : UserControl
    {
        public TableDefaultRUN()
        {
            InitializeComponent();
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panelcontent.FlowDirection = FlowDirection.TopDown;
            panelcontent.WrapContents = false;       
            panelcontent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            panelcontent.Controls.Clear();
            if (values != null && values.Count > 0)
            {
                int count = 1;
                foreach (var item in values)
                {
                    var strUnit = "N/A";
                    if(!string.IsNullOrEmpty(item.Unit)) strUnit = item.Unit;
                    var strRange = "N/A";
                    if (!string.IsNullOrEmpty(item.Min)&& !string.IsNullOrEmpty(item.Min))
                    {

                        if (double.TryParse(item.Min, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double min) && double.TryParse(item.Max, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double max) && min < max){
                            strRange= min + " to " + max;
                        }                        
                    }
                    AddNewRow(
                        count++,                       
                        item.Title,
                        item.Value,
                        strUnit,
                        strRange,
                        item.Type,
                        item.TypeInput,
                        item.Required,
                        item.Report
                    );
                }
            }
            ResizeC();
        }
        public int _MaxHeight { get; set; } = 300;
        //public void ResizeC()
        //{
        //    int totalHeight = 0;

        //    foreach (RowDefaultRUN row in panelcontent.Controls)
        //        totalHeight += row.Height;

        //    bool needScroll = totalHeight > _MaxHeight;

        //    panel1.AutoScroll = needScroll;
        //    panel1.Height = needScroll ? _MaxHeight : totalHeight;

        //    // Width thật của vùng hiển thị
        //    int width = panel1.DisplayRectangle.Width;

        //    panelcontent.Location = Point.Empty;
        //    panelcontent.Width = width-1;
        //    panelcontent.Height = totalHeight;

        //    foreach (RowDefaultRUN row in panelcontent.Controls)
        //        row.Width = width;

        //    this.Height = panel1.Height + panelBorderRadiusCustom1.Height;

        //    //var height = 01;
        //    //if (panelcontent.Controls.Count > 0)
        //    //{

        //    //    foreach (System.Windows.Forms.Control control in panelcontent.Controls)
        //    //    {
        //    //        height += control.Height;
        //    //    }
        //    //}
        //    //if (height > _MaxHeight)
        //    //{
        //    //    panelcontent.Width = this.Width - 20;
        //    //    foreach (RowDefaultRUN c in panelcontent.Controls)
        //    //    {
        //    //        c.Width = panelcontent.Width-2;
        //    //    }
        //    //    panelcontent.Height = height;
        //    //    panel1.Width = this.Width + 0;
        //    //    panel1.Height = _MaxHeight;

        //    //}
        //    //else
        //    //{
        //    //    panelcontent.Width = this.Width + 0;
        //    //    foreach (RowDefaultRUN c in panelcontent.Controls)
        //    //    {
        //    //        c.Width = panelcontent.Width;
        //    //    }
        //    //    panelcontent.Height = height;
        //    //    panel1.Height = height;
        //    //}
        //    //this.Height = panel1.Height + 43;
        //    //panel1.Invalidate();
        //}
        public void ResizeC()
        {
            int totalHeight = panelcontent.Controls.Cast<Control>().Sum(c => c.Height);

            bool needScroll = totalHeight > _MaxHeight;

            panel1.AutoScroll = needScroll;
            panel1.Height = needScroll ? _MaxHeight : totalHeight;

            // Chiều rộng thực tế
            int width = this.ClientSize.Width;

            if (needScroll)
                width -= SystemInformation.VerticalScrollBarWidth;

            panelcontent.SuspendLayout();

            panelcontent.Width = width;
            panelcontent.Height = totalHeight;

            foreach (RowDefaultRUN row in panelcontent.Controls)
                row.Width = width;

            panelcontent.ResumeLayout();

            this.Height = panel1.Height + 43;
        }
        public void AddNewRow(int no, string title, string value, string unit, string range, string type, string typeInput, bool required, bool report)
        {
            RowDefaultRUN row = new RowDefaultRUN();
            row.Width = this.Width;
            row.LoadData(no,  title, value, unit, range, type, typeInput, required, report);
            panelcontent.Controls.Add(row);
        }

        public List<ProcedureVariableViewModel> GetVariables()
        {
            List<ProcedureVariableViewModel> result = new List<ProcedureVariableViewModel>();
            if (panelcontent.Controls.Count > 0)
            {
                foreach (RowDefaultRUN item in panelcontent.Controls)
                {
                    result.Add(item.GetData());
                }
            }
            return result;
        }

        public bool ValidateInputs(out string errorMessage)
        {
            errorMessage = "";
            if (panelcontent.Controls.Count > 0)
            {
                int index = 1;
                foreach (RowDefaultRUN item in panelcontent.Controls)
                {
                  
                    if (!string.IsNullOrEmpty(item._typeInput)&&item._typeInput.Contains("Input"))
                    {
                        if (!item.ValidateInput(out string rowError))
                        {
                            errorMessage = $"Row {index}: {rowError}";
                            return false;
                        }
                    }
                
                    index++;
                }
            }
            return true;
        }
    }
}
