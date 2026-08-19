using System;
using System.IO;
using T3.Configuration;
using T3ACS.Data;
using T3ACS.UITests.Config;
using T3ACS.UITests.Data;
using T3ACS.UITests.Screens;
using Xunit;

namespace T3ACS.UITests.Tests.ProcedureTests
{
    public class EditProcedureTests : UiTestBase
    {
        [Fact]
        public void EditProcedure_AddSecondStepViaRealUI()
        {
            Assert.True(File.Exists(TestConfig.ExePath), "Test app exe not found at " + TestConfig.ExePath);

            // Same Row-0-is-newest reasoning as DeleteProcedureTests - see
            // TestDataSeeder.SeedEditableProcedure and ProcedureListDialog's class doc. Seeds a
            // procedure with one existing "String" step already bound to SeedParameterName - see
            // SeedEditableProcedure's doc comment for why a step-less procedure can't be used here.
            var procedureName = "UITest Editable Procedure " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var procedureId = TestDataSeeder.SeedEditableProcedure(TestConfig.DbPath, procedureName);

            using var session = LaunchApp();

            var mainWindow = new MainWindow(session);
            var procedureList = mainWindow.OpenProcedureManagement();

            // "Edit Procedure" has no confirm popup unlike Delete - btnAction_Click closes
            // FormTableInspections directly and FormEditProcedure gets embedded in
            // mainWindow.panelMain in its place (FormMainRunStep.EditProcedureId).
            procedureList.SelectAction(0, "Edit Procedure");
            procedureList.ClickApply();

            // The seeded procedure already has one "String" step, so its group ("Basic Steps") is
            // auto-expanded on load (FormEditProcedure.LoadProcedure -> loadStepType) - no need to
            // click a group header first, unlike editing a genuinely step-less procedure.
            var stepEditor = new StepEditorScreen(session);
            stepEditor.AddStep("Number", TestDataSeeder.SeedParameterName);

            var notification = stepEditor.ClickCreateProcedure();
            Assert.True(notification.Text.Contains("successfully"),
                "Edit did not report success. Notification said: " + notification.Text);
            notification.ClickOk();

            Assert.True(stepEditor.IsClosed(), "Step editor is still open after a successful save.");

            AssertSecondStepWasSaved(procedureId, procedureName);
        }

        /// <summary>Don't just trust the UI's "successfully" text - confirm the second
        /// ProcedureDetail row actually landed in the DB, the same rigor used for the other
        /// Procedure tests.</summary>
        private static void AssertSecondStepWasSaved(int procedureId, string procedureName)
        {
            Main.ConnectionStringSQLite = TestConfig.DbPath;
            var db = new SQLiteDataBase();
            var dt = db.GetDataTable("select count(*) as Cnt from ProcedureDetail where ProcedureId=" + procedureId);
            var count = int.Parse(dt.Rows[0]["Cnt"].ToString());
            Assert.True(count >= 2,
                $"Procedure '{procedureName}' (id={procedureId}) has only {count} ProcedureDetail row(s) after adding a second step via the edit flow.");
        }
    }
}
