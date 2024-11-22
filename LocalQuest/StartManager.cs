using QuerryNetworking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    public static class StartManager
    {
        // the current game version
        public static string? GameVersion;
        public static void Request(string? URL, Api ServerLocation, int StatusCode)
        {
            // of there's no url (should be impossible)
            if(string.IsNullOrEmpty(URL))
            {
                // warn
                Log.Warn("No URL");
                return;
            }
            // if url isn't versioncheck
            if(!URL.Contains("versioncheck"))
            {
                // return
                return;
            }
            // get game version from query string 
            GameVersion = URL.Split("?")[1].Replace("v=", "").Replace("_EA", "");
            // log game version
            Log.Info("Game version: " + GameVersion);
            // set game version
            Config.SetString("LastGameVersion", GameVersion);
            // remove request event
            ServerLocation.OnRequest -= Request;
            // remove restart event
            ServerLocation.OnRequest -= CheckRestart;
            // stop the server (should be BuildDetection)
            ServerLocation.Stop();
            // once the BuildDetection server stops, the main server is started back in Program.cs
        }

        // runs when BuildDetection NOT VersionCheck
        public static void CheckRestart(string? URL, Api ServerLocation, int StatusCode)
        {
            // if BuildDetection DOES have this request
            if(StatusCode != 404)
            {
                // don't start previous version
                return;
            }
            // set game version to the previous one
            GameVersion = Config.GetString("LastGameVersion");
            //remove the request event
            ServerLocation.OnRequest -= Request;
            // remove the check restart event
            ServerLocation.OnRequest -= CheckRestart;
            // stop the current server, should be BuildDetection
            ServerLocation.Stop();
            // once the BuildDetection server stops, the main server is started back in Program.cs
        }

        // starts the selected build
        public static void StartSelected()
        {
            // of there's no game version
            if(GameVersion == null)
            {
                // just log nothing selected
                Log.Warn("no game version selected!");
                return;
            }

            // get port override
            string? PortOverride = Config.GetString("ServerPort");
            if (string.IsNullOrEmpty(PortOverride))
            {
                // set to default if there's no port override
                PortOverride = "16512";
            }

            // 2017 RebornRec
            if (GameVersion.Contains("2017") && Config.GetBool("ReCompat"))
            {
                Api GameServer = new Api("http://localhost:2056/");
                Console.Title = "LocalQuest - mid 2018";
                GameServer.Listener.Prefixes.Add("http://localhost:2057/");
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.Mid2018" }, "LocalQuest - ReCompat 2017! server is online [|X3]", "Mid2018");
                return;
            }

            // get the version as integer 🙀
            int VerInt = int.Parse(GameVersion);

            if(VerInt >= 20200403)
            {
                Api GameServer = new Api("http://localhost:" + PortOverride + "/");
                Console.Title = "LocalQuest - late 2019+";
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.Late2018", "LocalQuest.Controllers.ServiceControllers" }, "LocalQuest - late 2019+! server is online [|X3]", "Late2019+");
            }
            if(VerInt >= 20181108)
            {
                Api GameServer = new Api("http://localhost:" + PortOverride + "/");
                Console.Title = "LocalQuest - late 2018";
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.Late2018" }, "LocalQuest - late 2018! server is online [|X3]", "Late2018");
            }
            else if(VerInt >= 20180827)
            {
                Api GameServer = new Api("http://localhost:" + PortOverride + "/");
                Console.Title = "LocalQuest - mid late 2018";
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.MidLate2018" }, "LocalQuest - mid late 2018! server is online [|X3]", "MidLate2018");
            }
            else
            {
                Api GameServer = new Api("http://localhost:" + PortOverride + "/");
                Console.Title = "LocalQuest - mid 2018";
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.Mid2018" }, "LocalQuest - mid 2018! server is online [|X3]", "Mid2018");
            }
        }
    }
}
