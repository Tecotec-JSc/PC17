namespace T3ACS.Controls
{
    partial class ContenStepTypeControl
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
            lblTextDescription = new Label();
            SuspendLayout();
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTitle.Location = new Point(48, 8);
            lblDefaultTitle.Margin = new Padding(0);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(540, 20);
            lblDefaultTitle.TabIndex = 0;
            lblDefaultTitle.Text = "Environmental Conditions Check";
            lblDefaultTitle.TextAlign = ContentAlignment.BottomLeft;
            lblDefaultTitle.Click += ContenStepTypeControl_Click;
            lblDefaultTitle.Enter += HoverOn;
            lblDefaultTitle.Leave += HoverLeave;
            lblDefaultTitle.MouseEnter += HoverOn;
            lblDefaultTitle.MouseLeave += HoverLeave;
            // 
            // lblTextDescription
            // 
            lblTextDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTextDescription.Location = new Point(48, 32);
            lblTextDescription.Name = "lblTextDescription";
            lblTextDescription.Size = new Size(540, 22);
            lblTextDescription.TabIndex = 1;
            lblTextDescription.Text = "label2";
            lblTextDescription.TextAlign = ContentAlignment.MiddleLeft;
            lblTextDescription.Click += ContenStepTypeControl_Click;
            lblTextDescription.Enter += HoverOn;
            lblTextDescription.Leave += HoverLeave;
            lblTextDescription.MouseEnter += HoverOn;
            lblTextDescription.MouseLeave += HoverLeave;
            // 
            // ContenStepTypeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 252, 252);
            Controls.Add(lblTextDescription);
            Controls.Add(lblDefaultTitle);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Name = "ContenStepTypeControl";
            Size = new Size(607, 62);
            Click += ContenStepTypeControl_Click;
            Enter += HoverOn;
            Leave += HoverLeave;
            MouseEnter += HoverOn;
            MouseLeave += HoverLeave;
            ResumeLayout(false);
        }

        #endregion

        private Label lblDefaultTitle;
        private Label lblTextDescription;
    }
}
