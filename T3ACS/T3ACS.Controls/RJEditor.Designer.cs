namespace T3ACS.Controls
{
    partial class RJEditor
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
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(938, 336);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.Click += richTextBox1_Click;
            richTextBox1.Enter += richTextBox1_Enter;
            richTextBox1.MouseEnter += richTextBox1_MouseEnter;
            richTextBox1.MouseLeave += richTextBox1_MouseLeave;
            // 
            // RJEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(richTextBox1);
            Name = "RJEditor";
            Size = new Size(946, 342);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
    }
}
