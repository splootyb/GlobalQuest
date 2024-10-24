using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class AvatarItem
    {
        public string? AvatarItemDesc { get; set; }
        public int UnlockedLevel { get; set; }
        // mask
        public int PlatformMask { get; set; } = -1;
        public string FriendlyName { get; set; } = "AvatarItem";
        public GiftRarity Rarity { get; set; }
    }
}
