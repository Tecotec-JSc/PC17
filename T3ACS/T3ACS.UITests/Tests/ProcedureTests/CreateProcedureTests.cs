using System;
using System.IO;
using T3ACS.UITests.Config;
using T3ACS.UITests.Data;
using T3ACS.UITests.Screens;
using Xunit;

namespace T3ACS.UITests.Tests.ProcedureTests
{
    public class CreateProcedureTests : UiTestBase
    {
        [Fact]
        public void CreateProcedure_WithTwoSteps_ViaRealUI()
        {
            Assert.True(File.Exists(TestConfig.ExePath), "Test app exe not found at " + TestConfig.ExePath);

            using var session = LaunchApp();

            var mainWindow = new MainWindow(session);
            var procedureList = mainWindow.OpenProcedureManagement();

            var chooseTemplate = procedureList.ClickNew();
            chooseTemplate.SelectTemplateCard(TestDataSeeder.SeedTemplateName);
            var configureDialog = chooseTemplate.ClickChoose();

            var procedureName = "UITest Procedure " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            configureDialog.FillHeader(procedureName, "UITest", "Created by automated UI test.");
            var stepEditor = configureDialog.Confirm();

            stepEditor.AddStep("Number", TestDataSeeder.SeedParameterName);
            stepEditor.AddStep("String", TestDataSeeder.SeedParameterName);
            session.Shots.Take(session.MainWindow, "steps-added");

            var notification = stepEditor.ClickCreateProcedure();
            Assert.False(notification.IsValidationError, "Save failed validation: " + notification.Text);
            notification.ClickOk();

            Assert.True(stepEditor.IsClosed(),
                "Procedure was not saved - the step editor is still open after clicking 'Create Procedure'. " +
                "Notification said: " + notification.Text);
            session.Shots.Take(session.MainWindow, "final-state");
        }
    }
}
