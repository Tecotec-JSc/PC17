using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Controls
{
    public class DataGridViewActionCell : DataGridViewTextBoxCell
    {
        public Image EditImage { get; set; }
        public Image DeleteImage { get; set; }

        public Rectangle GetEditRectangle(Rectangle cellBounds)
        {
            int size = 16;
            int spacing = 10;

            int totalWidth = size * 2 + spacing;

            int startX = cellBounds.X + (cellBounds.Width - totalWidth) / 2;
            int y = cellBounds.Y + (cellBounds.Height - size) / 2;

            return new Rectangle(startX, y, size, size);
        }

        public Rectangle GetDeleteRectangle(Rectangle cellBounds)
        {
            int size = 16;
            int spacing = 10;

            int totalWidth = size * 2 + spacing;

            int startX = cellBounds.X + (cellBounds.Width - totalWidth) / 2;
            int y = cellBounds.Y + (cellBounds.Height - size) / 2;

            return new Rectangle(startX + size + spacing, y, size, size);
        }

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
            // nền + border
            base.Paint(graphics,
                       clipBounds,
                       cellBounds,
                       rowIndex,
                       cellState,
                       "",
                       "",
                       errorText,
                       cellStyle,
                       advancedBorderStyle,
                       DataGridViewPaintParts.Background |
                       DataGridViewPaintParts.Border);

            if (EditImage != null)
                graphics.DrawImage(EditImage, GetEditRectangle(cellBounds));

            if (DeleteImage != null)
                graphics.DrawImage(DeleteImage, GetDeleteRectangle(cellBounds));
        }
    }
}
