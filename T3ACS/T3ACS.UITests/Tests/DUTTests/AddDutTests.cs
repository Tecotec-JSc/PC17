using System;
using System.IO;
using T3ACS.UITests.Config;
using T3ACS.UITests.Screens;
using Xunit;

namespace T3ACS.UITests.Tests.DUTTests
{
    public class AddDutTests : UiTestBase
    {
        [Fact]
        public void AddDut_WithRequiredFieldsOnly_ViaRealUI()
        {
            Assert.True(File.Exists(TestConfig.ExePath), "Test app exe not found at " + TestConfig.ExePath);

            using var session = LaunchApp();

            var mainWindow = new MainWindow(session);
            var addDutDialog = mainWindow.OpenAddDut();

            // serialNumber/modelDut must each be <=10 chars, no spaces (FormAddDUT.cs validation).
            var suffix = DateTime.Now.ToString("HHmmss");
            var dutName = "UITestDUT " + suffix;
            addDutDialog.FillRequiredFields(
                name: dutName,
                category: "UITest",
                modelDut: "MDL" + suffix,
                serialNumber: "SN" + suffix,
                manufacturer: "UITestMfg");

            var notification = addDutDialog.ClickSave();
            Assert.True(notification.Text.Contains("successfully"),
                "Save did not report success. Notification said: " + notification.Text);
            notification.ClickOk();

            Assert.True(addDutDialog.IsClosed(),
                "DUT was not saved - the Add DUT dialog is still open after clicking 'Add DUT'. " +
                "Notification said: " + notification.Text);
        }
    }
}
