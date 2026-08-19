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
            label1 = new Label();
            ButtonCustom1 = new Controls.Buttons.ButtonCustom();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Image = Properties.Resources.ChromeClose;
            label1.Location = new Point(1886, 4);
            label1.Name = "label1";
            label1.Size = new Size(29, 19);
            label1.TabIndex = 0;
            label1.Text = "     ";
            label1.Click += label1_Click;
            // 
            // ButtonCustom1
            // 
            ButtonCustom1.BackColor = Color.FromArgb(10, 66, 79);
            ButtonCustom1.BackColorG = Color.FromArgb(10, 66, 79);
            ButtonCustom1.BorderColorG = Color.FromArgb(48, 100, 112);
            ButtonCustom1.BorderSize = 1;
            ButtonCustom1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.ForeColor = Color.FromArgb(0, 32, 77);
            ButtonCustom1.ForeColorG = Color.FromArgb(0, 32, 77);
            ButtonCustom1.HoverG = false;
            ButtonCustom1.HoverColor = Color.Empty;
            ButtonCustom1.iConLocation = new Point(6, 5);
            ButtonCustom1.ImageAd = (Image)resources.GetObject("ButtonCustom1.ImageAd");
            ButtonCustom1.Location = new Point(422, 37);
            ButtonCustom1.Name = "ButtonCustom1";
            ButtonCustom1.RadiusBottomLeft = 5;
            ButtonCustom1.RadiusBottomRight = 5;
            ButtonCustom1.RadiusTopLeft = 5;
            ButtonCustom1.RadiusTopRight = 5;
            ButtonCustom1.Size = new Size(28, 28);
            ButtonCustom1.TabIndex = 1;
            ButtonCustom1.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCustom1.TextLocation = new Point(35, 4);
            ButtonCustom1.Texts = "label2";
            ButtonCustom1._EventSelect += ButtonCustom1__EventSelect;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 66, 79);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(480, 377);
            Controls.Add(ButtonCustom1);
            Controls.Add(label1);
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

        private Label label1;
        private Controls.Buttons.ButtonCustom ButtonCustom1;
    }
}