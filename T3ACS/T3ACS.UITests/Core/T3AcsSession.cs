using System;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace T3ACS.UITests.Core
{
    /// <summary>
    /// One running instance of the isolated test app + the automation handles a test needs to
    /// drive it. Screens (see T3ACS.UITests.Screens) take a session instead of separate
    /// Application/UIA3Automation/mainWindow parameters.
    /// </summary>
    public sealed class T3AcsSession : IDisposable
    {
        public Application App { get; }
        public UIA3Automation Automation { get; }
        public AutomationElement MainWindow { get; }
        public Screenshotter Shots { get; }

        private T3AcsSession(Application app, UIA3Automation automation, AutomationElement mainWindow, Screenshotter shots)
        {
            App = app;
            Automation = automation;
            MainWindow = mainWindow;
            Shots = shots;
        }

        /// <summary>testName namespaces this run's screenshots (see Screenshotter) - pass the
        /// calling test's name, e.g. via UiTestBase.LaunchApp's [CallerMemberName] default.</summary>
        public static T3AcsSession Launch(string exePath, string shotsDir, string testName)
        {
            var automation = new UIA3Automation();
            var app = Application.Launch(exePath);
            var mainWindow = app.GetMainWindow(automation, TimeSpan.FromSeconds(30));
            Thread.Sleep(1000); // let the main window finish laying out before driving it

            var session = new T3AcsSession(app, automation, mainWindow, new Screenshotter(shotsDir, testName));
            session.Shots.Take(mainWindow, "app-started");
            return session;
        }

        /// <summary>
        /// A stuck modal dialog (validation popup left open by a failing assertion, etc.) can
        /// make App.Close() a no-op - it only asks the window to close, it doesn't guarantee it
        /// does. Escalate to Kill() if the process is still alive shortly after, so a failing
        /// test doesn't leave a stray T3ACS.exe holding the DB file open for the next run (the
        /// exact problem ProcessCleanup.KillStrayInstances exists to paper over - fixing it here
        /// means future test authors hit it less often).
        /// </summary>
        public void Dispose()
        {
            try
            {
                App.Close();
                for (int i = 0; i < 10 && !App.HasExited; i++)
                {
                    Thread.Sleep(200);
                }
                if (!App.HasExited)
                {
                    App.Kill();
                }
            }
            catch { /* best-effort */ }

            Automation.Dispose();
        }
    }
}
