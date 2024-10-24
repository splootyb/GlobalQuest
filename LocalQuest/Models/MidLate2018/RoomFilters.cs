using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class RoomFilters
    {
        public List<string> PinnedFilters { get; set; } = new List<string>()
        {
            "recroomoriginal",
            "community",
            "pvp",
            "quest",
            "game",
            "featured",
            "jerryjuke",
        };
        public List<string> PopularFilters { get; set; } = new List<string>()
        {
            "pvp",
            "quest",
            "game",
            "jerryjuke",
        };
    }
}
