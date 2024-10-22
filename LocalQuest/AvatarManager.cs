using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    public class AvatarManager
    {
        public static List<AvatarItem>? AvatarItems;
        public static async Task SetupAvatarItems()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Getting avatar items...");
            List<AvatarItem>? LocalItems = FileManager.GetJSON<List<AvatarItem>>("Avatar/AvatarItems");
            if(LocalItems == null)
            {
                LocalItems = await DownloadAvatarItems();
            }
            FileManager.WriteJSON("Avatar/AvatarItems", LocalItems);
            AvatarItems = LocalItems;
            Console.Clear();
        }
        public static async Task<List<AvatarItem>> DownloadAvatarItems()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Downloading avatar items...");
            List<AvatarItem>? Data = await NetworkFiles.GetData<List<AvatarItem>>("AvatarItems.json", true);
            if (Data != null)
            {
                return Data;
            }
            else
            {
                return new List<AvatarItem>();
            }
        }
        public static List<SavedOutfit> GetSavedOutfits()
        {
            List<SavedOutfit>? LocalOutfits = FileManager.GetJSON<List<SavedOutfit>>("Avatar/SavedOutfits");
            if (LocalOutfits == null)
            {
                LocalOutfits = new List<SavedOutfit>();
            }
            FileManager.WriteJSON("Avatar/SavedOutfits", LocalOutfits);

            return LocalOutfits;
        }

        public static SavedOutfit SaveOutfit(SavedOutfitReq New)
        {
            List<SavedOutfit>? LocalOutfits = FileManager.GetJSON<List<SavedOutfit>>("Avatar/SavedOutfits");
            if (LocalOutfits == null)
            {
                LocalOutfits = new List<SavedOutfit>();
            }

            SavedOutfit? ExistingOutfit = LocalOutfits.FirstOrDefault(A => A.Slot == int.Parse(New.Slot));
            if(ExistingOutfit == null)
            {
                LocalOutfits.Add(new SavedOutfit()
                {
                    Slot = int.Parse(New.Slot),
                    OutfitSelections = New.OutfitSelections,
                    PreviewImageName = New.PreviewImageName,
                });
            }
            else
            {
                ExistingOutfit.PreviewImageName = New.PreviewImageName;
                ExistingOutfit.OutfitSelections = New.OutfitSelections;
            }

            FileManager.WriteJSON("Avatar/SavedOutfits", LocalOutfits);

            return new SavedOutfit()
            {
                Slot = int.Parse(New.Slot),
                OutfitSelections = New.OutfitSelections,
                PreviewImageName = New.PreviewImageName,
            };
        }
    }
}
