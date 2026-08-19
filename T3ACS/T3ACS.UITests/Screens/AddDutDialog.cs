using System;
using System.Threading;
using T3ACS.UITests.Core;

namespace T3ACS.UITests.Screens
{
    /// <summary>FormAddDUT - modal, borderless, Win32 title is literally "FormAddDUT" (the app
    /// never set a friendlier Text on this one - confirmed in FormAddDUT.Designer.cs). Same form
    /// for both "DUT Management -> Create" (dutId=0) and editing an existing DUT.</summary>
    public class AddDutDialog
    {
        private readonly T3AcsSession _session;
        public FlaUI.Core.AutomationElements.Window Root { get; }

        private AddDutDialog(T3AcsSession session, FlaUI.Core.AutomationElements.Window root)
        {
            _session = session;
            Root = root;
        }

        public static AddDutDialog WaitFor(T3AcsSession session)
        {
            var window = WindowFinder.FindWindowByTitle(session.App, session.Automation, "FormAddDUT", TimeSpan.FromSeconds(10));
            if (window == null) throw new InvalidOperationException("Add DUT dialog did not open.");
            session.Shots.Take(window, "add-dut-empty");
            return new AddDutDialog(session, window);
        }

        /// <summary>Fills only the required fields (FormAddDUT.ButtonCustom2__EventSelect:
        /// Name/Category/Model/SerialNumber/Manufacturer - calibration dates/shipment/user unit
        /// are optional and validated as strict dd/MM/yyyy dates if provided, so this test
        /// deliberately leaves them blank). serialNumber and modelDut must each be <=10 chars
        /// with no spaces or the form rejects them before ever attempting to save.</summary>
        public void FillRequiredFields(string name, string category, string modelDut, string serialNumber, string manufacturer)
        {
            Interactions.TypeIntoContainer(RequireField("txtName"), name);
            Interactions.TypeIntoContainer(RequireField("txtCategory"), category);
            Interactions.TypeIntoContainer(RequireField("txtModel"), modelDut);
            Interactions.TypeIntoContainer(RequireField("txtSerialNumber"), serialNumber);
            Interactions.TypeIntoContainer(RequireField("txtManufacturer"), manufacturer);
            _session.Shots.Take(Root, "add-dut-filled");
        }

        /// <summary>Clicks "Add DUT" and returns the resulting notification. Note the app shows
        /// this notification with the same "warning" status icon on both success AND validation
        /// failure (FormAddDUT.cs always calls ShowMess(..., 2)) - check NotificationDialog.Text
        /// for "successfully", not the status/icon, to tell them apart.</summary>
        public NotificationDialog ClickSave()
        {
            var btn = ElementFinder.FindById(Root, "btnSave", TimeSpan.FromSeconds(5));
            if (btn == null) throw new InvalidOperationException("'Add DUT' button not found.");

            var before = WindowFinder.SnapshotHandles(_session.App);
            btn.Click();
            Thread.Sleep(800);
            var notification = WindowFinder.WaitForNewWindow(_session.App, _session.Automation, before, TimeSpan.FromSeconds(5));
            if (notification == null) throw new InvalidOperationException("No notification dialog appeared after clicking 'Add DUT'.");
            return new NotificationDialog(notification);
        }

        /// <summary>FormAddDUT.Close()s itself right after a successful save's notification is
        /// dismissed (ButtonCustom2__EventSelect, after ShowMess returns) - a validation failure
        /// leaves it open instead, so this is the definitive "did it save" signal, same pattern
        /// as StepEditorScreen.IsClosed().</summary>
        public bool IsClosed()
        {
            return WindowFinder.FindWindowByTitle(_session.App, _session.Automation, "FormAddDUT", TimeSpan.FromSeconds(1)) == null;
        }

        private FlaUI.Core.AutomationElements.AutomationElement RequireField(string automationId)
        {
            var field = ElementFinder.FindById(Root, automationId, TimeSpan.FromSeconds(5));
            if (field == null) throw new InvalidOperationException($"Field '{automationId}' not found.");
            return field;
        }
    }
}
