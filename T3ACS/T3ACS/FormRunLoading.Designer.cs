namespace T3ACS
{
    partial class FormRunLoading
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
            lblTitle = new Label();
            lblPercent = new Label();
            lblStatus = new Label();
            prgLoading = new CustomProgressBar();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(3, 5, 71);
            lblTitle.Location = new Point(30, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đang tải procedure...";
            //
            // lblPercent
            //
            lblPercent.BackColor = Color.Transparent;
            lblPercent.Font = new Font("Segoe UI", 9F);
            lblPercent.ForeColor = Color.FromArgb(120, 120, 120);
            lblPercent.Location = new Point(360, 68);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(50, 18);
            lblPercent.TabIndex = 1;
            lblPercent.Text = "0%";
            lblPercent.TextAlign = ContentAlignment.TopRight;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(90, 90, 90);
            lblStatus.Location = new Point(30, 116);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(120, 17);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Đang khởi tạo...";
            //
            // prgLoading
            //
            prgLoading.Location = new Point(30, 90);
            prgLoading.Name = "prgLoading";
            prgLoading.Size = new Size(380, 12);
            prgLoading.TabIndex = 3;
            //
            // FormRunLoading
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(440, 170);
            Controls.Add(prgLoading);
            Controls.Add(lblStatus);
            Controls.Add(lblPercent);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRunLoading";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRunLoading";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblStatus;
        private CustomProgressBar prgLoading;
    }
}
