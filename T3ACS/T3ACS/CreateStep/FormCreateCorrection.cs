using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormCreateCorrection : Form
    {
        public FormCreateCorrection()
        {
            InitializeComponent();

        }
        public List<ProcedureVariableViewModel> _varis;
        public List<ProcedureDetaiVariableViewModel> _data;
        public void SetdatSelect()
        {
            if (_varis == null) _varis = new List<ProcedureVariableViewModel>();
            List<string> lstdata = new List<string>();
            if (_varis.Count > 0)
            {
                lstdata = _varis.Select(t => t.Name).ToList();
            }
            selectMarkerId.SetData(lstdata);
            selectReadingValue.SetData(lstdata);
        }
        public int _stepNumber;
        public void LoadData(List<ProcedureVariableViewModel> varis, List<ProcedureDetaiVariableViewModel> data,int step)
        {
            _varis = varis;
            _data = data;
            _stepNumber= step;
            SetdatSelect();
            if (_data != null && _data.Count > 3)
            {
                _data = _data.OrderBy(t=>t.NumberOrder).ToList();
                var pathDll = varis.Where(t => t.Name == _data[0].Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(pathDll.Value)) selectFileDll.Texts = pathDll.Value;
                var pathcalib = varis.Where(t => t.Name == _data[1].Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(pathcalib.Value)) selectFileCalibration.Texts = pathcalib.Value;
                var marker = varis.Where(t => t.Name == _data[2].Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(marker.Name)) selectMarkerId.Texts = marker.Name;
                var readingv = varis.Where(t => t.Name == _data[3].Name).FirstOrDefault();
                if (!string.IsNullOrEmpty(readingv.Name)) selectReadingValue.Texts = readingv.Name;
            }
        }
        public bool checkSave(out string mess)
        {
            mess = "";
            var strdll= selectFileDll.Texts;
            if (string.IsNullOrEmpty(strdll))
            {
                mess = "You need to select a DLL file before saving.";
                return false;
            }
            var strcalib = selectFileCalibration.Texts;
            if (string.IsNullOrEmpty(strcalib))
            {
                mess = "You need to select a Calibration file before saving.";
                return false;
            }
            var strMarker = selectMarkerId.Texts;
            if (string.IsNullOrEmpty(strMarker)||strMarker== "Select parameter")
            {
                mess = "You must select a parameter marker before saving.";
                return false;
            }
            var strReading = selectReadingValue.Texts;
            if (string.IsNullOrEmpty(strMarker) || strMarker == "Select parameter")
            {
                mess = "You must select a parameter reading value before saving.";
                return false;
            }
            return true;
        }
        public void SaveData() {
            if (_data == null)
            {
                _data = new List<ProcedureDetaiVariableViewModel> ();
            }
            if (_data.Count == 0||_data.Count<4)
            {
                ProcedureVariableViewModel vDll = new ProcedureVariableViewModel ();
                vDll.Name = "pathDllCorrection";
                int newId = 1;
                while (_varis.Count(t => t.Name == vDll.Name) > 0)
                {
                    vDll.Name = "pathDllCorrection" + newId;
                    newId++;
                }
                vDll.Title = "Path dll Correction";
                vDll.Report = false;
                vDll.Required = false;
                vDll.Type = "String";
                vDll.Value=selectFileDll.Texts;
                _varis.Add(vDll);
                ProcedureDetaiVariableViewModel vdDll = new ProcedureDetaiVariableViewModel ();
                vdDll.Value = vDll.Value;
                vdDll.Name = vDll.Name;
                vdDll.NumberOrder = 1;
                vdDll.ProcedureDetailId = _stepNumber;
                _data.Add(vdDll);
                ProcedureVariableViewModel vCorrection = new ProcedureVariableViewModel();
                vCorrection.Name = "pathCorrection";
                newId = 1;
                while (_varis.Count(t => t.Name == vCorrection.Name) > 0)
                {
                    vCorrection.Name = "pathCorrection" + newId;
                    newId++;
                }
                vCorrection.Title = "Path Correction";
                vCorrection.Report = false;
                vCorrection.Required = false;
                vCorrection.Type = "String";
                vCorrection.Value = selectFileCalibration.Texts;
                _varis.Add(vCorrection);
                ProcedureDetaiVariableViewModel vdCorrection= new ProcedureDetaiVariableViewModel();
                vdCorrection.Value = vCorrection.Value;
                vdCorrection.Name = vCorrection.Name;
                vdCorrection.NumberOrder = 2;
                vdCorrection.ProcedureDetailId = _stepNumber;
                _data.Add(vdCorrection);

                var vReading = _varis.Where(t=>t.Name==selectReadingValue.Texts).FirstOrDefault();

                ProcedureDetaiVariableViewModel vdMapReading = new ProcedureDetaiVariableViewModel();
                vdMapReading.Value = vReading.Value;
                vdMapReading.Name = vReading.Name;
                vdMapReading.NumberOrder = 4;
                vdMapReading.ProcedureDetailId = _stepNumber;
                _data.Add(vdMapReading);

                var vMarkerID = _varis.Where(t => t.Name == selectMarkerId.Texts).FirstOrDefault();

                ProcedureDetaiVariableViewModel vdMapMarker = new ProcedureDetaiVariableViewModel();
                vdMapMarker.Value = vMarkerID.Value;
                vdMapMarker.Name = vMarkerID.Name;
                vdMapMarker.NumberOrder = 3;
                vdMapMarker.ProcedureDetailId = _stepNumber;
                _data.Add(vdMapMarker);
            }
            else
            {
                _data= _data.OrderBy(t=>t.NumberOrder).ToList();
                _data[0].Value=selectFileDll.Texts;              
                _varis.Where(t => t.Name == _data[0].Name).FirstOrDefault().Value= selectFileDll.Texts;
                _data[1].Value = selectFileCalibration.Texts;
                _varis.Where(t => t.Name == _data[1].Name).FirstOrDefault().Value = selectFileCalibration.Texts;
                var marker= _varis.Where(t=>t.Name == selectMarkerId.Texts).FirstOrDefault();
                _data[2].Name = marker.Name;
                _data[2].Value= marker.Value;
                var reading = _varis.Where(t => t.Name == selectReadingValue.Texts).FirstOrDefault();
                _data[3].Name = reading.Name;
                _data[3].Value = reading.Value;
            }

           
        }

        private void selectMarkerId__eventAddnew(object sender, EventArgs e)
        {
            FormAddOneVariable frm = new FormAddOneVariable();    
            frm.LoadData(_varis);
            if(frm.ShowDialog()==DialogResult.OK)
            {
                _varis = frm._variables;
                var lstdata = _varis.Select(t => t.Title).ToList();
                selectMarkerId.SetData(lstdata);
                selectReadingValue.SetData(lstdata);
            }
        }
    }
}
