using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class SavedOutfit
    {
        public int Slot { get; set; }
        public string? PreviewImageName { get; set; }
        public string? OutfitSelections { get; set; }
    }

    public class SavedOutfitReq
    {
        public string Slot { get; set; } = "0";
        public string? PreviewImageName { get; set; }
        public string? OutfitSelections { get; set; }
    }
}
