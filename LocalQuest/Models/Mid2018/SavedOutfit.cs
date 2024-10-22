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

    public class SavedOutfitV1
    {
        public SavedOutfitV1()
        {

        }
        public SavedOutfitV1(SavedOutfit Outfit)
        {
            Slot = Outfit.Slot;
            PreviewImageName = Outfit.PreviewImageName;
            OutfitSelections = Outfit.OutfitSelections;
        }
        public int Slot { get; set; }
        public string? PreviewImageName { get; set; }
        public string? OutfitSelections { get; set; }
        public string? HairColor { get; set; }
        public string? SkinColor { get; set; }
    }

    public class SavedOutfitReq
    {
        public string Slot { get; set; } = "0";
        public string? PreviewImageName { get; set; }
        public string? OutfitSelections { get; set; }
    }
}
