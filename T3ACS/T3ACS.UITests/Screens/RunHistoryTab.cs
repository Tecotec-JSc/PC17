using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>panelHistory inside FormTableInspections ("Procedure Management" window) - the
    /// "RUN HISTORY" tab reached via ProcedureListDialog.OpenHistoryTab(). Same grid/action-combo/
    /// confirm-popup shape as the procedure list tab (dataGridView2/cboActionHistory/
    /// btnActionHistory instead of dataGridView1/cboActionProcedure/btnActionProcedure), same
    /// "Row {index}" / ORDER BY ResultProcedureId DESC caveats - see ProcedureListDialog's class
    /// doc and TestDataSeeder.SeedRunHistoryResult. Only "Delete" is wired up in the real app;
    /// "View log"/"View report" items exist in the dropdown but their handlers are commented out
    /// dead code (FormTableInspections.btnActionHistory_Click).</summary>
    public class RunHistoryTab
    {
        private readonly T3AcsSession _session;
        public Window Root { get; }

        public RunHistoryTab(T3AcsSession session, Window root)
        {
            _session = session;
            Root = root;
        }

        /// <summary>Checks rowIndex's row, picks "Delete" in the action dropdown, clicks Apply,
        /// confirms the "Are you sure?" popup, and returns the resulting notification - mirrors
        /// ProcedureListDialog.DeleteRow exactly (same borderless-popup handle-diff caveat).</summary>
        public NotificationDialog DeleteRow(int rowIndex)
        {
            SelectAction(rowIndex, "Delete");

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

        public void SelectAction(int rowIndex, string actionText)
        {
            CheckRow(rowIndex);

            var combo = ElementFinder.FindById(Root, "cboActionHistory", TimeSpan.FromSeconds(5));
            if (combo == null) throw new InvalidOperationException("Action dropdown (cboActionHistory) not found.");

            var expandCollapse = combo.Patterns.ExpandCollapse.PatternOrDefault;
            if (expandCollapse != null) expandCollapse.Expand();
            else combo.Click();
            Thread.Sleep(300);
            var item = ElementFinder.FindByText(Root, actionText, TimeSpan.FromSeconds(3));
            if (item == null) throw new InvalidOperationException($"Action dropdown item '{actionText}' not found after opening it.");
            item.Click();
            Thread.Sleep(200);
        }

        public void ClickApply()
        {
            var btn = ElementFinder.FindById(Root, "btnActionHistory", TimeSpan.FromSeconds(5));
            if (btn == null) throw new InvalidOperationException("Apply button (btnActionHistory) not found.");
            btn.Click();
            Thread.Sleep(500);
        }

        private void CheckRow(int rowIndex)
        {
            var row = ElementFinder.FindByText(Root, $"Row {rowIndex}", TimeSpan.FromSeconds(10));
            if (row == null) throw new InvalidOperationException($"History grid row {rowIndex} not found.");
            var checkbox = row.FindFirstDescendant(cf => cf.ByControlType(ControlType.CheckBox));
            if (checkbox == null) throw new InvalidOperationException($"Checkbox for history grid row {rowIndex} not found.");
            checkbox.Click();
            Thread.Sleep(200);
        }
    }
}
