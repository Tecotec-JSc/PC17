namespace T3ACS.Controls
{
    partial class ButtonControl
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
            lblbtn1 = new Label();
            SuspendLayout();
            // 
            // lblbtn1
            // 
            lblbtn1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblbtn1.BackColor = Color.White;
            lblbtn1.Location = new Point(6, 5);
            lblbtn1.Name = "lblbtn1";
            lblbtn1.Size = new Size(105, 25);
            lblbtn1.TabIndex = 0;
            lblbtn1.Text = "lblbtn1";
            lblbtn1.TextAlign = ContentAlignment.MiddleCenter;
            lblbtn1.Click += lblbtn1_Click;
            lblbtn1.Enter += label1_Enter;
            lblbtn1.Leave += label1_Leave;
            lblbtn1.MouseEnter += label1_MouseEnter;
            lblbtn1.MouseLeave += label1_MouseLeave;
            // 
            // ButtonControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblbtn1);
            Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "ButtonControl";
            Size = new Size(118, 34);
            ResumeLayout(false);
        }

        #endregion

        private Label lblbtn1;
    }
}
