namespace T3ACS.Controls.SelectCustoms
{
    partial class SelectParameter
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
            lblText = new Label();
            lblIcon = new Label();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblText.Location = new Point(37, 5);
            lblText.Name = "lblText";
            lblText.Size = new Size(106, 22);
            lblText.TabIndex = 3;
            lblText.Text = "label2";
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Click += All_Click;
            lblText.MouseEnter += UserControl_MouseEnter;
            lblText.MouseLeave += UserControl_MouseLeave;
            // 
            // lblIcon
            // 
            lblIcon.Location = new Point(13, 6);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(16, 21);
            lblIcon.TabIndex = 2;
            lblIcon.Click += All_Click;
            lblIcon.MouseEnter += UserControl_MouseEnter;
            lblIcon.MouseLeave += UserControl_MouseLeave;
            // 
            // SelectParameter
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblText);
            Controls.Add(lblIcon);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SelectParameter";
            Size = new Size(146, 32);
            Click += All_Click;
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblText;
        private Label lblIcon;
    }
}
