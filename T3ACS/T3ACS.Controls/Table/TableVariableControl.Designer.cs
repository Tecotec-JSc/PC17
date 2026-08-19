using T3ACS.Controls.PanelCustoms;

namespace T3ACS.Controls
{
    partial class TableVariableControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableVariableControl));
            panelControl1 = new PanelCustomBorder();
            lblDefaultName = new Label();
            lblDefaultTitle = new Label();
            lblDefaultValue = new Label();
            lblDefaultUnit = new Label();
            lblDefaultMin = new Label();
            lblDefaultMax = new Label();
            lblDefaultType = new Label();
            lblDefaultTypeImport = new Label();
            lblDefaultRequired = new Label();
            lblDefaultReport = new Label();
            lblDefaultAction = new Label();
            panelTableBody = new FlowLayoutPanel();
            lblbtnCheckAll = new Label();
            panel1 = new PanelBorderRadiusCustom();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelControl1.BackColor = Color.FromArgb(243, 242, 241);
            panelControl1.BorderColor = Color.DarkGray;
            panelControl1.BorderSize = 1;
            panelControl1.Location = new Point(0, 0);
            panelControl1.Margin = new Padding(0);
            panelControl1.Name = "panelControl1";
            panelControl1.Padding = new Padding(2);
            panelControl1.Size = new Size(1072, 45);
            panelControl1.TabIndex = 1;
            // 
            // lblDefaultName
            // 
            lblDefaultName.AutoSize = true;
            lblDefaultName.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultName.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultName.Location = new Point(47, 12);
            lblDefaultName.Name = "lblDefaultName";
            lblDefaultName.Size = new Size(23, 19);
            lblDefaultName.TabIndex = 30;
            lblDefaultName.Text = "ID";
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.AutoSize = true;
            lblDefaultTitle.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTitle.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultTitle.Location = new Point(148, 12);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(49, 19);
            lblDefaultTitle.TabIndex = 30;
            lblDefaultTitle.Text = "Name";
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.AutoSize = true;
            lblDefaultValue.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultValue.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultValue.Location = new Point(345, 12);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(45, 19);
            lblDefaultValue.TabIndex = 30;
            lblDefaultValue.Text = "Value";
            // 
            // lblDefaultUnit
            // 
            lblDefaultUnit.AutoSize = true;
            lblDefaultUnit.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultUnit.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultUnit.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultUnit.Location = new Point(449, 12);
            lblDefaultUnit.Name = "lblDefaultUnit";
            lblDefaultUnit.Size = new Size(36, 19);
            lblDefaultUnit.TabIndex = 30;
            lblDefaultUnit.Text = "Unit";
            // 
            // lblDefaultMin
            // 
            lblDefaultMin.AutoSize = true;
            lblDefaultMin.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultMin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMin.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultMin.Location = new Point(525, 12);
            lblDefaultMin.Name = "lblDefaultMin";
            lblDefaultMin.Size = new Size(34, 19);
            lblDefaultMin.TabIndex = 30;
            lblDefaultMin.Text = "Min";
            // 
            // lblDefaultMax
            // 
            lblDefaultMax.AutoSize = true;
            lblDefaultMax.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultMax.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMax.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultMax.Location = new Point(576, 12);
            lblDefaultMax.Name = "lblDefaultMax";
            lblDefaultMax.Size = new Size(38, 19);
            lblDefaultMax.TabIndex = 30;
            lblDefaultMax.Text = "Max";
            // 
            // lblDefaultType
            // 
            lblDefaultType.AutoSize = true;
            lblDefaultType.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultType.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultType.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultType.Location = new Point(653, 12);
            lblDefaultType.Name = "lblDefaultType";
            lblDefaultType.Size = new Size(41, 19);
            lblDefaultType.TabIndex = 30;
            lblDefaultType.Text = "Type";
            // 
            // lblDefaultTypeImport
            // 
            lblDefaultTypeImport.AutoSize = true;
            lblDefaultTypeImport.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultTypeImport.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTypeImport.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultTypeImport.Location = new Point(754, 12);
            lblDefaultTypeImport.Name = "lblDefaultTypeImport";
            lblDefaultTypeImport.Size = new Size(48, 19);
            lblDefaultTypeImport.TabIndex = 30;
            lblDefaultTypeImport.Text = "Mode";
            // 
            // lblDefaultRequired
            // 
            lblDefaultRequired.AutoSize = true;
            lblDefaultRequired.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultRequired.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultRequired.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultRequired.Location = new Point(860, 12);
            lblDefaultRequired.Name = "lblDefaultRequired";
            lblDefaultRequired.Size = new Size(70, 19);
            lblDefaultRequired.TabIndex = 30;
            lblDefaultRequired.Text = "Required";
            // 
            // lblDefaultReport
            // 
            lblDefaultReport.AutoSize = true;
            lblDefaultReport.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultReport.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultReport.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultReport.Location = new Point(924, 12);
            lblDefaultReport.Name = "lblDefaultReport";
            lblDefaultReport.Size = new Size(55, 19);
            lblDefaultReport.TabIndex = 30;
            lblDefaultReport.Text = "Report";
            // 
            // lblDefaultAction
            // 
            lblDefaultAction.AutoSize = true;
            lblDefaultAction.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultAction.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultAction.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultAction.Location = new Point(989, 12);
            lblDefaultAction.Name = "lblDefaultAction";
            lblDefaultAction.Size = new Size(52, 19);
            lblDefaultAction.TabIndex = 30;
            lblDefaultAction.Text = "Action";
            // 
            // panelTableBody
            // 
            panelTableBody.AutoScroll = true;
            panelTableBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTableBody.BackColor = Color.White;
            panelTableBody.FlowDirection = FlowDirection.TopDown;
            panelTableBody.Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelTableBody.ForeColor = Color.FromArgb(0, 32, 77);
            panelTableBody.Location = new Point(1, 0);
            panelTableBody.Margin = new Padding(0);
            panelTableBody.Name = "panelTableBody";
            panelTableBody.Size = new Size(1072, 215);
            panelTableBody.TabIndex = 31;
            panelTableBody.WrapContents = false;
            // 
            // lblbtnCheckAll
            // 
            lblbtnCheckAll.BackColor = Color.FromArgb(243, 242, 241);
            lblbtnCheckAll.Cursor = Cursors.Hand;
            lblbtnCheckAll.Image = (Image)resources.GetObject("lblbtnCheckAll.Image");
            lblbtnCheckAll.Location = new Point(3, 2);
            lblbtnCheckAll.Name = "lblbtnCheckAll";
            lblbtnCheckAll.Size = new Size(40, 40);
            lblbtnCheckAll.TabIndex = 32;
            lblbtnCheckAll.Click += lblbtnCheckAll_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColorG = Color.Empty;
            panel1.BorderColor = Color.DarkGray;
            panel1.BorderSize = 1;
            panel1.Controls.Add(panelTableBody);
            panel1.Location = new Point(0, 42);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.RadiusBottomLeft = 5;
            panel1.RadiusBottomRight = 5;
            panel1.RadiusTopLeft = 0;
            panel1.RadiusTopRight = 0;
            panel1.Size = new Size(1072, 218);
            panel1.TabIndex = 34;
            panel1.VerticalPoints = (List<int>)resources.GetObject("panel1.VerticalPoints");
            // 
            // TableVariableControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(lblbtnCheckAll);
            Controls.Add(lblDefaultAction);
            Controls.Add(lblDefaultReport);
            Controls.Add(lblDefaultRequired);
            Controls.Add(lblDefaultTypeImport);
            Controls.Add(lblDefaultType);
            Controls.Add(lblDefaultMin);
            Controls.Add(lblDefaultMax);
            Controls.Add(lblDefaultUnit);
            Controls.Add(lblDefaultValue);
            Controls.Add(lblDefaultTitle);
            Controls.Add(lblDefaultName);
            Controls.Add(panelControl1);
            Font = new Font("Segoe UI", 10.5F);
            Margin = new Padding(0);
            Name = "TableVariableControl";
            Size = new Size(1072, 260);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelCustomBorder panelControl1;
        private Label lblDefaultName;
        private Label lblDefaultTitle;
        private Label lblDefaultValue;
        private Label lblDefaultUnit;
        private Label lblDefaultMin;
        private Label lblDefaultMax;
        private Label lblDefaultType;
        private Label lblDefaultTypeImport;
        private Label lblDefaultRequired;
        private Label lblDefaultReport;
        private Label lblDefaultAction;
        private FlowLayoutPanel panelTableBody;
        private Label lblbtnCheckAll;
        private PanelBorderRadiusCustom panel1;
    }
}
