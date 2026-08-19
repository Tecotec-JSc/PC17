using T3ACS.Controls;

namespace T3ACS.StepDefault
{
    partial class FormEvaluateBrowserURL
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
            rtbNote = new RJEditor();
            panelString = new FlowLayoutPanel();
            panelControlAll1 = new PanelControlAll();
            panelStickBottom = new Panel();
            labelDivider = new Label();
            btnExport = new ButtonIconLable();
            btnFailed = new ButtonIconLable();
            btnPass = new ButtonIconLable();
            btnQuit = new ButtonControl();
            panelForm = new Panel();
            panelHold = new Panel();
            panelStickBottom.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // rtbNote
            // 
            rtbNote.BackColor = Color.White;
            rtbNote.BorderColor = Color.DarkGray;
            rtbNote.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rtbNote.BorderRadius = 5;
            rtbNote.BorderSize = 1;
            rtbNote.Location = new Point(32, 7);
            rtbNote.Name = "rtbNote";
            rtbNote.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rtbNote.PlaceholderText = "Notes";
            rtbNote.RadiusBottomLeft = 5;
            rtbNote.RadiusBottomRight = 5;
            rtbNote.RadiusTopLeft = 5;
            rtbNote.RadiusTopRight = 5;
            rtbNote.Size = new Size(1071, 158);
            rtbNote.TabIndex = 1;
            rtbNote.Texts = "";
            rtbNote.UnderlinedStyle = false;
            // 
            // panelString
            // 
            panelString.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelString.FlowDirection = FlowDirection.TopDown;
            panelString.Location = new Point(32, 171);
            panelString.Name = "panelString";
            panelString.Size = new Size(1081, 551);
            panelString.TabIndex = 2;
            panelString.WrapContents = false;
            // 
            // panelControlAll1
            // 
            panelControlAll1.BackColor = SystemColors.Window;
            panelControlAll1.BorderColor = Color.WhiteSmoke;
            panelControlAll1.BorderFocusColor = Color.HotPink;
            panelControlAll1.BorderSize = 5;
            panelControlAll1.Location = new Point(307, 8);
            panelControlAll1.Margin = new Padding(2, 3, 2, 3);
            panelControlAll1.Name = "panelControlAll1";
            panelControlAll1.Padding = new Padding(2, 3, 2, 3);
            panelControlAll1.Size = new Size(581, 62);
            panelControlAll1.TabIndex = 10;
            // 
            // panelStickBottom
            // 
            panelStickBottom.Anchor = AnchorStyles.None;
            panelStickBottom.Controls.Add(labelDivider);
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
            // labelDivider
            // 
            labelDivider.BackColor = Color.FromArgb(220, 224, 230);
            labelDivider.Location = new Point(587, 10);
            labelDivider.Name = "labelDivider";
            labelDivider.Size = new Size(1, 53);
            labelDivider.TabIndex = 20;
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
            btnFailed.Click += btnFailed_Click;
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
            btnQuit.Texts = "Quit";
            btnQuit.Click += btnQuit_Click;
            // 
            // panelForm
            // 
            panelForm.Controls.Add(panelHold);
            panelForm.Controls.Add(panelStickBottom);
            panelForm.Controls.Add(panelString);
            panelForm.Controls.Add(rtbNote);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1118, 804);
            panelForm.TabIndex = 18;
            panelForm.Scroll += FormEvaluate_Scroll;
            // 
            // panelHold
            // 
            panelHold.Location = new Point(12, 723);
            panelHold.Name = "panelHold";
            panelHold.Size = new Size(14, 80);
            panelHold.TabIndex = 18;
            // 
            // FormEvaluateBrowserURL
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1118, 804);
            Controls.Add(panelForm);
            Font = new Font("Segoe UI Variable Text", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEvaluateBrowserURL";
            Text = "FormEvaluateBrowserURL";
            panelStickBottom.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RJEditor rtbNote;
        private FlowLayoutPanel panelString;
        private PanelControlAll panelControlAll1;
        private Panel panelStickBottom;
        private Label labelDivider;
        private ButtonIconLable btnExport;
        private ButtonIconLable btnFailed;
        private ButtonIconLable btnPass;
        private ButtonControl btnQuit;
        private Panel panelForm;
        private Panel panelHold;
    }
}
