using T3ACS.Controls;
using T3ACS.Controls.Buttons;


namespace T3ACS.StepDefault
{
    public partial class FormAddCorrection : Form
    {
        public FormAddCorrection()
        {
            InitializeComponent();

            // Set up form properties
            this.BackColor = Color.FromArgb(6, 16, 20); // Dark theme background
            this.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);

            // Configure standard drag-and-drop file selectors
            ConfigureFileSelector(selectedFileLibrary, "Select Library File...");
            ConfigureFileSelector(selectedFileCalibration, "Select Calibration File...");

            // Configure standard parameter dropdowns
            ConfigureDropdown(cboMarkerID);
            ConfigureDropdown(cboReadingValue);
        }

        private void ConfigureFileSelector(SelectedFile fileSelector, string buttonText)
        {
            fileSelector.BackColorG = Color.FromArgb(7, 21, 29);
            fileSelector.BorderColorG = Color.FromArgb(14, 82, 98);
            fileSelector.BoderColorG = Color.FromArgb(14, 82, 98);
            fileSelector.HighlightColorG = Color.FromArgb(7, 21, 29);
            fileSelector.ForeColor = Color.White;

            if (fileSelector.Controls["buttonAdvance1"] is ButtonCustom btn)
            {
                btn.Texts = buttonText;
                btn.BackColor = Color.FromArgb(7, 21, 29);
                btn.BorderColorG = Color.FromArgb(14, 82, 98);
                btn.ForeColor = Color.FromArgb(0, 162, 177); // Cyan text
            }
            if (fileSelector.Controls["lblFileInput"] is TextBox txt)
            {
                txt.ForeColor = Color.FromArgb(130, 130, 130);
            }
        }

        private void ConfigureDropdown(SelectCustomD cbo)
        {
            cbo.BackColor = Color.FromArgb(21, 32, 39);
            cbo.BorderColor = Color.FromArgb(14, 82, 98);
            cbo.ForeColor = Color.White;
            cbo.ArrowColor = Color.FromArgb(130, 130, 130);

            foreach (Control child in cbo.Controls)
            {
                if (child.Name == "lblContent")
                {
                    child.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                    child.ForeColor = Color.FromArgb(130, 130, 130);
                    child.BackColor = Color.FromArgb(21, 32, 39);
                }
                else if (child.Name == "label2")
                {
                    child.BackColor = Color.FromArgb(21, 32, 39);
                }
            }

            cbo._EventSelect += (sender, e) =>
            {
                if (cbo.Controls["lblContent"] is Label lbl)
                {
                    if (!string.IsNullOrEmpty(lbl.Text) && lbl.Text != "Select parameter")
                    {
                        lbl.ForeColor = Color.White;
                    }
                    else
                    {
                        lbl.ForeColor = Color.FromArgb(130, 130, 130);
                    }
                }
            };
        }

        private void cboMarkerID_Load(object sender, EventArgs e)
        {

        }
    }
}
