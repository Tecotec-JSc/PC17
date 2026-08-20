using Newtonsoft.Json;
using OfficeOpenXml;
using T3ACS.Data.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class ExcelModel : IExcelModel
    {
        public bool DrawTemplateExcel(TemplateViewModel vm1, string pathTemplate, string fileExport, out string error)
        {
            error = "";
            try
            {
                var strjs = JsonConvert.SerializeObject(vm1);
                var vm = JsonConvert.DeserializeObject<TemplateViewModel>(strjs);
                System.IO.File.Copy(pathTemplate, fileExport, true);
                ExcelOpenXml excel = new ExcelOpenXml(fileExport, "Sheet1");
                var lstValueCertificate = excel.GetAllValueInputInDefault();

                if (lstValueCertificate != null && lstValueCertificate.Count > 0)
                {
                    foreach (var item in lstValueCertificate)
                    {
                        if (item != "[Step]" && item != "[Table]")
                        {
                            var str = excel.GetCellBy(item);
                            if (!string.IsNullOrEmpty(str))
                            {
                                var col = str.Split(',');
                                var rowInput = int.Parse(col[0]);
                                var colInput = int.Parse(col[1].Replace("\r\n", ""));
                                switch (item)
                                {
                                    case "[Device]":
                                        excel.AddItemToSpreadsheet(rowInput, colInput, vm.DUTNames);
                                        break;
                                    case "[SerialNumber]":
                                        excel.AddItemToSpreadsheet(rowInput, colInput, vm.DUTModels);
                                        break;
                                    case "[CalibrationDate]":
                                        excel.AddItemToSpreadsheet(rowInput, colInput, vm.StartTime.ToString("dd/MM/yyyy"));
                                        break;
                                    case "[CalibrationProcedure]":
                                        excel.AddItemToSpreadsheet(rowInput, colInput, vm.Subject);
                                        break;
                                    case "[Manufacture]":
                                        excel.AddItemToSpreadsheet(rowInput, colInput, vm.DUTBrand);
                                        break;
                                    default:
                                        excel.AddItemToSpreadsheet(rowInput, colInput, "");
                                        break;
                                }
                            }
                        }
                    }
                }
                // table
                var str1 = excel.GetCellBy("[Table]");
                int rowTable = -1;
                int colTable = -1;
                if (!string.IsNullOrEmpty(str1) && str1.Contains(","))
                {
                    var splitStr1 = str1.Split(",");
                    rowTable = int.Parse(splitStr1[0]);
                    colTable = int.Parse(splitStr1[1]);
                }
                // start step
                var str2 = excel.GetCellBy("[Step]");
                int rowStart = -1;
                int colStart = -1;
                if (!string.IsNullOrEmpty(str2) && str2.Contains(","))
                {
                    var splitStr2 = str2.Split(",");
                    rowStart = int.Parse(splitStr2[0]);
                    colStart = int.Parse(splitStr2[1]);
                }
                var rowNow = rowStart + 2;
                if (vm.TableProcedures != null && vm.TableProcedures.Count > 0)
                {
                    foreach (var step in vm.TableProcedures)
                    {
                        // title step
                        excel.CopyRow(rowStart, colStart, rowStart, colStart + 3, rowNow, colStart, rowNow, colStart + 3);
                        excel.AddItemToSpreadsheet(rowNow, colStart, "Step " + step.NumberOder + ": " + step.Title + ".");
                        if (step.MaskDoneValue != null)
                        {
                            if (step.MaskDoneValue.Value)
                            {
                                excel.AddItemToSpreadsheet(rowNow, colStart + 3, "Pass");
                            }
                            else excel.AddItemToSpreadsheet(rowNow, colStart + 3, "Failed");
                        }

                        rowNow++;

                        if (step.Variables != null && step.Variables.Count > 0)
                        {
                            var numberVrepor = 0;
                            List<ProcedureDetaiVariableViewModel> lstStepV = new List<ProcedureDetaiVariableViewModel>();
                            List<ProcedureVariableViewModel> lstVariables = new List<ProcedureVariableViewModel>();
                            foreach (var variable in step.Variables)
                            {
                                if (vm.Variables.Count(t => t.Name == variable.Name && t.Report) > 0)
                                {
                                    numberVrepor++;
                                    lstStepV.Add(variable);
                                    lstVariables.Add(vm.Variables.Where(t => t.Name == variable.Name && t.Report).FirstOrDefault());
                                }
                            }

                            // Setup Table
                            var colCount = lstStepV.Count(t => t.Name.Contains("Grid"));
                            var lstitemGrid = lstStepV.Where(t => t.Name.Contains("Grid")).ToList();
                            var rowStartTable = rowNow + 1;
                            var rowTbCount = 1;
                            if (colCount > 0)
                            {
                                int n = 0;
                                foreach (var item in lstStepV)
                                {
                                    if (item.Name.Contains("Grid"))
                                    {
                                        rowStartTable += n;
                                        break;
                                    }
                                    n++;
                                }
                                // SetupTitle
                                for (int i = 0; i < colCount; i++)
                                {
                                    excel.Copy(rowTable + 1, colTable, rowStartTable, colTable + i);
                                    excel.Copy(rowTable + 1, colTable, rowStartTable + 1, colTable + 1);
                                    excel.AddItemToSpreadsheet(rowStartTable, colTable + i, lstVariables[i].Title);
                                }
                                // SetupRow
                                if (lstitemGrid != null)
                                {
                                    foreach (var item in lstitemGrid)
                                    {
                                        if (!string.IsNullOrEmpty(item.Value))
                                        {
                                            try
                                            {
                                                var lstObj = JsonConvert.DeserializeObject<List<object>>(item.Value);

                                                var countx = lstObj.Count;
                                                if (rowTbCount < countx) rowTbCount = countx;
                                            }
                                            catch (Exception ex)
                                            {

                                            }

                                        }
                                    }
                                    if (rowTbCount > 1)
                                    {
                                        for (int i = 0; i < rowTbCount - 1; i++)
                                        {
                                            for (int j = 0; j < colCount; j++)
                                            {
                                                excel.Copy(rowTable + 2, colTable, rowStartTable + 2 + i, colTable + j);
                                            }

                                        }
                                    }
                                }

                            }
                            int colTableNow = colTable + 0;
                            bool StartTable = false;
                            int numberNow = 0;
                            int k = 0;
                            foreach (var item in lstStepV)
                            {
                                var item2 = lstVariables[k];
                                if (!item.Name.Contains("Grid"))
                                {
                                    if (StartTable)
                                    {
                                        rowNow += rowTbCount + 2;
                                        StartTable = false;
                                    }
                                    excel.Copy(rowStart + 1, colStart, rowNow, colStart);
                                    var strValue = item2.Title + ": ";
                                    if (item2.Type == "Boolean")
                                    {
                                        if (item.Value.ToLower() == "true") strValue += "Pass";
                                        else strValue += "Failed";
                                    }
                                    else if (item2.Type == "String")
                                    {
                                        strValue += item.Value;
                                    }
                                    else if (!string.IsNullOrEmpty(item2.Unit)&&item2.Unit.Trim().ToUpper()=="HZ"&&!string.IsNullOrEmpty(item.Value))
                                    {

                                        strValue += FormatFrequency(double.Parse(item.Value, System.Globalization.CultureInfo.InvariantCulture));
                                    }
                                    else
                                    {
                                        strValue += item.Value;
                                        if (!string.IsNullOrEmpty(item2.Unit)) strValue += " " + item2.Unit;
                                    }
                                    excel.AddItemToSpreadsheet(rowNow, colStart, strValue);
                                    rowNow++;
                                }
                                else
                                {
                                    StartTable = true;
                                    if (!string.IsNullOrEmpty(item.Value))
                                    {
                                        var lststring = JsonConvert.DeserializeObject<List<object>>(item.Value);
                                        for (int i = 0; i < lststring.Count; i++)
                                        {
                                            excel.AddItemToSpreadsheet(rowStartTable + 1 + i, colTableNow, lststring[i].ToString());

                                        }
                                    }
                                    colTableNow++;

                                }
                                numberNow++;
                                if (numberNow == numberVrepor && StartTable)
                                {
                                    rowNow += rowTbCount + 2;
                                }
                                k++;
                            }
                        }
                    }
                }
                excel.RemoveRow(rowTable, 5);
                excel.SaveAndClose();
                
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        private string FormatFrequency(double hz)
        {
            if (hz >= 1e9) return (hz / 1e9).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " GHz";
            if (hz >= 1e6) return (hz / 1e6).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " MHz";
            if (hz >= 1e3) return (hz / 1e3).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " kHz";
            return hz.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " Hz";
        }
        public ExcelModel()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        }
        public DataTable GetDataFormFile(string filePath, int rowStart)
        {
            var result = new DataTable();
            ExcelOpenXml excel = new ExcelOpenXml(filePath, "Sheet1");
            result = excel.ReadDataTable(rowStart, true);
            return result;
        }

    }
}
