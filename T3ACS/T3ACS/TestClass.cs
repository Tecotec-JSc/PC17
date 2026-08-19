using T3ACS.Model;

using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace T3ACS
{
    public class TestClass
    {
        public void CreateFileTest()
        {
            FileExtensionInputViewModel vm = new FileExtensionInputViewModel();
            vm.Category = "RFTestSet";
            vm.Name = "Osiloscope";
            vm.Type = 1;
            vm.TypeFrame = 1;
            vm.PathDll = "\\Osiloscrop.dll";
            vm.MetaData = "";
            vm.Description = "Extension driver of osiloscope model DSO3254A";
            vm.Model = "DSO3254A";
            vm.MetaData = "Control Osiloscope;";
            vm.FunctionCalls = new List<FunctionCallViewModel>();
            FunctionCallViewModel fc1 = new FunctionCallViewModel();
            fc1.Assembly = "Osiloscope";
            fc1.AssemblyType = "CallDll";
            fc1.Name = "SetSimulator";
            fc1.MetaData = "Simulator";
            fc1.Description = "function simulator";
            fc1.Category = "RFTestSet";
            fc1.SetType = false;
            fc1.FunctionValues = new List<FunctionValueViewModel>();     
            FunctionValueViewModel vl1= new FunctionValueViewModel();
            vl1.Name = "UseSimulator";
            vl1.TypeValue = "Boolean";
            vl1.Title = "Value set simulator";
            vl1.Required = true;
            vl1.Description = "Value indicates whether the simulator is set. true: simulator is set. false: simulator is not set";
            fc1.FunctionValues.Add(vl1);
            vm.FunctionCalls.Add(fc1);
            FunctionCallViewModel fc2 = new FunctionCallViewModel();
            fc2.Assembly = "Osiloscope";
            fc2.AssemblyType = "CallDll";
            fc2.Name = "Connect";
            fc2.MetaData = "ConnectIP";
            fc2.Description = "function connect to osiloscope";
            fc2.Category = "RFTestSet";
            fc2.SetType = true;
            fc2.FunctionValues = new List<FunctionValueViewModel>();
            FunctionValueViewModel vl2 = new FunctionValueViewModel();
            vl2.Name = "IPAddress";
            vl2.TypeValue = "String";
            vl2.Title = "IP Address";
            vl2.Required = true;
            vl2.Description = "IP Address";
            fc2.FunctionValues.Add(vl2);
            FunctionValueViewModel vl3 = new FunctionValueViewModel();
            vl3.Name = "Port";
            vl3.TypeValue = "Integer";
            vl3.Title = "Port";
            vl3.Required = true;
            vl3.Description = "Port";
            fc2.FunctionValues.Add(vl3);
            vm.FunctionCalls.Add(fc2);
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionOsiloscope.xml";
            FileXML.SaveToXml(vm,filePath);

        }
        public TemplateViewModel GetProcedureTestOsilo()
        {
            TemplateViewModel vm = new TemplateViewModel();
            vm.Subject = "Test Osilo";
            vm.Version = "1.1";
            vm.Category = "RFTestSet";
            vm.TableProcedures = new List<TableProcedureViewModel>();
            TableProcedureViewModel step = new TableProcedureViewModel();
            step.Title = "Control Osiloscrope";
            step.Description = "Test control Osiloscrope";
            step.NumberOder = 1;
            step.LoopInput = 1;
            step.StepType = "Osiloscope";
            step.Required = true;
            step.ProcedureDetailValue2s = new List<ProcedureDetailValueViewModel>();
            ProcedureDetailValueViewModel variable1 = new ProcedureDetailValueViewModel();
            variable1.NumberOder = 1;
            variable1.Name = "pathDllDriver";
            variable1.Title = "Path file dll driver OsiloScrope";
            variable1.Value = "\\Extension\\OsiloScope\\Dso32154a\\Ver1.0.0\\dllcode.dll";
            variable1.Type = "HashTag";
            variable1.StrValueType= "#OsiloScope,#Dso32154a";
            step.ProcedureDetailValue2s.Add(variable1);
            ProcedureDetailValueViewModel variable2 = new ProcedureDetailValueViewModel();
            variable2.NumberOder = 2;
            variable2.Name = "AssemblyType";
            variable2.Title = "Assembly and Type dll driver OsiloScrope";
            variable2.Value = "hantekdso3254a.Dso32154a";
            variable2.Type = "String";           
            step.ProcedureDetailValue2s.Add(variable2);
            ProcedureDetailValueViewModel variable3 = new ProcedureDetailValueViewModel();
            variable3.NumberOder = 3;
            variable3.Name = "ListValueConnect";
            variable3.Title = "Value to connect Osiloscrope";
            variable3.Value = "";
            variable3.Type = "String";
            step.ProcedureDetailValue2s.Add(variable3);    
            ProcedureDetailValueViewModel variable4 = new ProcedureDetailValueViewModel();
            variable4.NumberOder = 4;
            variable4.Name = "TypePrepare";
            variable4.Title = "Value to connect Osiloscrope";
            variable4.Value = "0";
            variable4.Type = "Byte";
            step.ProcedureDetailValue2s.Add(variable4);
            ProcedureDetailValueViewModel variable5 = new ProcedureDetailValueViewModel();
            variable5.NumberOder = 5;
            variable5.Name = "TypeRun";
            variable5.Title = "Type to Run Osiloscrope";
            variable5.Value = "0";
            variable5.Type = "Byte";
            step.ProcedureDetailValue2s.Add(variable5);
            step.Functions = new List<ProcedureDetailFunction>();
            //OpenView
            ProcedureDetailFunction OpenView = new ProcedureDetailFunction();
            OpenView.PathDll = "\\Extension\\OsiloScope\\ViewDisplay\\codedll.dll";
            OpenView.Assembly = "codedll";
            OpenView.FunctionName = "OpenView";
            OpenView.AssemblyType = "Form1";
            OpenView.Value = "SetPathDll";
            OpenView.NumberOrder = 1;
            OpenView.ValueDetails = new List<ProcedureDetailFunctionValue>();
            ProcedureDetailFunctionValue value1 = new ProcedureDetailFunctionValue();
            value1.ProcedureDetailValueName = "pathDllDriver";
            value1.Type = "Input";
            OpenView.ValueDetails.Add(value1);
            ProcedureDetailFunctionValue value2 = new ProcedureDetailFunctionValue();
            value2.ProcedureDetailValueName = "AssemblyType";
            value2.Type = "Input";
            OpenView.ValueDetails.Add(value2);
            step.Functions.Add(OpenView);
            //Prepare
            ProcedureDetailFunction Prepare = new ProcedureDetailFunction();   
            Prepare.FunctionName = "Prepare";
            Prepare.Value = "PrepareLoad";
            Prepare.NumberOrder = 2;
            Prepare.ValueDetails = new List<ProcedureDetailFunctionValue>();
            ProcedureDetailFunctionValue value3 = new ProcedureDetailFunctionValue();
            value3.ProcedureDetailValueName = "ListValueConnect";
            value3.Type = "Input";
            value3.IsList = true;
            Prepare.ValueDetails.Add(value3);
            ProcedureDetailFunctionValue value4 = new ProcedureDetailFunctionValue();
            value4.ProcedureDetailValueName = "TypePrepare";
            value4.Type = "Input";
            Prepare.ValueDetails.Add(value4);
            step.Functions.Add(Prepare);
            //Run
            ProcedureDetailFunction Run = new ProcedureDetailFunction();
            Run.FunctionName = "Run";
            Run.Value = "Run";
            Run.NumberOrder = 3;
            Run.ValueDetails = new List<ProcedureDetailFunctionValue>();
            ProcedureDetailFunctionValue value5 = new ProcedureDetailFunctionValue();
            value5.ProcedureDetailValueName = "TypeRun";
            value5.Type = "Input";
            Run.ValueDetails.Add(value5);         
            step.Functions.Add(Run);
            //Stop
            ProcedureDetailFunction Stop = new ProcedureDetailFunction();
            Stop.FunctionName = "Stop";
            Stop.Value = "StopLoad";
            Stop.NumberOrder = 4;           
            step.Functions.Add(Stop);
            vm.TableProcedures.Add(step);
            return vm;
        }
        public void CreateFileTestOsilo()
        {
           // var procedure = GetProcedureTestOsilo();
           // FileExtensionInputViewModel vm = new FileExtensionInputViewModel();
           // vm.Category = "RFTestSet";
           // vm.Name = "RFTESTSET";
           // vm.Version = "1.0.1";
           // vm.Type = (int)EnumTypeExtension.Solution;          
           // //vm.PathDll = "\\Osiloscrop.dll";
           // vm.MetaData = "";
           // vm.Description = "Extension solution of osiloscope model DSO3254A";
           //// vm.Model = "DSO3254A";
           // vm.MetaData = "Control Osiloscope;";
           // vm.Extensions = new List<FileExtensionInputViewModel>();
           // // extension procedure
           // FileExtensionInputViewModel fileExProcedure = new FileExtensionInputViewModel();
           // fileExProcedure.Category = "RFTestSet";
           // fileExProcedure.Name = "RFTESTSET";
           // fileExProcedure.Version = "1.0.1";
           // fileExProcedure.Type = (int)EnumTypeExtension.Procedure;
           // fileExProcedure.Procedure= procedure;
           // vm.Extensions.Add(fileExProcedure);
           // //Extension Osilo
           // var filename = "C:\\CodeNow\\T3ACSM\\T3ACS\\Extension\\Osilo\\Ocsilloscope.xml";
           // XmlSerializer serializer = new XmlSerializer(typeof(FileExtensionInputViewModel));
           // FileExtensionInputViewModel dr;
           // using (FileStream fs = new FileStream(filename, FileMode.Open))
           // {
           //     dr = (FileExtensionInputViewModel)serializer.Deserialize(fs);
           // }
           // vm.Extensions.Add(dr);
           // var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionSolution.xml";
           // FileXML.SaveToXml(vm, filePath);
        }
        public void CreateFileToolRfTestSet()
        {
            FileExtensionInputViewModel vm = new FileExtensionInputViewModel();
            vm.Category = "RFTestSet";
            vm.Type = 4;
            vm.Name = "RF Test Set";
            vm.Version = "1.0.0";
            vm.PathDll = "\\EliteRF.dll";
            vm.FunctionCalls = new List<FunctionCallViewModel>();
            FunctionCallViewModel fc1 = new FunctionCallViewModel();
            fc1.Assembly = "EliteRF";
            fc1.AssemblyType = "FormMainEliteRF";
            fc1.Name = "Show";
            vm.FunctionCalls.Add(fc1);
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionToolsEliteRF.xml";
            FileXML.SaveToXml(vm, filePath);
        }
    }
}
