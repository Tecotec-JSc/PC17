namespace T3ACS.Controls.CardCustoms
{
    partial class CardTitleCollape
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
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(6, 7);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(107, 19);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Image = Properties.Resources.iconSpan;
            label2.Location = new Point(116, 10);
            label2.Name = "label2";
            label2.Size = new Size(12, 12);
            label2.TabIndex = 2;
            label2.Click += label1_Click;
            label2.MouseEnter += UserControl_MouseEnter;
            label2.MouseLeave += UserControl_MouseLeave;
            // 
            // CardTitleCollape
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            ForeColor = Color.FromArgb(5, 7, 72);
            Margin = new Padding(1, 0, 0, 0);
            Name = "CardTitleCollape";
            Size = new Size(132, 32);
            Click += label1_Click;
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
    }
}
