namespace T3ACS.Controls
{
    partial class RowStepControl
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
            lblDefaultTitle = new Label();
            SuspendLayout();
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.Location = new Point(24, 12);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(365, 22);
            lblDefaultTitle.TabIndex = 0;
            lblDefaultTitle.Text = "label1";
            lblDefaultTitle.Click += lblDefaultTitle_Click;
            lblDefaultTitle.Enter += lblDefaultTitle_Enter;
            lblDefaultTitle.Leave += lblDefaultTitle_Leave;
            lblDefaultTitle.MouseEnter += lblDefaultTitle_MouseEnter;
            lblDefaultTitle.MouseLeave += lblDefaultTitle_MouseLeave;
            // 
            // RowStepControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDefaultTitle);
            Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(0);
            Name = "RowStepControl";
            Size = new Size(406, 46);
            Click += RowStepControl_Click;
            Enter += RowStepControl_Enter;
            Leave += RowStepControl_Leave;
            MouseEnter += RowStepControl_MouseEnter;
            MouseLeave += RowStepControl_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblDefaultTitle;
    }
}
