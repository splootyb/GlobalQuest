using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class ChecklistItem
    {
        public int Order { get; set; }
        public ObjectiveType Objective { get; set; }
        public int Count { get; set; }
        public int CreditAmount { get; set; }
    }
}
