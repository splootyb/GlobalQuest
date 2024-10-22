using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class ObjectiveProgress
    {
        public List<ProgressObjective> Objectives { get; set; } = new List<ProgressObjective>();
        public List<ObjectiveGroup> ObjectiveGroups { get; set; } = new List<ObjectiveGroup>();
    }
}
