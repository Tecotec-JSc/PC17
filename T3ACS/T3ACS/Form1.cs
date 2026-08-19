
using System;
using System.IO;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            selectVariable1.SetData(new List<string>() { "alibaba", "Oho" }, null);

        }
    
    }
}
