using LocalQuest.Models.Mid2018;
using LocalQuest.Models.MidLate2018;
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

            AddRROs();

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

        static void AddRROs()
        {
            if(AllRooms == null)
            {
                Log.Warn("AllRooms doesn't exist?!");
                return;
            }

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = true,
                Accessibility = Accessibility.Unlisted,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = int.Parse(Config.GetString("AccountId")),
                Description = "Your private room",
                ImageName = "DefaultPFP",
                Name = "DormRoom",
                DormRoom = true,
                RoomId = 100,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "76d98498-60a1-430c-ab76-b54a29b7a163",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Wrecked :p",
                ImageName = "DefaultPFP",
                Name = "RecCenter",
                RRO = true,
                RoomId = 101,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "cbad71af-0831-44d8-b8ef-69edafa841f6",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = true,
                AllowScreenMode = true,
                Accessibility = Accessibility.Unlisted,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Make something",
                ImageName = "DefaultPFP",
                Name = "MakerRoom",
                RRO = true,
                RoomId = 102,
                Tags = "#base," + TagType.AGOnly,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "a75f7547-79eb-47c6-8986-6767abcb4f92",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Look at the moon",
                ImageName = "DefaultPFP",
                Name = "Crescendo",
                RRO = true,
                RoomId = 103,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "49cb8993-a956-43e2-86f4-1318f279b22a",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

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
        public DateTime? MinSupportedDate { get; set; } = DateTime.MinValue;
        public long RoomId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
        public bool Sandbox { get; set; }
        public bool RRO { get; set; } = false;
        public bool DormRoom { get; set; } = false;
        public int CreatorPlayerId { get; set; }
        public bool? AllowScreenMode { get; set; }
        public string Tags { get; set; } = "";
        public Accessibility? Accessibility { get; set; } = Models.Mid2018.Accessibility.Public;
        public List<SceneBase> Scenes { get; set; } = new List<SceneBase>();
    }

    public class SceneBase
    {
        public long SceneId { get; set; }
        public required string UnitySceneId { get; set; }
        public string? Name { get; set; }
        public string? DataBlob { get; set; }
    }
}
