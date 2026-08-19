namespace T3ACS.Controls
{
    partial class ButtonActionControl
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
            lblContent = new Label();
            SuspendLayout();
            // 
            // lblIcon
            // 
            //lblIcon.Image = Properties.Resources.iconStopDefault;
            lblIcon.Location = new Point(24, 8);
            lblIcon.Margin = new Padding(0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(32, 32);
            lblIcon.TabIndex = 0;
            lblIcon.Click += ButtonActionControl_Click;
            lblIcon.Enter += ButtonActionControl_Enter;
            lblIcon.Leave += ButtonActionControl_Leave;
            lblIcon.MouseEnter += ButtonActionControl_Enter;
            lblIcon.MouseLeave += ButtonActionControl_Leave;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(22, 48);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(40, 19);
            lblContent.TabIndex = 1;
            lblContent.Text = "Stop";
            lblContent.Click += ButtonActionControl_Click;
            lblContent.Enter += ButtonActionControl_Enter;
            lblContent.Leave += ButtonActionControl_Leave;
            lblContent.MouseEnter += ButtonActionControl_Enter;
            lblContent.MouseLeave += ButtonActionControl_Leave;
            // 
            // ButtonActionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblContent);
            Controls.Add(lblIcon);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(2, 161, 255);
            Name = "ButtonActionControl";
            Size = new Size(80, 80);
            Click += ButtonActionControl_Click;
            Enter += ButtonActionControl_Enter;
            Leave += ButtonActionControl_Leave;
            MouseEnter += ButtonActionControl_Enter;
            MouseLeave += ButtonActionControl_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIcon;
        private Label lblContent;
    }
}
