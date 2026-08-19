namespace T3ACS.Controls
{
    partial class SelectCustomTypeButton
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
            lblContent = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblContent.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContent.ForeColor = Color.White;
            lblContent.Location = new Point(12, 8);
            lblContent.Margin = new Padding(0);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(178, 17);
            lblContent.TabIndex = 0;
            lblContent.Text = "label1";
            lblContent.TextAlign = ContentAlignment.MiddleLeft;
            lblContent.Click += OpenPopup;
            lblContent.MouseEnter += UserControl_MouseEnter;
            lblContent.MouseLeave += UserControl_MouseLeave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Image = Properties.Resources.iconCollape;
            label1.Location = new Point(203, 9);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(14, 14);
            label1.TabIndex = 1;
            label1.Click += OpenPopup;
            label1.MouseEnter += UserControl_MouseEnter;
            label1.MouseLeave += UserControl_MouseLeave;
            // 
            // SelectCustomTypeButton
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label1);
            Controls.Add(lblContent);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(5, 7, 72);
            Margin = new Padding(0);
            Name = "SelectCustomTypeButton";
            Size = new Size(228, 32);
            Click += OpenPopup;
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblContent;
        private Label label1;
    }
}
