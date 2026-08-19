using T3ACS.Controls.Variable;
using T3ACS.Model;
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

namespace T3ACS.Controls
{
    public partial class PopupAddVariable : Form
    {
        public PopupAddVariable()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        public int RadiusTopLeft { get; set; } = 0;
        public int RadiusTopRight { get; set; } = 0;
        public int RadiusBottomLeft { get; set; } = 0;
        public int RadiusBottomRight { get; set; } = 0;
        public Color BorderColor { get; set; } = Color.DarkGray;
        public int BorderSize { get; set; } = 1;
        // danh sách các điểm X để vẽ line dọc
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);

            using (Pen borderPen = new Pen(BorderColor, BorderSize))
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
        public List<ProcedureVariableViewModel> _Data;
        public List<ProcedureDetailFunctionVariable> _DataSelect;
        public void LoadData(List<ProcedureVariableViewModel> data, List<ProcedureDetailFunctionVariable> dataSelect)
        {
            _Data = data;
            _DataSelect= dataSelect;
            if (data != null && data.Count > 0)
            {
                foreach(var item in data)
                {
                    CardVariableSelect card = new CardVariableSelect();
                    var des = item.Type+"";
                    if (!string.IsNullOrEmpty(item.Min) && !string.IsNullOrEmpty(item.Max)) {
                        des += " . " + item.Min + "-" + item.Max + " . " + item.Unit;
                    } else if (!string.IsNullOrEmpty(item.Min)) des += " >= " + item.Min + " " + item.Unit;
                    else if (!string.IsNullOrEmpty(item.Max)) des += " <= " + item.Max + " " + item.Unit;
                    card.SetText(item.Name, des);
                    card.Margin = new Padding(0);
                    card._SelectCard += Card__SelectCard;
                    flowPanelBorderRadius1.Controls.Add(card);
                    if (dataSelect != null && dataSelect.Count > 0 && dataSelect.Count(t => t.VariableName == item.Name) > 0)
                        card.Visible = false;
                    else card.Visible = true;
                }
            }
        }

        private void Card__SelectCard(object? sender, EventArgs e)
        {
            var item = sender as CardVariableSelect;
            var obj = _Data.Where(t=>t.Name==item.Name).FirstOrDefault();
            if (_DataSelect == null) _DataSelect = new List<ProcedureDetailFunctionVariable>();
            _DataSelect.Add(new ProcedureDetailFunctionVariable() { VariableName = item._Name,VariableId=obj.ProcedureVariableId,Value=obj.Value,Title=obj.Title });
            item.Visible = false;
        }

        private void PopupAddVariable_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
