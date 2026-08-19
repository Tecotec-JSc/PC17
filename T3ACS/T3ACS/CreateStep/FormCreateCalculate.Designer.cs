namespace T3ACS.CreateStep
{
    partial class FormCreateCalculate
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
            tableDefault = new Controls.TableDefaultVariable();
            selectedFileDll = new Controls.SelectedFile();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            selectedFileCalibration = new Controls.SelectedFile();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 5, 51);
            label1.Location = new Point(10, 179);
            label1.Name = "label1";
            label1.Size = new Size(115, 19);
            label1.TabIndex = 4;
            label1.Text = "Input Parameters";
            // 
            // tableDefault
            // 
            tableDefault._MaxHeight = 289;
            tableDefault.BackColor = Color.White;
            tableDefault.BackColorRow1 = Color.Empty;
            tableDefault.BackColorRow2 = Color.Empty;
            tableDefault.Font = new Font("Segoe UI", 10.5F);
            tableDefault.Location = new Point(12, 217);
            tableDefault.Margin = new Padding(3, 4, 3, 4);
            tableDefault.Name = "tableDefault";
            tableDefault.Size = new Size(1072, 289);
            tableDefault.TabIndex = 5;
            tableDefault._ShowError += tableDefault__ShowError;
            // 
            // selectedFileDll
            // 
            selectedFileDll.BackColor = Color.White;
            selectedFileDll.BackColorG = Color.White;
            selectedFileDll.BoderColorG = Color.DarkGray;
            selectedFileDll.BorderColorG = Color.DarkGray;
            selectedFileDll.BorderSize = 1;
            selectedFileDll.ButtonText = "Select Library File...";
            selectedFileDll.filter = "(*.DLL) | *.dll";
            selectedFileDll.Font = new Font("Segoe UI", 10.5F);
            selectedFileDll.HighlightColorG = Color.FromArgb(232, 232, 232);
            selectedFileDll.Location = new Point(60, 45);
            selectedFileDll.Margin = new Padding(3, 4, 3, 4);
            selectedFileDll.Name = "selectedFileDll";
            selectedFileDll.RadiusBottomLeft = 5;
            selectedFileDll.RadiusBottomRight = 5;
            selectedFileDll.RadiusTopLeft = 5;
            selectedFileDll.RadiusTopRight = 5;
            selectedFileDll.Size = new Size(1024, 53);
            selectedFileDll.TabIndex = 6;
            selectedFileDll.TextButton = "Select Library File...";
            selectedFileDll.TextDefault = "Or drag and drop a DLL file here.";
            selectedFileDll.Texts = "";
            selectedFileDll._selectChange += selectedFileDll__selectChange;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(3, 5, 51);
            label2.Location = new Point(10, 12);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 4;
            label2.Text = "Load Files";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(3, 5, 51);
            label3.Location = new Point(10, 60);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 4;
            label3.Text = "Path: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(3, 5, 51);
            label4.Location = new Point(10, 125);
            label4.Name = "label4";
            label4.Size = new Size(44, 19);
            label4.TabIndex = 4;
            label4.Text = "Path: ";
            // 
            // selectedFileCalibration
            // 
            selectedFileCalibration.BackColor = Color.White;
            selectedFileCalibration.BackColorG = Color.White;
            selectedFileCalibration.BoderColorG = Color.DarkGray;
            selectedFileCalibration.BorderColorG = Color.DarkGray;
            selectedFileCalibration.BorderSize = 1;
            selectedFileCalibration.ButtonText = "Select calibration file";
            selectedFileCalibration.filter = "(*.TXT) | *.txt";
            selectedFileCalibration.Font = new Font("Segoe UI", 10.5F);
            selectedFileCalibration.HighlightColorG = Color.FromArgb(232, 232, 232);
            selectedFileCalibration.Location = new Point(60, 110);
            selectedFileCalibration.Margin = new Padding(3, 4, 3, 4);
            selectedFileCalibration.Name = "selectedFileCalibration";
            selectedFileCalibration.RadiusBottomLeft = 5;
            selectedFileCalibration.RadiusBottomRight = 5;
            selectedFileCalibration.RadiusTopLeft = 5;
            selectedFileCalibration.RadiusTopRight = 5;
            selectedFileCalibration.Size = new Size(1024, 53);
            selectedFileCalibration.TabIndex = 6;
            selectedFileCalibration.TextButton = "Select calibration file";
            selectedFileCalibration.TextDefault = "Or drag and drop a TXT file here.";
            selectedFileCalibration.Texts = "";
            selectedFileCalibration._selectChange += selectedFileCalibration__selectChange;
            // 
            // FormCreateCalculate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1096, 519);
            Controls.Add(selectedFileCalibration);
            Controls.Add(selectedFileDll);
            Controls.Add(tableDefault);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCreateCalculate";
            Text = "FormCreateCalculate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Controls.TableDefaultVariable tableDefault;
        private Controls.SelectedFile selectedFileDll;
        private Label label2;
        private Label label3;
        private Label label4;
        private Controls.SelectedFile selectedFileCalibration;
    }
}