using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class TableInspectionViewModel
    {
        public int ProcedureId { get; set; }
        public bool Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string DUT { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }

    }
    public class TableResultInspectionViewModel
    {

        public int ResultProcedureId { get; set; }
        public bool Action { get; set; }
        public string RUN { get; set; }
        public string DUT { get; set; }
        public string Author { get; set; }
        public string STATUS { get; set; }
        public string STARTTIME { get; set; }
        public string ENDTIME { get; set; }
        public int PROGRESS { get; set; }

    }
}
