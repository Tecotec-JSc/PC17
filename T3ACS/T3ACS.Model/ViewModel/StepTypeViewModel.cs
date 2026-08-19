using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Model
{
    public class StepTypeViewModel
    {
        public string StepType { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Version { get; set; }
        public string GroupName { get; set; }
        public string RepeatCount { get; set; }
        public string Content { get; set; }
    }
    public enum StepType
    {
        Boolean,     
        String,
        Number,
        PathFile
    }
}
