using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class EquipmentItem
    {
        public string? PrefabName { get; set; }
        public string? ModificationGuid { get; set; }
        public int UnlockedLevel { get; set; }
        public bool Favorited { get; set; }
    }
}
