using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Controls.SelectStepType
{
    public class SelectPopup : Form
    {
        private ListBox lstItems;
        private List<string> _data = new();

        public event Action<string> ItemSelected;

        public SelectPopup(int width)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Width = 498;
            Height = 250;



            lstItems = new ListBox
            {
                Dock = DockStyle.Fill,
                DrawMode = DrawMode.OwnerDrawFixed
            };
            Controls.Add(lstItems);
            lstItems.Click += SelectItem;
            lstItems.DrawItem += DrawItem;
            lstItems.ItemHeight = 34;   // chiều cao mỗi item
            lstItems.Font = new Font("Segoe UI", 10f);
        }
        public void SetData(List<string> data)
        {
            _data = data;
            lstItems.DataSource = _data.ToList();
        }

        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Brush brush = new SolidBrush(Color.FromArgb(0, 82, 130));
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            e.Graphics.FillRectangle(
                selected ? brush : Brushes.White, e.Bounds

                );

            e.Graphics.DrawString(
                lstItems.Items[e.Index].ToString(),
                e.Font,
                selected ? Brushes.White : Brushes.Black,
                e.Bounds);
        }
        private void SelectItem(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem == null) return;
            ItemSelected?.Invoke(lstItems.SelectedItem.ToString());
            Hide();
        }

    }
}
