using  T3ACS.Controls;

namespace T3ACS.Controls.Card
{
    partial class CardSelectBoolean
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
            btnPass = new ButtonImageNoBorder();
            btnNottPass = new ButtonImageNoBorder();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 16);
            label1.Name = "label1";
            label1.Size = new Size(902, 32);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // btnPass
            // 
            btnPass.Cursor = Cursors.Hand;
            btnPass.Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPass.ForeColor = Color.FromArgb(0, 32, 77);
            btnPass.Location = new Point(970, 14);
            btnPass.Margin = new Padding(0);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(34, 34);
            btnPass.TabIndex = 1;
            // 
            // btnNottPass
            // 
            btnNottPass.Cursor = Cursors.Hand;
            btnNottPass.Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNottPass.ForeColor = Color.FromArgb(0, 32, 77);
            btnNottPass.Location = new Point(1020, 14);
            btnNottPass.Margin = new Padding(0);
            btnNottPass.Name = "btnNottPass";
            btnNottPass.Size = new Size(34, 34);
            btnNottPass.TabIndex = 2;
            // 
            // CardSelectBoolean
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnNottPass);
            Controls.Add(btnPass);
            Controls.Add(label1);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Name = "CardSelectBoolean";
            Size = new Size(1071, 59);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ButtonImageNoBorder btnPass;
        private ButtonImageNoBorder btnNottPass;
    }
}
