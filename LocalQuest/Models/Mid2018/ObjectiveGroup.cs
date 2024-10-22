using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class ObjectiveGroup
    {
        public int Group { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime ClearedAt { get; set; }
    }
}
