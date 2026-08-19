using T3ACS.Controls;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormAddPara : Form
    {
        public List<string> paraControlName;
        public List<string> _titles;
        public List<ParaControl> paraControls;
        public  List<ProcedureVariableViewModel> _data;

        public FormAddPara()
        {
            InitializeComponent();
            //this.AutoScroll = true;
            ////_imain = imain;
            //// ❌ Không cho scroll ngang
            //this.HorizontalScroll.Enabled = false;
            //this.HorizontalScroll.Visible = false;

            //// Ngưỡng xuất hiện scroll Y
            //this.AutoScrollMinSize = new Size(0, 489);
        }
        int y;
        public void LoadData(List<ProcedureVariableViewModel> variable,string steptypeTitle)
        {
            flowLayoutPanel1.Controls.Clear();
           lblTitleListPara.Text = steptypeTitle;
            _data = variable;
            paraControlName = new List<string>();
            _titles = new List<string>();
            paraControls = new List<ParaControl>();
            y = 1;
            if (variable != null && variable.Count > 0)
            {
                foreach (var item in variable)
                {
                    string value = "Value: " + item.Value + " " + item.Unit;
                    ParaControl control = new ParaControl();
                    if (item.Type == "Double")
                    {
                        string rank = "Ranks: ";
                        if (item.Min != null)
                        {
                            if (item.Max != null)
                            {

                                rank += item.Min + " to " + item.Max;
                            }
                            else
                            {
                                rank += "Min " + item.Min;
                            }
                            rank += " " + item.Unit;
                        }
                        else
                        {
                            if (item.Max != null) rank += "Max " + item.Max + " " + item.Unit;
                        }

                        control.LoadData(item.Name, item.Title, value, rank);
                    }
                    else
                    {
                        control.LoadData(item.Name, item.Title, value, "");
                    }
                    control.Location = new Point(24, y);
                    control.EventEdit += btn_EditClick;
                    control.EventRemove += btn_RemoveClick;
                    flowLayoutPanel1.Controls.Add(control);
                    y += 148;
                    paraControlName.Add(item.Name);
                    _titles.Add(item.Title);
                    paraControls.Add(control);
                }
            }
            ResizeForm();
        }
        public void AddPara(ProcedureVariableViewModel item)
        {
            if (_data == null) _data = new List<ProcedureVariableViewModel>();
            _data.Add(item);
            string value = "Value: " + item.Value + " " + item.Unit;
            ParaControl control = new ParaControl();
            if (item.Type == "Double")
            {
                string rank = "Ranks: ";
                if (item.Min != null)
                {
                    if (item.Max != null)
                    {

                        rank += item.Min + " to " + item.Max;
                    }
                    else
                    {
                        rank += "Min " + item.Min;
                    }
                    rank += " " + item.Unit;
                }
                else
                {
                    if (item.Max != null) rank += "Max " + item.Max + " " + item.Unit;
                }

                control.LoadData(item.Name, item.Title, value, rank);
            }
            else
            {
                control.LoadData(item.Name, item.Title, value, "");
            }        
            control.EventEdit += btn_EditClick;
            control.EventRemove += btn_RemoveClick;
            flowLayoutPanel1.Controls.Add(control);         
            if (paraControlName == null) paraControlName = new List<string>();
            paraControlName.Add(item.Name);
            if(_titles==null) _titles = new List<string>();
            _titles.Add(item.Title);
            if (paraControls == null) paraControls = new List<ParaControl>();
            paraControls.Add(control);
            ResizeForm();
        }
        public int HeightForm;
        public void ResizeForm()
        {           
            HeightForm = 40;
            if(flowLayoutPanel1!=null&&flowLayoutPanel1.Controls.Count>0)
            {
                foreach(System.Windows.Forms.Control control in flowLayoutPanel1.Controls)
                {
                    HeightForm += control.Height +8;
                }
            }
            if(HeightForm < 343) HeightForm = 343;
            flowLayoutPanel1.Height = HeightForm - 40;
            this.SuspendLayout();

            this.Size = new Size(this.Width, HeightForm);

            this.ResumeLayout();
            this.Refresh();

        }
        public void RemovePara(string name)
        {
            ParaControl btn = paraControls.Where(t => t.Name == name).FirstOrDefault();
            int i = 0;
            foreach (var item in paraControlName)
            {
                if (item == btn.Name)
                {
                    _data.RemoveAt(i);
                }
                i++;
            }
            paraControls.Remove(btn);
            paraControlName.Remove(btn.Name);
            flowLayoutPanel1.Controls.Remove(btn);
            if (paraControls.Count > 0)
            {

                foreach (ParaControl item in paraControls)
                {
                    if (item.Location.Y > btn.Location.Y)
                    {
                        item.Location = new Point(24, item.Location.Y - 148);
                    }

                }
            }
            btn.Dispose();
            ResizeForm();
        }
        private void btn_EditClick(object sender, EventArgs e)
        {
            //ParaControl? btn = sender as ParaControl;
            //if (btn != null)
            //{
            //    FormBlur blur = new FormBlur();
            //    blur.Size = new Size(1920, 1080);
            //    blur.Location = this.Location;
            //    blur.Show();

            //    int i = 0;
            //    foreach (var item in paraControlName)
            //    {
            //        if (item == btn.Name)
            //        {
            //            break;
            //        }
            //        i++;
            //    }
            //    var item1 = _data1[i];
            //    List<string> names1 = new List<string>();
            //    foreach (var item in paraControlName)
            //    {
            //        if (item != item1.Name) names1.Add(item);
            //    }
            //    List<string> titl1 = new List<string>();
            //    foreach (var item in _titles)
            //    {
            //        if (item != item1.Title) titl1.Add(item);
            //    }
            //    if (item1.Type == "Double")
            //    {
            //        FormAddNumberInputValue frmNumber = new FormAddNumberInputValue();
            //        frmNumber.LoadData(names1, titl1);
            //        frmNumber.EditPara(item1.Name, item1.Title, item1.Value, item1.Min + "", item1.Max + "", item1.Unit);
            //        if (frmNumber.ShowDialog() == DialogResult.OK)
            //        {
            //            var data = frmNumber.GetValueInput();
            //            _data1[i].Name = data[0];
            //            _data1[i].Value = data[1];
            //            _data1[i].Unit = data[4];
            //            _data1[i].Title = data[5];
            //            _data1[i].NumberOder = _data1.Count + 1;
            //            if (!string.IsNullOrEmpty(data[2])) _data1[i].Min = double.Parse(data[2]);
            //            if (!string.IsNullOrEmpty(data[3])) _data1[i].Max = double.Parse(data[3]);
            //            paraControlName[i] = data[0];
            //            _titles[i] = data[5];
            //            string value = "Value: " + data[1] + " " + data[4];
            //            if (_data1[i].Type == "Double")
            //            {
            //                string rank = "Ranks: ";
            //                if (_data1[i].Min != null)
            //                {
            //                    if (_data1[i].Max != null)
            //                    {

            //                        rank += _data1[i].Min + " to " + _data1[i].Max;
            //                    }
            //                    else
            //                    {
            //                        rank += "Min " + _data1[i].Min;
            //                    }
            //                    rank += " " + _data1[i].Unit;
            //                }
            //                else
            //                {
            //                    if (_data1[i].Max != null) rank += "Max " + _data1[i].Max + " " + _data1[i].Unit;
            //                }

            //                btn.LoadData(_data1[i].Name, _data1[i].Title, value, rank);
            //            }
            //            else
            //            {
            //                btn.LoadData(_data1[i].Name, _data1[i].Title, value, "");
            //            }
            //        }
            //        frmNumber.Dispose();
            //    }
            //    else if (item1.Type.ToUpper() == "STRING")
            //    {
            //        FormAddStringInputValue frmString = new FormAddStringInputValue();
            //        frmString.LoadData(names1, titl1);
            //        frmString.EditPara(item1.Name, item1.Title, item1.Value);
            //        if (frmString.ShowDialog() == DialogResult.OK)
            //        {
            //            var data = frmString.GetValueInput();
            //            _data1[i].Name = data[0];
            //            _data1[i].Value = data[1];                    
            //            _data1[i].Title = data[2];
            //            _data1[i].NumberOder = _data1.Count + 1;        
            //            paraControlName[i] = data[0];
            //            _titles[i] = data[2];
            //            string value = "Value: " + data[1];                       
            //                btn.LoadData(_data1[i].Name, _data1[i].Title, value, "");
                      
            //        }
            //        frmString.Dispose();
            //    }
                
            //    blur.Close();
            //    blur.Dispose();
            //    this.Focus();
            //}
        }
        private void btn_RemoveClick(object sender, EventArgs e)
        {
            ParaControl btn = sender as ParaControl;
            int i = 0;
            foreach (var item in paraControlName)
            {
                if (item == btn.Name)
                {
                    _data.RemoveAt(i);
                }
                i++;
            }
            paraControls.Remove(btn);
            paraControlName.Remove(btn.Name);
            flowLayoutPanel1.Controls.Remove(btn);
            if (paraControls.Count > 0)
            {

                foreach (ParaControl item in paraControls)
                {
                    if (item.Location.Y > btn.Location.Y)
                    {
                        item.Location = new Point(24, item.Location.Y - 148);
                    }

                }
            }
            btn.Dispose();
        }
       
    }
}
