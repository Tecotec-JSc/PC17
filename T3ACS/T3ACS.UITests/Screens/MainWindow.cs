using System;
using FlaUI.Core.AutomationElements;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>The app's single top-level window. Most screens (ChooseTemplateScreen,
    /// StepEditorScreen...) are panels swapped into this window's panelMain, not separate
    /// top-level windows - see HUONG_DAN_AUTOMATION.md section 5.1.</summary>
    public class MainWindow
    {
        private readonly T3AcsSession _session;
        public AutomationElement Root => _session.MainWindow;

        public MainWindow(T3AcsSession session)
        {
            _session = session;
        }

        public ProcedureListDialog OpenProcedureManagement()
        {
            var openProcedure = ClickMenuAndFindItem("Procedure Management", "Open Procedure");
            openProcedure.Click();
            return ProcedureListDialog.WaitFor(_session);
        }

        public AddDutDialog OpenAddDut()
        {
            var create = ClickMenuAndFindItem("DUT Management", "Create");
            create.Click();
            return AddDutDialog.WaitFor(_session);
        }

        /// <summary>Clicks a top-level menu (e.g. "DUT Management") and returns its submenu item
        /// (e.g. "Create"), retrying the click if the dropdown doesn't register the first time -
        /// see HUONG_DAN_AUTOMATION.md section 5.8.</summary>
        private AutomationElement ClickMenuAndFindItem(string menuText, string itemText)
        {
            var menu = ElementFinder.FindByText(Root, menuText, TimeSpan.FromSeconds(15));
            if (menu == null) throw new InvalidOperationException($"Menu '{menuText}' not found.");

            AutomationElement item = null;
            for (int attempt = 0; attempt < 5 && item == null; attempt++)
            {
                menu.Click();
                item = ElementFinder.FindByText(Root, itemText, TimeSpan.FromSeconds(4));
            }
            if (item == null) throw new InvalidOperationException($"Menu item '{itemText}' (under '{menuText}') not found.");
            return item;
        }
    }
}
