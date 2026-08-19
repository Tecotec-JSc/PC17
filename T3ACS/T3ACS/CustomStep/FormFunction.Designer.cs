using T3ACS.Controls;

namespace T3ACS
{
    partial class FormFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFunction));
            labelDefaultExtension = new Label();
            labelDefaultFunction = new Label();
            selectControl1 = new SelectControl();
            selectControl2 = new SelectControl();
            labelDefaultModel = new Label();
            labelDefaultVersion = new Label();
            selectControl3 = new SelectControl();
            selectControl4 = new SelectControl();
            labelDefaultTable = new Label();
            btnAddVariable = new Button();
            tableVariableSelect1 = new TableVariableSelect();
            SuspendLayout();
            // 
            // labelDefaultExtension
            // 
            labelDefaultExtension.AutoSize = true;
            labelDefaultExtension.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultExtension.ForeColor = Color.FromArgb(0, 32, 77);
            labelDefaultExtension.Location = new Point(3, 9);
            labelDefaultExtension.Margin = new Padding(0);
            labelDefaultExtension.Name = "labelDefaultExtension";
            labelDefaultExtension.Size = new Size(69, 19);
            labelDefaultExtension.TabIndex = 2;
            labelDefaultExtension.Text = "Extension";
            // 
            // labelDefaultFunction
            // 
            labelDefaultFunction.AutoSize = true;
            labelDefaultFunction.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultFunction.ForeColor = Color.FromArgb(0, 32, 77);
            labelDefaultFunction.Location = new Point(525, 9);
            labelDefaultFunction.Margin = new Padding(0);
            labelDefaultFunction.Name = "labelDefaultFunction";
            labelDefaultFunction.Size = new Size(129, 19);
            labelDefaultFunction.TabIndex = 2;
            labelDefaultFunction.Text = "Function / Hashtag";
            // 
            // selectControl1
            // 
            selectControl1.Location = new Point(5, 32);
            selectControl1.Name = "selectControl1";
            selectControl1.Size = new Size(495, 34);
            selectControl1.TabIndex = 3;
            // 
            // selectControl2
            // 
            selectControl2.Location = new Point(527, 33);
            selectControl2.Name = "selectControl2";
            selectControl2.Size = new Size(495, 34);
            selectControl2.TabIndex = 3;
            // 
            // labelDefaultModel
            // 
            labelDefaultModel.AutoSize = true;
            labelDefaultModel.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultModel.ForeColor = Color.FromArgb(0, 32, 77);
            labelDefaultModel.Location = new Point(3, 79);
            labelDefaultModel.Margin = new Padding(0);
            labelDefaultModel.Name = "labelDefaultModel";
            labelDefaultModel.Size = new Size(49, 19);
            labelDefaultModel.TabIndex = 2;
            labelDefaultModel.Text = "Model";
            // 
            // labelDefaultVersion
            // 
            labelDefaultVersion.AutoSize = true;
            labelDefaultVersion.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultVersion.ForeColor = Color.FromArgb(0, 32, 77);
            labelDefaultVersion.Location = new Point(525, 81);
            labelDefaultVersion.Margin = new Padding(0);
            labelDefaultVersion.Name = "labelDefaultVersion";
            labelDefaultVersion.Size = new Size(55, 19);
            labelDefaultVersion.TabIndex = 4;
            labelDefaultVersion.Text = "Version";
            // 
            // selectControl3
            // 
            selectControl3.Location = new Point(5, 106);
            selectControl3.Name = "selectControl3";
            selectControl3.Size = new Size(495, 34);
            selectControl3.TabIndex = 3;
            // 
            // selectControl4
            // 
            selectControl4.Location = new Point(527, 106);
            selectControl4.Name = "selectControl4";
            selectControl4.Size = new Size(495, 34);
            selectControl4.TabIndex = 3;
            // 
            // labelDefaultTable
            // 
            labelDefaultTable.AutoSize = true;
            labelDefaultTable.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDefaultTable.ForeColor = Color.FromArgb(0, 32, 77);
            labelDefaultTable.Location = new Point(5, 174);
            labelDefaultTable.Margin = new Padding(0);
            labelDefaultTable.Name = "labelDefaultTable";
            labelDefaultTable.Size = new Size(80, 19);
            labelDefaultTable.TabIndex = 2;
            labelDefaultTable.Text = "Table Rows";
            // 
            // btnAddVariable
            // 
            btnAddVariable.BackColor = Color.White;
            btnAddVariable.FlatAppearance.BorderSize = 0;
            btnAddVariable.FlatAppearance.MouseDownBackColor = Color.White;
            btnAddVariable.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddVariable.FlatStyle = FlatStyle.Flat;
            btnAddVariable.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnAddVariable.Image = (Image)resources.GetObject("btnAddVariable.Image");
            btnAddVariable.Location = new Point(885, 158);
            btnAddVariable.Margin = new Padding(0);
            btnAddVariable.Name = "btnAddVariable";
            btnAddVariable.Size = new Size(137, 35);
            btnAddVariable.TabIndex = 57;
            btnAddVariable.UseVisualStyleBackColor = false;
            // 
            // tableVariableSelect1
            // 
            tableVariableSelect1.BackColor = Color.White;
            tableVariableSelect1.Font = new Font("Segoe UI", 10.5F);
            tableVariableSelect1.ForeColor = Color.FromArgb(0, 32, 77);
            tableVariableSelect1.Location = new Point(3, 220);
            tableVariableSelect1.Margin = new Padding(0);
            tableVariableSelect1.Name = "tableVariableSelect1";
            tableVariableSelect1.Size = new Size(1022, 126);
            tableVariableSelect1.TabIndex = 58;
            tableVariableSelect1._ShowError += tableVariableSelect1__ShowError;
            tableVariableSelect1._UpdateHeight += tableVariableSelect1__UpdateHeight;
            // 
            // FormFunction
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1034, 352);
            Controls.Add(tableVariableSelect1);
            Controls.Add(btnAddVariable);
            Controls.Add(labelDefaultVersion);
            Controls.Add(selectControl2);
            Controls.Add(selectControl4);
            Controls.Add(selectControl3);
            Controls.Add(selectControl1);
            Controls.Add(labelDefaultFunction);
            Controls.Add(labelDefaultTable);
            Controls.Add(labelDefaultModel);
            Controls.Add(labelDefaultExtension);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormFunction";
            Text = "FormFunction";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDefaultExtension;
        private Label labelDefaultFunction;
        private SelectControl selectControl1;
        private SelectControl selectControl2;
        private Label labelDefaultModel;
        private Label labelDefaultVersion;
        private SelectControl selectControl3;
        private SelectControl selectControl4;
        private Label labelDefaultTable;
        private Button btnAddVariable;
        private TableVariableSelect tableVariableSelect1;
    }
}