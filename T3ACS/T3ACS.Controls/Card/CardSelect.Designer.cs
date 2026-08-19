namespace T3ACS.Controls
{
    partial class CardSelect
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
            lblCardTitle = new Label();
            lblCardContent = new Label();
            lblCardCheck = new Label();
            SuspendLayout();
            // 
            // lblCardTitle
            // 
            lblCardTitle.BackColor = Color.Transparent;
            lblCardTitle.Cursor = Cursors.Hand;
            lblCardTitle.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardTitle.Location = new Point(38, 4);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(1460, 32);
            lblCardTitle.TabIndex = 5;
            lblCardTitle.Text = "lblCardTitle";
            lblCardTitle.Click += clickCard;
            lblCardTitle.MouseEnter += UserControl_MouseEnter;
            lblCardTitle.MouseLeave += UserControl_MouseLeave;
            // 
            // lblCardContent
            // 
            lblCardContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCardContent.BackColor = Color.Transparent;
            lblCardContent.Cursor = Cursors.Hand;
            lblCardContent.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCardContent.Location = new Point(39, 36);
            lblCardContent.Name = "lblCardContent";
            lblCardContent.Size = new Size(1449, 43);
            lblCardContent.TabIndex = 6;
            lblCardContent.Text = "label3";
            lblCardContent.Click += clickCard;
            lblCardContent.MouseEnter += UserControl_MouseEnter;
            lblCardContent.MouseLeave += UserControl_MouseLeave;
            // 
            // lblCardCheck
            // 
            lblCardCheck.Cursor = Cursors.Hand;
            lblCardCheck.Image = Properties.Resources.NotChecked;
            lblCardCheck.Location = new Point(10, 15);
            lblCardCheck.Name = "lblCardCheck";
            lblCardCheck.Size = new Size(16, 16);
            lblCardCheck.TabIndex = 4;
            lblCardCheck.Click += clickCard;
            lblCardCheck.MouseEnter += UserControl_MouseEnter;
            lblCardCheck.MouseLeave += UserControl_MouseLeave;
            // 
            // CardSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblCardTitle);
            Controls.Add(lblCardContent);
            Controls.Add(lblCardCheck);
            Cursor = Cursors.Hand;
            Name = "CardSelect";
            Size = new Size(1501, 82);
            Click += clickCard;
            MouseEnter += UserControl_MouseEnter;
            MouseLeave += UserControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblCardTitle;
        private Label lblCardContent;
        private Label lblCardCheck;
    }
}
