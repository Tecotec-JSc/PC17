namespace T3ACS.CreateStep
{
    partial class FormAddOneVariable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddOneVariable));
            label1 = new Label();
            btnCancel = new Controls.Buttons.ButtonCustom();
            btnSave = new Controls.Buttons.ButtonCustom();
            tableVariableControl1 = new Controls.TableVariableControl();
            lblError = new Label();
            flowPanelBorderRadius1 = new flowPanelBorderRadius();
            flowPanelBorderRadius1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 5);
            label1.Margin = new Padding(3, 5, 3, 10);
            label1.Name = "label1";
            label1.Size = new Size(134, 19);
            label1.TabIndex = 1;
            label1.Text = "Add New Parameter";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.BackColorG = Color.White;
            btnCancel.BorderColorG = Color.DarkGray;
            btnCancel.BorderSize = 1;
            btnCancel.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(0, 32, 77);
            btnCancel.ForeColorG = Color.FromArgb(0, 32, 77);
            btnCancel.HoverG = false;
            btnCancel.HoverColor = Color.Empty;
            btnCancel.iConLocation = new Point(11, 5);
            btnCancel.ImageAd = null;
            btnCancel.Location = new Point(818, 146);
            btnCancel.Margin = new Padding(760, 3, 3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.RadiusBottomLeft = 5;
            btnCancel.RadiusBottomRight = 5;
            btnCancel.RadiusTopLeft = 5;
            btnCancel.RadiusTopRight = 5;
            btnCancel.Size = new Size(121, 32);
            btnCancel.TabIndex = 2;
            btnCancel.TextAlign = ContentAlignment.MiddleLeft;
            btnCancel.TextLocation = new Point(35, 4);
            btnCancel.Texts = "Cancel";
            btnCancel._EventSelect += btnCancel__EventSelect;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.BackColorG = Color.FromArgb(0, 82, 130);
            btnSave.BorderColorG = Color.DarkGray;
            btnSave.BorderSize = 1;
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(0, 32, 77);
            btnSave.ForeColorG = Color.White;
            btnSave.HoverG = false;
            btnSave.HoverColor = Color.Empty;
            btnSave.iConLocation = new Point(11, 5);
            btnSave.ImageAd = null;
            btnSave.Location = new Point(962, 146);
            btnSave.Margin = new Padding(20, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.RadiusBottomLeft = 5;
            btnSave.RadiusBottomRight = 5;
            btnSave.RadiusTopLeft = 5;
            btnSave.RadiusTopRight = 5;
            btnSave.Size = new Size(121, 32);
            btnSave.TabIndex = 2;
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextLocation = new Point(35, 4);
            btnSave.Texts = "Save";
            btnSave._EventSelect += btnSave__EventSelect;
            // 
            // tableVariableControl1
            // 
            tableVariableControl1.BackColor = Color.White;
            tableVariableControl1.Location = new Point(3, 37);
            tableVariableControl1.Name = "tableVariableControl1";
            tableVariableControl1.Size = new Size(1139, 103);
            tableVariableControl1.TabIndex = 3;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(10, 155);
            lblError.Margin = new Padding(10, 12, 3, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(45, 19);
            lblError.TabIndex = 4;
            lblError.Text = "label2";
            // 
            // flowPanelBorderRadius1
            // 
            flowPanelBorderRadius1.BorderColor = Color.DarkGray;
            flowPanelBorderRadius1.BorderSize = 1;
            flowPanelBorderRadius1.Controls.Add(label1);
            flowPanelBorderRadius1.Controls.Add(tableVariableControl1);
            flowPanelBorderRadius1.Controls.Add(lblError);
            flowPanelBorderRadius1.Controls.Add(btnCancel);
            flowPanelBorderRadius1.Controls.Add(btnSave);
            flowPanelBorderRadius1.Location = new Point(0, 0);
            flowPanelBorderRadius1.Margin = new Padding(0);
            flowPanelBorderRadius1.Name = "flowPanelBorderRadius1";
            flowPanelBorderRadius1.RadiusBottomLeft = 5;
            flowPanelBorderRadius1.RadiusBottomRight = 5;
            flowPanelBorderRadius1.RadiusTopLeft = 5;
            flowPanelBorderRadius1.RadiusTopRight = 5;
            flowPanelBorderRadius1.Size = new Size(1142, 194);
            flowPanelBorderRadius1.TabIndex = 5;
            flowPanelBorderRadius1.VerticalPoints = (List<int>)resources.GetObject("flowPanelBorderRadius1.VerticalPoints");
            // 
            // FormAddOneVariable
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1142, 195);
            Controls.Add(flowPanelBorderRadius1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAddOneVariable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAddOneVariable";
            flowPanelBorderRadius1.ResumeLayout(false);
            flowPanelBorderRadius1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Controls.Buttons.ButtonCustom btnCancel;
        private Controls.Buttons.ButtonCustom btnSave;
        private Controls.TableVariableControl tableVariableControl1;
        private Label lblError;
        private flowPanelBorderRadius flowPanelBorderRadius1;
    }
}