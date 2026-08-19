namespace T3ACS.Controls
{
    partial class FormPopUpTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPopUpTemplate));
            flowPanelBorderRadius1 = new flowPanelBorderRadius();
            SuspendLayout();
            // 
            // flowPanelBorderRadius1
            // 
            flowPanelBorderRadius1.BorderColor = Color.DarkGray;
            flowPanelBorderRadius1.BorderSize = 1;
            flowPanelBorderRadius1.Dock = DockStyle.Fill;
            flowPanelBorderRadius1.Location = new Point(0, 0);
            flowPanelBorderRadius1.Margin = new Padding(0);
            flowPanelBorderRadius1.Name = "flowPanelBorderRadius1";
            flowPanelBorderRadius1.RadiusBottomLeft = 5;
            flowPanelBorderRadius1.RadiusBottomRight = 5;
            flowPanelBorderRadius1.RadiusTopLeft = 5;
            flowPanelBorderRadius1.RadiusTopRight = 5;
            flowPanelBorderRadius1.Size = new Size(200, 101);
            flowPanelBorderRadius1.TabIndex = 0;
            flowPanelBorderRadius1.VerticalPoints = (List<int>)resources.GetObject("flowPanelBorderRadius1.VerticalPoints");
            // 
            // FormPopUpTemplate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(200, 101);
            Controls.Add(flowPanelBorderRadius1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPopUpTemplate";
            StartPosition = FormStartPosition.Manual;
            Text = "FormPopUpTemplate";
            Deactivate += FormPopUpTemplate_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private flowPanelBorderRadius flowPanelBorderRadius1;
    }
}