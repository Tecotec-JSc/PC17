namespace T3ACS.Controls.SelectCustoms
{
    partial class SelectCustomAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCustomAdd));
            lblContent = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblContent.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContent.Location = new Point(10, 6);
            lblContent.Margin = new Padding(0);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(448, 22);
            lblContent.TabIndex = 1;
            lblContent.Text = "Select DUT";
            lblContent.TextAlign = ContentAlignment.MiddleLeft;
            lblContent.Click += lblContent_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(477, 9);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 12);
            label2.TabIndex = 2;
            label2.Click += lblContent_Click;
            // 
            // SelectCustomAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(lblContent);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(130, 135, 137);
            Margin = new Padding(0);
            Name = "SelectCustomAdd";
            Size = new Size(500, 32);
            Click += lblContent_Click;
            ResumeLayout(false);
        }

        #endregion

        private Label lblContent;
        private Label label2;
    }
}
