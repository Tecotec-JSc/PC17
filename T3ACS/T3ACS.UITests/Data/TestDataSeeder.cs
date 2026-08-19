using System.Collections.Generic;
using System.Data;
using T3.Configuration;
using T3ACS.Data;
using T3ACS.Model;

namespace T3ACS.UITests.Data
{
    /// <summary>
    /// Seeds the isolated test app's SQLite DB (see Config.TestConfig) with a known-good
    /// "UITest Seed Template" procedure before each UI test run, so the UI test does
    /// not depend on whatever templates happen to already exist and does not need to fight the
    /// app's own (flaky, borderless, non-modal) DUT/parameter picker popups to build one from
    /// scratch. Run via the static Seed() call from the test constructor.
    ///
    /// The template needs Type=2 and at least one ProcedureDetail row to show up in
    /// FormChoseTemplateProcedure's list at all (see ProcedureManager.GetTemplates()'s INNER
    /// JOIN + WHERE Type=2), and that one step needs its own bound parameter or
    /// FormEditProcedure's "Add to Procedure" validation (which checks the currently active step
    /// before allowing a new one) blocks immediately - neither of which
    /// ProcedureModel.InsertProcedure produces on its own.
    /// </summary>
    public static class TestDataSeeder
    {
        public const string SeedTemplateName = "UITest Seed Template";
        public const string SeedParameterName = "TestParam";

        public static void Seed(string dbPath)
        {
            Main.ConnectionStringSQLite = dbPath;
            var db = new SQLiteDataBase();

            var dutRows = db.GetDataTable("select DUTId, DUTName, Model, Brand from DUT limit 1");
            if (dutRows.Rows.Count == 0)
            {
                throw new System.InvalidOperationException(
                    "No DUT rows found in " + dbPath + " - cannot seed a template with a valid DUT " +
                    "(FormConfigureNewProcedure requires one to save).");
            }
            var dutRow = dutRows.Rows[0];
            var dutComposite = $"{dutRow["DUTName"]};{dutRow["Model"]};{dutRow["Brand"]}";

            var existing = db.GetDataTable("select ProcedureId from Procedure where ProcedureName = '" + SeedTemplateName + "'");
            foreach (DataRow row in existing.Rows)
            {
                var oldId = row["ProcedureId"];
                db.ExecuteNonQuery("DELETE FROM ProcedureDetail WHERE ProcedureId=" + oldId);
                db.ExecuteNonQuery("DELETE FROM ProcedureVariable WHERE ProcedureId=" + oldId);
                db.ExecuteNonQuery("DELETE FROM Procedure WHERE ProcedureId=" + oldId);
            }

            var pm = new ProcedureModel();
            var newId = pm.InsertProcedure(
                SeedTemplateName, pm.GetNewId(), "Seed template for automated UI tests.",
                "1.0", "UITest", "5", dutComposite, null, null);

            var vm = new TemplateViewModel
            {
                ProcedureId = newId,
                Subject = SeedTemplateName,
                Description = "Seed template for automated UI tests.",
                Version = "1.0",
                Category = "UITest",
                Duration = "5",
                DUTName = dutComposite,
                Variables = new List<ProcedureVariableViewModel>
                {
                    new ProcedureVariableViewModel
                    {
                        Name = SeedParameterName,
                        Title = "Test Parameter",
                        Type = "String",
                        TypeInput = "String",
                        Required = false,
                        Report = false
                    }
                },
                TableProcedures = new List<TableProcedureViewModel>
                {
                    new TableProcedureViewModel
                    {
                        NumberOder = 1,
                        Title = "Seed step",
                        Description = "Placeholder step so this template satisfies GetTemplates()'s join.",
                        StepType = "String",
                        Required = false,
                        LoopInput = 1,
                        Variables = new List<ProcedureDetaiVariableViewModel>
                        {
                            new ProcedureDetaiVariableViewModel
                            {
                                Name = SeedParameterName,
                                Title = "Test Parameter",
                                TypeInput = "String",
                                Required = false,
                                Report = false
                            }
                        }
                    }
                }
            };

            if (!pm.UpdateProcedure(vm, out string error))
            {
                throw new System.InvalidOperationException("Failed to seed template steps: " + error);
            }

            db.ExecuteNonQuery("UPDATE Procedure SET Type=2 WHERE ProcedureId=" + newId);
        }

        /// <summary>
        /// Inserts a bare, Type=1 procedure with no steps - just enough to appear in
        /// FormTableInspections' "PROCEDURE LIST" grid (ProcedureManager.GetSBy filters
        /// WHERE P.Type=1, so the Type=2 seed template from Seed() above deliberately never
        /// shows up there) for a test that needs to act on an existing row (delete, edit...).
        /// The grid is ORDER BY P.ProcedureId DESC, so a freshly-inserted row is always Row 0 -
        /// callers don't need to search for it by name.
        /// </summary>
        public static int SeedDeletableProcedure(string dbPath, string name)
        {
            Main.ConnectionStringSQLite = dbPath;
            var pm = new ProcedureModel();
            var newId = pm.InsertProcedure(
                name, pm.GetNewId(), "Throwaway procedure for a delete/edit test.",
                "1.0", "UITest", "5", "", null, null);
            if (newId <= 0)
            {
                throw new System.InvalidOperationException("Failed to seed a deletable procedure named '" + name + "'.");
            }
            return newId;
        }

