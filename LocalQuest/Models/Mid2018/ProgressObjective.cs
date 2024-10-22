using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class ProgressObjective
    {
        public int Index { get; set; }
        public int Group { get; set; }
        public float Progress { get; set; }
        public float VisualProgress { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsRewarded { get; set; }
    }
}
