using T3ACS.Model;

namespace T3ACS
{
    public partial class FormTableInfo : Form
    {
        private TableProcedureViewModel _vm;
        private int _startCycle;

        public FormTableInfo(TableProcedureViewModel vm, int startCycle)
        {
            InitializeComponent();
            _vm = vm;
            _startCycle = startCycle;
            txaDescription.Rtf = vm.Description;
            txtStepName.Texts = vm.Title;
            if (vm.Required) lblCheck.Image = Properties.Resources.Radio_Button;
            else lblCheck.Image = Properties.Resources.rdonocheck;
            txaDescription.ReadOnly = true;
        }
    }
}
