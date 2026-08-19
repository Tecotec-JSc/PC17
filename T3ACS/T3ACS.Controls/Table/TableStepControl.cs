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
    public partial class TableStepControl : UserControl
    {
        private Color borderColor = Color.DarkGray;
        private Color borderFocusColor = Color.FromArgb(3, 120, 212);

        private Color hoverGround = Color.DarkGray;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private int borderSize = 1;
        private int borderRadius = 0;
        public event EventHandler _ClickControl;
        public string StepType;
        public TableStepControl()
        {
            InitializeComponent();
        }
        RowStepControl CardAcive;
        public string rowActiveName;
        public void LoadFormData(List<SortCardViewModel> cards)
        {
            if (panelContent.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control item in panelContent.Controls)
                {
                    item.Dispose();
                }
            }
            panelContent.Controls.Clear();
            if (cards != null && cards.Count > 0)
            {
                foreach (var card in cards)
                {
                    RowStepControl rowStepControl = new RowStepControl();
                    rowStepControl.Width = panelContent.Width;
                    rowStepControl.SetValue(card.Name, card.Content, card.NumberOrder);
                    rowStepControl._ClickControl += rowClick;
                    panelContent.Controls.Add(rowStepControl);
                }
            }
        }
        public void SetActive(int numberoder)
        {
            foreach (RowStepControl row in panelContent.Controls)
            {
                if (row._NumberOrder == numberoder)
                {
                    row._Selected = true;
                    rowActiveName = row.Name;
                }
                else row._Selected = false;
                row.ChangeStyleSelect();
            }
        }
        public void RemoveStep(int numberOder)
        {
            foreach (RowStepControl row in panelContent.Controls)
            {
                if (row._NumberOrder == numberOder)
                {
                    panelContent.Controls.Remove(row);                    
                }             
           
            }
            if (panelContent.Controls.Count > 0)
            {
                foreach (RowStepControl row in panelContent.Controls)
                {
                    if (row._NumberOrder > numberOder)
                    {
                        row.ChangeNumberOrder(row._NumberOrder - 1);        
                    }
                }               
                SetActive(numberOder - 1);
            }
        }
        private void rowClick(object sender, EventArgs e)
        {

            // Raise event ra ngoài
            _ClickControl?.Invoke(sender, EventArgs.Empty);

            // (Option) Raise luôn Click của UserControl
            this.OnClick(e);
        }
        public void RowSelect(RowStepControl btn)
        {

            foreach (RowStepControl row in panelContent.Controls)
            {
                if (row.Name == btn.Name)
                {
                    row._Selected = true;
                    rowActiveName = row.Name;
                }
                else row._Selected = false;
                row.ChangeStyleSelect();
                rowActiveName = btn.Name;
            }
        }
        public void AddNewStep(string name, string content, int numberOrder)
        {
            RowStepControl rowStepControl = new RowStepControl();
            rowStepControl.Width = panelContent.Width;
            rowStepControl.SetValue(name, content, numberOrder);
            rowStepControl._ClickControl += rowClick;
            panelContent.Controls.Add(rowStepControl);
        }
        public void SetText(int numberOrder, string text)
        {
            foreach (RowStepControl row in panelContent.Controls)
            {
                if (row._NumberOrder == numberOrder)
                {
                    row.SetText(numberOrder + ". " + text);
                }

            }
        }
        public void ChangeIndexControl(int control1number, int control2Number)
        {
            RowStepControl control1 = panelContent.Controls[control1number-1] as RowStepControl;
            RowStepControl control2 = panelContent.Controls[control2Number - 1] as RowStepControl;
            panelContent.SuspendLayout();
            panelContent.Controls.SetChildIndex(control1, control2Number-1);
            panelContent.Controls.SetChildIndex(control2, control1number - 1);
            control1.ChangeNumberOrder(control2Number);
            control2.ChangeNumberOrder(control1number); 
            panelContent.ResumeLayout();
        }
        
    }
}
