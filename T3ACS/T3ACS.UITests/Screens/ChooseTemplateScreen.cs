using System;
using System.Threading;
using FlaUI.Core.AutomationElements;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormChoseTemplateProcedure, embedded in MainWindow.Root - the "Choose Template"
    /// screen shown right after clicking NEW.</summary>
    public class ChooseTemplateScreen
    {
        private readonly T3AcsSession _session;
        public AutomationElement Root => _session.MainWindow;

        public ChooseTemplateScreen(T3AcsSession session)
        {
            _session = session;
        }

        public void SearchTemplate(string text)
        {
            var searchBox = ElementFinder.FindById(Root, "txtSearchTemplate", TimeSpan.FromSeconds(10));
            if (searchBox == null) throw new InvalidOperationException("Template search box not found.");
            Interactions.TypeIntoContainer(searchBox, text);
            Thread.Sleep(500);
            _session.Shots.Take(Root, "after-search-filter");
        }

        /// <summary>
        /// Filters the (possibly long, scrolled) template list down to templateName via the
        /// search box, then clicks its card. Picking a template that already has a DUT assigned
        /// (rather than "Blank Template"/card0) sidesteps this app's flaky borderless DUT picker
        /// popup entirely - see HUONG_DAN_AUTOMATION.md section 5.5 for why a plain
        /// InsertProcedure-created template won't even show up here without extra seeding.
        /// </summary>
        public void SelectTemplateCard(string templateName)
        {
            SearchTemplate(templateName);

            var panel = ElementFinder.FindById(Root, "panelTemp", TimeSpan.FromSeconds(10));
            if (panel == null) throw new InvalidOperationException("Template list panel not found.");

            AutomationElement card = null;
            var deadline = DateTime.UtcNow + TimeSpan.FromSeconds(10);
            while (card == null && DateTime.UtcNow < deadline)
            {
                card = Array.Find(panel.FindAllChildren(), c =>
                {
                    var id = c.Properties.AutomationId.ValueOrDefault;
                    if (id == null || !id.StartsWith("card") || id == "card0") return false;
                    return c.FindFirstDescendant(cf => cf.ByName(templateName)) != null;
                });
                if (card == null) Thread.Sleep(300);
            }
            if (card == null) throw new InvalidOperationException($"Template card '{templateName}' not found. Did the seed step run?");
            card.Click();
            Thread.Sleep(200);
        }

        public ConfigureProcedureDialog ClickChoose()
        {
            var chooseBtn = ElementFinder.FindById(Root, "ButtonCustom2", TimeSpan.FromSeconds(10));
            if (chooseBtn == null) throw new InvalidOperationException("'Choose' button not found.");

            // Retry the click since it occasionally doesn't register the first time (section 5.8).
            for (int attempt = 0; attempt < 4; attempt++)
            {
                chooseBtn.Click();
                // Tăng timeout lên 10s mỗi lần retry vì dialog mở chậm hơn trên CI
                var window = WindowFinder.FindWindowByTitle(_session.App, _session.Automation, "Configure your new procedure", TimeSpan.FromSeconds(10));
                if (window != null)
                {
                    _session.Shots.Take(window, "configure-procedure-empty");
                    return new ConfigureProcedureDialog(_session, window);
                }
            }
            throw new InvalidOperationException("Configure-procedure dialog did not open.");
        }
    }
}
