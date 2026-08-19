namespace T3ACS.Controls
{
    partial class RJSelectFileControl
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
            buttonControl1 = new ButtonControl();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonControl1
            // 
            buttonControl1.BackColor = Color.White;
            buttonControl1.BackColors = Color.White;
            buttonControl1.BorderColor = Color.FromArgb(227, 242, 253);
            buttonControl1.BorderFocusColor = Color.FromArgb(3, 120, 212);
            buttonControl1.BorderRadius = 5;
            buttonControl1.BorderSize = 1;
            buttonControl1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonControl1.ForeColors = Color.FromArgb(0, 32, 77);
            buttonControl1.HoverColors = Color.DarkGray;
            buttonControl1.Location = new Point(13, 7);
            buttonControl1.Name = "buttonControl1";
            buttonControl1.Size = new Size(118, 34);
            buttonControl1.TabIndex = 0;
            buttonControl1.Texts = "lblbtn1";
            buttonControl1.Click += buttonControl1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(114, 160, 204);
            label1.Location = new Point(151, 15);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 1;
            label1.Text = "No file chose";
            // 
            // RJSelectFileControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(buttonControl1);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RJSelectFileControl";
            Size = new Size(394, 49);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ButtonControl buttonControl1;
        private Label label1;
    }
}
