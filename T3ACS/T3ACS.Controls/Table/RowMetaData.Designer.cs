using T3ACS.Controls.PanelCustoms;

namespace T3ACS.Controls
{
    partial class RowMetaData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowMetaData));
            panelBorderControl1 = new PanelCustomBorder();
            txtValue = new RJTextBox();
            txtTitle = new RJTextBox();
            lblbtnSave = new Label();
            lblbtnEdit = new Label();
            lblDefaultValue = new Label();
            lblCheckItem = new Label();
            lblDefaultTitle = new Label();
            SuspendLayout();
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBorderControl1.BackColor = Color.White;
            panelBorderControl1.BorderColor = Color.DarkGray;      
            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(0, -1);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(955, 52);
            panelBorderControl1.TabIndex = 16;
            // 
            // txtValue
            // 
            txtValue.BackColor = Color.White;
            txtValue.BorderColor = Color.DarkGray;
            txtValue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtValue.BorderRadius = 5;
            txtValue.BorderSize = 1;
            txtValue.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValue.Location = new Point(491, 5);
            txtValue.Margin = new Padding(4);
            txtValue.Multiline = false;
            txtValue.Name = "txtValue";
            txtValue.Padding = new Padding(10, 7, 10, 7);
            txtValue.PasswordChar = false;
            txtValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtValue.PlaceholderText = "";
            txtValue.ReadOnly = false;
            txtValue.Size = new Size(372, 40);
            txtValue.TabIndex = 29;
            txtValue.UnderlinedStyle = false;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.White;
            txtTitle.BorderColor = Color.DarkGray;
            txtTitle.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTitle.BorderRadius = 5;
            txtTitle.BorderSize = 1;
            txtTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(55, 5);
            txtTitle.Margin = new Padding(4);
            txtTitle.Multiline = false;
            txtTitle.Name = "txtTitle";
            txtTitle.Padding = new Padding(10, 7, 10, 7);
            txtTitle.PasswordChar = false;
            txtTitle.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTitle.PlaceholderText = "";
            txtTitle.ReadOnly = false;
            txtTitle.Size = new Size(398, 40);
            txtTitle.TabIndex = 30;
            txtTitle.UnderlinedStyle = false;
            // 
            // lblbtnSave
            // 
            lblbtnSave.BackColor = Color.White;
            lblbtnSave.Cursor = Cursors.Hand;
            lblbtnSave.Image = (Image)resources.GetObject("lblbtnSave.Image");
            lblbtnSave.Location = new Point(870, 5);
            lblbtnSave.Name = "lblbtnSave";
            lblbtnSave.Size = new Size(42, 42);
            lblbtnSave.TabIndex = 27;
            lblbtnSave.Click += lblbtnSave_Click;
            // 
            // lblbtnEdit
            // 
            lblbtnEdit.BackColor = Color.White;
            lblbtnEdit.Cursor = Cursors.Hand;
            lblbtnEdit.Image = (Image)resources.GetObject("lblbtnEdit.Image");
            lblbtnEdit.Location = new Point(870, 5);
            lblbtnEdit.Name = "lblbtnEdit";
            lblbtnEdit.Size = new Size(42, 42);
            lblbtnEdit.TabIndex = 28;
            lblbtnEdit.Click += lblbtnEdit_Click;
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.BackColor = Color.White;
            lblDefaultValue.Font = new Font("Segoe UI", 10.5F);
            lblDefaultValue.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultValue.Location = new Point(491, 14);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(370, 22);
            lblDefaultValue.TabIndex = 26;
            lblDefaultValue.Text = "Value";
            lblDefaultValue.TextChanged += lblDefaultValue_TextChanged;
            // 
            // lblCheckItem
            // 
            lblCheckItem.BackColor = Color.White;
            lblCheckItem.Cursor = Cursors.Hand;
            lblCheckItem.Image = Properties.Resources.NotChecked;
            lblCheckItem.Location = new Point(6, 5);
            lblCheckItem.Name = "lblCheckItem";
            lblCheckItem.Size = new Size(42, 40);
            lblCheckItem.TabIndex = 24;
            lblCheckItem.Click += lblCheckItem_Click;
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.Font = new Font("Segoe UI", 10.5F);
            lblDefaultTitle.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultTitle.Location = new Point(52, 11);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(370, 22);
            lblDefaultTitle.TabIndex = 25;
            lblDefaultTitle.Text = "Title";
            lblDefaultTitle.TextChanged += lblDefaultTitle_TextChanged;
            // 
            // RowMetaData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtValue);
            Controls.Add(txtTitle);
            Controls.Add(lblbtnSave);
            Controls.Add(lblbtnEdit);
            Controls.Add(lblDefaultValue);
            Controls.Add(lblCheckItem);
            Controls.Add(lblDefaultTitle);
            Controls.Add(panelBorderControl1);
            Margin = new Padding(0);
            Name = "RowMetaData";
            Size = new Size(955, 51);
            ResumeLayout(false);
        }

        #endregion

        private PanelCustomBorder panelBorderControl1;
        private RJTextBox txtValue;
        private RJTextBox txtTitle;
        private Label lblbtnSave;
        private Label lblbtnEdit;
        private Label lblDefaultValue;
        private Label lblCheckItem;
        private Label lblDefaultTitle;
    }
}
