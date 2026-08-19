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
    public class DeleteProcedureTests : UiTestBase
    {
        [Fact]
        public void DeleteProcedure_ViaRealUI()
        {
            Assert.True(File.Exists(TestConfig.ExePath), "Test app exe not found at " + TestConfig.ExePath);

            // ProcedureManager.GetSBy (the "PROCEDURE LIST" grid's data source) filters WHERE
            // Type=1 and orders newest-first, so a freshly-seeded Type=1 procedure always lands
            // at Row 0 - see TestDataSeeder.SeedDeletableProcedure and ProcedureListDialog's
            // class doc for why that matters (grid cells can't be found by their displayed text).
            var procedureName = "UITest Deletable Procedure " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var procedureId = TestDataSeeder.SeedDeletableProcedure(TestConfig.DbPath, procedureName);

            using var session = LaunchApp();

            var mainWindow = new MainWindow(session);
            var procedureList = mainWindow.OpenProcedureManagement();

            var notification = procedureList.DeleteRow(0);
            Assert.True(notification.Text.Contains("successfully"),
                "Delete did not report success. Notification said: " + notification.Text);
            notification.ClickOk();

            AssertProcedureGoneFromDb(procedureId, procedureName);
        }

        /// <summary>Don't just trust the UI's "successfully" text - confirm the row is actually
        /// gone from the DB, the same rigor used for the create-procedure test.</summary>
        private static void AssertProcedureGoneFromDb(int procedureId, string procedureName)
        {
            Main.ConnectionStringSQLite = TestConfig.DbPath;
            var db = new SQLiteDataBase();
            var dt = db.GetDataTable("select count(*) as Cnt from Procedure where ProcedureId=" + procedureId);
            var count = int.Parse(dt.Rows[0]["Cnt"].ToString());
            Assert.True(count == 0,
                $"Procedure '{procedureName}' (id={procedureId}) is still in the DB after the delete flow reported success.");
        }
    }
}
