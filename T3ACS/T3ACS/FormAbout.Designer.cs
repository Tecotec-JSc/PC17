namespace T3ACS
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            lblCloseIcon = new Label();
            btnClose = new Controls.Buttons.ButtonCustom();
            SuspendLayout();
            // 
            // lblCloseIcon
            // 
            lblCloseIcon.AutoSize = true;
            lblCloseIcon.BackColor = Color.Transparent;
            lblCloseIcon.Image = Properties.Resources.ChromeClose;
            lblCloseIcon.Location = new Point(1886, 4);
            lblCloseIcon.Name = "lblCloseIcon";
            lblCloseIcon.Size = new Size(29, 19);
            lblCloseIcon.TabIndex = 0;
            lblCloseIcon.Text = "     ";
            lblCloseIcon.Click += lblCloseIcon_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(10, 66, 79);
            btnClose.BackColorG = Color.FromArgb(10, 66, 79);
            btnClose.BorderColorG = Color.FromArgb(48, 100, 112);
            btnClose.BorderSize = 1;
            btnClose.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(0, 32, 77);
            btnClose.ForeColorG = Color.FromArgb(0, 32, 77);
            btnClose.HoverG = false;
            btnClose.HoverColor = Color.Empty;
            btnClose.iConLocation = new Point(6, 5);
            btnClose.ImageAd = (Image)resources.GetObject("btnClose.ImageAd");
            btnClose.Location = new Point(422, 37);
            btnClose.Name = "btnClose";
            btnClose.RadiusBottomLeft = 5;
            btnClose.RadiusBottomRight = 5;
            btnClose.RadiusTopLeft = 5;
            btnClose.RadiusTopRight = 5;
            btnClose.Size = new Size(28, 28);
            btnClose.TabIndex = 1;
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.TextLocation = new Point(35, 4);
            btnClose.Texts = "label2";
            btnClose._EventSelect += btnClose__EventSelect;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 66, 79);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(480, 377);
            Controls.Add(btnClose);
            Controls.Add(lblCloseIcon);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += FormAbout_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCloseIcon;
        private Controls.Buttons.ButtonCustom btnClose;
    }
}