
using T3ACS.Model;

namespace T3ACS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException +=
                CurrentDomain_UnhandledException;

            TaskScheduler.UnobservedTaskException +=
                TaskScheduler_UnobservedTaskException;

            AppDomain.CurrentDomain.ProcessExit +=
                CurrentDomain_ProcessExit;

            Application.ApplicationExit +=
                Application_ApplicationExit;

            Logger.Log("========== APP START ==========");









            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            T3.Configuration.Main.LoadVariablesFromRegistry();
            T3.Configuration.Main.LoadThemeDefault();


            //Application.AddMessageFilter(new MouseClickFilter());
            ILicenseModel model = new LicenseModel();
            //bool checkLicense = true;
            bool checkLicense = model.CheckKeyLicense();
            if (!checkLicense)
            {
                FormLicense frmLicense = new FormLicense();
                if (frmLicense.ShowDialog() == DialogResult.OK)
                {
                    checkLicense = true;
                }
            }
            if (checkLicense)
            {
                ThemeT3ACS.IsSelectedTheme = false;
                ThemeT3ACS them = new ThemeT3ACS();
           
                them.LoadThemeDefault();
                them.LoadThemeSelected();
               Application.Run(new VSat.Spectrum.FormLoadScreen());

                // Yêu cầu đăng nhập trước khi vào màn hình chính. Đăng nhập thành công sẽ set
                // Session.CurrentUserId để tầng Data ghi audit (người tạo/sửa) cho mỗi bản ghi.
                using (var frmLogin = new FormLogin())
                {
                    if (frmLogin.ShowDialog() != DialogResult.OK)
                        return; // Không đăng nhập -> thoát ứng dụng.
                }

                Application.Run(new FormMain());
           //  Application.Run(new FormTest1());
            }


        }
        private static void Application_ThreadException(
 object sender,
 System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.Log("THREAD EXCEPTION");
            Logger.Log(e.Exception.ToString());
        }

        private static void CurrentDomain_UnhandledException(
            object sender,
            UnhandledExceptionEventArgs e)
        {
            Logger.Log("UNHANDLED EXCEPTION");

            if (e.ExceptionObject != null)
                Logger.Log(e.ExceptionObject.ToString());
        }

        private static void TaskScheduler_UnobservedTaskException(
            object sender,
            UnobservedTaskExceptionEventArgs e)
        {
            Logger.Log("TASK EXCEPTION");
            Logger.Log(e.Exception.ToString());

            e.SetObserved();
        }

        private static void CurrentDomain_ProcessExit(
            object sender,
            EventArgs e)
        {
            Logger.Log("PROCESS EXIT");
        }

        private static void Application_ApplicationExit(
            object sender,
            EventArgs e)
        {
            Logger.Log("APPLICATION EXIT");
        }
    }
}