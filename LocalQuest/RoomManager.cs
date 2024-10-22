using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class RoomManager
    {
        public static List<RoomBase>? AllRooms;
        public static async Task DownloadRooms()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Downloading rooms...");
            List<RoomBase>? Data = await NetworkFiles.GetData<List<RoomBase>>("RoomData.json", true);
            if(Data != null)
            {
                AllRooms = Data;
            }
            else
            {
                AllRooms = new List<RoomBase>();
            }

            Console.WriteLine("Reading local rooms...");
            List<RoomBase>? LocalRooms = FileManager.GetJSON<List<RoomBase>>("LocalRooms");
            if(LocalRooms == null)
            {
                Console.WriteLine("Creating rooms file...");
                LocalRooms = new List<RoomBase>();
                FileManager.WriteJSON("LocalRooms", LocalRooms);
            }
            AllRooms.AddRange(LocalRooms);

            Console.WriteLine("Confirming bookmarks...");
            List<long>? Bookmarks = FileManager.GetJSON<List<long>>("BookmarkRooms");
            if (Bookmarks == null)
            {
                Console.WriteLine("Creating bookmarks file...");
                Bookmarks = new List<long>();
                FileManager.WriteJSON("BookmarkRooms", Bookmarks);
            }

            Console.WriteLine("Confirming recents...");
            List<RoomJoin>? Recents = FileManager.GetJSON<List<RoomJoin>>("RecentRooms");
            if (Recents == null)
            {
                Console.WriteLine("Creating recents file...");
                Recents = new List<RoomJoin>();
                FileManager.WriteJSON("RecentRooms", Recents);
            }

            Console.Clear();
        }

        public static void AddLocalRoom(RoomBase New)
        {
            Console.WriteLine("Reading local rooms...");
            List<RoomBase>? LocalRooms = FileManager.GetJSON<List<RoomBase>>("LocalRooms");
            if (LocalRooms == null)
            {
                Console.WriteLine("Creating rooms file...");
                LocalRooms = new List<RoomBase>();
                FileManager.WriteJSON("LocalRooms", LocalRooms);
            }
            LocalRooms.Add(New);
            FileManager.WriteJSON("LocalRooms", LocalRooms);
            if(AllRooms != null)
            {
                AllRooms.Add(New);
            }
        }

        public static void UpdateLocalRoom(RoomBase Updated)
        {
            Console.WriteLine("Reading local rooms...");
            List<RoomBase>? LocalRooms = FileManager.GetJSON<List<RoomBase>>("LocalRooms");
            if (LocalRooms == null)
            {
                Console.WriteLine("Creating rooms file...");
                LocalRooms = new List<RoomBase>();
                FileManager.WriteJSON("LocalRooms", LocalRooms);
            }
            LocalRooms.Remove(LocalRooms.FirstOrDefault(A => A.RoomId == Updated.RoomId));
            LocalRooms.Add(Updated);
            FileManager.WriteJSON("LocalRooms", LocalRooms);
            if (AllRooms != null)
            {
                AllRooms.Add(Updated);
                AllRooms.Remove(AllRooms.FirstOrDefault(A => A.RoomId == Updated.RoomId));
            }
        }

        public static void BookmarkRoom(long RoomId, bool Bookmark)
        {
            List<long>? Bookmarks = FileManager.GetJSON<List<long>>("BookmarkRooms");
            if (Bookmarks == null)
            {
                Console.WriteLine("Creating bookmarks file...");
                Bookmarks = new List<long>();
                FileManager.WriteJSON("BookmarkRooms", Bookmarks);
            }
            if(Bookmark)
            {
                if (!Bookmarks.Contains(RoomId))
                    Bookmarks.Add(RoomId);
            }
            else
            {
                if (Bookmarks.Contains(RoomId))
                    Bookmarks.Remove(RoomId);
            }
            FileManager.WriteJSON("BookmarkRooms", Bookmarks);
        }

        public static List<long> GetBookmarks()
        {
            List<long>? Bookmarks = FileManager.GetJSON<List<long>>("BookmarkRooms");
            if (Bookmarks == null)
            {
                Console.WriteLine("Creating bookmarks file...");
                Bookmarks = new List<long>();
                FileManager.WriteJSON("BookmarkRooms", Bookmarks);
            }
            return Bookmarks;
        }

        public static void JoinTime(long RoomId)
        {
            Console.WriteLine("Getting recents...");
            List<RoomJoin>? Recents = FileManager.GetJSON<List<RoomJoin>>("RecentRooms");
            if (Recents == null)
            {
                Console.WriteLine("Creating recents file...");
                Recents = new List<RoomJoin>();
                FileManager.WriteJSON("RecentRooms", Recents);
            }
            RoomJoin? Recent = Recents.FirstOrDefault(A => A.RoomId == RoomId);
            if (Recent == null)
            {
                Recents.Add(new RoomJoin()
                {
                    LastJoin = DateTime.Now,
                    RoomId = RoomId
                });
            }
            else
            {
                Recent.LastJoin = DateTime.Now;
            }
            FileManager.WriteJSON("RecentRooms", Recents);
        }

        public static List<long> GetRecentRooms()
        {
            Console.WriteLine("Getting recents...");
            List<RoomJoin>? Recents = FileManager.GetJSON<List<RoomJoin>>("RecentRooms");
            if (Recents == null)
            {
                Console.WriteLine("Creating recents file...");
                Recents = new List<RoomJoin>();
                FileManager.WriteJSON("RecentRooms", Recents);
            }
            return Recents.OrderByDescending(A => A.LastJoin).Select(A => A.RoomId).ToList();
        }
    }

    public class RoomJoin
    {
        public long RoomId { get; set; }
        public DateTime LastJoin { get; set; }
    }

    public class RoomBase
    {
        public RoomBase()
        {
            if(Accessibility == null)
            {
                Accessibility = Models.Mid2018.Accessibility.Public;
            }
        }
        public DateTime? CreationTime { get; set; } = DateTime.MinValue;
        public long RoomId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
        public bool Sandbox { get; set; }
        public int CreatorPlayerId { get; set; }
        public bool? AllowScreenMode { get; set; }
        public Accessibility? Accessibility { get; set; } = Models.Mid2018.Accessibility.Public;
        public List<SceneBase> Scenes { get; set; } = new List<SceneBase>();
    }

    public class SceneBase
    {
        public required string UnitySceneId { get; set; }
        public string? Name { get; set; }
        public string? DataBlob { get; set; }
    }
}
