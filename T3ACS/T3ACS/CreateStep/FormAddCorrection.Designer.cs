namespace T3ACS.StepDefault
{
    partial class FormAddCorrection
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddCorrection));
            label1 = new Label();
            lblPath1 = new Label();
            lblPath2 = new Label();
            selectedFileLibrary = new Controls.SelectedFile();
            selectedFileCalibration = new Controls.SelectedFile();
            labelConfigCorrection = new Label();
            panelTable = new Controls.PanelBorderRadiusCustom();
            panelHeader = new Controls.PanelBorderRadiusCustom();
            lblHeaderParam = new Label();
            lblHeaderMapping = new Label();
            panelRow1 = new Controls.PanelBorderRadiusCustom();
            lblMarkerID = new Label();
            cboMarkerID = new Controls.SelectCustomD();
            panelRow2 = new Controls.PanelBorderRadiusCustom();
            lblReadingValue = new Label();
            cboReadingValue = new Controls.SelectCustomD();
            panelTable.SuspendLayout();
            panelHeader.SuspendLayout();
            panelRow1.SuspendLayout();
            panelRow2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(70, 19);
            label1.TabIndex = 0;
            label1.Text = "Load Files";
            // 
            // lblPath1
            // 
            lblPath1.AutoSize = true;
            lblPath1.ForeColor = Color.White;
            lblPath1.Location = new Point(12, 51);
            lblPath1.Name = "lblPath1";
            lblPath1.Size = new Size(40, 19);
            lblPath1.TabIndex = 1;
            lblPath1.Text = "Path:";
            // 
            // lblPath2
            // 
            lblPath2.AutoSize = true;
            lblPath2.ForeColor = Color.White;
            lblPath2.Location = new Point(12, 111);
            lblPath2.Name = "lblPath2";
            lblPath2.Size = new Size(40, 19);
            lblPath2.TabIndex = 3;
            lblPath2.Text = "Path:";
            // 
            // selectedFileLibrary
            // 
            selectedFileLibrary.BackColor = Color.FromArgb(6, 16, 20);
            selectedFileLibrary.BackColorG = Color.FromArgb(6, 16, 20);
            selectedFileLibrary.BoderColorG = Color.FromArgb(14, 82, 98);
            selectedFileLibrary.BorderColorG = Color.FromArgb(14, 82, 98);       
            selectedFileLibrary.BorderSize = 1;
            selectedFileLibrary.ButtonText = "Select Library File...";
            selectedFileLibrary.Font = new Font("Segoe UI", 10.5F);
            selectedFileLibrary.ForeColor = Color.White;
            selectedFileLibrary.HighlightColorG = Color.FromArgb(6, 47, 56);
            selectedFileLibrary.Location = new Point(60, 40);
            selectedFileLibrary.Margin = new Padding(3, 4, 3, 4);
            selectedFileLibrary.Name = "selectedFileLibrary";
            selectedFileLibrary.RadiusBottomLeft = 5;
            selectedFileLibrary.RadiusBottomRight = 5;
            selectedFileLibrary.RadiusTopLeft = 5;
            selectedFileLibrary.RadiusTopRight = 5;
            selectedFileLibrary.Size = new Size(1024, 53);
            selectedFileLibrary.TabIndex = 2;
            selectedFileLibrary.Texts = "";
            // 
            // selectedFileCalibration
            // 
            selectedFileCalibration.BackColor = Color.FromArgb(6, 16, 20);
            selectedFileCalibration.BackColorG = Color.FromArgb(6, 16, 20);
            selectedFileCalibration.BoderColorG = Color.FromArgb(14, 82, 98);
            selectedFileCalibration.BorderColorG = Color.FromArgb(14, 82, 98);

            selectedFileCalibration.BorderSize = 1;
            selectedFileCalibration.ButtonText = "Select calibration file";
            selectedFileCalibration.Font = new Font("Segoe UI", 10.5F);
            selectedFileCalibration.ForeColor = Color.White;
            selectedFileCalibration.HighlightColorG = Color.FromArgb(6, 47, 56);
            selectedFileCalibration.Location = new Point(60, 100);
            selectedFileCalibration.Margin = new Padding(3, 4, 3, 4);
            selectedFileCalibration.Name = "selectedFileCalibration";
            selectedFileCalibration.RadiusBottomLeft = 5;
            selectedFileCalibration.RadiusBottomRight = 5;
            selectedFileCalibration.RadiusTopLeft = 5;
            selectedFileCalibration.RadiusTopRight = 5;
            selectedFileCalibration.Size = new Size(1024, 53);
            selectedFileCalibration.TabIndex = 4;
            selectedFileCalibration.Texts = "";
            // 
            // labelConfigCorrection
            // 
            labelConfigCorrection.AutoSize = true;
            labelConfigCorrection.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            labelConfigCorrection.ForeColor = Color.White;
            labelConfigCorrection.Location = new Point(12, 170);
            labelConfigCorrection.Name = "labelConfigCorrection";
            labelConfigCorrection.Size = new Size(180, 20);
            labelConfigCorrection.TabIndex = 5;
            labelConfigCorrection.Text = "Configuration Correction";
            // 
            // panelTable
            // 
            panelTable.BackColorG = Color.Empty;
            panelTable.BorderColor = Color.FromArgb(14, 82, 98);
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(panelHeader);
            panelTable.Controls.Add(panelRow1);
            panelTable.Controls.Add(panelRow2);
            panelTable.Location = new Point(12, 204);
            panelTable.Name = "panelTable";
            panelTable.RadiusBottomLeft = 5;
            panelTable.RadiusBottomRight = 5;
            panelTable.RadiusTopLeft = 5;
            panelTable.RadiusTopRight = 5;
            panelTable.Size = new Size(1072, 140);
            panelTable.TabIndex = 6;
            panelTable.VerticalPoints = (List<int>)resources.GetObject("panelTable.VerticalPoints");
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(14, 82, 98);
            panelHeader.BackColorG = Color.FromArgb(6, 47, 56);
            panelHeader.BorderColor = Color.FromArgb(14, 82, 98);
            panelHeader.BorderSize = 1;
            panelHeader.Controls.Add(lblHeaderParam);
            panelHeader.Controls.Add(lblHeaderMapping);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.RadiusBottomLeft = 0;
            panelHeader.RadiusBottomRight = 0;
            panelHeader.RadiusTopLeft = 5;
            panelHeader.RadiusTopRight = 5;
            panelHeader.Size = new Size(1072, 40);
            panelHeader.TabIndex = 0;
            panelHeader.VerticalPoints = (List<int>)resources.GetObject("panelHeader.VerticalPoints");
            // 
            // lblHeaderParam
            // 
            lblHeaderParam.AutoSize = true;
            lblHeaderParam.BackColor = Color.Transparent;
            lblHeaderParam.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblHeaderParam.ForeColor = Color.White;
            lblHeaderParam.Location = new Point(16, 11);
            lblHeaderParam.Name = "lblHeaderParam";
            lblHeaderParam.Size = new Size(80, 19);
            lblHeaderParam.TabIndex = 0;
            lblHeaderParam.Text = "Parameter";
            // 
            // lblHeaderMapping
            // 
            lblHeaderMapping.AutoSize = true;
            lblHeaderMapping.BackColor = Color.Transparent;
            lblHeaderMapping.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblHeaderMapping.ForeColor = Color.White;
            lblHeaderMapping.Location = new Point(516, 11);
            lblHeaderMapping.Name = "lblHeaderMapping";
            lblHeaderMapping.Size = new Size(89, 19);
            lblHeaderMapping.TabIndex = 1;
            lblHeaderMapping.Text = "Mapping To";
            // 
            // panelRow1
            // 
            panelRow1.BackColorG = Color.Empty;
            panelRow1.BorderColor = Color.FromArgb(14, 82, 98);
            panelRow1.BorderSize = 1;
            panelRow1.Controls.Add(lblMarkerID);
            panelRow1.Controls.Add(cboMarkerID);
            panelRow1.Location = new Point(0, 40);
            panelRow1.Name = "panelRow1";
            panelRow1.RadiusBottomLeft = 0;
            panelRow1.RadiusBottomRight = 0;
            panelRow1.RadiusTopLeft = 0;
            panelRow1.RadiusTopRight = 0;
            panelRow1.Size = new Size(1072, 50);
            panelRow1.TabIndex = 1;
            panelRow1.VerticalPoints = (List<int>)resources.GetObject("panelRow1.VerticalPoints");
            // 
            // lblMarkerID
            // 
            lblMarkerID.AutoSize = true;
            lblMarkerID.Font = new Font("Segoe UI", 10.5F);
            lblMarkerID.ForeColor = Color.White;
            lblMarkerID.Location = new Point(16, 14);
            lblMarkerID.Name = "lblMarkerID";
            lblMarkerID.Size = new Size(71, 19);
            lblMarkerID.TabIndex = 0;
            lblMarkerID.Text = "Marker ID";
            // 
            // cboMarkerID
            // 
            cboMarkerID.ArrowColor = Color.White;
            cboMarkerID.BackColor = Color.FromArgb(56, 58, 67);
            cboMarkerID.BorderColor = Color.DarkGray;
            cboMarkerID.BorderSize = 1;
            cboMarkerID.Font = new Font("Segoe UI", 10.5F);
            cboMarkerID.ForeColor = Color.White;
            cboMarkerID.Location = new Point(516, 5);
            cboMarkerID.Margin = new Padding(0);
            cboMarkerID.Name = "cboMarkerID";
            cboMarkerID.RadiusBottomLeft = 5;
            cboMarkerID.RadiusBottomRight = 5;
            cboMarkerID.RadiusTopLeft = 5;
            cboMarkerID.RadiusTopRight = 5;
            cboMarkerID.SelectedIndex = -1;
            cboMarkerID.ShowArrow = true;
            cboMarkerID.Size = new Size(540, 40);
            cboMarkerID.TabIndex = 1;
            cboMarkerID.Texts = "Select parameter";
            cboMarkerID.Load += cboMarkerID_Load;
            // 
            // panelRow2
            // 
            panelRow2.BackColorG = Color.Empty;
            panelRow2.BorderColor = Color.FromArgb(14, 82, 98);
            panelRow2.BorderSize = 1;
            panelRow2.Controls.Add(lblReadingValue);
            panelRow2.Controls.Add(cboReadingValue);
            panelRow2.Location = new Point(0, 90);
            panelRow2.Name = "panelRow2";
            panelRow2.RadiusBottomLeft = 5;
            panelRow2.RadiusBottomRight = 5;
            panelRow2.RadiusTopLeft = 0;
            panelRow2.RadiusTopRight = 0;
            panelRow2.Size = new Size(1072, 50);
            panelRow2.TabIndex = 2;
            panelRow2.VerticalPoints = (List<int>)resources.GetObject("panelRow2.VerticalPoints");
            // 
            // lblReadingValue
            // 
            lblReadingValue.AutoSize = true;
            lblReadingValue.Font = new Font("Segoe UI", 10.5F);
            lblReadingValue.ForeColor = Color.White;
            lblReadingValue.Location = new Point(16, 14);
            lblReadingValue.Name = "lblReadingValue";
            lblReadingValue.Size = new Size(95, 19);
            lblReadingValue.TabIndex = 0;
            lblReadingValue.Text = "Reading Value";
            // 
            // cboReadingValue
            // 
            cboReadingValue.ArrowColor = Color.White;
            cboReadingValue.BackColor = Color.FromArgb(56, 58, 67);
            cboReadingValue.BorderColor = Color.DarkGray;
            cboReadingValue.BorderSize = 1;
            cboReadingValue.Font = new Font("Segoe UI", 10.5F);
            cboReadingValue.ForeColor = Color.White;
            cboReadingValue.Location = new Point(516, 6);
            cboReadingValue.Margin = new Padding(0);
            cboReadingValue.Name = "cboReadingValue";
            cboReadingValue.RadiusBottomLeft = 5;
            cboReadingValue.RadiusBottomRight = 5;
            cboReadingValue.RadiusTopLeft = 5;
            cboReadingValue.RadiusTopRight = 5;
            cboReadingValue.SelectedIndex = -1;
            cboReadingValue.ShowArrow = true;
            cboReadingValue.Size = new Size(540, 40);
            cboReadingValue.TabIndex = 1;
            cboReadingValue.Texts = "Select parameter";
            // 
            // FormAddCorrection
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 32, 39);
            ClientSize = new Size(1096, 512);
            Controls.Add(label1);
            Controls.Add(lblPath1);
            Controls.Add(selectedFileLibrary);
            Controls.Add(lblPath2);
            Controls.Add(selectedFileCalibration);
            Controls.Add(labelConfigCorrection);
            Controls.Add(panelTable);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAddCorrection";
            Text = "FormAddCorrection";
            panelTable.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelRow1.ResumeLayout(false);
            panelRow1.PerformLayout();
            panelRow2.ResumeLayout(false);
            panelRow2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblPath1;
        private Label lblPath2;
        private T3ACS.Controls.SelectedFile selectedFileLibrary;
        private T3ACS.Controls.SelectedFile selectedFileCalibration;
        private Label labelConfigCorrection;
        private T3ACS.Controls.PanelBorderRadiusCustom panelTable;
        private T3ACS.Controls.PanelBorderRadiusCustom panelHeader;
        private Label lblHeaderParam;
        private Label lblHeaderMapping;
        private T3ACS.Controls.PanelBorderRadiusCustom panelRow1;
        private Label lblMarkerID;
        private T3ACS.Controls.SelectCustomD cboMarkerID;
        private T3ACS.Controls.PanelBorderRadiusCustom panelRow2;
        private Label lblReadingValue;
        private T3ACS.Controls.SelectCustomD cboReadingValue;
    }
}