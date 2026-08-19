namespace T3ACS.Controls
{
    partial class SelectControl
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
            label1 = new Label();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.BackColor = Color.Transparent;
            lblText.Font = new Font("Segoe UI", 10.5F);
            lblText.Location = new Point(15, 8);
            lblText.Name = "lblText";
            lblText.Size = new Size(44, 19);
            lblText.TabIndex = 1;
            lblText.Text = "Select";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Image = Properties.Resources.ArrowDown;
            label1.Location = new Point(709, 8);
            label1.Name = "label1";
            label1.Size = new Size(27, 23);
            label1.TabIndex = 2;
            label1.Click += OpenPopup;
            // 
            // SelectControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lblText);
            Name = "SelectControl";
            Size = new Size(739, 35);
            Click += OpenPopup;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblText;
        private Label label1;
    }
}
