namespace T3ACS.Controls.tab
{
    partial class TabControl
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(9, 5);
            label1.Name = "label1";
            label1.Size = new Size(182, 30);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += label1_Click;
            label1.MouseEnter += UserControl_MouseEnter;
            label1.MouseLeave += UserControl_MouseLeave;
            // 
            // TabControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10.5F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TabControl";
            Size = new Size(194, 39);
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}
