namespace T3ACS.CreateStep
{
    partial class FormCreateParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateParameter));
            tableVariableControl1 = new Controls.TableVariableControl();
            btnIconDelete = new Controls.Buttons.ButtonCustom();
            label1 = new Label();
            selectParameter1 = new Controls.SelectCustoms.SelectParameter();
            SuspendLayout();
            // 
            // tableVariableControl1
            // 
            tableVariableControl1._MaxHeight = 400;
            tableVariableControl1.BackColor = Color.White;
            tableVariableControl1.BackColorRow1 = Color.Empty;
            tableVariableControl1.BackColorRow2 = Color.Empty;
            tableVariableControl1.Font = new Font("Segoe UI", 10.5F);
            tableVariableControl1.Location = new Point(14, 50);
            tableVariableControl1.Margin = new Padding(3, 4, 3, 4);
            tableVariableControl1.Name = "tableVariableControl1";
            tableVariableControl1.Size = new Size(1061, 456);
            tableVariableControl1.TabIndex = 7;
            tableVariableControl1._ShowError += tableVariableControl1__ShowError;
            tableVariableControl1._ChangeNumberRow += tableVariableControl1__ChangeNumberRow;
            // 
            // btnIconDelete
            // 
            btnIconDelete.BackColor = Color.White;
            btnIconDelete.BackColorG = Color.White;
            btnIconDelete.BorderColorG = Color.DarkGray;
            btnIconDelete.BorderSize = 1;
            btnIconDelete.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconDelete.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconDelete.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconDelete.ForeColorG = Color.FromArgb(0, 32, 77);
            btnIconDelete.HoverG = false;
            btnIconDelete.HoverColor = Color.Empty;
            btnIconDelete.iConLocation = new Point(13, 5);
            btnIconDelete.ImageAd = (Image)resources.GetObject("btnIconDelete.ImageAd");
            btnIconDelete.Location = new Point(783, 12);
            btnIconDelete.Margin = new Padding(0);
            btnIconDelete.Name = "btnIconDelete";
            btnIconDelete.RadiusBottomLeft = 5;
            btnIconDelete.RadiusBottomRight = 5;
            btnIconDelete.RadiusTopLeft = 5;
            btnIconDelete.RadiusTopRight = 5;
            btnIconDelete.Size = new Size(117, 32);
            btnIconDelete.TabIndex = 5;
            btnIconDelete.TextAlign = ContentAlignment.MiddleLeft;
            btnIconDelete.TextLocation = new Point(33, 4);
            btnIconDelete.Texts = "Delete (0)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 5, 51);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 4;
            label1.Text = "List Parameter";
            // 
            // selectParameter1
            // 
            selectParameter1._SelectedValues = null;
            selectParameter1.BackColor = Color.White;
            selectParameter1.BackColorG = Color.FromArgb(11, 123, 105);
            selectParameter1.BorderColorG = Color.DarkGray;
            selectParameter1.BorderSize = 1;
            selectParameter1.Font = new Font("Segoe UI", 10.5F);
            selectParameter1.FontG = new Font("Segoe UI", 10.5F);
            selectParameter1.ForeColor = Color.FromArgb(0, 32, 77);
            selectParameter1.ForeColorG = Color.White;
            selectParameter1.HoverG = false;
            selectParameter1.HoverColor = Color.Empty;
            selectParameter1.iConLocation = new Point(13, 6);
            selectParameter1.ImageAd = (Image)resources.GetObject("selectParameter1.ImageAd");
            selectParameter1.Location = new Point(903, 12);
            selectParameter1.Margin = new Padding(3, 4, 3, 4);
            selectParameter1.Name = "selectParameter1";
            selectParameter1.RadiusBottomLeft = 5;
            selectParameter1.RadiusBottomRight = 5;
            selectParameter1.RadiusTopLeft = 5;
            selectParameter1.RadiusTopRight = 5;
            selectParameter1.Size = new Size(172, 32);
            selectParameter1.TabIndex = 8;
            selectParameter1.TextAdd = "Add New Parameter";
            selectParameter1.TextAlign = ContentAlignment.MiddleLeft;
            selectParameter1.TextLocation = new Point(37, 5);
            selectParameter1.Texts = "Select Parameter";
            selectParameter1._eventSelected += selectParameter1__EventSelect;
            selectParameter1._eventDeselect += selectParameter1__eventDeselect;
            selectParameter1._eventAddnew += selectParameter1__eventAddnew;
            // 
            // FormCreateParameter
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1096, 519);
            Controls.Add(selectParameter1);
            Controls.Add(tableVariableControl1);
            Controls.Add(btnIconDelete);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCreateParameter";
            Text = "FormCreateParameter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.TableVariableControl tableVariableControl1;
        private Controls.Buttons.ButtonCustom btnIconDelete;
        private Label label1;
        private Controls.SelectCustoms.SelectParameter selectParameter1;
    }
}