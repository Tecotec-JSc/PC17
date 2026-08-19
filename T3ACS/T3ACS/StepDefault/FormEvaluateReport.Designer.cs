namespace T3ACS.StepDefault
{
    partial class FormEvaluateReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvaluateReport));
            panelForm = new Panel();
            panelString = new Controls.PanelBorderRadiusCustom();
            chkPDFReport = new Controls.CheckBoxDUT();
            ButtonCustom1 = new Controls.Buttons.ButtonCustom();
            txtReportDate = new Controls.RJTextBox32();
            txtOutputPath = new Controls.RJTextBox32();
            txtReportName = new Controls.RJTextBox32();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label6 = new Label();
            label4 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelBorderRadiusCustom1 = new Controls.PanelBorderRadiusCustom();
            rtbNote = new Controls.RJEditor();
            panelHold = new Panel();
            panelStickBottom = new Panel();
            label11 = new Label();
            btnExport = new Controls.ButtonIconLable();
            btnFailed = new Controls.ButtonIconLable();
            btnPass = new Controls.ButtonIconLable();
            btnQuit = new Controls.ButtonControl();
            panelControlAll1 = new Controls.PanelControlAll();
            panelForm.SuspendLayout();
            panelString.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            panelStickBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelForm
            // 
            panelForm.Controls.Add(panelString);
            panelForm.Controls.Add(panelBorderRadiusCustom1);
            panelForm.Controls.Add(panelHold);
            panelForm.Controls.Add(panelStickBottom);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1118, 804);
            panelForm.TabIndex = 19;
            // 
            // panelString
            // 
            panelString.BackColorG = Color.Empty;
            panelString.BorderColor = Color.FromArgb(14, 82, 98);
            panelString.BorderSize = 1;
            panelString.Controls.Add(chkPDFReport);
            panelString.Controls.Add(ButtonCustom1);
            panelString.Controls.Add(txtReportDate);
            panelString.Controls.Add(txtOutputPath);
            panelString.Controls.Add(txtReportName);
            panelString.Controls.Add(label7);
            panelString.Controls.Add(label5);
            panelString.Controls.Add(label3);
            panelString.Controls.Add(label6);
            panelString.Controls.Add(label4);
            panelString.Controls.Add(label8);
            panelString.Controls.Add(label2);
            panelString.Controls.Add(label1);
            panelString.Location = new Point(12, 184);
            panelString.Name = "panelString";
            panelString.RadiusBottomLeft = 5;
            panelString.RadiusBottomRight = 5;
            panelString.RadiusTopLeft = 5;
            panelString.RadiusTopRight = 5;
            panelString.Size = new Size(1096, 545);
            panelString.TabIndex = 20;
            panelString.VerticalPoints = (List<int>)resources.GetObject("panelString.VerticalPoints");
            // 
            // chkPDFReport
            // 
            chkPDFReport.BoxBackCheckColor = Color.White;
            chkPDFReport.BoxBackColor = Color.White;
            chkPDFReport.BoxBorderColor = Color.DarkGray;
            chkPDFReport.BoxSize = 20;
            chkPDFReport.CheckColor = Color.FromArgb(0, 82, 130);
            chkPDFReport.Location = new Point(14, 204);
            chkPDFReport.Name = "chkPDFReport";
            chkPDFReport.Size = new Size(22, 22);
            chkPDFReport.TabIndex = 36;
            chkPDFReport.UseVisualStyleBackColor = true;
            // 
            // ButtonCustom1
            // 
            ButtonCustom1.BackColor = Color.White;
            ButtonCustom1.BackColorG = Color.FromArgb(232, 232, 232);
            ButtonCustom1.BorderColorG = Color.DarkGray;
            ButtonCustom1.BorderSize = 1;
            ButtonCustom1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.ForeColor = Color.FromArgb(0, 32, 77);
            ButtonCustom1.ForeColorG = Color.FromArgb(0, 32, 77);
            ButtonCustom1.HoverG = false;
            ButtonCustom1.HoverColor = Color.Empty;
            ButtonCustom1.iConLocation = new Point(11, 5);
            ButtonCustom1.ImageAd = null;
            ButtonCustom1.Location = new Point(422, 156);
            ButtonCustom1.Name = "ButtonCustom1";
            ButtonCustom1.RadiusBottomLeft = 5;
            ButtonCustom1.RadiusBottomRight = 5;
            ButtonCustom1.RadiusTopLeft = 5;
            ButtonCustom1.RadiusTopRight = 5;
            ButtonCustom1.Size = new Size(120, 32);
            ButtonCustom1.TabIndex = 35;
            ButtonCustom1.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCustom1.TextLocation = new Point(35, 4);
            ButtonCustom1.Texts = "Browse";
            ButtonCustom1._EventSelect += ButtonCustom1__EventSelect;
            // 
            // txtReportDate
            // 
            txtReportDate.BackColor = Color.White;
            txtReportDate.BorderColor = Color.DarkGray;
            txtReportDate.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtReportDate.BorderRadius = 5;
            txtReportDate.BorderSize = 1;
            txtReportDate.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReportDate.Location = new Point(557, 155);
            txtReportDate.Margin = new Padding(4);
            txtReportDate.Multiline = false;
            txtReportDate.Name = "txtReportDate";
            txtReportDate.Padding = new Padding(10, 7, 10, 7);
            txtReportDate.PasswordChar = false;
            txtReportDate.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtReportDate.PlaceholderText = "dd/MM/yyyy";
            txtReportDate.ReadOnly = false;
            txtReportDate.Size = new Size(529, 32);
            txtReportDate.TabIndex = 33;
            txtReportDate.Texts = "";
            txtReportDate.UnderlinedStyle = false;
            // 
            // txtOutputPath
            // 
            txtOutputPath.BackColor = Color.White;
            txtOutputPath.BorderColor = Color.DarkGray;
            txtOutputPath.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtOutputPath.BorderRadius = 5;
            txtOutputPath.BorderSize = 1;
            txtOutputPath.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutputPath.Location = new Point(14, 155);
            txtOutputPath.Margin = new Padding(4);
            txtOutputPath.Multiline = false;
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Padding = new Padding(10, 7, 10, 7);
            txtOutputPath.PasswordChar = false;
            txtOutputPath.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtOutputPath.PlaceholderText = "";
            txtOutputPath.ReadOnly = false;
            txtOutputPath.Size = new Size(400, 32);
            txtOutputPath.TabIndex = 34;
            txtOutputPath.Texts = "";
            txtOutputPath.UnderlinedStyle = false;
            // 
            // txtReportName
            // 
            txtReportName.BackColor = Color.White;
            txtReportName.BorderColor = Color.DarkGray;
            txtReportName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtReportName.BorderRadius = 5;
            txtReportName.BorderSize = 1;
            txtReportName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReportName.Location = new Point(14, 81);
            txtReportName.Margin = new Padding(4);
            txtReportName.Multiline = false;
            txtReportName.Name = "txtReportName";
            txtReportName.Padding = new Padding(10, 7, 10, 7);
            txtReportName.PasswordChar = false;
            txtReportName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtReportName.PlaceholderText = "";
            txtReportName.ReadOnly = false;
            txtReportName.Size = new Size(1072, 32);
            txtReportName.TabIndex = 32;
            txtReportName.Texts = "";
            txtReportName.UnderlinedStyle = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(641, 124);
            label7.Name = "label7";
            label7.Size = new Size(15, 19);
            label7.TabIndex = 29;
            label7.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(106, 124);
            label5.Name = "label5";
            label5.Size = new Size(15, 19);
            label5.TabIndex = 30;
            label5.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(110, 50);
            label3.Name = "label3";
            label3.Size = new Size(15, 19);
            label3.TabIndex = 31;
            label3.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(3, 5, 51);
            label6.Location = new Point(557, 124);
            label6.Name = "label6";
            label6.Size = new Size(84, 19);
            label6.TabIndex = 24;
            label6.Text = "Report Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(3, 5, 51);
            label4.Location = new Point(12, 124);
            label4.Name = "label4";
            label4.Size = new Size(86, 19);
            label4.TabIndex = 25;
            label4.Text = "Output Path";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(3, 5, 51);
            label8.Location = new Point(42, 204);
            label8.Name = "label8";
            label8.Size = new Size(140, 19);
            label8.TabIndex = 26;
            label8.Text = "Generate PDF Report";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(3, 5, 51);
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(92, 19);
            label2.TabIndex = 27;
            label2.Text = "Report Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 5, 51);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(142, 19);
            label1.TabIndex = 28;
            label1.Text = "Report Configuration";
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(14, 82, 98);
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(rtbNote);
            panelBorderRadiusCustom1.Location = new Point(12, 12);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(1096, 156);
            panelBorderRadiusCustom1.TabIndex = 19;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // rtbNote
            // 
            rtbNote.BackColor = Color.White;
            rtbNote.BorderColor = Color.DarkGray;
            rtbNote.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rtbNote.BorderRadius = 5;
            rtbNote.BorderSize = 1;
            rtbNote.Location = new Point(12, 12);
            rtbNote.Name = "rtbNote";
            rtbNote.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rtbNote.PlaceholderText = "Notes";
            rtbNote.RadiusBottomLeft = 5;
            rtbNote.RadiusBottomRight = 5;
            rtbNote.RadiusTopLeft = 5;
            rtbNote.RadiusTopRight = 5;
            rtbNote.Size = new Size(1072, 132);
            rtbNote.TabIndex = 2;
            rtbNote.Texts = "";
            rtbNote.UnderlinedStyle = false;
            // 
            // panelHold
            // 
            panelHold.Location = new Point(12, 735);
            panelHold.Name = "panelHold";
            panelHold.Size = new Size(13, 60);
            panelHold.TabIndex = 18;
            // 
            // panelStickBottom
            // 
            panelStickBottom.Anchor = AnchorStyles.None;
            panelStickBottom.Controls.Add(label11);
            panelStickBottom.Controls.Add(btnExport);
            panelStickBottom.Controls.Add(btnFailed);
            panelStickBottom.Controls.Add(btnPass);
            panelStickBottom.Controls.Add(btnQuit);
            panelStickBottom.Controls.Add(panelControlAll1);
            panelStickBottom.Location = new Point(70, 728);
            panelStickBottom.Name = "panelStickBottom";
            panelStickBottom.Size = new Size(1089, 73);
            panelStickBottom.TabIndex = 17;
            // 
            // label11
            // 
            label11.BackColor = Color.White;
            label11.Image = (Image)resources.GetObject("label11.Image");
            label11.Location = new Point(587, 10);
            label11.Name = "label11";
            label11.Size = new Size(10, 53);
            label11.TabIndex = 20;
            // 
            // btnExport
            // 
            btnExport._ImageDefault = null;
            btnExport._ImageDisable = null;
            btnExport._ImageSelect = null;
            btnExport.Font = new Font("Segoe UI", 10.5F);
            btnExport.ForeColor = Color.FromArgb(0, 32, 77);
            btnExport.Location = new Point(632, 19);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 36);
            btnExport.TabIndex = 17;
            btnExport._ClickControl += btnExport__ClickControl;
            // 
            // btnFailed
            // 
            btnFailed._ImageDefault = null;
            btnFailed._ImageDisable = null;
            btnFailed._ImageSelect = null;
            btnFailed.Font = new Font("Segoe UI", 10.5F);
            btnFailed.ForeColor = Color.FromArgb(0, 32, 77);
            btnFailed.Location = new Point(454, 19);
            btnFailed.Margin = new Padding(3, 4, 3, 4);
            btnFailed.Name = "btnFailed";
            btnFailed.Size = new Size(93, 36);
            btnFailed.TabIndex = 18;
            btnFailed._ClickControl += btnFailed_Click;
            // 
            // btnPass
            // 
            btnPass._ImageDefault = null;
            btnPass._ImageDisable = null;
            btnPass._ImageSelect = null;
            btnPass.Font = new Font("Segoe UI", 10.5F);
            btnPass.ForeColor = Color.FromArgb(0, 32, 77);
            btnPass.Location = new Point(332, 19);
            btnPass.Margin = new Padding(3, 4, 3, 4);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(90, 36);
            btnPass.TabIndex = 19;
            btnPass._ClickControl += btnPass_Click;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.White;
            btnQuit.BackColors = Color.White;
            btnQuit.BorderColor = Color.FromArgb(227, 242, 253);
            btnQuit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnQuit.BorderRadius = 5;
            btnQuit.BorderSize = 1;
            btnQuit.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuit.ForeColors = Color.FromArgb(0, 32, 77);
            btnQuit.HoverColors = Color.DarkGray;
            btnQuit.Location = new Point(781, 19);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(94, 36);
            btnQuit.TabIndex = 16;
            btnQuit.Texts = "lblbtn1";
            btnQuit.Click += btnQuit_Click;
            // 
            // panelControlAll1
            // 
            panelControlAll1.BackColor = SystemColors.Window;
            panelControlAll1.BorderColor = Color.WhiteSmoke;
            panelControlAll1.BorderFocusColor = Color.HotPink;
            panelControlAll1.BorderSize = 5;
            panelControlAll1.Location = new Point(307, 7);
            panelControlAll1.Margin = new Padding(2, 3, 2, 3);
            panelControlAll1.Name = "panelControlAll1";
            panelControlAll1.Padding = new Padding(2, 3, 2, 3);
            panelControlAll1.Size = new Size(581, 62);
            panelControlAll1.TabIndex = 10;
            // 
            // FormEvaluateReport
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1118, 804);
            Controls.Add(panelForm);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEvaluateReport";
            Text = "FormEvaluateReport";
            panelForm.ResumeLayout(false);
            panelString.ResumeLayout(false);
            panelString.PerformLayout();
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelStickBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelForm;
        private Panel panelHold;
        private Panel panelStickBottom;
        private Label label11;
        private Controls.ButtonIconLable btnExport;
        private Controls.ButtonIconLable btnFailed;
        private Controls.ButtonIconLable btnPass;
        private Controls.ButtonControl btnQuit;
        private Controls.PanelControlAll panelControlAll1;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Controls.RJEditor rtbNote;
        private Controls.PanelBorderRadiusCustom panelString;
        private Controls.CheckBoxDUT chkPDFReport;
        private Controls.Buttons.ButtonCustom ButtonCustom1;
        private Controls.RJTextBox32 txtReportDate;
        private Controls.RJTextBox32 txtOutputPath;
        private Controls.RJTextBox32 txtReportName;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label6;
        private Label label4;
        private Label label8;
        private Label label2;
        private Label label1;
    }
}