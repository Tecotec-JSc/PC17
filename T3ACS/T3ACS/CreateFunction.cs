using Newtonsoft.Json;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS
{
    public class CreateFunction
    {
        public void CreateFileTest()
        {
            FileExtensionInputViewModel vm = new FileExtensionInputViewModel();
            vm.Category = "RFTestSet";
            vm.Name = "RFTestSet";
            vm.Type =(int) EnumTypeExtension.Procedure;
            //vm.Procedures = GetProcedureTestSpectrum();
            vm.Version = "1.0.0";
            vm.TypeFrame = 1;
            // vm.Model = "DS520A";       
            //var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionSpectrumProcedure.xml";
            vm.Procedures = new List<TemplateViewModel>();
            vm.Procedures.Add(GetProcedureTestSpectrum3());
            ////
            //ProcedureModel model = new ProcedureModel();
            //TemplateViewModel temp1 = model.GetProcedureById(15);
            //TemplateViewModel temp2 = model.GetProcedureById(17);            
            //TemplateViewModel temp3 = model.GetProcedureById(18);
            //TemplateViewModel temp4 = model.GetProcedureById(19);
            //vm.Procedures.Add(temp4);
            //vm.Procedures.Add(temp1);
            //vm.Procedures.Add(temp2);
            //vm.Procedures.Add(temp3);
            //for (int i = 23; i < 34; i++)
            //{
            //    TemplateViewModel tempa = model.GetProcedureById(i);
            //    vm.Procedures.Add(tempa);
            //}
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionProcedureSpectrumRelay.xml";
            FileXML.SaveToXml(vm, filePath);
        }
        public TemplateViewModel GetProcedureTestSpectrum()
        {
            TemplateViewModel vm = new TemplateViewModel();
            vm.Subject = "Hiện thị phổ tín hiệu đơn tần bất kì từ 100Khz đến 20GHz";
            vm.Version = "1.1";
            vm.Category = "RFTestSet";
            vm.TableProcedures = new List<TableProcedureViewModel>();
            vm.Variables = new List<ProcedureVariableViewModel>();
            //
            ProcedureVariableViewModel variablePathDll = new ProcedureVariableViewModel();
            variablePathDll.Name = "pathDllDriverSpectrum";
            variablePathDll.Value = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
            variablePathDll.Type = "PathFile";
            vm.Variables.Add(variablePathDll);

            ProcedureVariableViewModel variableGetForm = new ProcedureVariableViewModel();
            variableGetForm.Name = "GetFormSpectrum";
            variableGetForm.Value = "GetFormByName";
            variableGetForm.Type = "String";
            vm.Variables.Add(variableGetForm);

            ProcedureVariableViewModel variableFormSweep = new ProcedureVariableViewModel();
            variableFormSweep.Name = "GetFormSweep";
            variableFormSweep.Value = "FormDetailStepSpectrum";
            variableFormSweep.Type = "String";
            vm.Variables.Add(variableFormSweep);

            ProcedureVariableViewModel variableInput1 = new ProcedureVariableViewModel();
            variableInput1.Name = "StartFrequency";
            variableInput1.Title = "Start Frequency";
            variableInput1.Value = "100.000";
            variableInput1.Type = "Double";
            variableInput1.Unit = "Hz";
            vm.Variables.Add(variableInput1);
            ProcedureVariableViewModel variableInput2 = new ProcedureVariableViewModel();
            variableInput2.Name = "StopFrequency";
            variableInput2.Title = "Stop Frequency";
            variableInput2.Value = "4.000.000.000";
            variableInput2.Type = "Double";
            variableInput2.Unit = "Hz";
            vm.Variables.Add(variableInput2);
            ProcedureVariableViewModel variableInput3 = new ProcedureVariableViewModel();
            variableInput3.Name = "StepFrequency";
            variableInput3.Title = "Step Frequency";
            variableInput3.Value = "100.000.000";
            variableInput3.Type = "Double";
            variableInput3.Unit = "Hz";
            vm.Variables.Add(variableInput3);

            TableProcedureViewModel step = new TableProcedureViewModel();
            step.Title = "Setting Spectrum trong chế độ sweep mode";
            step.Description = "Setting Spectrum các tham số trong chế độ sweep mode Sweep_Start:100kHz_Stop:20GHz_Step:20MHz\r\nSignalGen: 1MHz_-18dBm ";
            step.NumberOder = 1;
            step.LoopInput = 1;
            step.StepType = "SettingSpectrumSweep";
            step.Required = true;
            step.Variables = new List<ProcedureDetaiVariableViewModel>();
            ProcedureDetaiVariableViewModel step1v1 = new ProcedureDetaiVariableViewModel();
            step1v1.Name = "pathDllDriverSpectrum";          
            step.Variables.Add(step1v1);
            ProcedureDetaiVariableViewModel step1v2 = new ProcedureDetaiVariableViewModel();
            step1v2.Name = "GetFormSpectrum";
            step.Variables.Add(step1v2);
            ProcedureDetaiVariableViewModel step1v3 = new ProcedureDetaiVariableViewModel();
            step1v3.Name = "GetFormSweep";
            step.Variables.Add(step1v3);
            ProcedureDetaiVariableViewModel step1v4 = new ProcedureDetaiVariableViewModel();
            step1v4.Name = "StartFrequency";
            step.Variables.Add(step1v4);
            ProcedureDetaiVariableViewModel step1v5 = new ProcedureDetaiVariableViewModel();
            step1v5.Name = "StopFrequency";
            step.Variables.Add(step1v5);
            ProcedureDetaiVariableViewModel step1v6 = new ProcedureDetaiVariableViewModel();
            step1v6.Name = "StepFrequency";
            step.Variables.Add(step1v6);
            step.Functions = new List<ProcedureDetailFunction>();
            //LoadViewRun
            {
                ProcedureDetailFunction functionLoadViewRun = new ProcedureDetailFunction();
                functionLoadViewRun.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadViewRun.Assembly = "EliteRF";
                functionLoadViewRun.FunctionName = "LoadView";
                functionLoadViewRun.AssemblyType = "ControlAllModel";
                functionLoadViewRun.Value = "GetFormByName";
                functionLoadViewRun.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormSweep";
                fv1.Value = "FormDetailStepSpectrum";
                functionLoadViewRun.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "StartFrequency";
                fv2.Value = "100.000";
                functionLoadViewRun.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "StopFrequency";
                fv3.Value = "4.000.000.000";
                functionLoadViewRun.FunctionVariables.Add(fv3);
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "StepFrequency";
                fv4.Value = "100.000.000";
                functionLoadViewRun.FunctionVariables.Add(fv4);
                step.Functions.Add(functionLoadViewRun);
            }
            //LoadViewCreate
            {
                ProcedureDetailFunction functionLoadViewCreate = new ProcedureDetailFunction();       
                functionLoadViewCreate.FunctionName = "LoadViewCreate";
                functionLoadViewCreate.Default = true;
                functionLoadViewCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "StartFrequency";
                fv1.Value = "100.000";
                functionLoadViewCreate.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "StopFrequency";
                fv2.Value = "4.000.000.000";
                functionLoadViewCreate.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "StepFrequency";
                fv3.Value = "100.000.000";
                functionLoadViewCreate.FunctionVariables.Add(fv3);
                step.Functions.Add(functionLoadViewCreate);
            }
            //SaveData
            {
                ProcedureDetailFunction functionLoadSaveData = new ProcedureDetailFunction();
                functionLoadSaveData.FunctionName = "SaveData";
                functionLoadSaveData.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadSaveData.Assembly = "EliteRF";
                functionLoadSaveData.AssemblyType = "ControlAllModel";
                functionLoadSaveData.Value = "SaveDataFormStep";
                functionLoadSaveData.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormSweep";
                fv1.Value = "FormDetailStepSpectrum";
                functionLoadSaveData.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "StartFrequency";
                fv2.Value = "100.000";
                functionLoadSaveData.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "StopFrequency";
                fv3.Value = "4.000.000.000";
                functionLoadSaveData.FunctionVariables.Add(fv3);
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "StepFrequency";
                fv4.Value = "100.000.000";
                functionLoadSaveData.FunctionVariables.Add(fv4);
                step.Functions.Add(functionLoadSaveData);

            }
            vm.TableProcedures.Add(step);






            //ProcedureDetailValueViewModel variable2 = new ProcedureDetailValueViewModel();
            //variable2.NumberOder = 2;
            //variable2.Name = "AssemblyType";
            //variable2.Title = "Assembly and Type dll driver OsiloScrope";
            //variable2.Value = "hantekdso3254a.Dso32154a";
            //variable2.Type = "String";
            //step.ProcedureDetailValue2s.Add(variable2);
            //ProcedureDetailValueViewModel variable3 = new ProcedureDetailValueViewModel();
            //variable3.NumberOder = 3;
            //variable3.Name = "ListValueConnect";
            //variable3.Title = "Value to connect Osiloscrope";
            //variable3.Value = "";
            //variable3.Type = "String";
            //step.ProcedureDetailValue2s.Add(variable3);
            //ProcedureDetailValueViewModel variable4 = new ProcedureDetailValueViewModel();
            //variable4.NumberOder = 4;
            //variable4.Name = "TypePrepare";
            //variable4.Title = "Value to connect Osiloscrope";
            //variable4.Value = "0";
            //variable4.Type = "Byte";
            //step.ProcedureDetailValue2s.Add(variable4);
            //ProcedureDetailValueViewModel variable5 = new ProcedureDetailValueViewModel();
            //variable5.NumberOder = 5;
            //variable5.Name = "TypeRun";
            //variable5.Title = "Type to Run Osiloscrope";
            //variable5.Value = "0";
            //variable5.Type = "Byte";
            //step.ProcedureDetailValue2s.Add(variable5);
            //step.Functions = new List<ProcedureDetailFunction>();
            ////OpenView
            //ProcedureDetailFunction OpenView = new ProcedureDetailFunction();
            //OpenView.PathDll = "\\Extension\\OsiloScope\\ViewDisplay\\codedll.dll";
            //OpenView.Assembly = "codedll";
            //OpenView.FunctionName = "OpenView";
            //OpenView.AssemblyType = "Form1";
            //OpenView.Value = "SetPathDll";
            //OpenView.NumberOrder = 1;
            //OpenView.ValueDetails = new List<ProcedureDetailFunctionValue>();
            //ProcedureDetailFunctionValue value1 = new ProcedureDetailFunctionValue();
            //value1.ProcedureDetailValueName = "pathDllDriver";
            //value1.Type = "Input";
            //OpenView.ValueDetails.Add(value1);
            //ProcedureDetailFunctionValue value2 = new ProcedureDetailFunctionValue();
            //value2.ProcedureDetailValueName = "AssemblyType";
            //value2.Type = "Input";
            //OpenView.ValueDetails.Add(value2);
            //step.Functions.Add(OpenView);
            ////Prepare
            //ProcedureDetailFunction Prepare = new ProcedureDetailFunction();
            //Prepare.FunctionName = "Prepare";
            //Prepare.Value = "PrepareLoad";
            //Prepare.NumberOrder = 2;
            //Prepare.ValueDetails = new List<ProcedureDetailFunctionValue>();
            //ProcedureDetailFunctionValue value3 = new ProcedureDetailFunctionValue();
            //value3.ProcedureDetailValueName = "ListValueConnect";
            //value3.Type = "Input";
            //value3.IsList = true;
            //Prepare.ValueDetails.Add(value3);
            //ProcedureDetailFunctionValue value4 = new ProcedureDetailFunctionValue();
            //value4.ProcedureDetailValueName = "TypePrepare";
            //value4.Type = "Input";
            //Prepare.ValueDetails.Add(value4);
            //step.Functions.Add(Prepare);
            ////Run
            //ProcedureDetailFunction Run = new ProcedureDetailFunction();
            //Run.FunctionName = "Run";
            //Run.Value = "Run";
            //Run.NumberOrder = 3;
            //Run.ValueDetails = new List<ProcedureDetailFunctionValue>();
            //ProcedureDetailFunctionValue value5 = new ProcedureDetailFunctionValue();
            //value5.ProcedureDetailValueName = "TypeRun";
            //value5.Type = "Input";
            //Run.ValueDetails.Add(value5);
            //step.Functions.Add(Run);
            ////Stop
            //ProcedureDetailFunction Stop = new ProcedureDetailFunction();
            //Stop.FunctionName = "Stop";
            //Stop.Value = "StopLoad";
            //Stop.NumberOrder = 4;
            //step.Functions.Add(Stop);
            //vm.TableProcedures.Add(step);
            return vm;
        }

        public TemplateViewModel GetProcedureTestSpectrum2()
        {
            TemplateViewModel vm = new TemplateViewModel();
            vm.Subject = "Hiện thị phổ tín hiệu đơn tần bất kì từ 100Khz đến 20GHz";
            vm.Version = "1.1";
            vm.Category = "RFTestSet";
            vm.TableProcedures = new List<TableProcedureViewModel>();
            vm.Variables = new List<ProcedureVariableViewModel>();
            //
            ProcedureVariableViewModel variablePathDll = new ProcedureVariableViewModel();
            variablePathDll.Name = "pathDllDriverSpectrum";
            variablePathDll.Value = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
            variablePathDll.Type = "PathFile";
            vm.Variables.Add(variablePathDll);

            ProcedureVariableViewModel variableGetForm = new ProcedureVariableViewModel();
            variableGetForm.Name = "GetFormSpectrum";
            variableGetForm.Value = "GetFormByName";
            variableGetForm.Type = "String";
            vm.Variables.Add(variableGetForm);

            ProcedureVariableViewModel variableFormSweep = new ProcedureVariableViewModel();
            variableFormSweep.Name = "GetFormSweep";
            variableFormSweep.Value = "FormDetailStepSpectrumZeroSpan";
            variableFormSweep.Type = "String";
            vm.Variables.Add(variableFormSweep);

            ProcedureVariableViewModel variableInput1 = new ProcedureVariableViewModel();
            variableInput1.Name = "CenterFrequency";
            variableInput1.Title = "Center Frequency";
            variableInput1.Value = "1.000.000";
            variableInput1.Type = "Double";
            variableInput1.Unit = "Hz";
            vm.Variables.Add(variableInput1);       
            ProcedureVariableViewModel variableInput2 = new ProcedureVariableViewModel();
            variableInput2.Name = "StepFrequency";
            variableInput2.Title = "Step Frequency";
            variableInput2.Value = "20.000.000";
            variableInput2.Type = "Double";
            variableInput2.Unit = "Hz";
            vm.Variables.Add(variableInput2);

            TableProcedureViewModel step = new TableProcedureViewModel();
            step.Title = "Setting Spectrum trong chế độ sweep mode";
            step.Description = "Setting Spectrum các tham số trong chế độ Zero span mode: center 1MHz, step 20 MHz \r\nSignalGen: 2GHz_-18dBm ";
            step.NumberOder = 1;
            step.LoopInput = 1;
            step.StepType = "SettingSpectrumZeroMode";
            step.Required = true;
            step.Variables = new List<ProcedureDetaiVariableViewModel>();
            ProcedureDetaiVariableViewModel step1v1 = new ProcedureDetaiVariableViewModel();
            step1v1.Name = "pathDllDriverSpectrum";
            step.Variables.Add(step1v1);
            ProcedureDetaiVariableViewModel step1v2 = new ProcedureDetaiVariableViewModel();
            step1v2.Name = "GetFormSpectrum";
            step.Variables.Add(step1v2);
            ProcedureDetaiVariableViewModel step1v3 = new ProcedureDetaiVariableViewModel();
            step1v3.Name = "GetFormSweep";
            step.Variables.Add(step1v3);
            ProcedureDetaiVariableViewModel step1v4 = new ProcedureDetaiVariableViewModel();
            step1v4.Name = "CenterFrequency";
            step.Variables.Add(step1v4);        
            ProcedureDetaiVariableViewModel step1v6 = new ProcedureDetaiVariableViewModel();
            step1v6.Name = "StepFrequency";
            step.Variables.Add(step1v6);
            step.Functions = new List<ProcedureDetailFunction>();
            //LoadViewRun
            {
                ProcedureDetailFunction functionLoadViewRun = new ProcedureDetailFunction();
                functionLoadViewRun.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadViewRun.Assembly = "EliteRF";
                functionLoadViewRun.FunctionName = "LoadView";
                functionLoadViewRun.AssemblyType = "ControlAllModel";
                functionLoadViewRun.Value = "GetFormByName";
                functionLoadViewRun.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormSweep";
                fv1.Value = "FormDetailStepSpectrum";
                functionLoadViewRun.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "CenterFrequency";
                fv2.Value = "1000.000";
                functionLoadViewRun.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "StepFrequency";
                fv4.Value = "20.000.000";
                functionLoadViewRun.FunctionVariables.Add(fv4);
                step.Functions.Add(functionLoadViewRun);
            }
            //LoadViewCreate
            {
                ProcedureDetailFunction functionLoadViewCreate = new ProcedureDetailFunction();
                functionLoadViewCreate.FunctionName = "LoadViewCreate";
                functionLoadViewCreate.Default = true;
                functionLoadViewCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "CenterFrequency";
                fv1.Value = "1000.000";
                functionLoadViewCreate.FunctionVariables.Add(fv1);             
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "StepFrequency";
                fv3.Value = "20.000.000";
                functionLoadViewCreate.FunctionVariables.Add(fv3);
                step.Functions.Add(functionLoadViewCreate);
            }
            //SaveData
            {
                ProcedureDetailFunction functionLoadSaveData = new ProcedureDetailFunction();
                functionLoadSaveData.FunctionName = "SaveData";
                functionLoadSaveData.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadSaveData.Assembly = "EliteRF";
                functionLoadSaveData.AssemblyType = "ControlAllModel";
                functionLoadSaveData.Value = "SaveDataFormStep";
                functionLoadSaveData.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormSweep";
                fv1.Value = "FormDetailStepSpectrumZeroSpan";
                functionLoadSaveData.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "CenterFrequency";
                fv2.Value = "1000.000";
                functionLoadSaveData.FunctionVariables.Add(fv2);              
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "StepFrequency";
                fv4.Value = "20.000.000";
                functionLoadSaveData.FunctionVariables.Add(fv4);
                step.Functions.Add(functionLoadSaveData);

            }
            vm.TableProcedures.Add(step);
            return vm;
        }



        public TemplateViewModel GetProcedureTestSpectrum3()
        {
            TemplateViewModel vm = new TemplateViewModel();
            vm.Subject = "Bật Spectrum Analyzer";
            vm.Version = "1.1";
            vm.Category = "RFTestSet";
            vm.TableProcedures = new List<TableProcedureViewModel>();
            vm.Variables = new List<ProcedureVariableViewModel>();
            //
            ProcedureVariableViewModel variablePathDll = new ProcedureVariableViewModel();
            variablePathDll.Name = "pathDllDriverSpectrum";
            variablePathDll.Value = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
            variablePathDll.Type = "PathFile";
            vm.Variables.Add(variablePathDll);

            ProcedureVariableViewModel variableGetForm = new ProcedureVariableViewModel();
            variableGetForm.Name = "GetFormSpectrum";
            variableGetForm.Value = "GetFormByName";
            variableGetForm.Type = "String";
            vm.Variables.Add(variableGetForm);

            ProcedureVariableViewModel variableFormSweep = new ProcedureVariableViewModel();
            variableFormSweep.Name = "GetFormRelay";
            variableFormSweep.Value = "FormStepRelay";
            variableFormSweep.Type = "String";
            vm.Variables.Add(variableFormSweep);

            ProcedureVariableViewModel variableInput1 = new ProcedureVariableViewModel();
            variableInput1.Name = "DevicesName";
            variableInput1.Title = "Các thiết bị tắt bật";
            variableInput1.Value = "Spectrum Analyzer";
            variableInput1.Type = "String"; 
            vm.Variables.Add(variableInput1);
            ProcedureVariableViewModel variableInput2 = new ProcedureVariableViewModel();
            variableInput2.Name = "TitleShow";
            variableInput2.Title = "Title hiện";
            variableInput2.Value = "Bật/ tắt Spectrum Analyzer";
            variableInput2.Type = "String"; 
            vm.Variables.Add(variableInput2);
            ProcedureVariableViewModel variableInput3 = new ProcedureVariableViewModel();
            variableInput3.Name = "StatusSpectrum";
            variableInput3.Title = "Bật/ tắt Spectrum Analyzer";
            variableInput3.Value = "False";
            variableInput3.Type = "Boolean";
            vm.Variables.Add(variableInput3);
            ProcedureVariableViewModel variableInput4 = new ProcedureVariableViewModel();
            variableInput4.Name = "RelayEnable";
            variableInput4.Title = "Cho phép bật tắt nguồn tại form";
            variableInput4.Value = "True";
            variableInput4.Type = "Boolean";
            vm.Variables.Add(variableInput4);
            ProcedureVariableViewModel variableInput5 = new ProcedureVariableViewModel();
            variableInput5.Name = "ReplayConfigPath";
            variableInput5.Title = "ConfigPath";
            variableInput5.Value = "";
            variableInput5.Type = "String";
            vm.Variables.Add(variableInput5);
            TableProcedureViewModel step = new TableProcedureViewModel();
            step.Title = "Bật nguồn cho Spectrum Analyzer";
            step.Description = "Bật nguồn cho Spectrum Analyzer. ";
            step.NumberOder = 1;
            step.LoopInput = 1;
            step.StepType = "RelayTurnOnOFF";
            step.Required = true;
            step.Variables = new List<ProcedureDetaiVariableViewModel>();
            ProcedureDetaiVariableViewModel step1v1 = new ProcedureDetaiVariableViewModel();
            step1v1.Name = "pathDllDriverSpectrum";
            step.Variables.Add(step1v1);
            ProcedureDetaiVariableViewModel step1v2 = new ProcedureDetaiVariableViewModel();
            step1v2.Name = "GetFormSpectrum";
            step.Variables.Add(step1v2);
            ProcedureDetaiVariableViewModel step1v3 = new ProcedureDetaiVariableViewModel();
            step1v3.Name = "GetFormRelay";
            step.Variables.Add(step1v3);
            ProcedureDetaiVariableViewModel step1v4 = new ProcedureDetaiVariableViewModel();
            step1v4.Name = "DevicesName";
            step.Variables.Add(step1v4);
            ProcedureDetaiVariableViewModel step1v6 = new ProcedureDetaiVariableViewModel();
            step1v6.Name = "TitleShow";     
            step.Variables.Add(step1v6);
            ProcedureDetaiVariableViewModel step1v7 = new ProcedureDetaiVariableViewModel();
            step1v7.Name = "RelayEnable";
            step.Variables.Add(step1v7);
            ProcedureDetaiVariableViewModel step1v8 = new ProcedureDetaiVariableViewModel();
            step1v8.Name = "StatusSpectrum";
            step.Variables.Add(step1v8);
            step.Functions = new List<ProcedureDetailFunction>();
            //LoadViewRun
            {
                ProcedureDetailFunction functionLoadViewRun = new ProcedureDetailFunction();
                functionLoadViewRun.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadViewRun.Assembly = "EliteRF";
                functionLoadViewRun.FunctionName = "LoadView";
                functionLoadViewRun.AssemblyType = "ControlAllModel";
                functionLoadViewRun.Value = "GetFormByName";
                functionLoadViewRun.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormRelay";
                fv1.Value = "FormStepRelay";
                functionLoadViewRun.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv11 = new ProcedureDetailFunctionVariable();
                fv11.VariableName = "ReplayConfigPath";
                fv11.Value = "";
                functionLoadViewRun.FunctionVariables.Add(fv11);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "DevicesName";
                fv2.Value = "Spectrum Analyzer";
                functionLoadViewRun.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "TitleShow";
                fv3.Value = "Bật/ tắt Spectrum Analyzer";
                functionLoadViewRun.FunctionVariables.Add(fv3);
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "RelayEnable";
                fv4.Value = "True";
                functionLoadViewRun.FunctionVariables.Add(fv4);
                step.Functions.Add(functionLoadViewRun);
            }
            //LoadViewCreate
            {
                ProcedureDetailFunction functionLoadViewCreate = new ProcedureDetailFunction();
                functionLoadViewCreate.FunctionName = "LoadViewCreate";
                functionLoadViewCreate.Default = true;
                functionLoadViewCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "DevicesName";
                fv1.Value = "Spectrum Analyzer";
                functionLoadViewCreate.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "TitleShow";
                fv3.Value = "Bật/ tắt Spectrum Analyzer";
                functionLoadViewCreate.FunctionVariables.Add(fv3);
                step.Functions.Add(functionLoadViewCreate);
            }
            //SaveData
            {
                ProcedureDetailFunction functionLoadSaveData = new ProcedureDetailFunction();
                functionLoadSaveData.FunctionName = "SaveData";
                functionLoadSaveData.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadSaveData.Assembly = "EliteRF";
                functionLoadSaveData.AssemblyType = "ControlAllModel";
                functionLoadSaveData.Value = "SaveDataFormStep";
                functionLoadSaveData.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormRelay";
                fv1.Value = "FormStepRelay";
                functionLoadSaveData.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "StatusSpectrum";
                fv2.Value = "False";
                functionLoadSaveData.FunctionVariables.Add(fv2);               
                step.Functions.Add(functionLoadSaveData);
            }
            vm.TableProcedures.Add(step);
            TableProcedureViewModel step2 = new TableProcedureViewModel();
            step2.Title = "Quan sát và ghi nhận đèn báo nguồn của Spectrum Analyzer";
            step2.Description = "Quan sát trạng thái switch tắt bật của spectrum analyzer.";
            step2.NumberOder = 2;
            step2.LoopInput = 1;
            step2.StepType = "RelayTurnStatus";
            step2.Required = true;
            step2.Variables = new List<ProcedureDetaiVariableViewModel>();
            ProcedureDetaiVariableViewModel step2v1 = new ProcedureDetaiVariableViewModel();
            step2v1.Name = "pathDllDriverSpectrum";
            step2.Variables.Add(step2v1);
            ProcedureDetaiVariableViewModel step2v2 = new ProcedureDetaiVariableViewModel();
            step2v2.Name = "GetFormSpectrum";
            step2.Variables.Add(step2v2);
            ProcedureDetaiVariableViewModel step2v3 = new ProcedureDetaiVariableViewModel();
            step2v3.Name = "GetFormRelay";
            step2.Variables.Add(step2v3);
            ProcedureDetaiVariableViewModel step2v4 = new ProcedureDetaiVariableViewModel();
            step2v4.Name = "DevicesName";
            step2.Variables.Add(step2v4);
            ProcedureDetaiVariableViewModel step2v6 = new ProcedureDetaiVariableViewModel();
            step2v6.Name = "TitleShow";
            step2.Variables.Add(step2v6);
            ProcedureDetaiVariableViewModel step2v7 = new ProcedureDetaiVariableViewModel();
            step2v7.Name = "RelayEnable";
            step2.Variables.Add(step2v7);
            ProcedureDetaiVariableViewModel step2v8 = new ProcedureDetaiVariableViewModel();
            step2v8.Name = "StatusSpectrum";
            step2.Variables.Add(step2v8);
            step2.Functions = new List<ProcedureDetailFunction>();
            //LoadViewRun
            {
                ProcedureDetailFunction functionLoadViewRun = new ProcedureDetailFunction();
                functionLoadViewRun.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadViewRun.Assembly = "EliteRF";
                functionLoadViewRun.FunctionName = "LoadView";
                functionLoadViewRun.AssemblyType = "ControlAllModel";
                functionLoadViewRun.Value = "GetFormByName";
                functionLoadViewRun.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormRelay";
                fv1.Value = "FormStepRelay";
                functionLoadViewRun.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "DevicesName";
                fv2.Value = "Spectrum Analyzer";
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "TitleShow";
                fv3.Value = "Quan sát trạng thái switch Spectrum Analyzer: ";
                functionLoadViewRun.FunctionVariables.Add(fv2);
                ProcedureDetailFunctionVariable fv4 = new ProcedureDetailFunctionVariable();
                fv4.VariableName = "RelayEnable";
                fv4.Value = "False";
                functionLoadViewRun.FunctionVariables.Add(fv4);
                step2.Functions.Add(functionLoadViewRun);
            }
            //LoadViewCreate
            {
                ProcedureDetailFunction functionLoadViewCreate = new ProcedureDetailFunction();
                functionLoadViewCreate.FunctionName = "LoadViewCreate";
                functionLoadViewCreate.Default = true;
                functionLoadViewCreate.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "DevicesName";
                fv1.Value = "Spectrum Analyzer";
                functionLoadViewCreate.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv3 = new ProcedureDetailFunctionVariable();
                fv3.VariableName = "TitleShow";
                fv3.Value = "Bật/ tắt Spectrum Analyzer";
                functionLoadViewCreate.FunctionVariables.Add(fv3);
                step2.Functions.Add(functionLoadViewCreate);
            }
            //SaveData
            {
                ProcedureDetailFunction functionLoadSaveData = new ProcedureDetailFunction();
                functionLoadSaveData.FunctionName = "SaveData";
                functionLoadSaveData.PathDll = "\\RFTestSet\\Tools\\1.0.0\\EliteRF.dll";
                functionLoadSaveData.Assembly = "EliteRF";
                functionLoadSaveData.AssemblyType = "ControlAllModel";
                functionLoadSaveData.Value = "SaveDataFormStep";
                functionLoadSaveData.FunctionVariables = new List<ProcedureDetailFunctionVariable>();
                ProcedureDetailFunctionVariable fv1 = new ProcedureDetailFunctionVariable();
                fv1.VariableName = "GetFormRelay";
                fv1.Value = "FormStepRelay";
                functionLoadSaveData.FunctionVariables.Add(fv1);
                ProcedureDetailFunctionVariable fv2 = new ProcedureDetailFunctionVariable();
                fv2.VariableName = "StatusSpectrum";
                fv2.Value = "False";
                functionLoadSaveData.FunctionVariables.Add(fv2);
                step2.Functions.Add(functionLoadSaveData);
            }
            vm.TableProcedures.Add(step2);
            return vm;
        }
    }
}
