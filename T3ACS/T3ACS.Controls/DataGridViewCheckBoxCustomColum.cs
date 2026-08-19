using System.Windows.Forms;

namespace T3ACS.Controls
{
    public class DataGridViewCheckBoxCustomColumn : DataGridViewColumn
    {
        public DataGridViewCheckBoxCustomColumn()
            : base(new DataGridViewCheckBoxCustomCell())
        {
            Width = 45;
        }
        public object TrueValue
        {
            get => ((DataGridViewCheckBoxCustomCell)CellTemplate).TrueValue;
            set => ((DataGridViewCheckBoxCustomCell)CellTemplate).TrueValue = value;
        }

        public object FalseValue
        {
            get => ((DataGridViewCheckBoxCustomCell)CellTemplate).FalseValue;
            set => ((DataGridViewCheckBoxCustomCell)CellTemplate).FalseValue = value;
        }

        public object IndeterminateValue
        {
            get => ((DataGridViewCheckBoxCustomCell)CellTemplate).IndeterminateValue;
            set => ((DataGridViewCheckBoxCustomCell)CellTemplate).IndeterminateValue = value;
        }
    }
}