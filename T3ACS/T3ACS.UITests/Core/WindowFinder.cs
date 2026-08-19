using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace T3ACS.UITests.Core
{
    /// <summary>
    /// UIA's own top-level-window enumeration proved unreliable for this app's borderless
    /// (FormBorderStyle.None) child dialogs, so every lookup here goes through raw Win32
    /// EnumWindows instead. See HUONG_DAN_AUTOMATION.md section 5.1 for the three window
    /// "shapes" this app uses and which lookup applies to each.
    /// </summary>
    public static class WindowFinder
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public static List<(IntPtr Handle, string Title)> GetProcessWindows(int pid)
        {
            var result = new List<(IntPtr, string)>();
            EnumWindows((hWnd, _) =>
            {
                GetWindowThreadProcessId(hWnd, out uint wpid);
                if (wpid == (uint)pid && IsWindowVisible(hWnd))
                {
                    var sb = new StringBuilder(256);
                    GetWindowText(hWnd, sb, 256);
                    result.Add((hWnd, sb.ToString()));
                }
                return true;
            }, IntPtr.Zero);
            return result;
        }

        public static List<IntPtr> SnapshotHandles(Application app) =>
            GetProcessWindows(app.ProcessId).ConvertAll(w => w.Handle);

        /// <summary>
        /// Find a borderless/untitled popup (DropdownPopup, FormPopUpMultiAdd...) by diffing the
        /// process's window handles before/after the action that opens it.
        /// </summary>
        public static Window WaitForNewWindow(Application app, UIA3Automation automation, List<IntPtr> before, TimeSpan timeout)
        {
            var deadline = DateTime.UtcNow + timeout;
            while (DateTime.UtcNow < deadline)
            {
                var now = GetProcessWindows(app.ProcessId);
                var added = now.Find(w => !before.Contains(w.Handle));
                if (added.Handle != IntPtr.Zero)
                {
                    return automation.FromHandle(added.Handle).AsWindow();
                }
                Thread.Sleep(200);
            }
            return null;
        }

        /// <summary>
        /// Find a modal dialog (ShowDialog(), has a real Text/title) by its exact Win32 window
        /// title - NOT the label text shown inside it.
        /// </summary>
        public static Window FindWindowByTitle(Application app, UIA3Automation automation, string title, TimeSpan timeout)
        {
            var deadline = DateTime.UtcNow + timeout;
            while (DateTime.UtcNow < deadline)
            {
                var match = GetProcessWindows(app.ProcessId).Find(w => w.Title == title);
                if (match.Handle != IntPtr.Zero)
                {
                    return automation.FromHandle(match.Handle).AsWindow();
                }
                Thread.Sleep(300);
            }
            Console.WriteLine($"Window '{title}' not found. Visible windows: " +
                string.Join(", ", GetProcessWindows(app.ProcessId).ConvertAll(w => $"'{w.Title}'")));
            return null;
        }
    }
}
