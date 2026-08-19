using T3ACS.Controls.Buttons;

namespace T3ACS
{
    partial class FormTest1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest1));
            panelBorderRadiusCustom1 = new Controls.PanelBorderRadiusCustom();
            SuspendLayout();
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BackColorG = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Location = new Point(577, 225);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(200, 100);
            panelBorderRadiusCustom1.TabIndex = 0;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // FormTest1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1481, 845);
            Controls.Add(panelBorderRadiusCustom1);
            Name = "FormTest1";
            Text = "FormTest1";
            ResumeLayout(false);
        }

        #endregion

        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom1;
    }
}