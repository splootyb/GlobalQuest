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
            GameVersion = URL.Split("?")[1].Replace("v=", "").Replace("_EA", "");
            Log.Info("Game version: " + GameVersion);
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
                return;
            }

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
