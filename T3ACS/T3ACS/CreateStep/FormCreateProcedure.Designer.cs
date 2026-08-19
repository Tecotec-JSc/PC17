using T3ACS.Controls;

namespace T3ACS
{
    partial class FormCreateProcedure
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
            panelBorderControl1 = new PanelBorderRadiusCustom();
            sortCard1 = new SortCard();
            panelBorderControl2 = new PanelBorderRadiusCustom();
            panelContent = new Panel();
            SuspendLayout();
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.BackColor = SystemColors.Window;
            panelBorderControl1.BorderColor = Color.DarkGray;
            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Dock = DockStyle.Left;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(0, 0);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(355, 983);
            panelBorderControl1.TabIndex = 0;
            // 
            // sortCard1
            // 
            sortCard1.BackColor = Color.White;
            sortCard1.Location = new Point(12, 16);
            sortCard1.Margin = new Padding(0);
            sortCard1.Name = "sortCard1";
            sortCard1.Size = new Size(331, 901);
            sortCard1.TabIndex = 1;
            sortCard1.ButtonClick += sortCard1_ButtonClick;
            // 
            // panelBorderControl2
            // 
            panelBorderControl2.BackColor = SystemColors.Window;
            panelBorderControl2.BorderColor = Color.DarkGray;
            panelBorderControl2.BorderSize = 1;
            panelBorderControl2.Dock = DockStyle.Fill;
            panelBorderControl2.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl2.Location = new Point(355, 0);
            panelBorderControl2.Margin = new Padding(0);
            panelBorderControl2.Name = "panelBorderControl2";
            panelBorderControl2.Padding = new Padding(2);
            panelBorderControl2.Size = new Size(1565, 983);
            panelBorderControl2.TabIndex = 2;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Location = new Point(356, 1);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1562, 981);
            panelContent.TabIndex = 3;
            // 
            // FormCreateProcedure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 983);
            Controls.Add(panelContent);
            Controls.Add(panelBorderControl2);
            Controls.Add(sortCard1);
            Controls.Add(panelBorderControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCreateProcedure";
            Text = "FormCreateProcedure";
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderControl1;
        private SortCard sortCard1;
        private PanelBorderRadiusCustom panelBorderControl2;
        private Panel panelContent;
    }
}