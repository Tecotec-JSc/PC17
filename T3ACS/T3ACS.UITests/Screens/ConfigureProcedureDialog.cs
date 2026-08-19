using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormConfigureNewProcedure - modal, borderless, Win32 title
    /// "Configure your new procedure" (the header form: name/category/description/DUT).</summary>
    public class ConfigureProcedureDialog
    {
        private readonly T3AcsSession _session;
        public Window Root { get; }

        public ConfigureProcedureDialog(T3AcsSession session, Window root)
        {
            _session = session;
            Root = root;
        }

        /// <summary>DUT is required to save but is intentionally not set here - it comes
        /// pre-filled from the template picked in ChooseTemplateScreen, so the flaky DUT popup
        /// never needs to be driven.</summary>
        public void FillHeader(string name, string category, string description)
        {
            var txtName = ElementFinder.FindById(Root, "txtProcedureName", TimeSpan.FromSeconds(10));
            if (txtName == null) throw new InvalidOperationException("Procedure name field not found.");
            Interactions.TypeIntoContainer(txtName, name); // template pre-fills this; SetValue replaces it outright

            var txtCategory = ElementFinder.FindById(Root, "txtCategory", TimeSpan.FromSeconds(5));
            if (txtCategory == null) throw new InvalidOperationException("Category field not found.");
            Interactions.TypeIntoContainer(txtCategory, category);

            var rtbDescription = ElementFinder.FindById(Root, "rtbDescription", TimeSpan.FromSeconds(5));
            if (rtbDescription != null)
            {
                Interactions.TypeIntoContainer(rtbDescription, description);
            }

            _session.Shots.Take(Root, "configure-procedure-filled");
        }

        public StepEditorScreen Confirm()
        {
            var btn = ElementFinder.FindById(Root, "btnChooseTemplate", TimeSpan.FromSeconds(5));
            if (btn == null) throw new InvalidOperationException("Confirm button not found.");
            btn.Click();
            Thread.Sleep(800);
            _session.Shots.Take(_session.MainWindow, "step-editor");
            return new StepEditorScreen(_session);
        }
    }
}
