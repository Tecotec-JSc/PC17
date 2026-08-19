using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormTableInspections - modal, borderless, Win32 title "Procedure Management"
    /// (the "PROCEDURE LIST" tab you land on after Procedure Management -> Open Procedure).
    ///
    /// The grid (dataGridView1) is a real WinForms DataGridView whose cell AutomationIds are
    /// runtime-generated numbers (e.g. "4263646052") that change every run - never target a cell
    /// by AutomationId. Each row IS reliably findable by exact Name "Row {index}" though (its
    /// child cells are named "{ColumnName} Row {index}" instead - note that's the COLUMN NAME,
    /// not the cell's displayed value, so you can't find a row by the DUT/procedure name shown in
    /// it either). Combined with ProcedureManager.GetSBy's `ORDER BY P.ProcedureId DESC`, "Row 0"
    /// is always the most recently created procedure - see TestDataSeeder.SeedDeletableProcedure.</summary>
    public class ProcedureListDialog
    {
        private readonly T3AcsSession _session;
        public Window Root { get; }

        private ProcedureListDialog(T3AcsSession session, Window root)
        {
            _session = session;
            Root = root;
        }

        public static ProcedureListDialog WaitFor(T3AcsSession session)
        {
            var window = WindowFinder.FindWindowByTitle(session.App, session.Automation, "Procedure Management", TimeSpan.FromSeconds(10));
            if (window == null) throw new InvalidOperationException("Procedure list window did not open.");
            session.Shots.Take(window, "procedure-list");
            return new ProcedureListDialog(session, window);
        }

        /// <summary>Switches from the "PROCEDURE LIST" tab to "RUN HISTORY" (panelHistory) within
        /// the same "Procedure Management" window - a Click, not a navigation, so no window
        /// wait/diff is needed, unlike opening a new dialog.</summary>
        public RunHistoryTab OpenHistoryTab()
        {
            var tabHistory = ElementFinder.FindById(Root, "tabHistory", TimeSpan.FromSeconds(10));
            if (tabHistory == null) throw new InvalidOperationException("'RUN HISTORY' tab not found.");
            tabHistory.Click();
            Thread.Sleep(500);
            _session.Shots.Take(Root, "run-history-tab");
            return new RunHistoryTab(_session, Root);
        }

        public ChooseTemplateScreen ClickNew()
        {
            var btnNew = ElementFinder.FindById(Root, "btnIconAddNew", TimeSpan.FromSeconds(10));
            if (btnNew == null) throw new InvalidOperationException("'NEW' button not found.");
            btnNew.Click();
            Thread.Sleep(500);
            _session.Shots.Take(_session.MainWindow, "choose-template");
            return new ChooseTemplateScreen(_session);
        }

        /// <summary>
        /// Checks rowIndex's row, picks "Delete Procedure" in the action dropdown, clicks Apply,
        /// confirms the "Are you sure?" popup, and returns the resulting success/error
        /// notification. Both extra popups (confirm, then the notification) are borderless with
        /// no title - each needs its own handle-diff snapshot taken *after* the previous popup is
        /// already open, or the diff would report that still-open popup as "new" again.
        /// </summary>
        public NotificationDialog DeleteRow(int rowIndex)
        {
            SelectAction(rowIndex, "Delete Procedure");

            var beforeConfirm = WindowFinder.SnapshotHandles(_session.App);
            ClickApply();
            var confirmDialog = WindowFinder.WaitForNewWindow(_session.App, _session.Automation, beforeConfirm, TimeSpan.FromSeconds(5));
            if (confirmDialog == null) throw new InvalidOperationException("Delete confirmation dialog did not open.");

            var beforeNotification = WindowFinder.SnapshotHandles(_session.App);
            var confirmOk = ElementFinder.FindById(confirmDialog, "btnOK", TimeSpan.FromSeconds(5));
            if (confirmOk == null) throw new InvalidOperationException("Confirmation dialog's OK button not found.");
            confirmOk.Click();

            var notification = WindowFinder.WaitForNewWindow(_session.App, _session.Automation, beforeNotification, TimeSpan.FromSeconds(5));
            if (notification == null) throw new InvalidOperationException("No notification appeared after confirming delete.");
            return new NotificationDialog(notification);
        }

        /// <summary>Checks rowIndex's row and picks actionText in the dropdown, without clicking
        /// Apply yet - for actions with a different follow-up than DeleteRow (e.g. "Edit
        /// Procedure" closes this dialog and opens the step editor directly, no confirm popup).</summary>
        public void SelectAction(int rowIndex, string actionText)
        {
            CheckRow(rowIndex);

            var combo = ElementFinder.FindById(Root, "cboActionProcedure", TimeSpan.FromSeconds(5));
            if (combo == null) throw new InvalidOperationException("Action dropdown (cboActionProcedure) not found.");

            // Two gotchas stacked here: (1) FlaUI's ComboBox.Select(text) throws a
            // NullReferenceException reading .Items on this control. (2) combo.Click() clicks
            // the bounding rectangle's *center*, which lands in the editable text portion of
            // this DropDown-style combo, not the small arrow button - it only selects the text,
            // never opens the list (confirmed visually: no dropdown appears). The ExpandCollapse
            // pattern sidesteps both - it opens the list without relying on click coordinates,
            // and the item is then a normal descendant findable via FindByText.
            var expandCollapse = combo.Patterns.ExpandCollapse.PatternOrDefault;
            if (expandCollapse != null) expandCollapse.Expand();
            else combo.Click(); // fallback if some other combo on another screen doesn't support it
            Thread.Sleep(300);
            var item = ElementFinder.FindByText(Root, actionText, TimeSpan.FromSeconds(3));
            if (item == null) throw new InvalidOperationException($"Action dropdown item '{actionText}' not found after opening it.");
            item.Click();
            Thread.Sleep(200);
        }

        public void ClickApply()
        {
            var btn = ElementFinder.FindById(Root, "btnActionProcedure", TimeSpan.FromSeconds(5));
            if (btn == null) throw new InvalidOperationException("Apply button (btnActionProcedure) not found.");
            btn.Click();
            Thread.Sleep(500);
        }

        private void CheckRow(int rowIndex)
        {
            var row = ElementFinder.FindByText(Root, $"Row {rowIndex}", TimeSpan.FromSeconds(10));
            if (row == null) throw new InvalidOperationException($"Grid row {rowIndex} not found.");
            var checkbox = row.FindFirstDescendant(cf => cf.ByControlType(ControlType.CheckBox));
            if (checkbox == null) throw new InvalidOperationException($"Checkbox for grid row {rowIndex} not found.");
            checkbox.Click();
            Thread.Sleep(200);
        }
    }
}
