using T3ACS.Controls.Buttons;

namespace T3ACS.Controls
{
    partial class SelectedFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedFile));
            lblFileInput = new TextBox();
            buttonAdvance1 = new ButtonCustom();
            SuspendLayout();
            // 
            // lblFileInput
            // 
            lblFileInput.AllowDrop = true;
            lblFileInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFileInput.BorderStyle = BorderStyle.None;
            lblFileInput.ForeColor = Color.FromArgb(130, 130, 130);
            lblFileInput.Location = new Point(201, 15);
            lblFileInput.Multiline = true;
            lblFileInput.Name = "lblFileInput";
            lblFileInput.Size = new Size(852, 24);
            lblFileInput.TabIndex = 1;
            lblFileInput.Text = "Or drag and drop a CSV file here.";
            lblFileInput.TextChanged += lblFileInput_TextChanged;
            lblFileInput.DragDrop += lblFileInput_DragDrop;
            lblFileInput.DragEnter += lblFileInput_DragEnter;
            lblFileInput.Enter += lblFileInput_Enter;
            lblFileInput.Leave += lblFileInput_Leave;
            // 
            // buttonAdvance1
            // 
            buttonAdvance1.BackColor = Color.FromArgb(232, 232, 232);          
            buttonAdvance1.BorderSize = 1;
            buttonAdvance1.Font = new Font("Segoe UI", 10.5F);
            buttonAdvance1.FontG = new Font("Segoe UI", 9F);
            buttonAdvance1.ForeColor = Color.Transparent;
            buttonAdvance1.ForeColorG = Color.FromArgb(3, 5, 51);
            buttonAdvance1.iConLocation = new Point(8, 6);
            buttonAdvance1.ImageAd = (Image)resources.GetObject("buttonAdvance1.ImageAd");
            buttonAdvance1.Location = new Point(12, 9);
            buttonAdvance1.Margin = new Padding(0);
            buttonAdvance1.Name = "buttonAdvance1";
            buttonAdvance1.RadiusBottomLeft = 5;
            buttonAdvance1.RadiusBottomRight = 5;
            buttonAdvance1.RadiusTopLeft = 5;
            buttonAdvance1.RadiusTopRight = 5;
            buttonAdvance1.Size = new Size(180, 34);
            buttonAdvance1.TabIndex = 2;
            buttonAdvance1.TextAlign = ContentAlignment.MiddleLeft;
            buttonAdvance1.TextLocation = new Point(32, 5);
            buttonAdvance1.Texts = "Select calibration file";
            buttonAdvance1._EventSelect += ButtonCustom1__EventSelect;
            // 
            // SelectedFile
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(buttonAdvance1);
            Controls.Add(lblFileInput);
            Font = new Font("Segoe UI", 10.5F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SelectedFile";
            Size = new Size(1072, 52);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox lblFileInput;
        private ButtonCustom buttonAdvance1;
    }
}
