using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls.Buttons
{
    partial class ButtonCustom
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
            lblIcon = new Label();
            lblText = new Label();
            SuspendLayout();
            // 
            // lblIcon
            // 
            lblIcon.Location = new Point(11, 5);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(16, 21);
            lblIcon.TabIndex = 0;
            lblIcon.Click += All_Click;
            lblIcon.MouseEnter += UserControl_MouseEnter;
            lblIcon.MouseLeave += UserControl_MouseLeave;
            // 
            // lblText
            // 
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblText.Location = new Point(35, 4);
            lblText.Name = "lblText";
            lblText.Size = new Size(96, 22);
            lblText.TabIndex = 1;
            lblText.Text = "label2";
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Click += All_Click;
            lblText.MouseEnter += UserControl_MouseEnter;
            lblText.MouseLeave += UserControl_MouseLeave;
            // 
            // ButtonCustom
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblText);
            Controls.Add(lblIcon);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Name = "ButtonCustom";
            Size = new Size(146, 32);
            Click += All_Click;
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblIcon;
        private Label lblText;
    }
}
