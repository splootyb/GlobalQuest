using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Consumable
    {
        public long Id { get; set; }
        public string? ConsumableItemDesc { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Count { get; set; }
        public int UnlockedLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
