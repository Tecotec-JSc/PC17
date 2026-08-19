using System;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormNotiAll - the success/error popup shown by ShowNoti(...) after an action like
    /// "Create Procedure". Always its own top-level window (see WindowFinder.WaitForNewWindow).</summary>
    public class NotificationDialog
    {
        public Window Root { get; }
        public string Text { get; }

        public NotificationDialog(Window root)
        {
            Root = root;
            Text = string.Join(" | ", root.FindAllDescendants()
                .Select(e => { try { return e.Name; } catch { return ""; } })
                .Where(n => !string.IsNullOrWhiteSpace(n)));
        }

        public bool IsValidationError => Text.Contains("Validate User Input");

        public void ClickOk()
        {
            var okButton = Root.FindFirstDescendant(cf => cf.ByName("OK"))
                            ?? Root.FindFirstDescendant(cf => cf.ByControlType(ControlType.Button));
            if (okButton == null) throw new InvalidOperationException("OK button not found on notification dialog: " + Text);
            okButton.Click();
            Thread.Sleep(500);
        }
    }
}
