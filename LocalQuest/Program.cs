using LocalQuest.Models.Mid2018;
using QuerryNetworking.Core;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace LocalQuest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Log.LogLevel = LogLevel.Debug;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "LocalQuest";
            Console.CursorVisible = false;
            Config.Setup();
            FileManager.Setup();
            Setup.Defaults();
            RoomManager.DownloadRooms().Wait();
            AvatarManager.SetupAvatarItems().Wait();
            if (Config.GetBool("NetworkDebug"))
            {
                QuerryNetworking.Logging.Log.LogLevel = QuerryNetworking.Logging.LogLevel.Debug;
            }
            else
            {
                QuerryNetworking.Logging.Log.LogLevel = QuerryNetworking.Logging.LogLevel.Info;
            }
            if(string.IsNullOrEmpty(Config.GetString("AutoDetect")))
            {
                Config.SetBool("AutoDetect", true);
            }
            if(!Config.Exists("PrivateDorm"))
            {
                Config.SetBool("PrivateDorm", true);
            }
            if (!Config.Exists("Level"))
            {
                Config.SetInt("Level", 1);
            }

            if (!Config.GetBool("FirstRun"))
            {
                Setup.Tutorial();
                Console.Clear();
            }
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - EpicQuest but localhost?! YEAH");

            string BetaString = "";
            if(Setup.Beta)
            {
                BetaString = " [BETA]";
            }

            Console.WriteLine("Server Version: " + Setup.Version + BetaString);

            UiTools.ShowBanner("Welcome, " + Config.GetString("DisplayName"));
            Console.ForegroundColor = ConsoleColor.White;

            List<string> Options = new List<string>()
            {
                "Start server",
                "Modify profile",
                "Settings",
            };

            Random R = new Random();
            if(R.Next(0,500) == 1)
            {
                Options.Add("What's mew :3");
            }
            else
            {
                Options.Add("What's new");
            }

            Options.Add("Join the discord");

            string Selection = UiTools.WriteControls(Options);

            switch (Selection)
            {
                case "Start server":
                    BuildChoice();
                    return;

                case "Settings":
                    Settings();
                    return;

                case "Modify profile":
                    ProfileSettings();
                    return;

                case "What's new":
                    WhatNew();
                    return;

                case "What's mew :3":
                    WhatNew();
                    return;

                case "Join the discord":
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    { 
                        FileName = "https://discord.gg/epicquest",
                        UseShellExecute = true
                    });
                    Main(new string[0]);
                    return;
            }
        }

        static void Settings()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - Settings");

            List<string> Controls = new List<string>()
            {
                "Go back",
                "Skip tutorial",
                "Manage data",
                "Private rooms",
                "Auto-Detect game version [currently: " + Config.GetBool("AutoDetect") + "]",
                "Use OpenRec/RebornRec style ui nav [currently: " + Config.GetBool("ReControl") + "]",
                "Log QuerryNetworking debug [currently: " + Config.GetBool("NetworkDebug") + "]",
            };

            bool ReCompat = Config.GetBool("ReCompat");
            if(!ReCompat)
            {
                Controls.Add("Server port override [currently: " + SettingStringValue("ServerPort") + "]");
                Controls.Add("RebornRec compatibility mode [currently: " + Config.GetBool("ReCompat") + "]");
            }
            else
            {
                Controls.Add("RebornRec compatibility mode [currently: " + Config.GetBool("ReCompat") + "]");
            }

            string Selection = UiTools.WriteControls(Controls);

            switch (Selection)
            {
                case "Go back":
                    Main(new string[0]);
                    return;

                case "Skip tutorial":
                    LocalQuest.Settings.SetSetting("Recroom.OOBE", "100");
                    Console.Clear();
                    UiTools.WriteTitle();
                    UiTools.ShowBanner("Complete!");
                    Console.WriteLine("Press any key to go back...");
                    Console.ReadKey();
                    Settings();
                    break;

                case "Private rooms":
                    PrivateRoomSettings();
                    break;

                case "Manage data":
                    SaveSettings();
                    break;

                case string S when S == ("Log QuerryNetworking debug [currently: " + Config.GetBool("NetworkDebug") + "]"):
                    Config.SetBool("NetworkDebug", !Config.GetBool("NetworkDebug"));
                    Settings();
                    break;
                
                case string S when S == ("Auto-Detect game version [currently: " + Config.GetBool("AutoDetect") + "]"):
                    Config.SetBool("AutoDetect", !Config.GetBool("AutoDetect"));
                    Settings();
                    break;

                case string S when S == ("Allow OpenRec/RebornRec style ui nav [currently: " + Config.GetBool("ReControl") + "]"):
                    Config.SetBool("ReControl", !Config.GetBool("ReControl"));
                    Settings();
                    break;

                case string S when S == ("Server port override [currently: " + SettingStringValue("ServerPort") + "]"):
                    ChangeStringSetting("ServerPort");
                    Settings();
                    break;

                case string S when S == ("RebornRec compatibility mode [currently: " + Config.GetBool("ReCompat") + "]"):
                    Config.SetBool("ReCompat", !Config.GetBool("ReCompat"));
                    if (Config.GetBool("ReCompat"))
                    {
                        Config.SetString("ServerPort", "2059");
                    }
                    else
                    {
                        Config.SetString("ServerPort", "");
                    }
                    Settings();
                    break;
                
                default:
                    Settings();
                    break;
            }
        }

        static void PrivateRoomSettings()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Settings - Private Rooms");

            List<string> Options = new List<string>()
            {
                "Go back",
                "Private Code [currently: " + SettingStringValue("PrivateCode") + "]",
                "Private DormRoom [currently: " + Config.GetBool("PrivateDorm") + "]"
            };
            string Selection = UiTools.WriteControls(Options);
            switch(Selection)
            {
                case "Go back":
                    Settings();
                    break;
                case string S when S == ("Private Code [currently: " + SettingStringValue("PrivateCode") + "]"):
                    ChangeStringSetting("PrivateCode");
                    PrivateRoomSettings();
                    break;
                case string S when S == ("Private DormRoom [currently: " + Config.GetBool("PrivateDorm") + "]"):
                    Config.SetBool("PrivateDorm", !Config.GetBool("PrivateDorm"));
                    PrivateRoomSettings();
                    break;
            }
        }

        static void ProfileSettings()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Settings - Profile");

            string Selection = UiTools.WriteControls(new List<string>()
            {
                "Go back",
                "Import from modern",
                "Reset your profile picture [currently: " + SettingStringValue("PFP") + "]",
                "Change Username [Currently: @" + Config.GetString("Username") + "]",
                "Change DisplayName [Currently: " + Config.GetString("DisplayName") + "]",
                "Change Level [Currently: " + Config.GetInt("Level") + "]",
                "Change your group [currently: " + SettingStringValue("CurrentGroup") + "]"
            });

            switch (Selection)
            {
                case "Go back":
                    Main(new string[0]);
                    break;
                case "Import from modern":
                    Setup.ImportModernProfile();
                    ProfileSettings();
                    break;
                case string S when S == ("Reset your profile picture [currently: " + SettingStringValue("PFP") + "]"):
                    Config.SetString("PFP", "DefaultPFP");
                    ProfileSettings();
                    break;
                case string S when S == "Change Username [Currently: @" + Config.GetString("Username") + "]":
                    ChangeStringSetting("Username");
                    ProfileSettings();
                    break;
                case string S when S == "Change DisplayName [Currently: " + Config.GetString("DisplayName") + "]":
                    ChangeStringSetting("DisplayName");
                    ProfileSettings();
                    break;
                case string S when S == ("Change your group [currently: " + SettingStringValue("CurrentGroup") + "]"):
                    ChangeStringSetting("CurrentGroup");
                    ProfileSettings();
                    break;
                case string S when S == ("Change Level [Currently: " + Config.GetInt("Level") + "]"):
                    ChangeIntSetting("Level");
                    ProfileSettings();
                    break;
                default:
                    ProfileSettings();
                    break;
            }
        }

        static void SaveSettings()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Settings - Data");
            List<string> Options = new List<string>()
            {
                "Go back",
                "Reset data",
                "Update data",
                "Import data from somewhere else"
            };
            string Result = UiTools.WriteControls(Options);
            switch(Result)
            {
                case "Go back":
                    Settings();
                    break;
                case "Reset data":
                    Console.Clear();
                    UiTools.WriteTitle();
                    Console.WriteLine("LocalQuest - Reset data");
                    Console.WriteLine("Are you sure?");
                    string O = UiTools.WriteControls(new List<string>() { "yes", "no" });
                    if (O == "no")
                    {
                        Settings();
                        return;
                    }

                    Console.Clear();
                    UiTools.WriteTitle();
                    Console.WriteLine("Deleting data folder...");
                    try
                    {
                        Directory.Delete(Directory.GetCurrentDirectory() + "/Data/", true);
                    }
                    catch
                    {
                        Log.Error("Failed to delete data folder!");
                    }
                    Console.WriteLine("Clearing config data...");
                    try
                    {
                        Config.Clear();
                    }
                    catch
                    {
                        Log.Error("Failed to clear config data!");
                    }

                    UiTools.ShowBanner("Done! Press [ENTER] to continue...");
                    Main(new string[0]);

                    break;
                case "Import data from somewhere else":
                    ImportChoice();
                    break;
                case "Update data":
                    List<AvatarItem> NewItems = AvatarManager.DownloadAvatarItems().Result;
                    FileManager.WriteJSON("Avatar/AvatarItems", NewItems);
                    SaveSettings();
                    break;
                default:
                    SaveSettings();
                    break;
            }
        }

        static void ImportChoice()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("Where are you importing from?");

            UiTools.ShowBanner("This WILL overwrite your existing SaveData", ConsoleColor.Yellow);

            List<string> Options = new List<string>()
            {
                "None! Go back",
                "RebornRec",
                "OpenRec"
            };

            string Select = UiTools.WriteControls(Options);

            switch(Select)
            {
                case "None! Go back":
                    SaveSettings();
                    break;
                case "RebornRec":
                    Setup.ImportData();
                    Main(new string[0]);
                    break;
                case "OpenRec":
                    Setup.ImportOpenData();
                    Main(new string[0]);
                    break;
                default:
                    ImportChoice();
                    break;
            }
        }

        public static string SettingStringValue(string Setting)
        {
            string Result = Config.GetString(Setting);
            if(string.IsNullOrEmpty(Result))
            {
                return "none";
            }
            return Result;
        }

        static void ChangeStringSetting(string Setting)
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - Change your " + Setting + "\nPlease input a value:\n");
            Console.WriteLine("Current value: " + Config.GetString(Setting));
            Console.Write("> ");
            string? Result = Console.ReadLine();
            if(!string.IsNullOrEmpty(Result))
            {
                Config.SetString(Setting, Result);
            }
            else
            {
                Config.SetString(Setting, "");
            }
        }

        static void ChangeIntSetting(string Setting)
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - Change your " + Setting + "\nPlease input an integer value:\n");
            Console.WriteLine("Current value: " + Config.GetInt(Setting));
            Console.Write("> ");
            string? Result = Console.ReadLine();
            if (!string.IsNullOrEmpty(Result) && Result.All(char.IsDigit))
            {
                Config.SetInt(Setting, int.Parse(Result));
            }
            else
            {
                Console.Clear();
                UiTools.WriteTitle();
                UiTools.ShowBanner("Must be an integer value!");
                UiTools.WriteControls(new List<string>() { "okay..." });
                ChangeIntSetting(Setting);
            }
        }

        static void BuildChoice()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - Choose a build");

            string? PortOverride = Config.GetString("ServerPort");
            if (string.IsNullOrEmpty(PortOverride))
            {
                PortOverride = "16512";
            }

            if(Config.GetBool("AutoDetect"))
            {
                Api DetectServer = new Api("http://localhost:" + PortOverride + "/");
                DetectServer.OnRequest += StartManager.CheckRestart;
                DetectServer.StartServer(new string[] { "LocalQuest.Controllers.BuildDetection" }, "Please start a build now", "BuildDetection");

                StartManager.StartSelected();

                return;
            }

            string Selection = UiTools.WriteControls(new List<string>()
            {
                "Go back",
                "mid 2018",
                "2017 (test)",
            });


            switch (Selection)
            {
                case "Go back":
                    Main(new string[0]);
                    return;
                case "mid 2018":
                    Console.Clear();
                    UiTools.WriteTitle();
                    Console.Title = "LocalQuest - mid 2018";
                    Console.WriteLine("LocalQuest - mid 2018");
                    try
                    {
                        StartManager.GameVersion = "20180716";
                        StartManager.StartSelected();
                    }
                    catch
                    {
                        StartFailure("Failed to start the server. [|X3]");
                    }
                    break;
                case "2017 (test)":
                    Console.Clear();
                    UiTools.WriteTitle();
                    Console.Title = "LocalQuest - 2017??";
                    Console.WriteLine("LocalQuest - 2017??");
                    try
                    {
                        StartManager.GameVersion = "20170716";
                        StartManager.StartSelected();
                    }
                    catch
                    {
                        StartFailure("Failed to start the server. [|X3]");
                    }
                    break;
            }
        }

        static void StartFailure(string Error)
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - startup failure");
            UiTools.ShowBanner(Error);
            Console.ForegroundColor = ConsoleColor.White;
            string Selection = UiTools.WriteControls(new List<string>()
            {
                "Go back",
            });

            switch (Selection)
            {
                case "Go back":
                    Main(new string[0]);
                    return;
            }
        }

        static void WhatNew()
        {
            Console.Clear();
            UiTools.WriteTitle();
            Console.WriteLine("LocalQuest - What's new");

            Console.WriteLine("Loading...");

            string? WhatNew = NetworkFiles.GetText("UpdateNotesV" + Setup.Version + ".txt").Result;
            Console.CursorTop -= 1;

            if (string.IsNullOrEmpty(WhatNew))
            {
                Console.WriteLine("Update notes not found!");
            }
            else
            {
                Console.WriteLine(WhatNew);
            }

            Console.WriteLine();

            string Selection = UiTools.WriteControls(new List<string>()
            {
                "Go back",
            });

            switch (Selection)
            {
                case "Go back":
                    Main(new string[0]);
                    return;
            }
        }
    }
}
