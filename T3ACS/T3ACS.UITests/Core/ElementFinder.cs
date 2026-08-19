using System;
using System.Threading;
using FlaUI.Core.AutomationElements;

namespace T3ACS.UITests.Core
{
    public static class ElementFinder
    {
        /// <summary>Find a descendant by AutomationId (the field name in *.Designer.cs).</summary>
        public static AutomationElement FindById(AutomationElement root, string automationId, TimeSpan timeout)
        {
            var deadline = DateTime.UtcNow + timeout;
            while (DateTime.UtcNow < deadline)
            {
                AutomationElement found = null;
                try { found = root.FindFirstDescendant(cf => cf.ByAutomationId(automationId)); } catch { }
                if (found != null) return found;
                Thread.Sleep(300);
            }
            return null;
        }

        /// <summary>
        /// Find a descendant by its displayed text (Name) - use for menu items, labels, and
        /// runtime-generated controls (e.g. step type cards) that have no fixed AutomationId.
        /// </summary>
        public static AutomationElement FindByText(AutomationElement root, string text, TimeSpan timeout)
        {
            var deadline = DateTime.UtcNow + timeout;
            while (DateTime.UtcNow < deadline)
            {
                AutomationElement found = null;
                try { found = root.FindFirstDescendant(cf => cf.ByName(text)); } catch { }
                if (found != null) return found;
                Thread.Sleep(300);
            }
            return null;
        }
    }
}
