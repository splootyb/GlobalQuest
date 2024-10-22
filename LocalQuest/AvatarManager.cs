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
    }
}
