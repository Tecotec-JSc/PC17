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

using System.Drawing.Drawing2D;
using System.Globalization;
using System.Security.Cryptography;
using System.Xml.Linq;
using T3ACS.Model;
namespace T3ACS
{
    public partial class FormAddDUT : Form
    {
        public FormAddDUT(int dutId)
        {
            InitializeComponent();
            _id = dutId;
            _model = new DUTModel();
            loadData(_id);
        }

        public int _id;

        DUTModel _model;


        private void loadData(int id)
        {
            DUTViewModel vm = new DUTViewModel();
            if (id > 0)
            {
                vm = _model.GetByID(id);
            }
            if (vm == null) vm = new DUTViewModel();
            if (vm != null && vm.DUTId > 0)
            {
                lblTitleDUT.Text = "Update DUT";
                btnSave.Texts = "Save";
            }
            else
            {
                lblTitleDUT.Text = "Add New DUT";
                btnSave.Texts = "Add DUT";
            }

            txtName.Texts = vm.DUTName;
            txtCategory.Texts = vm.Category;
            txtModel.Texts = vm.DUTModel;
            txtSerialNumber.Texts = vm.SensorNumber;
            txtManufacturer.Texts = vm.Brand;
            txtCalibrationDate.Texts = vm.CalibrationDate;
            txtCalibrationDue.Texts = vm.CalibrationDue;
            txtShipmentDate.Texts = vm.ShipmentDate;
            txtUserUnit.Texts = vm.UserUnit;
        }


        private void SetFormRadius(int radius)
        {
            GraphicsPath path = new GraphicsPath();

            Rectangle rect = new Rectangle(0, 0, Width, Height);
            int d = radius * 2;

            path.StartFigure();

            // Top Left
            path.AddArc(rect.Left, rect.Top, d, d, 180, 90);

            // Top Right
            path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);

            // Bottom Right
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);

            // Bottom Left
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();

            Region?.Dispose();
            Region = new Region(path);
            path.Dispose();
        }

        private void FormAddDUT_Load(object sender, EventArgs e)
        {
            SetFormRadius(5);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCustom2__EventSelect(object sender, EventArgs e)
        {
            var check = true;
            var messageB = "";
            var name = txtName.Texts;
            var category = txtCategory.Texts;
            var modelDUT = txtModel.Texts;
            var serialNumber = txtSerialNumber.Texts;
            var manufacturer = txtManufacturer.Texts;
            var calibrationDate = txtCalibrationDate.Texts;
            var calibrationDue = txtCalibrationDue.Texts;
            var shippingDate = txtShipmentDate.Texts;
            var userUnit = txtUserUnit.Texts;
            List<int> a = new List<int>();

            if (string.IsNullOrEmpty(name)  || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(serialNumber) || string.IsNullOrEmpty(manufacturer)/* || string.IsNullOrEmpty(calibrationDate) || string.IsNullOrEmpty(calibrationDue) || string.IsNullOrEmpty(shippingDate) || string.IsNullOrEmpty(userUnit)*/ || string.IsNullOrEmpty(modelDUT))
            {
                ShowMess("Notification", "You must input all required information .", 2);
                return;
            }
            if (serialNumber.IndexOf(" ") != -1 || serialNumber.Length > 10)
            {
                ShowMess("Notification", "Serial can have 10 characters maximum and can not contain space.", 2);
                return;
            }
            if (modelDUT.IndexOf(" ") != -1 || modelDUT.Length > 10)
            {
                ShowMess("Notification", "Model can have 10 characters maximum and can not contain space.", 2);
                return;
            }

            if(!string.IsNullOrEmpty(calibrationDate))
            try
            {
                DateTime.ParseExact(calibrationDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            }
            catch
            {
                ShowMess("Notification", "Calibration Date is date type dd/MM/yyyy.", 2);
                return;
            }
            if (!string.IsNullOrEmpty(calibrationDue))
                try
            {
                DateTime.ParseExact(calibrationDue, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            }
            catch
            {
                ShowMess("Notification", "Calibration Due is date type dd/MM/yyyy.", 2);
                return;
            }
            if (!string.IsNullOrEmpty(shippingDate))
                try
            {
                DateTime.ParseExact(shippingDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            }
            catch
            {
                ShowMess("Notification", "Shipment Date is date type dd/MM/yyyy.", 2);
                return;
            }
            DUTViewModel vm = new DUTViewModel() { DUTId = _id };
            vm.DUTName = name;
            vm.DUTModel = modelDUT;
            vm.Category = txtCategory.Texts;
            vm.SensorNumber = txtSerialNumber.Texts;
            vm.Brand = txtManufacturer.Texts;
            vm.CalibrationDate = txtCalibrationDate.Texts;
            vm.CalibrationDue = txtCalibrationDue.Texts;
            vm.ShipmentDate = txtShipmentDate.Texts;
            vm.UserUnit = txtUserUnit.Texts;
            if (vm.DUTId > 0)
            {
                if (_model.UpdateDUT(vm))
                {
                    messageB = "Update new DUT successfully.";
                }
                else
                {
                    check = false;
                    messageB = "Error to update DUT.";
                }

            }
            else
            {
                _id = _model.InsertDUT(vm);
                if (_id > 0)
                {

                    messageB = "Insert new DUT successfully.";
                }
                else
                {
                    check = false;
                    messageB = "Error to insert DUT.";
                }
            }
            ShowMess("Notification", messageB, 2);
            if (check)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>
        private void ShowMess(string title, string strmess, int status)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            frmNoti.ShowDialog();
            frmNoti.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
            this.Focus();
        }

        private void ButtonCustom1__EventSelect(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Load(object sender, EventArgs e)
        {

        }
    }
}
