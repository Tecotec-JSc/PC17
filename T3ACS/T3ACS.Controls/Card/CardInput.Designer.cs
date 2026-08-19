namespace T3ACS.Controls.Card
{
    partial class CardInput
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
            rjTextBox321 = new RJTextBox32();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 6);
            label1.Name = "label1";
            label1.Size = new Size(1040, 19);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // rjTextBox321
            // 
            rjTextBox321.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rjTextBox321.BackColor = Color.White;
            rjTextBox321.BorderColor = Color.DarkGray;
            rjTextBox321.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rjTextBox321.BorderRadius = 5;
            rjTextBox321.BorderSize = 1;
            rjTextBox321.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rjTextBox321.Location = new Point(14, 36);
            rjTextBox321.Margin = new Padding(4);
            rjTextBox321.Multiline = false;
            rjTextBox321.Name = "rjTextBox321";
            rjTextBox321.Padding = new Padding(10, 7, 10, 7);
            rjTextBox321.PasswordChar = false;
            rjTextBox321.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rjTextBox321.PlaceholderText = "";
            rjTextBox321.ReadOnly = false;
            rjTextBox321.Size = new Size(1040, 32);
            rjTextBox321.TabIndex = 2;
            rjTextBox321.Texts = "";
            rjTextBox321.UnderlinedStyle = false;
            // 
            // CardInputString
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rjTextBox321);
            Controls.Add(label1);
            Font = new Font("Segoe UI Variable Text", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Name = "CardInputString";
            Size = new Size(1071, 79);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RJTextBox32 rjTextBox321;
    }
}
