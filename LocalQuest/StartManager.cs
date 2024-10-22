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
        public static string? GameVersion;
        public static void Request(string? URL, Api ServerLocation, int StatusCode)
        {
            if(string.IsNullOrEmpty(URL))
            {
                Log.Warn("No URL");
                return;
            }
            if(!URL.Contains("versioncheck"))
            {
                return;
            }
            GameVersion = URL.Split("?")[1].Replace("?v=", "").Replace("_EA", "");
            Config.SetString("LastGameVersion", GameVersion);
            ServerLocation.OnRequest -= Request;
            ServerLocation.OnRequest -= CheckRestart;
            ServerLocation.Stop();
        }

        public static void CheckRestart(string? URL, Api ServerLocation, int StatusCode)
        {
            if(StatusCode != 404)
            {
                return;
            }
            GameVersion = Config.GetString("LastGameVersion");
            ServerLocation.OnRequest -= Request;
            ServerLocation.OnRequest -= CheckRestart;
            ServerLocation.Stop();
        }

        public static void StartSelected()
        {
            if(GameVersion == null)
            {
                Log.Warn("no game version selected!");
                return;
            }

            string? PortOverride = Config.GetString("ServerPort");
            if (string.IsNullOrEmpty(PortOverride))
            {
                PortOverride = "16512";
            }

            if (GameVersion.Contains("2017") && Config.GetBool("ReCompat"))
            {
                Api GameServer = new Api("http://localhost:2056/");
                Console.Title = "LocalQuest - mid 2018";
                GameServer.Listener.Prefixes.Add("http://localhost:2057/");
                GameServer.StartServer(new string[] { "LocalQuest.Controllers.Mid2018" }, "LocalQuest - ReCompat 2017! server is online [|X3]", "Mid2018");
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
