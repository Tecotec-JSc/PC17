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
    public class RunHistoryTests : UiTestBase
    {
        /// <summary>
        /// KNOWN FAILING - real app bug, not an automation bug. Clicking "Apply" on the RUN HISTORY
        /// tab fires TWO click handlers instead of one:
        ///   T3ACS\FormTableInspections.Designer.cs:770
        ///     btnActionHistory._EventSelect += btnAction_Click;       // should be btnActionHistory_Click
        ///     btnActionHistory.Click         += btnActionHistory_Click;
        /// btnAction_Click is the PROCEDURE LIST tab's handler; it runs first, sees nothing checked
        /// in dataGridView1 (the Procedure List grid, untouched by this test), and shows "You need
        /// select one procedure." - blocking the real RUN HISTORY confirm dialog this test expects.
        /// Per explicit instruction, this repo does not modify T3ACS main source, so this test is
        /// left failing on purpose (RunHistoryTab.DeleteRow throws "Confirmation dialog's OK button
        /// not found." because the window it finds is that wrong notification, not the real
        /// confirm dialog) until someone fixes the Designer.cs line above - no automation change
        /// needed once that happens.
        /// </summary>
        [Fact]
        public void DeleteRunHistoryResult_ViaRealUI()
        {
            Assert.True(File.Exists(TestConfig.ExePath), "Test app exe not found at " + TestConfig.ExePath);

            // Same Row-0-is-newest reasoning as DeleteProcedureTests - see
            // TestDataSeeder.SeedRunHistoryResult and ProcedureListDialog's class doc.
            var resultTitle = "UITest Run Result " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var resultId = TestDataSeeder.SeedRunHistoryResult(TestConfig.DbPath, resultTitle);

            using var session = LaunchApp();

            var mainWindow = new MainWindow(session);
            var procedureList = mainWindow.OpenProcedureManagement();
            var runHistory = procedureList.OpenHistoryTab();

            var notification = runHistory.DeleteRow(0);
            Assert.True(notification.Text.Contains("successfully"),
                "Delete did not report success. Notification said: " + notification.Text);
            notification.ClickOk();

            AssertResultGoneFromDb(resultId, resultTitle);
        }

        /// <summary>Don't just trust the UI's "successfully" text - confirm the row is actually
        /// gone from the DB, the same rigor used for the other Procedure tests.</summary>
        private static void AssertResultGoneFromDb(int resultId, string resultTitle)
        {
            Main.ConnectionStringSQLite = TestConfig.DbPath;
            var db = new SQLiteDataBase();
            var dt = db.GetDataTable("select count(*) as Cnt from ResultProcedure where ResultProcedureId=" + resultId);
            var count = int.Parse(dt.Rows[0]["Cnt"].ToString());
            Assert.True(count == 0,
                $"Run history result '{resultTitle}' (id={resultId}) is still in the DB after the delete flow reported success.");
        }
    }
}
