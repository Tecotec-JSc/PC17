
using System;
using System.Windows.Forms;

namespace T3.ServerHost
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            T3Server.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }
    }
}