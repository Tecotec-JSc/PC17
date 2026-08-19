using Microsoft.Win32;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormCreateStepType : Form
    {
        public FormCreateStepType()
        {
            InitializeComponent();
        }
        string pathDll;
        private void button1_Click(object sender, EventArgs e)
        {
            FileExtensionInputViewModel EX = new FileExtensionInputViewModel();
            EX.Category = txtCategory.Text;
            EX.Name = txtCategory.Text;
            EX.Type = (int)EnumTypeExtension.StepType;         
            EX.Version = txtVersion.Text;
            EX.TypeFrame = 1;
            TemplateViewModel vm = new TemplateViewModel();
            vm.Subject = txtTieuDe.Text;
            vm.TableProcedures = new List<TableProcedureViewModel>();
            vm.Variables = new List<ProcedureVariableViewModel>();            
            var strFileName = txtFileName.Text;
            var strFileDll = txtFileDll.Text;
            if (!string.IsNullOrEmpty(strFileDll) && File.Exists(strFileDll))
            {
                var filename = strFileDll.Substring(strFileDll.LastIndexOf("\\") + 1);
                pathDll = "\\" + EX.Category + "\\Tools\\" + EX.Version + "\\" + filename;
            }
            var strStepType = txtStepType.Text;
            var strLoadViewRun = txtLoadViewRun.Text.Replace("\n","");
            var strLoadViewCreate = txtLoadViewCreate.Text.Replace("\n", "");
            var strSaveData = txtSaveData.Text.Replace("\n", "");
            var strSaveDataCreate = txtSaveDataCreate.Text.Replace("\n", "");
            var strMonitor = txtMonitor.Text.Replace("\n", "");
            var strAssembly = txtAssembly.Text;
            var strAssemblyType = txtAssemblyType.Text;
            if (string.IsNullOrEmpty(strStepType))
            {
                MessageBox.Show("Step type is required");
                return;
            }
            TableProcedureViewModel step = new TableProcedureViewModel();
            step.StepType = strStepType;
            step.Description = txtDescription.Text;
            step.Variables = new List<ProcedureDetaiVariableViewModel>();
            step.Functions = new List<ProcedureDetailFunction>();
            if (!string.IsNullOrEmpty(strLoadViewRun))
            {
                ProcedureDetailFunction functionLoadViewRun = new ProcedureDetailFunction();
                functionLoadViewRun.PathDll = pathDll;
                functionLoadViewRun.Assembly = strAssembly;
                functionLoadViewRun.FunctionName = "LoadView";
                functionLoadViewRun.AssemblyType = strAssemblyType;
                functionLoadViewRun.Value = strLoadViewRun.Substring(0, strLoadViewRun.IndexOf("("));
                functionLoadViewRun.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                var index1 = strLoadViewRun.IndexOf("(");
                var index2 = strLoadViewRun.IndexOf(")");
                var strVariables = strLoadViewRun.Substring(index1 + 1, index2 - (index1 + 1));
                var col = strVariables.Split(',');
                foreach (string strv in col)
                {
                    var strtext = strv.Trim();
                    var strType = strtext.Substring(0, strtext.IndexOf(" "));
                    strType = strType.Substring(0, 1).ToUpper() + strType.Substring(1);
                    var strVariable = strtext.Substring(strtext.IndexOf(" ") + 1);
                    var variableName = "";
                    var variablevalue = "";
                    var variableTitle = "";
                    var variableUnit = "";
                    var variableItems = "";
                    var variableMin = "";
                    var variableMax = "";
                    var variableTypeInput = "";
                    var variableRequired = "";
                    var variableReport = "";
                    if (strVariable.IndexOf("=") != -1)
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_;"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_;") + 3);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                        var strc = strc1.Substring(strc1.IndexOf("=") + 2);
                        variablevalue = strc.Substring(0, strc.IndexOf("\""));
                        strc = strc.Substring(strc.IndexOf("\"") + 1);
                        if (!string.IsNullOrEmpty(strc))
                        {
                            var col2 = strc.Split("_;");
                            if (col2.Length > 1)
                            {
                                if (col2[1].Length > 2)
                                    variableUnit = col2[1].Substring(1, col2[1].Length - 2);
                            }
                            if (col2.Length > 2)
                            {
                                if (col2[2].Length > 2)
                                {
                                    variableItems = col2[2].Substring(1, col2[2].Length - 2);
                                    variableItems = variableItems.Replace("|", ",");
                                }
                                  
                            }
                            if (col2.Length > 3)
                            {
                                if (col2[3].Length > 2)
                                    variableMin = col2[3].Substring(1, col2[3].Length - 2);
                            }
                            if (col2.Length > 4)
                            {
                                if (col2[4].Length > 2)
                                    variableMax = col2[4].Substring(1, col2[4].Length - 2);
                            }
                            if (col2.Length > 5)
                            {
                                if (col2[5].Length > 2)
                                    variableTypeInput = col2[5].Substring(1, col2[5].Length - 2);
                            }
                            if (col2.Length > 6)
                            {
                                if (col2[6].Length > 2)
                                    variableRequired = col2[6].Substring(1, col2[6].Length - 2);
                            }
                            if (col2.Length > 7)
                            {
                                if (col2[7].Length > 2)
                                    variableReport = col2[7].Substring(1, col2[7].Length - 2);
                            }
                        }
                    }
                    else
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_") + 2);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                    }

                    if (vm.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureVariableViewModel variableInput = new ProcedureVariableViewModel();
                        variableInput.Name = variableName;
                        variableInput.Title = variableTitle;
                        variableInput.Value = variablevalue;
                        variableInput.Unit = variableUnit;
                        variableInput.Type = strType;
                        variableInput.Items = variableItems;
                        variableInput.Min = variableMin;
                        variableInput.Max = variableMax;
                        variableInput.TypeInput = variableTypeInput;
                        if (!string.IsNullOrEmpty(variableReport) && bool.TryParse(variableReport, out bool reporta))
                            variableInput.Report = reporta;
                        if (!string.IsNullOrEmpty(variableRequired) && bool.TryParse(variableRequired, out bool requireda))
                            variableInput.Required = requireda;
                        vm.Variables.Add(variableInput);
                    }
                    if (step.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureDetaiVariableViewModel stepv = new ProcedureDetaiVariableViewModel();
                        stepv.Name = variableName;
                        stepv.Title = variableTitle;
                        stepv.TypeInput = variableTypeInput;
                        stepv.Value = variablevalue;
                        step.Variables.Add(stepv);
                    }
                    ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                    fv1.VariableName = variableName;
                    fv1.Value = variablevalue;
                    functionLoadViewRun.FunctionVariables.Add(fv1);
                }
                step.Functions.Add(functionLoadViewRun);
            }
            if (!string.IsNullOrEmpty(strLoadViewCreate))
            {
                ProcedureDetailFunction functionLoadViewCreate = new ProcedureDetailFunction();
                functionLoadViewCreate.PathDll = pathDll;
                functionLoadViewCreate.Assembly = strAssembly;
                functionLoadViewCreate.AssemblyType = strAssemblyType;
                functionLoadViewCreate.FunctionName = "LoadViewCreate";
                if (strLoadViewCreate.StartsWith("Default"))
                {
                    functionLoadViewCreate.Default = true;

                    functionLoadViewCreate.Value = "";
                }
                else
                {
                    functionLoadViewCreate.Default = false;
                    functionLoadViewCreate.Value = strLoadViewCreate.Substring(0, strLoadViewRun.IndexOf("("));
                }

                functionLoadViewCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                var index1 = strLoadViewCreate.IndexOf("(");
                var index2 = strLoadViewCreate.IndexOf(")");
                if (index1 != -1)
                {
                    var strVariables = strLoadViewCreate.Substring(index1 + 1, index2 - (index1 + 1));

                    var col = strVariables.Split(',');
                    if (col != null && col.Count() > 0)
                    {
                        foreach (string strv in col)
                        {
                            var strtext = strv.Trim();
                            var strType = strtext.Substring(0, strtext.IndexOf(" "));
                            strType = strType.Substring(0, 1).ToUpper() + strType.Substring(1);
                            var strVariable = strtext.Substring(strtext.IndexOf(" ") + 1);
                            var variableName = "";
                            var variablevalue = "";
                            var variableTitle = "";
                            var variableUnit = "";
                            var variableItems = "";
                            var variableMin = "";
                            var variableMax = "";
                            var variableTypeInput = "";
                            var variableRequired = "";
                            var variableReport = "";
                            if (strVariable.IndexOf("=") != -1)
                            {
                                variableName = strVariable.Substring(0, strVariable.IndexOf("_;"));
                                var strc1 = strVariable.Substring(strVariable.IndexOf("_;") + 3);
                                variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                                var strc = strc1.Substring(strc1.IndexOf("=") + 2);
                                variablevalue = strc.Substring(0, strc.IndexOf("\""));
                                strc = strc.Substring(strc.IndexOf("\"") + 1);
                                if (!string.IsNullOrEmpty(strc))
                                {
                                    var col2 = strc.Split("_;");
                                    if (col2.Length > 1)
                                    {
                                        if (col2[1].Length > 2)
                                            variableUnit = col2[1].Substring(1, col2[1].Length - 2);
                                    }
                                    if (col2.Length > 2)
                                    {
                                        if (col2[2].Length > 2)
                                        {
                                            variableItems = col2[2].Substring(1, col2[2].Length - 2);
                                            variableItems = variableItems.Replace("|", ",");
                                        }

                                    }
                                    if (col2.Length > 3)
                                    {
                                        if (col2[3].Length > 2)
                                            variableMin = col2[3].Substring(1, col2[3].Length - 2);
                                    }
                                    if (col2.Length > 4)
                                    {
                                        if (col2[4].Length > 2)
                                            variableMax = col2[4].Substring(1, col2[4].Length - 2);
                                    }
                                    if (col2.Length > 5)
                                    {
                                        if (col2[5].Length > 2)
                                            variableTypeInput = col2[5].Substring(1, col2[5].Length - 2);
                                    }
                                    if (col2.Length > 6)
                                    {
                                        if (col2[6].Length > 2)
                                            variableRequired = col2[6].Substring(1, col2[6].Length - 2);
                                    }
                                    if (col2.Length > 7)
                                    {
                                        if (col2[7].Length > 2)
                                            variableReport = col2[7].Substring(1, col2[7].Length - 2);
                                    }
                                }
                            }
                            else
                            {
                                variableName = strVariable.Substring(0, strVariable.IndexOf("_"));
                                var strc1 = strVariable.Substring(strVariable.IndexOf("_") + 2);
                                variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                            }

                            if (vm.Variables.Count(t => t.Name == variableName) == 0)
                            {
                                ProcedureVariableViewModel variableInput = new ProcedureVariableViewModel();
                                variableInput.Name = variableName;
                                variableInput.Title = variableTitle;
                                variableInput.Value = variablevalue;
                                variableInput.Unit = variableUnit;
                                variableInput.Type = strType;
                                variableInput.Items = variableItems;
                                variableInput.Min = variableMin;
                                variableInput.Max = variableMax;
                                variableInput.TypeInput = variableTypeInput;
                                if (!string.IsNullOrEmpty(variableReport) && bool.TryParse(variableReport, out bool reporta))
                                    variableInput.Report = reporta;
                                if (!string.IsNullOrEmpty(variableRequired) && bool.TryParse(variableRequired, out bool requireda))
                                    variableInput.Required = requireda;
                                vm.Variables.Add(variableInput);
                            }
                            if (step.Variables.Count(t => t.Name == variableName) == 0)
                            {
                                ProcedureDetaiVariableViewModel stepv = new ProcedureDetaiVariableViewModel();
                                stepv.Name = variableName;
                                stepv.Title = variableTitle;
                                stepv.TypeInput = variableTypeInput;
                                stepv.Value = variablevalue;
                                step.Variables.Add(stepv);
                            }
                            ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                            fv1.VariableName = variableName;
                            fv1.Value = variablevalue;
                            functionLoadViewCreate.FunctionVariables.Add(fv1);
                        }
                    }
                }


                step.Functions.Add(functionLoadViewCreate);
            }
            if (!string.IsNullOrEmpty(strSaveData))
            {
                ProcedureDetailFunction functionLoadSaveData = new ProcedureDetailFunction();
                functionLoadSaveData.PathDll = pathDll;
                functionLoadSaveData.Assembly = strAssembly;
                functionLoadSaveData.FunctionName = "SaveData";
                functionLoadSaveData.AssemblyType = strAssemblyType;
                functionLoadSaveData.Value = strSaveData.Substring(0, strSaveData.IndexOf("("));
                functionLoadSaveData.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                var index1 = strSaveData.IndexOf("(");
                var index2 = strSaveData.IndexOf(")");
                var strVariables = strSaveData.Substring(index1 + 1, index2 - (index1 + 1));
                var col = strVariables.Split(',');
                foreach (string strv in col)
                {
                    var strtext = strv.Trim();
                    var strType = strtext.Substring(0, strtext.IndexOf(" "));
                    strType = strType.Substring(0, 1).ToUpper() + strType.Substring(1);
                    var strVariable = strtext.Substring(strtext.IndexOf(" ") + 1);
                    var variableName = "";
                    var variablevalue = "";
                    var variableTitle = "";
                    var variableUnit = "";
                    var variableItems = "";
                    var variableMin = "";
                    var variableMax = "";
                    var variableTypeInput = "";
                    var variableRequired = "";
                    var variableReport = "";
                    if (strVariable.IndexOf("=") != -1)
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_;"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_;") + 3);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                        var strc = strc1.Substring(strc1.IndexOf("=") + 2);
                        variablevalue = strc.Substring(0, strc.IndexOf("\""));
                        strc = strc.Substring(strc.IndexOf("\"") + 1);
                        if (!string.IsNullOrEmpty(strc))
                        {
                            var col2 = strc.Split("_;");
                            if (col2.Length > 1)
                            {
                                if (col2[1].Length > 2)
                                    variableUnit = col2[1].Substring(1, col2[1].Length - 2);
                            }
                            if (col2.Length > 2)
                            {
                                if (col2[2].Length > 2)
                                {
                                    variableItems = col2[2].Substring(1, col2[2].Length - 2);
                                    variableItems = variableItems.Replace("|", ",");
                                }

                            }
                            if (col2.Length > 3)
                            {
                                if (col2[3].Length > 2)
                                    variableMin = col2[3].Substring(1, col2[3].Length - 2);
                            }
                            if (col2.Length > 4)
                            {
                                if (col2[4].Length > 2)
                                    variableMax = col2[4].Substring(1, col2[4].Length - 2);
                            }
                            if (col2.Length > 5)
                            {
                                if (col2[5].Length > 2)
                                    variableTypeInput = col2[5].Substring(1, col2[5].Length - 2);
                            }
                            if (col2.Length > 6)
                            {
                                if (col2[6].Length > 2)
                                    variableRequired = col2[6].Substring(1, col2[6].Length - 2);
                            }
                            if (col2.Length > 7)
                            {
                                if (col2[7].Length > 2)
                                    variableReport = col2[7].Substring(1, col2[7].Length - 2);
                            }
                        }
                    }
                    else
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_") + 2);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                    }

                    if (vm.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureVariableViewModel variableInput = new ProcedureVariableViewModel();
                        variableInput.Name = variableName;
                        variableInput.Title = variableTitle;
                        variableInput.Value = variablevalue;
                        variableInput.Unit = variableUnit;
                        variableInput.Type = strType;
                        variableInput.Items = variableItems;
                        variableInput.Min = variableMin;
                        variableInput.Max = variableMax;
                        variableInput.TypeInput = variableTypeInput;
                        if (!string.IsNullOrEmpty(variableReport) && bool.TryParse(variableReport, out bool reporta))
                            variableInput.Report = reporta;
                        if (!string.IsNullOrEmpty(variableRequired) && bool.TryParse(variableRequired, out bool requireda))
                            variableInput.Required = requireda;
                        vm.Variables.Add(variableInput);
                    }
                    if (step.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureDetaiVariableViewModel stepv = new ProcedureDetaiVariableViewModel();
                        stepv.Name = variableName;
                        stepv.Title = variableTitle;
                        stepv.TypeInput = variableTypeInput;
                        stepv.Value = variablevalue;
                        step.Variables.Add(stepv);
                    }
                    ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                    fv1.VariableName = variableName;
                    fv1.Value = variablevalue;
                    functionLoadSaveData.FunctionVariables.Add(fv1);
                }
                step.Functions.Add(functionLoadSaveData);
            }
            if (!string.IsNullOrEmpty(strSaveDataCreate))
            {
                ProcedureDetailFunction functionLoadSaveDataCreate = new ProcedureDetailFunction();
                functionLoadSaveDataCreate.PathDll = pathDll;
                functionLoadSaveDataCreate.Assembly = strAssembly;
                functionLoadSaveDataCreate.FunctionName = "SaveDataCreate";
                functionLoadSaveDataCreate.AssemblyType = strAssemblyType;
                functionLoadSaveDataCreate.Value = strSaveDataCreate.Substring(0, strSaveDataCreate.IndexOf("("));
                functionLoadSaveDataCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                var index1 = strSaveDataCreate.IndexOf("(");
                var index2 = strSaveDataCreate.IndexOf(")");
                var strVariables = strSaveDataCreate.Substring(index1 + 1, index2 - (index1 + 1));
                var col = strVariables.Split(',');
                foreach (string strv in col)
                {
                    var strtext = strv.Trim();
                    var strType = strtext.Substring(0, strtext.IndexOf(" "));
                    strType = strType.Substring(0, 1).ToUpper() + strType.Substring(1);
                    var strVariable = strtext.Substring(strtext.IndexOf(" ") + 1);
                    var variableName = "";
                    var variablevalue = "";
                    var variableTitle = "";
                    var variableUnit = "";
                    var variableItems = "";
                    var variableMin = "";
                    var variableMax = "";
                    var variableTypeInput = "";
                    var variableRequired = "";
                    var variableReport = "";
                    if (strVariable.IndexOf("=") != -1)
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_;"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_;") + 3);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                        var strc = strc1.Substring(strc1.IndexOf("=") + 2);
                        variablevalue = strc.Substring(0, strc.IndexOf("\""));
                        strc = strc.Substring(strc.IndexOf("\"") + 1);
                        if (!string.IsNullOrEmpty(strc))
                        {
                            var col2 = strc.Split("_;");
                            if (col2.Length > 1)
                            {
                                if (col2[1].Length > 2)
                                    variableUnit = col2[1].Substring(1, col2[1].Length - 2);
                            }
                            if (col2.Length > 2)
                            {
                                if (col2[2].Length > 2)
                                {
                                    variableItems = col2[2].Substring(1, col2[2].Length - 2);
                                    variableItems = variableItems.Replace("|", ",");
                                }

                            }
                            if (col2.Length > 3)
                            {
                                if (col2[3].Length > 2)
                                    variableMin = col2[3].Substring(1, col2[3].Length - 2);
                            }
                            if (col2.Length > 4)
                            {
                                if (col2[4].Length > 2)
                                    variableMax = col2[4].Substring(1, col2[4].Length - 2);
                            }
                            if (col2.Length > 5)
                            {
                                if (col2[5].Length > 2)
                                    variableTypeInput = col2[5].Substring(1, col2[5].Length - 2);
                            }
                            if (col2.Length > 6)
                            {
                                if (col2[6].Length > 2)
                                    variableRequired = col2[6].Substring(1, col2[6].Length - 2);
                            }
                            if (col2.Length > 7)
                            {
                                if (col2[7].Length > 2)
                                    variableReport = col2[7].Substring(1, col2[7].Length - 2);
                            }
                        }
                    }
                    else
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_") + 2);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                    }

                    if (vm.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureVariableViewModel variableInput = new ProcedureVariableViewModel();
                        variableInput.Name = variableName;
                        variableInput.Title = variableTitle;
                        variableInput.Value = variablevalue;
                        variableInput.Unit = variableUnit;
                        variableInput.Type = strType;
                        variableInput.Items = variableItems;
                        variableInput.Min = variableMin;
                        variableInput.Max = variableMax;
                        variableInput.TypeInput = variableTypeInput;
                        if (!string.IsNullOrEmpty(variableReport) && bool.TryParse(variableReport, out bool reporta))
                            variableInput.Report = reporta;
                        if (!string.IsNullOrEmpty(variableRequired) && bool.TryParse(variableRequired, out bool requireda))
                            variableInput.Required = requireda;
                        vm.Variables.Add(variableInput);
                    }
                    if (step.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureDetaiVariableViewModel stepv = new ProcedureDetaiVariableViewModel();
                        stepv.Name = variableName;
                        stepv.Title = variableTitle;
                        stepv.TypeInput = variableTypeInput;
                        stepv.Value = variablevalue;
                        step.Variables.Add(stepv);
                    }
                    ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                    fv1.VariableName = variableName;
                    fv1.Value = variablevalue;
                    functionLoadSaveDataCreate.FunctionVariables.Add(fv1);
                }
                step.Functions.Add(functionLoadSaveDataCreate);
            }
            if (!string.IsNullOrEmpty(strMonitor))
            {
                ProcedureDetailFunction functionLoadMonitor = new ProcedureDetailFunction();
                functionLoadMonitor.PathDll = pathDll;
                functionLoadMonitor.Assembly = strAssembly;
                functionLoadMonitor.FunctionName = "Monitor";
                functionLoadMonitor.AssemblyType = strAssemblyType;
                functionLoadMonitor.Value = strMonitor.Substring(0, strMonitor.IndexOf("("));
                functionLoadMonitor.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                var index1 = strMonitor.IndexOf("(");
                var index2 = strMonitor.IndexOf(")");
                var strVariables = strMonitor.Substring(index1 + 1, index2 - (index1 + 1));
                var col = strVariables.Split(',');
                foreach (string strv in col)
                {
                    var strtext = strv.Trim();
                    var strType = strtext.Substring(0, strtext.IndexOf(" "));
                    strType = strType.Substring(0, 1).ToUpper() + strType.Substring(1);
                    var strVariable = strtext.Substring(strtext.IndexOf(" ") + 1);
                    var variableName = "";
                    var variablevalue = "";
                    var variableTitle = "";
                    var variableUnit = "";
                    var variableItems = "";
                    var variableMin = "";
                    var variableMax = "";
                    var variableTypeInput = "";
                    var variableRequired = "";
                    var variableReport = "";
                    if (strVariable.IndexOf("=") != -1)
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_;"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_;") + 3);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                        var strc = strc1.Substring(strc1.IndexOf("=") + 2);
                        variablevalue = strc.Substring(0, strc.IndexOf("\""));
                        strc = strc.Substring(strc.IndexOf("\"") + 1);
                        if (!string.IsNullOrEmpty(strc))
                        {
                            var col2 = strc.Split("_;");
                            if (col2.Length > 1)
                            {
                                if (col2[1].Length > 2)
                                    variableUnit = col2[1].Substring(1, col2[1].Length - 2);
                            }
                            if (col2.Length > 2)
                            {
                                if (col2[2].Length > 2)
                                {
                                    variableItems = col2[2].Substring(1, col2[2].Length - 2);
                                    variableItems = variableItems.Replace("|", ",");
                                }

                            }
                            if (col2.Length > 3)
                            {
                                if (col2[3].Length > 2)
                                    variableMin = col2[3].Substring(1, col2[3].Length - 2);
                            }
                            if (col2.Length > 4)
                            {
                                if (col2[4].Length > 2)
                                    variableMax = col2[4].Substring(1, col2[4].Length - 2);
                            }
                            if (col2.Length > 5)
                            {
                                if (col2[5].Length > 2)
                                    variableTypeInput = col2[5].Substring(1, col2[5].Length - 2);
                            }
                            if (col2.Length > 6)
                            {
                                if (col2[6].Length > 2)
                                    variableRequired = col2[6].Substring(1, col2[6].Length - 2);
                            }
                            if (col2.Length > 7)
                            {
                                if (col2[7].Length > 2)
                                    variableReport = col2[7].Substring(1, col2[7].Length - 2);
                            }
                        }
                    }
                    else
                    {
                        variableName = strVariable.Substring(0, strVariable.IndexOf("_"));
                        var strc1 = strVariable.Substring(strVariable.IndexOf("_") + 2);
                        variableTitle = strc1.Substring(0, strc1.IndexOf("\""));
                    }

                    if (vm.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureVariableViewModel variableInput = new ProcedureVariableViewModel();
                        variableInput.Name = variableName;
                        variableInput.Title = variableTitle;
                        variableInput.Value = variablevalue;
                        variableInput.Unit = variableUnit;
                        variableInput.Type = strType;
                        variableInput.Items = variableItems;
                        variableInput.Min = variableMin;
                        variableInput.Max = variableMax;
                        variableInput.TypeInput = variableTypeInput;
                        if (!string.IsNullOrEmpty(variableReport) && bool.TryParse(variableReport, out bool reporta))
                            variableInput.Report = reporta;
                        if (!string.IsNullOrEmpty(variableRequired) && bool.TryParse(variableRequired, out bool requireda))
                            variableInput.Required = requireda;
                        vm.Variables.Add(variableInput);
                    }
                    if (step.Variables.Count(t => t.Name == variableName) == 0)
                    {
                        ProcedureDetaiVariableViewModel stepv = new ProcedureDetaiVariableViewModel();
                        stepv.Name = variableName;
                        stepv.Title = variableTitle;
                        stepv.TypeInput = variableTypeInput;
                        stepv.Value = variablevalue;
                        step.Variables.Add(stepv);
                    }
                    ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                    fv1.VariableName = variableName;
                    fv1.Value = variablevalue;
                    functionLoadMonitor.FunctionVariables.Add(fv1);
                }
                step.Functions.Add(functionLoadMonitor);
            }
            vm.TableProcedures.Add(step);
            EX.Procedures = new List<TemplateViewModel>() { vm };
            var filePath = AppDomain.CurrentDomain.BaseDirectory + strFileName + ".xml";
            FileXML.SaveToXml(EX, filePath);
            FormNotiAll frm = new FormNotiAll();
            frm.LoadData("notificatoin", "OK", 1);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = openFileDialog.Filter = "(*.dll) | *.dll";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileDll.Text = openFileDialog.FileName;
            }
        }
    }
}
