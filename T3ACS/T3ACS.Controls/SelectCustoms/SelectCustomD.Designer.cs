namespace T3ACS.Controls
{ 
    partial class SelectCustomD
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
            lblContent = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblContent.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContent.Location = new Point(8, 6);
            lblContent.Margin = new Padding(0);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(179, 15);
            lblContent.TabIndex = 0;
            lblContent.Text = "label1";
            lblContent.TextAlign = ContentAlignment.MiddleLeft;
            lblContent.Click += OpenPopup;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Location = new Point(204, 8);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 12);
            label2.TabIndex = 1;
            label2.Click += OpenPopup;
            label2.Paint += label2_Paint;
            // 
            // SelectCustomD
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(lblContent);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(0);
            Name = "SelectCustomD";
            Size = new Size(225, 28);
            Click += OpenPopup;
            ResumeLayout(false);
        }

        #endregion
        public int SelectedIndex
        {
            get
            {
                if (Items == null || Texts == null) return -1;
                return Array.IndexOf(Items, Texts);
            }
            set
            {
                if (Items == null) return;

                if (value >= 0 && value < Items.Length)
                    Texts = Items[value];
            }
        }
        private Label lblContent;
        private Label label2;
    }
}
