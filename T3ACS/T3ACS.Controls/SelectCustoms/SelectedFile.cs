using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace T3ACS.Controls
{
    public partial class SelectedFile : UserControl
    {
        public SelectedFile()
        {
            InitializeComponent();

        }
        #region border
        [Category("Border Advance")]
        public int RadiusTopLeft { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusTopRight { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusBottomLeft { get; set; } = 5;
        [Category("Border Advance")]
        public int RadiusBottomRight { get; set; } = 5;
        [Category("Border Advance")]
        public Color BorderColorG { get; set; } = Color.DarkGray;
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColorG;
            //if (selected) colorDraWBorder = selectedBorderColor;
            var backcolorfill = backColor;          
            using (SolidBrush brush = new SolidBrush(backcolorfill))
            {

                g.FillPath(brush, path);
            }
            using (Pen borderPen = new Pen(colorDraWBorder, BorderSize))
            {


                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, path);
            }
        }
        private GraphicsPath GetPath(Rectangle r)
        {
            int tl = RadiusTopLeft;
            int tr = RadiusTopRight;
            int bl = RadiusBottomLeft;
            int br = RadiusBottomRight;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            // Top left
            if (tl > 0)
                path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(r.X, r.Y, r.X, r.Y);

            // Top
            path.AddLine(r.X + tl, r.Y, r.Right - tr, r.Y);

            // Top right
            if (tr > 0)
                path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90);

            // Right
            path.AddLine(r.Right, r.Y + tr, r.Right, r.Bottom - br);

            // Bottom right
            if (br > 0)
                path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90);

            // Bottom
            path.AddLine(r.Right - br, r.Bottom, r.X + bl, r.Bottom);

            // Bottom left
            if (bl > 0)
                path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            // Left
            path.AddLine(r.X, r.Bottom - bl, r.X, r.Y + tl);

            path.CloseFigure();

            return path;
        }
        #endregion 
        public event EventHandler _selectChange;
        public string filter { get; set; } = "(*.CSV) | *.csv";
        private void lblFileInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void lblFileInput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
            {
                MessageBox.Show("Chỉ được kéo 1 file.");
                return;
            }
            string file = files[0];
            lblFileInput.Text = file;
            _selectChange?.Invoke(this, EventArgs.Empty);
        }

        private string textbtn = "Select calibration file";

        [Category("Code Advance")]
        public string TextButton
        {
            get
            {
                return textbtn;
            }
            set
            {
                textbtn= value;
                buttonAdvance1.Texts = textbtn;
            }
        }
        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                if (lblFileInput.Text != TextDefault)
                    return lblFileInput.Text;
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lblFileInput.Text = TextDefault;
                    lblFileInput.ForeColor = Color.FromArgb(130, 130, 130);
                }
                else
                {
                    lblFileInput.Text = value;
                    lblFileInput.ForeColor = this.ForeColor == Color.Empty ? Color.White : this.ForeColor;
                }
            }
        }

        [Category("Code Advance")]
        public string ButtonText
        {
            get => buttonAdvance1.Texts;
            set
            {
                buttonAdvance1.Texts = value;
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                if (lblFileInput != null && lblFileInput.Text != "Or drag and drop a CSV file here.")
                {
                    lblFileInput.ForeColor = value;
                }
            }
        }

        private Color backColor = Color.White;
        private Color hightLightColor = Color.FromArgb(232, 232, 232);
        private Color borderColor = Color.DarkGray;

        public string TextDefault { get; set; } = "Or drag and drop a CSV file here.";


        private void ButtonCustom1__EventSelect(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!string.IsNullOrEmpty(filter)) openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFileInput.Text = openFileDialog.FileName;
                lblFileInput.ForeColor = this.ForeColor == Color.Empty ? Color.White : this.ForeColor;
                _selectChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public void lblFileInput_Enter(object sender, EventArgs e)
        {
            if (lblFileInput.Text == "Or drag and drop a CSV file here.")
            {
                lblFileInput.Text = "";
                lblFileInput.ForeColor = this.ForeColor == Color.Empty ? Color.White : this.ForeColor;
            }
        }

        public void lblFileInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblFileInput.Text))
            {
                lblFileInput.Text = "Or drag and drop a CSV file here.";
                lblFileInput.ForeColor = Color.FromArgb(130, 130, 130);
            }
        }

        public void lblFileInput_TextChanged(object sender, EventArgs e)
        {
            _selectChange?.Invoke(this, EventArgs.Empty);
        }

        public Color BoderColorG
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                buttonAdvance1.BorderColorG = borderColor;
            }
        }

        public Color BackColorG
        {
            get { return backColor; }
            set
            {
                backColor = value;
                this.BackColor = backColor;
                lblFileInput.BackColor = backColor;
            }
        }

        public Color HighlightColorG
        {
            get { return hightLightColor; }
            set
            {
                hightLightColor = value;                
                buttonAdvance1.BackColor = hightLightColor;
            }
        }
    }
}
