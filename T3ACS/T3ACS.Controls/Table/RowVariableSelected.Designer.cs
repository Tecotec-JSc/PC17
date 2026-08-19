namespace T3ACS.Controls.Table
{
    partial class RowVariableSelected
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowVariableSelected));
            panelRowSelected = new PanelBorderRadiusCustom();
            btnRemove = new Label();
            btnSave = new Label();
            btnEdit = new Label();
            txtSizeSValue = new RJTextBox32();
            txtSizeSTitle = new RJTextBox32();
            lblSizeSReport = new Label();
            lblSizeSRequired = new Label();
            lblSizeSMax = new Label();
            lblSizeSMin = new Label();
            lblSizeSValue = new Label();
            lblSizeSTitle = new Label();
            lblSizeSName = new Label();
            panelRowSelected.SuspendLayout();
            SuspendLayout();
            // 
            // panelRowSelected
            // 
            panelRowSelected.BackColorG = Color.White;
            panelRowSelected.BorderColor = Color.DarkGray;
            panelRowSelected.BorderSize = 1;
            panelRowSelected.Controls.Add(btnRemove);
            panelRowSelected.Controls.Add(btnSave);
            panelRowSelected.Controls.Add(btnEdit);
            panelRowSelected.Controls.Add(txtSizeSValue);
            panelRowSelected.Controls.Add(txtSizeSTitle);
            panelRowSelected.Controls.Add(lblSizeSReport);
            panelRowSelected.Controls.Add(lblSizeSRequired);
            panelRowSelected.Controls.Add(lblSizeSMax);
            panelRowSelected.Controls.Add(lblSizeSMin);
            panelRowSelected.Controls.Add(lblSizeSValue);
            panelRowSelected.Controls.Add(lblSizeSTitle);
            panelRowSelected.Controls.Add(lblSizeSName);
            panelRowSelected.Dock = DockStyle.Fill;
            panelRowSelected.Location = new Point(0, 0);
            panelRowSelected.Margin = new Padding(0);
            panelRowSelected.Name = "panelRowSelected";
            panelRowSelected.RadiusBottomLeft = 5;
            panelRowSelected.RadiusBottomRight = 5;
            panelRowSelected.RadiusTopLeft = 0;
            panelRowSelected.RadiusTopRight = 0;
            panelRowSelected.Size = new Size(1024, 42);
            panelRowSelected.TabIndex = 0;
            panelRowSelected.VerticalPoints = (List<int>)resources.GetObject("panelRowSelected.VerticalPoints");
            panelRowSelected.Paint += panelRowSelected_Paint;
            // 
            // btnRemove
            // 
            btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
            btnRemove.Location = new Point(936, 10);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(20, 20);
            btnRemove.TabIndex = 2;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnSave
            // 
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(907, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(20, 20);
            btnSave.TabIndex = 2;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.Location = new Point(907, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(20, 20);
            btnEdit.TabIndex = 2;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtSizeSValue
            // 
            txtSizeSValue.BackColor = Color.White;
            txtSizeSValue.BorderColor = Color.DarkGray;
            txtSizeSValue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtSizeSValue.BorderRadius = 5;
            txtSizeSValue.BorderSize = 1;
            txtSizeSValue.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSizeSValue.Location = new Point(319, 5);
            txtSizeSValue.Margin = new Padding(4);
            txtSizeSValue.Multiline = false;
            txtSizeSValue.Name = "txtSizeSValue";
            txtSizeSValue.Padding = new Padding(10, 7, 10, 7);
            txtSizeSValue.PasswordChar = false;
            txtSizeSValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtSizeSValue.PlaceholderText = "";
            txtSizeSValue.ReadOnly = false;
            txtSizeSValue.Size = new Size(138, 32);
            txtSizeSValue.TabIndex = 1;
            txtSizeSValue.Texts = "";
            txtSizeSValue.UnderlinedStyle = false;
            // 
            // txtSizeSTitle
            // 
            txtSizeSTitle.BackColor = Color.White;
            txtSizeSTitle.BorderColor = Color.DarkGray;
            txtSizeSTitle.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtSizeSTitle.BorderRadius = 5;
            txtSizeSTitle.BorderSize = 1;
            txtSizeSTitle.Font = new Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSizeSTitle.Location = new Point(5, 5);
            txtSizeSTitle.Margin = new Padding(4);
            txtSizeSTitle.Multiline = false;
            txtSizeSTitle.Name = "txtSizeSTitle";
            txtSizeSTitle.Padding = new Padding(10, 7, 10, 7);
            txtSizeSTitle.PasswordChar = false;
            txtSizeSTitle.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtSizeSTitle.PlaceholderText = "";
            txtSizeSTitle.ReadOnly = false;
            txtSizeSTitle.Size = new Size(136, 32);
            txtSizeSTitle.TabIndex = 1;
            txtSizeSTitle.Texts = "";
            txtSizeSTitle.UnderlinedStyle = false;
            // 
            // lblSizeSReport
            // 
            lblSizeSReport.Location = new Point(812, 10);
            lblSizeSReport.Name = "lblSizeSReport";
            lblSizeSReport.Size = new Size(101, 25);
            lblSizeSReport.TabIndex = 0;
            // 
            // lblSizeSRequired
            // 
            lblSizeSRequired.Image = Properties.Resources.IconCheckboxNo;
            lblSizeSRequired.Location = new Point(702, 10);
            lblSizeSRequired.Name = "lblSizeSRequired";
            lblSizeSRequired.Size = new Size(100, 25);
            lblSizeSRequired.TabIndex = 0;
            // 
            // lblSizeSMax
            // 
            lblSizeSMax.Location = new Point(584, 10);
            lblSizeSMax.Name = "lblSizeSMax";
            lblSizeSMax.Size = new Size(108, 25);
            lblSizeSMax.TabIndex = 0;
            // 
            // lblSizeSMin
            // 
            lblSizeSMin.Location = new Point(468, 10);
            lblSizeSMin.Name = "lblSizeSMin";
            lblSizeSMin.Size = new Size(106, 25);
            lblSizeSMin.TabIndex = 0;
            // 
            // lblSizeSValue
            // 
            lblSizeSValue.Location = new Point(319, 10);
            lblSizeSValue.Name = "lblSizeSValue";
            lblSizeSValue.Size = new Size(139, 25);
            lblSizeSValue.TabIndex = 0;
            // 
            // lblSizeSTitle
            // 
            lblSizeSTitle.Location = new Point(173, 10);
            lblSizeSTitle.Name = "lblSizeSTitle";
            lblSizeSTitle.Size = new Size(136, 25);
            lblSizeSTitle.TabIndex = 0;
            // 
            // lblSizeSName
            // 
            lblSizeSName.Location = new Point(5, 10);
            lblSizeSName.Name = "lblSizeSName";
            lblSizeSName.Size = new Size(157, 25);
            lblSizeSName.TabIndex = 0;
            // 
            // RowVariableSelected
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelRowSelected);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(0);
            Name = "RowVariableSelected";
            Size = new Size(1024, 42);
            panelRowSelected.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelRowSelected;
        private Label lblSizeSName;
        private Label lblSizeSValue;
        private Label lblSizeSTitle;
        private Label lblSizeSReport;
        private Label lblSizeSRequired;
        private Label lblSizeSMax;
        private Label lblSizeSMin;
        private RJTextBox32 txtSizeSTitle;
        private RJTextBox32 txtSizeSValue;
        private Label btnRemove;
        private Label btnSave;
        private Label btnEdit;
    }
}
