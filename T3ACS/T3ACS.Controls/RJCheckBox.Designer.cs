namespace T3ACS.Controls
{
    partial class RJCheckBox
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
            lblTextContent = new Label();
            SuspendLayout();
            // 
            // lblIcon
            // 
            lblIcon.BackColor = Color.White;
            //lblIcon.Image = Properties.Resources.NotChecked;
            lblIcon.Location = new Point(3, 3);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(23, 23);
            lblIcon.TabIndex = 0;
            lblIcon.Click += lblIcon_Click;
            // 
            // lblTextContent
            // 
            lblTextContent.AutoSize = true;
            lblTextContent.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTextContent.Location = new Point(36, 6);
            lblTextContent.Name = "lblTextContent";
            lblTextContent.Size = new Size(51, 16);
            lblTextContent.TabIndex = 1;
            lblTextContent.Text = "ON/OFF";
            lblTextContent.Click += lblTextContent_Click;
            // 
            // RJCheckBox
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTextContent);
            Controls.Add(lblIcon);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RJCheckBox";
            Size = new Size(102, 29);
            Click += RJCheckBox_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIcon;
        private Label lblTextContent;
    }
}
