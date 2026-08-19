namespace T3ACS
{
    partial class FormDropDownPopUp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDropDownPopUp));
            flowLayoutPanel1 = new flowPanelBorderRadius();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderColor = Color.DarkGray;
            flowLayoutPanel1.BorderSize = 1;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RadiusBottomLeft = 5;
            flowLayoutPanel1.RadiusBottomRight = 5;
            flowLayoutPanel1.RadiusTopLeft = 0;
            flowLayoutPanel1.RadiusTopRight = 0;
            flowLayoutPanel1.Size = new Size(231, 57);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.VerticalPoints = (List<int>)resources.GetObject("flowLayoutPanel1.VerticalPoints");
            // 
            // FormDropDownPopUp
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(231, 56);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDropDownPopUp";
            StartPosition = FormStartPosition.Manual;
            Text = "FormDropDownPopUp";
            Deactivate += FormDropDownPopUp_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private flowPanelBorderRadius flowLayoutPanel1;
    }
}