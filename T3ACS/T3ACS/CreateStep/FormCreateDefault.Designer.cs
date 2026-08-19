namespace T3ACS.CreateStep
{
    partial class FormCreateDefault
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
            label1 = new Label();
            tableDefaultVariable1 = new Controls.TableDefaultVariable();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 5, 51);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(115, 19);
            label1.TabIndex = 4;
            label1.Text = "Input Parameters";
            // 
            // tableDefaultVariable1
            // 
            tableDefaultVariable1._MaxHeight = 478;
            tableDefaultVariable1.BackColor = Color.White;
            tableDefaultVariable1.BackColorRow1 = Color.FromArgb(250, 250, 250);
            tableDefaultVariable1.BackColorRow2 = Color.Empty;
            tableDefaultVariable1.Font = new Font("Segoe UI", 10.5F);
            tableDefaultVariable1.Location = new Point(12, 35);
            tableDefaultVariable1.Margin = new Padding(3, 4, 3, 4);
            tableDefaultVariable1.Name = "tableDefaultVariable1";
            tableDefaultVariable1.Size = new Size(1072, 478);
            tableDefaultVariable1.TabIndex = 5;
            tableDefaultVariable1._ShowError += tableDefaultVariable1__ShowError;
            // 
            // FormCreateDefault
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1096, 519);
            Controls.Add(tableDefaultVariable1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCreateDefault";
            Text = "FormCreateDefault";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Controls.TableDefaultVariable tableDefaultVariable1;
    }
}