
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    public class DataGridViewCheckBoxCustomCell : DataGridViewCheckBoxCell
    {
        public override object DefaultNewRowValue => FalseValue ?? false;

        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);

            ToggleValue();
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            base.OnClick(e);

            ToggleValue();
        }

        private void ToggleValue()
        {
            if (DataGridView == null || RowIndex < 0)
                return;

            object current = Value;

            bool isChecked = false;

            if (current != null &&
                current != DBNull.Value &&
                current.Equals(TrueValue))
            {
                isChecked = true;
            }

            Value = isChecked
                ? (FalseValue ?? false)
                : (TrueValue ?? true);

            DataGridView.NotifyCurrentCellDirty(true);
            DataGridView.EndEdit();
            DataGridView.InvalidateCell(this);
        }





        public int BoxSize { get; set; } = 20;
        public Color BoxBackColor { get; set; } = Color.White;
        public Color BoxBorderColor { get; set; } = Color.Transparent;
        public Color BoxBackCheckColor { get; set; } = Color.FromArgb(191, 216, 230);
        public Color CheckColor { get; set; } = Color.FromArgb(0, 82, 130);

        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // nền cell
            using (SolidBrush br = new SolidBrush(cellStyle.BackColor))
                graphics.FillRectangle(br, cellBounds);

            // viền cell mặc định
            PaintBorder(
                graphics,
                clipBounds,
                cellBounds,
                cellStyle,
                advancedBorderStyle);

            bool isChecked = false;

            if (formattedValue != null &&
                formattedValue != DBNull.Value)
            {
                if (formattedValue.ToString() == "1") isChecked = true;
                else if (formattedValue.ToString() == "0") isChecked = false;
                else
                    isChecked = bool.Parse(formattedValue.ToString());
            }

            Rectangle r = new Rectangle(
                cellBounds.X + (cellBounds.Width - BoxSize) / 2,
                cellBounds.Y + (cellBounds.Height - BoxSize) / 2,
                BoxSize - 1,
                BoxSize - 1);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetPath(r))
            {
                using (SolidBrush br = new SolidBrush(
                    isChecked ? BoxBackCheckColor : BoxBackColor))
                {
                    graphics.FillPath(br, path);
                }

                using (Pen pen = new Pen(BoxBorderColor))
                {
                    graphics.DrawPath(pen, path);
                }

                if (isChecked)
                {
                    using (Pen pen = new Pen(CheckColor, 2.2f))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;

                        Point p1 = new Point(
                            r.X + BoxSize / 4,
                            r.Y + BoxSize / 2);

                        Point p2 = new Point(
                            r.X + BoxSize / 2 - 1,
                            r.Y + BoxSize * 3 / 4);

                        Point p3 = new Point(
                            r.X + BoxSize * 3 / 4,
                            r.Y + BoxSize / 4);

                        graphics.DrawLines(pen, new[] { p1, p2, p3 });
                    }
                }
            }
        }

        private GraphicsPath GetPath(Rectangle r)
        {
            const int radius = 3;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);

            path.CloseFigure();

            return path;
        }
    }
}