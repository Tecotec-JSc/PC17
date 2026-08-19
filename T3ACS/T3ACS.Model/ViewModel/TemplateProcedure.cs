using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class TemplateProcedureViewModel
    {
        public int ProcedureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int CountSteps { get; set; }
        public string Duration { get; set; }
        public string Category { get; set; }
    }
}