        /// <summary>
        /// Inserts a Type=1 procedure with exactly one existing step (parameter
        /// <see cref="SeedParameterName"/> already bound to it) - basically Seed()'s template shape,
        /// minus the final "UPDATE Procedure SET Type=2" so it shows up in FormTableInspections'
        /// "PROCEDURE LIST" grid (GetSBy's WHERE P.Type=1) instead of the templates picker.
        ///
        /// A pre-existing step is required for a UI edit test that adds a *second* step: the
        /// "Select Parameter" popup (StepEditorScreen.AddStep) only offers procedure-level
        /// variables that some existing step already references (FormEditProcedure.loadStepContent
        /// prunes _vm.Variables down to referenced-only before ever showing the picker) - a
        /// genuinely step-less procedure would never offer SeedParameterName at all, since nothing
        /// has referenced it yet. Also, unlike a step-less procedure (which starts with every step
        /// type group collapsed - see selectStepType("") in FormEditProcedure.LoadProcedure), a
        /// procedure with an existing step auto-expands that step's group on load, so callers don't
        /// need to click a group header before StepEditorScreen.AddStep like SeedDeletableProcedure
        /// callers editing a step-less row would.
        /// </summary>
        public static int SeedEditableProcedure(string dbPath, string name)
        {
            Main.ConnectionStringSQLite = dbPath;
            var pm = new ProcedureModel();
            var newId = pm.InsertProcedure(
                name, pm.GetNewId(), "Throwaway procedure for an edit test.",
                "1.0", "UITest", "5", "", null, null);
            if (newId <= 0)
            {
                throw new System.InvalidOperationException("Failed to seed an editable procedure named '" + name + "'.");
            }

            var vm = new TemplateViewModel
            {
                ProcedureId = newId,
                Subject = name,
                Description = "Throwaway procedure for an edit test.",
                Version = "1.0",
                Category = "UITest",
                Duration = "5",
                DUTName = "",
                Variables = new List<ProcedureVariableViewModel>
                {
                    new ProcedureVariableViewModel
                    {
                        Name = SeedParameterName,
                        Title = "Test Parameter",
                        Type = "String",
                        TypeInput = "String",
                        Required = false,
                        Report = false
                    }
                },
                TableProcedures = new List<TableProcedureViewModel>
                {
                    new TableProcedureViewModel
                    {
                        NumberOder = 1,
                        Title = "Existing step",
                        Description = "Pre-existing step so the edit test adds a second one.",
                        StepType = "String",
                        Required = false,
                        LoopInput = 1,
                        Variables = new List<ProcedureDetaiVariableViewModel>
                        {
                            new ProcedureDetaiVariableViewModel
                            {
                                Name = SeedParameterName,
                                Title = "Test Parameter",
                                TypeInput = "String",
                                Required = false,
                                Report = false
                            }
                        }
                    }
                }
            };

            if (!pm.UpdateProcedure(vm, out string error))
            {
                throw new System.InvalidOperationException("Failed to seed the existing step for edit test procedure '" + name + "': " + error);
            }

            return newId;
        }

        /// <summary>
        /// Inserts a ResultProcedure row (a completed run) backed by a throwaway procedure, the
        /// same shape FormRunMain.SaveResult uses for a real run (Type=0/Status=1/UserId=2 - see
        /// FormRunMain.cs around _Vm.Type = 0), so it shows up in FormTableInspections' "RUN
        /// HISTORY" tab (ProcedureManager.GetResultsBy, ORDER BY ResultProcedureId DESC - same
        /// Row-0-is-newest reasoning as SeedDeletableProcedure). Returns the new ResultProcedureId.
        /// </summary>
        public static int SeedRunHistoryResult(string dbPath, string resultTitle)
        {
            Main.ConnectionStringSQLite = dbPath;
            var pm = new ProcedureModel();
            var procedureId = pm.InsertProcedure(
                resultTitle + " Procedure", pm.GetNewId(), "Procedure backing a seeded run-history result.",
                "1.0", "UITest", "5", "", null, null);
            if (procedureId <= 0)
            {
                throw new System.InvalidOperationException("Failed to seed the backing procedure for run-history result '" + resultTitle + "'.");
            }

            var vm = new TemplateViewModel
            {
                Subject = resultTitle,
                Description = "Seeded run result for a UI test.",
                ProcedureId = procedureId,
                Type = 0,
                Status = 1,
                Percent = 100,
                Log = "",
                UserId = 2,
                StartTime = System.DateTime.Now.AddMinutes(-5),
                EndTime = System.DateTime.Now,
                TableProcedures = new List<TableProcedureViewModel>()
            };

            var resultId = pm.InsertResultProcedure(vm);
            if (resultId <= 0)
            {
                throw new System.InvalidOperationException("Failed to seed a run-history result named '" + resultTitle + "'.");
            }
            return resultId;
        }
    }
}
