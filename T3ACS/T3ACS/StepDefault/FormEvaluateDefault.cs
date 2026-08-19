using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using T3ACS.Controls;
using T3ACS.Model;
using T3ACS.ViewModel;

namespace T3ACS
{
    public partial class FormEvaluateDefault : Form
    {
        public FormEvaluateDefault()
        {
            InitializeComponent();                       
            LoadButtonBot();
            panelForm.AutoScroll = true;
            panelForm.HorizontalScroll.Enabled = false;
            panelForm.HorizontalScroll.Visible = false;
            panelForm.AutoScrollMinSize = new Size(0, 804);   
        }
        public void ShowEvalueate(Form form, string note,bool? done)
        {
            _Maskdone = done;
            MaskDone();        
            rtbNote.Texts = note;
            panelString.SuspendLayout();
            panelString.Controls.Clear();         
            if (form != null)
            {
                form.TopLevel = false;               
                panelString.Controls.Add(form);
                form.Size = panelString.Size;
                form.Show();
                form.BringToFront();
            }
        }
        public void LoadButtonBot()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            //btnPass
            btnPass._ImageDefault = Image.FromFile(pathApp + "PassDefault.png");
            btnPass._ImageSelect = Image.FromFile(pathApp + "PassActive.png");
            btnPass._ImageDisable = Image.FromFile(pathApp + "PassDisable.png");

            btnPass.SetEnalbe(true);
            //btnFailed
            btnFailed._ImageDefault = Image.FromFile(pathApp + "FailedDefault.png");
            btnFailed._ImageSelect = Image.FromFile(pathApp + "FailedActive.png");
            btnFailed._ImageDisable = Image.FromFile(pathApp + "FailedDisable.png");

            btnFailed.SetEnalbe(true);
            //btnExport
            btnExport._ImageDefault = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageSelect = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageDisable = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport.Cursor = Cursors.No;
            btnExport.SetEnalbe(false);

            //btnExport
            btnQuit.Texts = "Quit";
            btnQuit.BorderColor = Color.FromArgb(0, 112, 203);
            btnQuit.ForeColor = Color.FromArgb(0, 112, 203);

        }    

        public string GetNote()
        {
            return rtbNote.Texts;
        }
        public bool? _Maskdone;
        private void MaskDone()
        {
            if (_Maskdone.HasValue)
            {
                btnPass.SetValue(_Maskdone.Value);
                btnFailed.SetValue(!_Maskdone.Value);
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            _Maskdone = true;
            MaskDone();
        }

        private void btnFailed_Click(object sender, EventArgs e)
        {
            _Maskdone = false;
            MaskDone();
        }
        public event EventHandler _StopProcedure;
        private void btnQuit_Click(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }
    }
}
