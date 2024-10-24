using LocalQuest.Models.Mid2018;
using LocalQuest.Models.MidLate2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            AllRooms.ForEach(A =>
            {
                if (A.RRO == true && !A.Tags.Contains("#recroomoriginal,2"))
                {
                    Log.Debug("adding rro tag to room: ^" + A.Name);
                    A.Tags += " #recroomoriginal," + (int)TagType.AGOnly;
                }
                else if (A.RRO == false && !A.Tags.Contains("#community,1"))
                {
                    Log.Debug("adding community tag to room: ^" + A.Name);
                    A.Tags += " #community," + (int)TagType.Auto;
                }
            });
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
                ImageName = "DormRoom",
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
                ImageName = "RecCenter",
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
                ImageName = "MakerRoom",
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
                ImageName = "Crescendo",
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

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Bowlingdnajfg",
                ImageName = "Bowling",
                Name = "Bowling",
                RRO = true,
                RoomId = 104,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "ae929543-9a07-41d5-8ee9-dbbee8c36800",
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
                Description = "Take turns drawing, acting, and guessing funny phrases with your friends!",
                ImageName = "3DCharades",
                Name = "3DCharades",
                RRO = true,
                RoomId = 105,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "4078dfed-24bb-4db7-863f-578ba48d726b",
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
                Description = "A leisurely stroll through the grass. Throw your disc into the goal. Sounds easy, right?",
                ImageName = "DiscGolfLake",
                Name = "DiscGolfLake",
                RRO = true,
                RoomId = 106,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "f6f7256c-e438-4299-b99e-d20bef8cf7e0",
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
                Description = "Throw your disc through hazards and around wind machines on this challenging course!",
                ImageName = "DiscGolfPropulsion",
                Name = "DiscGolfPropulsion",
                RRO = true,
                RoomId = 107,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "d9378c9f-80bc-46fb-ad1e-1bed8a674f55",
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
                Description = "Throw dodgeballs to knock out your friends in this gym classic!",
                ImageName = "Dodgeball",
                Name = "Dodgeball",
                RRO = true,
                RoomId = 108,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "3d474b26-26f7-45e9-9a36-9b02847d5e6f",
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
                Description = "A simple rally game between two players in a plexiglass tube with a zero-g ball.",
                ImageName = "Paddleball",
                Name = "Paddleball",
                RRO = true,
                RoomId = 109,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "d89f74fa-d51e-477a-a425-025a891dd499",
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
                Description = "Red and Blue teams splat each other in capture the flag and team battle.",
                ImageName = "Paintball",
                Name = "Paintball",
                RRO = true,
                RoomId = 110,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "e122fe98-e7db-49e8-a1b1-105424b6e1f0",
                        DataBlob = "",
                        Name = "River"
                    },
                    new SceneBase()
                    {
                        SceneId = 2,
                        UnitySceneId = "a785267d-c579-42ea-be43-fec1992d1ca7",
                        DataBlob = "",
                        Name = "Homestead"
                    },
                    new SceneBase()
                    {
                        SceneId = 3,
                        UnitySceneId = "ff4c6427-7079-4f59-b22a-69b089420827",
                        DataBlob = "",
                        Name = "Quarry"
                    },
                    new SceneBase()
                    {
                        SceneId = 4,
                        UnitySceneId = "380d18b5-de9c-49f3-80f7-f4a95c1de161",
                        DataBlob = "",
                        Name = "Clearcut"
                    },
                    new SceneBase()
                    {
                        SceneId = 5,
                        UnitySceneId = "58763055-2dfb-4814-80b8-16fac5c85709",
                        DataBlob = "",
                        Name = "Spillway"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = false,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Red and Blue teams splat each other in capture the flag and team battle.",
                ImageName = "PaintballVR",
                Name = "PaintballVR",
                RRO = true,
                RoomId = 111,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "e122fe98-e7db-49e8-a1b1-105424b6e1f0",
                        DataBlob = "",
                        Name = "River"
                    },
                    new SceneBase()
                    {
                        SceneId = 2,
                        UnitySceneId = "a785267d-c579-42ea-be43-fec1992d1ca7",
                        DataBlob = "",
                        Name = "Homestead"
                    },
                    new SceneBase()
                    {
                        SceneId = 3,
                        UnitySceneId = "ff4c6427-7079-4f59-b22a-69b089420827",
                        DataBlob = "",
                        Name = "Quarry"
                    },
                    new SceneBase()
                    {
                        SceneId = 4,
                        UnitySceneId = "380d18b5-de9c-49f3-80f7-f4a95c1de161",
                        DataBlob = "",
                        Name = "Clearcut"
                    },
                    new SceneBase()
                    {
                        SceneId = 5,
                        UnitySceneId = "58763055-2dfb-4814-80b8-16fac5c85709",
                        DataBlob = "",
                        Name = "Spillway"
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
                Description = "The goblin king stole Coach's Golden Trophy. Team up and embark on an epic quest to recover it!",
                ImageName = "GoldenTrophy",
                Name = "GoldenTrophy",
                RRO = true,
                RoomId = 112,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "91e16e35-f48f-4700-ab8a-a1b79e50e51b",
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
                Description = "Robot invaders threaten the galaxy! Team up with your friends and bring the laser heat!",
                ImageName = "TheRiseofJumbotron",
                Name = "TheRiseofJumbotron",
                RRO = true,
                RoomId = 113,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "acc06e66-c2d0-4361-b0cd-46246a4c455c",
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
                Description = "Can your band of adventurers brave the enchanted wilds, and lift the curse of the crimson cauldron?",
                ImageName = "CrimsonCauldron",
                Name = "CrimsonCauldron",
                RRO = true,
                RoomId = 114,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "949fa41f-4347-45c0-b7ac-489129174045",
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
                Description = "Can your pirate crew get to the Isle, defeat its fearsome guardian, and escape with the gold?",
                ImageName = "IsleOfLostSkulls",
                Name = "IsleOfLostSkulls",
                RRO = true,
                RoomId = 115,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "7e01cfe0-820a-406f-b1b3-0a5bf575235c",
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
                Description = "Teams of three run around slamming themselves into an over-sized soccer ball. Goal!",
                ImageName = "Soccer",
                Name = "Soccer",
                RRO = true,
                RoomId = 116,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "6d5eea4b-f069-4ed0-9916-0e2f07df0d03",
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
                Description = "Teams battle each other and waves of robots.",
                ImageName = "LaserTag",
                Name = "LaserTag",
                RRO = true,
                RoomId = 117,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "239e676c-f12f-489f-bf3a-d4c383d692c3",
                        DataBlob = "",
                        Name = "Hangar"
                    },
                    new SceneBase()
                    {
                        SceneId = 2,
                        UnitySceneId = "9d6456ce-6264-48b4-808d-2d96b3d91038",
                        DataBlob = "",
                        Name = "CyberJunkCity"
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
                Description = "Squads of three battle it out on Frontier Island. Last squad standing wins!",
                ImageName = "RecRoyaleSquads",
                Name = "RecRoyaleSquads",
                RRO = true,
                RoomId = 118,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "253fa009-6e65-4c90-91a1-7137a56a267f",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = false,
                AllowScreenMode = false,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "Squads of three battle it out on Frontier Island. Last squad standing wins!",
                ImageName = "RecRoyaleVR",
                Name = "RecRoyaleVR",
                RRO = true,
                RoomId = 119,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "253fa009-6e65-4c90-91a1-7137a56a267f",
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
                Description = "Battle it out on Frontier Island. Last person standing wins!",
                ImageName = "RecRoyaleSolos",
                Name = "RecRoyaleSolos",
                RRO = true,
                RoomId = 120,
                Tags = "",
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "b010171f-4875-4e89-baba-61e878cd41e1",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = true,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "A low-key lounge to chill with your friends. Great for private parties!",
                ImageName = "Lounge",
                Name = "Lounge",
                RRO = true,
                RoomId = 120,
                Tags = "#base," + TagType.AGOnly,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = true,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "A theater for plays, music, comedy and other performances.",
                ImageName = "PerformanceHall",
                Name = "PerformanceHall",
                RRO = true,
                RoomId = 121,
                Tags = "#base," + TagType.AGOnly,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "9932f88f-3929-43a0-a012-a40b5128e346",
                        DataBlob = "",
                        Name = "Home"
                    }
                },
            });

            AllRooms.Add(new RoomBase()
            {
                Sandbox = true,
                AllowScreenMode = true,
                Accessibility = Accessibility.Public,
                CreationTime = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                MinSupportedDate = DateTime.MinValue.AddYears(2017).AddMonths(7).AddDays(26),
                CreatorPlayerId = 1,
                Description = "A sprawling park with amphitheater, play fields, and a cave.",
                ImageName = "Park",
                Name = "Park",
                RRO = true,
                RoomId = 122,
                Tags = "#base," + TagType.AGOnly,
                Scenes = new List<SceneBase>()
                {
                    new SceneBase()
                    {
                        SceneId = 1,
                        UnitySceneId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
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
                AllRooms.ForEach(A =>
                {
                    if (A.RRO && !A.Tags.Contains("#recroomoriginal,2"))
                    {
                        A.Tags += " #recroomoriginal," + (int)TagType.AGOnly;
                    }
                    else if (A.RRO == false && !A.Tags.Contains("#community,1"))
                    {
                        A.Tags += " #community," + (int)TagType.Auto;
                    }
                });
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
                AllRooms.ForEach(A =>
                {
                    if (A.RRO && !A.Tags.Contains("#recroomoriginal,2"))
                    {
                        A.Tags += " #recroomoriginal," + (int)TagType.AGOnly;
                    }
                    else if (A.RRO == false && !A.Tags.Contains("#community,1"))
                    {
                        A.Tags += " #community," + (int)TagType.Auto;
                    }
                });
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
