using System;
using System.Diagnostics;

namespace T3ACS.UITests.Core
{
    public static class ProcessCleanup
    {
        /// <summary>A previous run that didn't shut down cleanly can leave the isolated test app
        /// running and holding the DB file open; clear it before touching the DB or launching a
        /// fresh instance. Only kills processes running from exactly exePath, never a real dev
        /// instance running from a different folder.</summary>
        public static void KillStrayInstances(string exePath)
        {
            foreach (var proc in Process.GetProcessesByName("T3ACS"))
            {
                try
                {
                    if (string.Equals(proc.MainModule?.FileName, exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        proc.Kill();
                        proc.WaitForExit(5000);
                    }
                }
                catch { /* best-effort cleanup */ }
            }
        }
    }
}
