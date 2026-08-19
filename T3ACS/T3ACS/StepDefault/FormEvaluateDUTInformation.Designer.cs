namespace T3ACS.StepDefault
{
    partial class FormEvaluateDUTInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvaluateDUTInformation));
            panelForm = new Panel();
            panelString = new Controls.PanelBorderRadiusCustom();
            label1 = new Label();
            tableDefaultrun1 = new Controls.Table.TableDefaultRUN();
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
            panelString.BackColor = Color.FromArgb(250, 250, 250);
            panelString.BackColorG = Color.Empty;
            panelString.BorderColor = Color.DarkGray;
            panelString.BorderSize = 1;
            panelString.Controls.Add(label1);
            panelString.Controls.Add(tableDefaultrun1);
            panelString.Location = new Point(12, 180);
            panelString.Name = "panelString";
            panelString.RadiusBottomLeft = 5;
            panelString.RadiusBottomRight = 5;
            panelString.RadiusTopLeft = 5;
            panelString.RadiusTopRight = 5;
            panelString.Size = new Size(1096, 545);
            panelString.TabIndex = 22;
            panelString.VerticalPoints = (List<int>)resources.GetObject("panelString.VerticalPoints");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 5, 51);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(128, 19);
            label1.TabIndex = 6;
            label1.Text = "DUT Configuration";
            // 
            // tableDefaultrun1
            // 
            tableDefaultrun1._MaxHeight = 300;
            tableDefaultrun1.BackColor = Color.White;
            tableDefaultrun1.Font = new Font("Segoe UI", 10.5F);
            tableDefaultrun1.Location = new Point(12, 52);
            tableDefaultrun1.Margin = new Padding(3, 4, 3, 4);
            tableDefaultrun1.Name = "tableDefaultrun1";
            tableDefaultrun1.Size = new Size(1072, 468);
            tableDefaultrun1.TabIndex = 0;
            tableDefaultrun1.Click += tableDefaultrun1_Click;
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
            panelBorderRadiusCustom1.TabIndex = 20;
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
            panelHold.Location = new Point(12, 723);
            panelHold.Name = "panelHold";
            panelHold.Size = new Size(14, 80);
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
            panelStickBottom.Location = new Point(15, 728);
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
            btnFailed.Click += btnFailed_Click_1;
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
            btnPass.Click += btnPass_Click;
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
            // FormEvaluateDUTInformation
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
            Name = "FormEvaluateDUTInformation";
            Text = "FormEvaluateDUTInformation";
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
        private Controls.Table.TableDefaultRUN tableDefaultrun1;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Controls.RJEditor rtbNote;
        private Controls.PanelBorderRadiusCustom panelString;
        private Label label1;
    }
}