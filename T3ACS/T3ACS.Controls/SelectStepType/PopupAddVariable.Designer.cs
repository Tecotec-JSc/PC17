namespace T3ACS.Controls
{
    partial class PopupAddVariable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupAddVariable));
            flowPanelBorderRadius1 = new flowPanelBorderRadius();
            SuspendLayout();
            // 
            // flowPanelBorderRadius1
            // 
            flowPanelBorderRadius1.AutoScroll = true;
            flowPanelBorderRadius1.BorderColor = Color.DarkGray;
            flowPanelBorderRadius1.BorderSize = 1;
            flowPanelBorderRadius1.Dock = DockStyle.Fill;
            flowPanelBorderRadius1.FlowDirection = FlowDirection.TopDown;
            flowPanelBorderRadius1.Location = new Point(0, 0);
            flowPanelBorderRadius1.Name = "flowPanelBorderRadius1";
            flowPanelBorderRadius1.RadiusBottomLeft = 5;
            flowPanelBorderRadius1.RadiusBottomRight = 5;
            flowPanelBorderRadius1.RadiusTopLeft = 5;
            flowPanelBorderRadius1.RadiusTopRight = 5;
            flowPanelBorderRadius1.Size = new Size(320, 256);
            flowPanelBorderRadius1.TabIndex = 0;
            flowPanelBorderRadius1.VerticalPoints = (List<int>)resources.GetObject("flowPanelBorderRadius1.VerticalPoints");
            flowPanelBorderRadius1.WrapContents = false;
            // 
            // PopupAddVariable
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(320, 256);
            Controls.Add(flowPanelBorderRadius1);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "PopupAddVariable";
            StartPosition = FormStartPosition.Manual;
            Text = "PopupAddVariable";
            Deactivate += PopupAddVariable_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private flowPanelBorderRadius flowPanelBorderRadius1;
    }
}