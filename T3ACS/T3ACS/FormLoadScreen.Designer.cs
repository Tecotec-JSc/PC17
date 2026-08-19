namespace VSat.Spectrum
{
    partial class FormLoadScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadScreen));
            panelTrack = new Panel();
            panelFill = new Panel();
            lblStatus = new Label();
            lblPercent = new Label();
            panelTrack.SuspendLayout();
            SuspendLayout();
            // 
            // panelTrack
            // 
            panelTrack.BackColor = Color.FromArgb(14, 48, 64);
            panelTrack.Controls.Add(panelFill);
            panelTrack.Location = new Point(750, 678);
            panelTrack.Name = "panelTrack";
            panelTrack.Size = new Size(420, 4);
            panelTrack.TabIndex = 0;
            // 
            // panelFill
            // 
            panelFill.BackColor = Color.FromArgb(0, 183, 228);
            panelFill.Location = new Point(0, 0);
            panelFill.Name = "panelFill";
            panelFill.Size = new Size(0, 4);
            panelFill.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(74, 143, 168);
            lblStatus.Location = new Point(750, 693);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(110, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Initializing system...";
            // 
            // lblPercent
            // 
            lblPercent.BackColor = Color.Transparent;
            lblPercent.Font = new Font("Segoe UI", 9F);
            lblPercent.ForeColor = Color.FromArgb(74, 143, 168);
            lblPercent.Location = new Point(1119, 693);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(51, 15);
            lblPercent.TabIndex = 2;
            lblPercent.Text = "0%";
            lblPercent.TextAlign = ContentAlignment.TopRight;
            // 
            // FormLoadScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 12, 16);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1920, 1061);
            Controls.Add(lblPercent);
            Controls.Add(lblStatus);
            Controls.Add(panelTrack);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLoadScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLoadScreen";
            panelTrack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTrack;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPercent;
    }
}