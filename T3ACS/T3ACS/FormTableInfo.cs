using T3ACS.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormTableInfo : Form
    {
        TableProcedureViewModel _vm;
        int _startCycle;
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
