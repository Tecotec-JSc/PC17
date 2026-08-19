using T3ACS.Controls.CardCustoms;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace T3ACS
{
    public partial class FormDropDownPopUp : Form
    {
        private int _targetWidth;
        private int _targetHeight;

        public FormDropDownPopUp(int with, List<string> data)
        {
            int maxTextWidth = 0;
            Font tempFont = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            foreach (var s in data)
            {
                Size size = TextRenderer.MeasureText(s, tempFont);
                if (size.Width > maxTextWidth)
                    maxTextWidth = size.Width;
            }
            tempFont.Dispose();

            int requiredWidth = maxTextWidth + 30; // 12px left padding + 13px right padding + 5px safety buffer
            _targetWidth = Math.Max(with, requiredWidth);

            int itemHeight = 28;
            int visibleCount = Math.Min(data.Count, 10);
            _targetHeight = visibleCount * itemHeight;

            if (_targetHeight == 0) _targetHeight = itemHeight;

            InitializeComponent();
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            this.AutoScaleMode = AutoScaleMode.None;

            flowLayoutPanel1.Height = _targetHeight;
            flowLayoutPanel1.Width = _targetWidth;
            SetData(data, _targetWidth);

            this.MinimumSize = new System.Drawing.Size(_targetWidth, _targetHeight);
            this.MaximumSize = new System.Drawing.Size(_targetWidth, _targetHeight);
            this.Size = new System.Drawing.Size(_targetWidth, _targetHeight);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Size = new System.Drawing.Size(_targetWidth, _targetHeight);
        }

        #region SetData
        
        public void SetData(List<string> data, int width)
        {
            flowLayoutPanel1.Controls.Clear();
            if (data != null && data.Count > 0)
            {
                int count=0;
                foreach (string s in data)
                {
                    CardRadius cardTitle = new CardRadius();
                    cardTitle.Texts = s;

               
                    cardTitle._EventSelect += CardTitle__EventSelect;
                    cardTitle.Margin = new Padding(0, -1, 0, 0); 
                    if (count > 0)
                    {
                        Panel line = new Panel();
                        line.Height = 1;
                        line.Dock = DockStyle.Top;
                        line.BackColor = Color.FromArgb(20, Color.Gray); 

                        cardTitle.Controls.Add(line);
                        line.BringToFront();
                    }
                    if (count == 0)
                    {
                      
                        cardTitle.RadiusTopLeft = 5;
                        cardTitle.RadiusTopRight=5;
                        if (count == data.Count - 1)
                        {
                            cardTitle.RadiusBottomLeft = 5;
                            cardTitle.RadiusBottomRight = 5;
                        }
                        else
                        {
                            cardTitle.RadiusBottomLeft = 0;
                            cardTitle.RadiusBottomRight = 0;
                        }
         
                    }else if (count == data.Count - 1)
                    {
                        cardTitle.RadiusTopLeft = 0;
                        cardTitle.RadiusTopRight=0;
                        cardTitle.RadiusBottomLeft = 5;
                        cardTitle.RadiusBottomRight = 5;
                    }
                    else
                    {
                        cardTitle.RadiusTopLeft = 0;
                        cardTitle.RadiusTopRight = 0;
                        cardTitle.RadiusBottomLeft = 0;
                        cardTitle.RadiusBottomRight = 0;
                    }
                    count++;
                    cardTitle.Width = width;
                    flowLayoutPanel1.Controls.Add(cardTitle);
                   
                }
            }           
        
        }
        public event EventHandler _EventSelect;
        private void CardTitle__EventSelect(object? sender, EventArgs e)
        {
            var item = sender as CardRadius;
            if (item != null)
            {
                _EventSelect.Invoke(item.Texts, e);
                this.Close();
            }
        }
        #endregion

        private void FormDropDownPopUp_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
