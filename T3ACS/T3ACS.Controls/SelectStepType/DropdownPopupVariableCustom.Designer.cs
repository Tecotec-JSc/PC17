namespace T3ACS.Controls
{
    partial class DropdownPopupVariableCustom
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
            panel1 = new Panel();
            panelSearch = new FlowLayoutPanel();
            rjTextSeach1 = new RJTextSeach();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panelSearch);
            panel1.Location = new Point(2, 46);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 195);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.FlowDirection = FlowDirection.TopDown;
            panelSearch.Location = new Point(1, 1);
            panelSearch.Margin = new Padding(0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1016, 193);
            panelSearch.TabIndex = 0;
            panelSearch.WrapContents = false;
            // 
            // rjTextSeach1
            // 
            rjTextSeach1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rjTextSeach1.BorderColor = Color.DarkGray;
            rjTextSeach1.BorderFocusColor = Color.DarkGray;
            rjTextSeach1.BorderRadius = 5;
            rjTextSeach1.BorderSize = 1;
            rjTextSeach1.Font = new Font("Segoe UI Variable Display", 10.5F);
            rjTextSeach1.Location = new Point(8, 8);
            rjTextSeach1.Margin = new Padding(3, 4, 3, 4);
            rjTextSeach1.Multiline = false;
            rjTextSeach1.Name = "rjTextSeach1";
            rjTextSeach1.PasswordChar = false;
            rjTextSeach1.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rjTextSeach1.PlaceholderText = "Search or add new...";
            rjTextSeach1.Size = new Size(1004, 30);
            rjTextSeach1.TabIndex = 0;
            rjTextSeach1.UnderlinedStyle = false;
            rjTextSeach1._TextChanged += rjTextSeach1__TextChanged;
            rjTextSeach1.Load += rjTextSeach1_Load;
            // 
            // DropdownPopupVariableCustom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1021, 245);
            Controls.Add(rjTextSeach1);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DropdownPopupVariableCustom";
            StartPosition = FormStartPosition.Manual;
            Text = "DropdownPopupVariableCustom";
            Shown += DropdownPopupVariableCustom_Shown;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RJTextSeach rjTextSeach1;
        private FlowLayoutPanel panelSearch;
    }
}