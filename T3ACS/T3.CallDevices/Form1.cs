namespace T3.CallDevices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool connected =
    T3Client.Invoke<bool>(
        @"C:\CTMT2025\CTMT2025\Micran\Dll\MicranModel.dll",
        "MicranModel.VNAModel",
        "Connect", new object[] { "", "" ,"",""});

        }
    }
}
