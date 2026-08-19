using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;

namespace T3ACS.UITests.Core
{
    public static class Interactions
    {
        /// <summary>
        /// RJTextBox32/RJEditor/RJTextSeach wrap a real inner TextBox/RichTextBox (field name
        /// e.g. "textBox1") with a DIFFERENT AutomationId than the field you found by name -
        /// typing has to land on that inner Edit/Document element, not the wrapper. Prefer the
        /// UIA ValuePattern over synthetic keystrokes: a click doesn't reliably transfer native
        /// keyboard focus for controls embedded in a swapped-in panel (as opposed to a modal
        /// dialog).
        /// </summary>
        public static void TypeIntoContainer(AutomationElement container, string text)
        {
            var inner = container.FindFirstDescendant(cf => cf.ByControlType(ControlType.Edit))
                        ?? container.FindFirstDescendant(cf => cf.ByControlType(ControlType.Document))
                        ?? container;
            inner.Click();
            Thread.Sleep(150);

            var valuePattern = inner.Patterns.Value.PatternOrDefault;
            if (valuePattern != null && valuePattern.IsReadOnly != true)
            {
                valuePattern.SetValue(text);
            }
            else
            {
                Keyboard.Type(text);
            }
        }
    }
}
