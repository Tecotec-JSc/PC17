using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Util
{
    public static class FileServices
    {
    
            public static bool ConvertExcelToPdf2(string excelFile, string outputFolder, out string error)
            {
                error = "";

                try
                {
                    Process process = new Process();

                    process.StartInfo.FileName =
                        @"C:\Program Files\LibreOffice\program\soffice.exe";

                    process.StartInfo.Arguments =
                        $"--headless --convert-to pdf --outdir \"{outputFolder}\" \"{excelFile}\"";

                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;

                    process.Start();
                    process.WaitForExit();

                    return process.ExitCode == 0;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }

            }
    
    }
}
