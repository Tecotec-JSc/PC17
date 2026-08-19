namespace T3ACS.Controls
{
    partial class ItemCheckListSelected
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemCheckListSelected));
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(6, 6);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Cursor = Cursors.Hand;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(63, 5);
            label1.Name = "label1";
            label1.Size = new Size(16, 16);
            label1.TabIndex = 3;
            label1.Click += label1_Click;
            // 
            // ItemCheckListSelected
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(225, 223, 221);
            Controls.Add(label1);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ItemCheckListSelected";
            Size = new Size(84, 26);
            Load += ItemCheckListSelected_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Label label1;
    }
}
