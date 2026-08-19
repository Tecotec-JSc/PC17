using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Controls
{
    public class DataGridViewActionColumn : DataGridViewColumn
    {
        public DataGridViewActionColumn()
            : base(new DataGridViewActionCell())
        {
            Width = 70;
            HeaderText = "Actions";
        }

        public Image EditImage
        {
            get => ((DataGridViewActionCell)CellTemplate).EditImage;
            set => ((DataGridViewActionCell)CellTemplate).EditImage = value;
        }

        public Image DeleteImage
        {
            get => ((DataGridViewActionCell)CellTemplate).DeleteImage;
            set => ((DataGridViewActionCell)CellTemplate).DeleteImage = value;
        }
    }
}
