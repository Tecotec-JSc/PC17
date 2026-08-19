namespace T3ACS.Controls
{
    partial class StepTypeGroupControl
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
            lblDefaultTitle = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.AutoSize = true;
            lblDefaultTitle.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTitle.Location = new Point(41, 9);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(213, 19);
            lblDefaultTitle.TabIndex = 1;
            lblDefaultTitle.Text = "Environmental Conditions Check";
            lblDefaultTitle.Click += lblDefaultTitle_Click;
            lblDefaultTitle.Enter += HoverOn;
            lblDefaultTitle.Leave += HoverLeave;
            lblDefaultTitle.MouseEnter += HoverOn;
            lblDefaultTitle.MouseLeave += HoverLeave;
            // 
            // label1
            // 
            label1.Image = Properties.Resources.arrowRight;
            label1.Location = new Point(3, 2);
            label1.Name = "label1";
            label1.Size = new Size(32, 32);
            label1.TabIndex = 2;
            label1.Click += label1_Click;
            label1.Enter += HoverOn;
            label1.Leave += HoverLeave;
            label1.MouseEnter += HoverOn;
            label1.MouseLeave += HoverLeave;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(252, 252, 252);
            panel1.Controls.Add(lblDefaultTitle);
            panel1.Controls.Add(label1);
            panel1.Cursor = Cursors.Hand;
            panel1.Location = new Point(0, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(709, 36);
            panel1.TabIndex = 3;
            panel1.Click += panel1_Click;
            panel1.Enter += HoverOn;
            panel1.Leave += HoverLeave;
            panel1.MouseEnter += HoverOn;
            panel1.MouseLeave += HoverLeave;
            // 
            // StepTypeGroupControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StepTypeGroupControl";
            Size = new Size(709, 45);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblDefaultTitle;
        private Label label1;
        private Panel panel1;
    }
}
