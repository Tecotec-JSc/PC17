using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormEditProcedure, embedded in MainWindow.Root - add/edit steps, then save.</summary>
    public class StepEditorScreen
    {
        private readonly T3AcsSession _session;
        public AutomationElement Root => _session.MainWindow;

        public StepEditorScreen(T3AcsSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Adds a step of stepTypeText (e.g. "Number", "String") and binds parameterName to it.
        /// A step needs BOTH a name and a bound parameter before the *next* "Add to Procedure"
        /// click will succeed - FormEditProcedure validates the currently active step first
        /// (section 5.6), and ContenStepTypeControl only fires its click event once per item per
        /// session (section 5.4), so each step type can only be added once per test run.
        /// </summary>
        public void AddStep(string stepTypeText, string parameterName)
        {
            var stepTypeItem = ElementFinder.FindByText(Root, stepTypeText, TimeSpan.FromSeconds(10));
            if (stepTypeItem == null) throw new InvalidOperationException($"Step type '{stepTypeText}' not found in panelStepType.");
            stepTypeItem.Click();
            Thread.Sleep(200);

            var addToProcedure = ElementFinder.FindById(Root, "buttonCustom1", TimeSpan.FromSeconds(5));
            if (addToProcedure == null) throw new InvalidOperationException("'Add to Procedure' button not found.");
            addToProcedure.Click();
            Thread.Sleep(500);

            var txtStepName = ElementFinder.FindById(Root, "txtStepName", TimeSpan.FromSeconds(5));
            if (txtStepName == null) throw new InvalidOperationException($"Step name field not found for step '{stepTypeText}'.");
            Interactions.TypeIntoContainer(txtStepName, stepTypeText + " step");
            _session.Shots.Take(Root, "after-add-to-procedure-" + stepTypeText);

            // Bind an existing procedure-level variable via the borderless, non-modal "Select
            // Parameter" popup - detected by window-handle diff since it has no title.
            var selectParameter = ElementFinder.FindById(Root, "selectParameter1", TimeSpan.FromSeconds(5));
            if (selectParameter == null) throw new InvalidOperationException($"'Select Parameter' control not found for step '{stepTypeText}'.");
            var before = WindowFinder.SnapshotHandles(_session.App);
            selectParameter.Click();
            var popup = WindowFinder.WaitForNewWindow(_session.App, _session.Automation, before, TimeSpan.FromSeconds(5));
            if (popup == null) throw new InvalidOperationException($"Select Parameter popup did not open for step '{stepTypeText}'.");
            var item = ElementFinder.FindByText(popup, parameterName, TimeSpan.FromSeconds(5));
            if (item == null) throw new InvalidOperationException($"Parameter '{parameterName}' not found in Select Parameter popup for step '{stepTypeText}'.");
            item.Click();
            Thread.Sleep(300);

            // Non-modal popup stays open for multi-select; click elsewhere so it loses focus and
            // its Deactivate handler closes it.
            var stepHeading = ElementFinder.FindById(Root, "lblHugStep", TimeSpan.FromSeconds(2));
            (stepHeading ?? Root).Click();
            Thread.Sleep(300);
        }

        public NotificationDialog ClickCreateProcedure()
        {
            var btn = ElementFinder.FindById(Root, "btnCreateProcedure", TimeSpan.FromSeconds(10));
            if (btn == null) throw new InvalidOperationException("'Create Procedure' button not found.");

            var before = WindowFinder.SnapshotHandles(_session.App);
            btn.Click();
            Thread.Sleep(1000);
            _session.Shots.Take(Root, "after-save");

            // ShowNoti (success or "Validate User Input" failure) opens as its own top-level
            // window, not a descendant of Root.
            var notification = WindowFinder.WaitForNewWindow(_session.App, _session.Automation, before, TimeSpan.FromSeconds(5));
            if (notification == null) throw new InvalidOperationException("No notification dialog appeared after clicking 'Create Procedure'.");
            return new NotificationDialog(notification);
        }

        /// <summary>panelMain only gets cleared on a successful save (see
        /// FormEditProcedure.btnCreateProcedure_Click), so this is the definitive "did it save"
        /// signal - a validation error leaves the step editor, and btnCreateProcedure, in place.</summary>
        public bool IsClosed()
        {
            return ElementFinder.FindById(Root, "btnCreateProcedure", TimeSpan.FromSeconds(1)) == null;
        }
    }
}
