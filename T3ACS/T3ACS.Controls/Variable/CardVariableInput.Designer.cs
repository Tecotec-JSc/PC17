namespace T3ACS.Controls.Variable
{
    partial class CardVariableInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardVariableInput));
            lblTitle = new Label();
            lblClose = new Label();
            txtInput = new RJTextBox32();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(0, 32, 77);
            lblTitle.Location = new Point(9, 7);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 19);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Step type";
            // 
            // lblClose
            // 
            lblClose.Cursor = Cursors.Hand;
            lblClose.Image = (Image)resources.GetObject("lblClose.Image");
            lblClose.Location = new Point(625, 2);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(20, 20);
            lblClose.TabIndex = 4;
            lblClose.Click += lblClose_Click;
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.White;
            txtInput.BorderColor = Color.DarkGray;
            txtInput.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtInput.BorderRadius = 5;
            txtInput.BorderSize = 1;
            txtInput.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInput.Location = new Point(9, 30);
            txtInput.Margin = new Padding(4);
            txtInput.Multiline = false;
            txtInput.Name = "txtInput";
            txtInput.Padding = new Padding(10, 7, 10, 7);
            txtInput.PasswordChar = false;
            txtInput.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtInput.PlaceholderText = "";
            txtInput.ReadOnly = false;
            txtInput.Size = new Size(624, 32);
            txtInput.TabIndex = 6;
            txtInput.UnderlinedStyle = false;
            // 
            // CardVariableInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtInput);
            Controls.Add(lblClose);
            Controls.Add(lblTitle);
            Margin = new Padding(0);
            Name = "CardVariableInput";
            Size = new Size(649, 74);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblClose;
        private RJTextBox32 txtInput;
    }
}
