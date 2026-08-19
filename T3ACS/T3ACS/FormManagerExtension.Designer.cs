using T3ACS.Controls;
using T3ACS.Controls.PanelCustoms;

namespace T3ACS
{
    partial class FormManagerExtension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManagerExtension));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTitleAll = new PanelBorderRadiusCustom();
            panelTitle = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnImport = new Button();
            panel1 = new Panel();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label18 = new Label();
            checkBox2 = new CheckBox();
            panelControlbottomol1 = new PanelCustomBorder();
            panel2 = new Panel();
            dtGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            clmTitle = new DataGridViewTextBoxColumn();
            clmModel = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            cboAction = new ComboBox();
            btnAction = new Button();
            panelTitle.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGrid).BeginInit();
            SuspendLayout();
            // 
            // panelTitleAll
            // 
            panelTitleAll.BackColor = SystemColors.Window;
            panelTitleAll.BorderColor = Color.LightGray;
            panelTitleAll.BorderSize = 1;
            panelTitleAll.Location = new Point(0, 0);
            panelTitleAll.Margin = new Padding(2);
            panelTitleAll.Name = "panelTitleAll";
            panelTitleAll.Padding = new Padding(3);
            panelTitleAll.Size = new Size(1080, 32);
            panelTitleAll.TabIndex = 11;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = SystemColors.Window;
            panelTitle.Controls.Add(label2);
            panelTitle.Controls.Add(label1);
            panelTitle.Location = new Point(3, 1);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1070, 29);
            panelTitle.TabIndex = 12;
            panelTitle.MouseDown += panelTitle_MouseDown;
            // 
            // label2
            // 
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(1031, 3);
            label2.Name = "label2";
            label2.Size = new Size(34, 24);
            label2.TabIndex = 2;
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 3);
            label1.Name = "label1";
            label1.Size = new Size(154, 21);
            label1.TabIndex = 2;
            label1.Text = "Extension Manager";
            // 
            // btnImport
            // 
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Image = (Image)resources.GetObject("btnImport.Image");
            btnImport.Location = new Point(9, 34);
            btnImport.Margin = new Padding(0);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(121, 33);
            btnImport.TabIndex = 13;
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(panelControlbottomol1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 113);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 605);
            panel1.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Window;
            label6.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(655, 12);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 20;
            label6.Text = "Model";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(806, 12);
            label4.Name = "label4";
            label4.Size = new Size(46, 21);
            label4.TabIndex = 19;
            label4.Text = "Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Window;
            label5.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(958, 12);
            label5.Name = "label5";
            label5.Size = new Size(78, 21);
            label5.TabIndex = 18;
            label5.Text = "VERSION";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(280, 11);
            label3.Name = "label3";
            label3.Size = new Size(114, 21);
            label3.TabIndex = 20;
            label3.Text = "DESCRIPTION";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = SystemColors.Window;
            label18.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(45, 12);
            label18.Name = "label18";
            label18.Size = new Size(56, 21);
            label18.TabIndex = 21;
            label18.Text = "NAME";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = SystemColors.Window;
            checkBox2.Location = new Point(19, 17);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 22;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // panelControlbottomol1
            // 
            panelControlbottomol1.BackColor = SystemColors.Window;
            panelControlbottomol1.BorderColor = Color.LightGray;
            panelControlbottomol1.BorderSize = 1;
            panelControlbottomol1.Location = new Point(9, 8);
            panelControlbottomol1.Margin = new Padding(2);
            panelControlbottomol1.Name = "panelControlbottomol1";
            panelControlbottomol1.Padding = new Padding(2);
            panelControlbottomol1.Size = new Size(1049, 30);
            panelControlbottomol1.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(dtGrid);
            panel2.Location = new Point(9, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(1049, 563);
            panel2.TabIndex = 12;
            // 
            // dtGrid
            // 
            dtGrid.AllowUserToAddRows = false;
            dtGrid.AllowUserToDeleteRows = false;
            dtGrid.AllowUserToResizeColumns = false;
            dtGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtGrid.BackgroundColor = SystemColors.Window;
            dtGrid.BorderStyle = BorderStyle.None;
            dtGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGrid.ColumnHeadersVisible = false;
            dtGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn2, clmTitle, clmModel, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtGrid.DefaultCellStyle = dataGridViewCellStyle3;
            dtGrid.Location = new Point(0, 0);
            dtGrid.Margin = new Padding(4, 5, 4, 5);
            dtGrid.Name = "dtGrid";
            dtGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Variable Display", 10.5F);
            dtGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dtGrid.RowTemplate.Height = 54;
            dtGrid.ScrollBars = ScrollBars.Vertical;
            dtGrid.Size = new Size(1049, 606);
            dtGrid.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "PackageId";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "Action";
            dataGridViewCheckBoxColumn1.FalseValue = "false";
            dataGridViewCheckBoxColumn1.HeaderText = "";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn1.TrueValue = "true";
            dataGridViewCheckBoxColumn1.Width = 36;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "PackageName";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn2.HeaderText = "PackageName";
            dataGridViewTextBoxColumn2.MinimumWidth = 232;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn2.Width = 232;
            // 
            // clmTitle
            // 
            clmTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmTitle.DataPropertyName = "Description";
            clmTitle.HeaderText = "PackageTitle";
            clmTitle.MinimumWidth = 379;
            clmTitle.Name = "clmTitle";
            // 
            // clmModel
            // 
            clmModel.DataPropertyName = "Model";
            clmModel.HeaderText = "Model";
            clmModel.MinimumWidth = 150;
            clmModel.Name = "clmModel";
            clmModel.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "TypeName";
            dataGridViewTextBoxColumn3.HeaderText = "Type";
            dataGridViewTextBoxColumn3.MinimumWidth = 152;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn3.Width = 152;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Version";
            dataGridViewTextBoxColumn6.HeaderText = "Version";
            dataGridViewTextBoxColumn6.MinimumWidth = 100;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // cboAction
            // 
            cboAction.FormattingEnabled = true;
            cboAction.Items.AddRange(new object[] { "Delete" });
            cboAction.Location = new Point(9, 84);
            cboAction.Name = "cboAction";
            cboAction.Size = new Size(163, 23);
            cboAction.TabIndex = 16;
            cboAction.Text = "Action";
            // 
            // btnAction
            // 
            btnAction.FlatAppearance.BorderSize = 0;
            btnAction.FlatStyle = FlatStyle.Flat;
            btnAction.Image = (Image)resources.GetObject("btnAction.Image");
            btnAction.Location = new Point(189, 78);
            btnAction.Margin = new Padding(0);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(68, 33);
            btnAction.TabIndex = 15;
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // FormManagerExtension
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 720);
            Controls.Add(cboAction);
            Controls.Add(btnAction);
            Controls.Add(panel1);
            Controls.Add(btnImport);
            Controls.Add(panelTitle);
            Controls.Add(panelTitleAll);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormManagerExtension";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manager Extension";
            Load += FormManagerExtension_Load;
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelTitleAll;
        private Panel panelTitle;
        private Label label2;
        private Label label1;
        private Button btnImport;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dtGrid;
        private ComboBox cboAction;
        private Button btnAction;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label18;
        private CheckBox checkBox2;
        private PanelCustomBorder panelControlbottomol1;
        private Label label6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn clmTitle;
        private DataGridViewTextBoxColumn clmModel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}