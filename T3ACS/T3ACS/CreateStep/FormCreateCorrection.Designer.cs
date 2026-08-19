namespace T3ACS.CreateStep
{
    partial class FormCreateCorrection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateCorrection));
            label1 = new Label();
            label2 = new Label();
            selectFileDll = new Controls.SelectedFile();
            label3 = new Label();
            selectFileCalibration = new Controls.SelectedFile();
            label4 = new Label();
            panelBorderRadiusCustom1 = new Controls.PanelBorderRadiusCustom();
            panelBorderRadiusCustom3 = new Controls.PanelBorderRadiusCustom();
            selectReadingValue = new Controls.SelectCustoms.SelectCustomAdd();
            label7 = new Label();
            panelBorderRadiusCustom2 = new Controls.PanelBorderRadiusCustom();
            selectMarkerId = new Controls.SelectCustoms.SelectCustomAdd();
            label6 = new Label();
            label8 = new Label();
            label5 = new Label();
            panelBorderRadiusCustom1.SuspendLayout();
            panelBorderRadiusCustom3.SuspendLayout();
            panelBorderRadiusCustom2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 11);
            label1.Name = "label1";
            label1.Size = new Size(71, 19);
            label1.TabIndex = 0;
            label1.Text = "Load Files";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label2.Location = new Point(11, 59);
            label2.Name = "label2";
            label2.Size = new Size(40, 19);
            label2.TabIndex = 0;
            label2.Text = "Path:";
            // 
            // selectFileDll
            // 
            selectFileDll.BackColor = Color.White;
            selectFileDll.BackColorG = Color.White;
            selectFileDll.BoderColorG = Color.DarkGray;
            selectFileDll.BorderColorG = Color.DarkGray;
            selectFileDll.BorderSize = 1;
            selectFileDll.ButtonText = "Select Library File...";
            selectFileDll.filter = "(*.DLL) | *.dll";
            selectFileDll.Font = new Font("Segoe UI", 10.5F);
            selectFileDll.HighlightColorG = Color.FromArgb(232, 232, 232);
            selectFileDll.Location = new Point(65, 45);
            selectFileDll.Margin = new Padding(3, 4, 3, 4);
            selectFileDll.Name = "selectFileDll";
            selectFileDll.RadiusBottomLeft = 5;
            selectFileDll.RadiusBottomRight = 5;
            selectFileDll.RadiusTopLeft = 5;
            selectFileDll.RadiusTopRight = 5;
            selectFileDll.Size = new Size(1019, 50);
            selectFileDll.TabIndex = 1;
            selectFileDll.TextButton = "Select Library File...";
            selectFileDll.TextDefault = "Or drag and drop a dll file here.";
            selectFileDll.Texts = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label3.Location = new Point(11, 119);
            label3.Name = "label3";
            label3.Size = new Size(40, 19);
            label3.TabIndex = 0;
            label3.Text = "Path:";
            // 
            // selectFileCalibration
            // 
            selectFileCalibration.BackColor = Color.White;
            selectFileCalibration.BackColorG = Color.White;
            selectFileCalibration.BoderColorG = Color.DarkGray;
            selectFileCalibration.BorderColorG = Color.DarkGray;
            selectFileCalibration.BorderSize = 1;
            selectFileCalibration.ButtonText = "Select Calibration File...";
            selectFileCalibration.filter = "";
            selectFileCalibration.Font = new Font("Segoe UI", 10.5F);
            selectFileCalibration.HighlightColorG = Color.FromArgb(232, 232, 232);
            selectFileCalibration.Location = new Point(65, 105);
            selectFileCalibration.Margin = new Padding(3, 4, 3, 4);
            selectFileCalibration.Name = "selectFileCalibration";
            selectFileCalibration.RadiusBottomLeft = 5;
            selectFileCalibration.RadiusBottomRight = 5;
            selectFileCalibration.RadiusTopLeft = 5;
            selectFileCalibration.RadiusTopRight = 5;
            selectFileCalibration.Size = new Size(1019, 50);
            selectFileCalibration.TabIndex = 1;
            selectFileCalibration.TextButton = "Select Calibration File...";
            selectFileCalibration.TextDefault = "Or drag and drop a file here.";
            selectFileCalibration.Texts = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 172);
            label4.Name = "label4";
            label4.Size = new Size(166, 19);
            label4.TabIndex = 0;
            label4.Text = "Configuration Correction";
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(panelBorderRadiusCustom3);
            panelBorderRadiusCustom1.Controls.Add(panelBorderRadiusCustom2);
            panelBorderRadiusCustom1.Controls.Add(label8);
            panelBorderRadiusCustom1.Controls.Add(label5);
            panelBorderRadiusCustom1.Location = new Point(12, 199);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(1072, 153);
            panelBorderRadiusCustom1.TabIndex = 2;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // panelBorderRadiusCustom3
            // 
            panelBorderRadiusCustom3.BackColor = Color.White;
            panelBorderRadiusCustom3.BackColorG = Color.Empty;
            panelBorderRadiusCustom3.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom3.BorderSize = 1;
            panelBorderRadiusCustom3.Controls.Add(selectReadingValue);
            panelBorderRadiusCustom3.Controls.Add(label7);
            panelBorderRadiusCustom3.Location = new Point(0, 101);
            panelBorderRadiusCustom3.Margin = new Padding(0);
            panelBorderRadiusCustom3.Name = "panelBorderRadiusCustom3";
            panelBorderRadiusCustom3.RadiusBottomLeft = 0;
            panelBorderRadiusCustom3.RadiusBottomRight = 0;
            panelBorderRadiusCustom3.RadiusTopLeft = 0;
            panelBorderRadiusCustom3.RadiusTopRight = 0;
            panelBorderRadiusCustom3.Size = new Size(1072, 52);
            panelBorderRadiusCustom3.TabIndex = 0;
            panelBorderRadiusCustom3.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom3.VerticalPoints");
            // 
            // selectReadingValue
            // 
            selectReadingValue.BackColor = Color.White;
            selectReadingValue.BorderColor = Color.DarkGray;
            selectReadingValue.BorderSize = 1;
            selectReadingValue.Font = new Font("Segoe UI", 10.5F);
            selectReadingValue.ForeColor = Color.FromArgb(130, 135, 137);
            selectReadingValue.Location = new Point(550, 11);
            selectReadingValue.Margin = new Padding(0);
            selectReadingValue.Name = "selectReadingValue";
            selectReadingValue.RadiusBottomLeft = 5;
            selectReadingValue.RadiusBottomRight = 5;
            selectReadingValue.RadiusTopLeft = 5;
            selectReadingValue.RadiusTopRight = 5;
            selectReadingValue.Size = new Size(512, 32);
            selectReadingValue.TabIndex = 1;
            selectReadingValue.TextAdd = "Add New Parameter...";
            selectReadingValue.Texts = "Select parameter";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label7.Location = new Point(17, 16);
            label7.Name = "label7";
            label7.Size = new Size(102, 19);
            label7.TabIndex = 0;
            label7.Text = "Reading Value ";
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColor = Color.White;
            panelBorderRadiusCustom2.BackColorG = Color.Empty;
            panelBorderRadiusCustom2.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(selectMarkerId);
            panelBorderRadiusCustom2.Controls.Add(label6);
            panelBorderRadiusCustom2.Location = new Point(0, 50);
            panelBorderRadiusCustom2.Margin = new Padding(0);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 0;
            panelBorderRadiusCustom2.RadiusBottomRight = 0;
            panelBorderRadiusCustom2.RadiusTopLeft = 0;
            panelBorderRadiusCustom2.RadiusTopRight = 0;
            panelBorderRadiusCustom2.Size = new Size(1072, 52);
            panelBorderRadiusCustom2.TabIndex = 0;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // selectMarkerId
            // 
            selectMarkerId.BackColor = Color.White;
            selectMarkerId.BorderColor = Color.DarkGray;
            selectMarkerId.BorderSize = 1;
            selectMarkerId.Font = new Font("Segoe UI", 10.5F);
            selectMarkerId.ForeColor = Color.FromArgb(130, 135, 137);
            selectMarkerId.Location = new Point(548, 9);
            selectMarkerId.Margin = new Padding(0);
            selectMarkerId.Name = "selectMarkerId";
            selectMarkerId.RadiusBottomLeft = 5;
            selectMarkerId.RadiusBottomRight = 5;
            selectMarkerId.RadiusTopLeft = 5;
            selectMarkerId.RadiusTopRight = 5;
            selectMarkerId.Size = new Size(514, 31);
            selectMarkerId.TabIndex = 3;
            selectMarkerId.TextAdd = "Add New Parameter...";
            selectMarkerId.Texts = "Select parameter";
            selectMarkerId._eventAddnew += selectMarkerId__eventAddnew;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label6.Location = new Point(14, 19);
            label6.Name = "label6";
            label6.Size = new Size(71, 19);
            label6.TabIndex = 0;
            label6.Text = "Marker ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(547, 15);
            label8.Name = "label8";
            label8.Size = new Size(84, 19);
            label8.TabIndex = 0;
            label8.Text = "Mapping To";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 15);
            label5.Name = "label5";
            label5.Size = new Size(72, 19);
            label5.TabIndex = 0;
            label5.Text = "Parameter";
            // 
            // FormCreateCorrection
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1096, 519);
            Controls.Add(panelBorderRadiusCustom1);
            Controls.Add(selectFileCalibration);
            Controls.Add(label3);
            Controls.Add(selectFileDll);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCreateCorrection";
            Padding = new Padding(1);
            Text = "s";
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            panelBorderRadiusCustom3.ResumeLayout(false);
            panelBorderRadiusCustom3.PerformLayout();
            panelBorderRadiusCustom2.ResumeLayout(false);
            panelBorderRadiusCustom2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Controls.SelectedFile selectFileDll;
        private Label label3;
        private Controls.SelectedFile selectFileCalibration;
        private Label label4;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private Controls.SelectCustoms.SelectCustomAdd selectMarkerId;
        private Controls.SelectCustoms.SelectCustomAdd selectReadingValue;
    }
}