using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model.ViewModel
{
    public class CorrectionViewModel
    {
        public int CorrectionId { get; set; }
        public string MarkerID { get; set; }
        public string ReadingValue { get; set; }
        public string CorrectionValue { get; set; }
        public string ReportValue { get; set; }
        public string Uncertainty {  get; set; }
        public string Result { get; set; }
    }
}
