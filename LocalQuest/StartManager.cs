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
    }
}
