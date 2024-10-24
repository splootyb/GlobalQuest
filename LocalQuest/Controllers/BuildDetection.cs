using LocalQuest.Models.Mid2018;
using QuerryNetworking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Controllers.BuildDetection
{
    public class BuildDetection : ClientRequest
    {
        [Get("/")]
        public Nameserver GetNameserver()
        {
            string? PortOverride = Config.GetString("ServerPort");
            if (string.IsNullOrEmpty(PortOverride))
            {
                PortOverride = "16512";
            }

            return new Nameserver()
            {
                API = "http://localhost:" + PortOverride + "/",
                Auth = "http://localhost:" + PortOverride + "/",
                Images = "http://localhost:" + PortOverride + "/img/",
                Notifications = "ws://localhost:" + PortOverride + "/",
                Commerce = "http://localhost:" + PortOverride + "/",
                WWW = "http://localhost:" + PortOverride + "/"
            };
        }

        [Get("/2")]
        public Nameserver GetNameserver2()
        {
            string? PortOverride = Config.GetString("ServerPort");
            if (string.IsNullOrEmpty(PortOverride))
            {
                PortOverride = "16512";
            }

            return new Nameserver()
            {
                API = "http://localhost:" + PortOverride + "/",
                Auth = "http://localhost:" + PortOverride + "/",
                Images = "http://localhost:" + PortOverride + "/img/",
                Notifications = "http://localhost:" + PortOverride + "/",
                Commerce = "http://localhost:" + PortOverride + "/",
                Accounts = "http://localhost:" + PortOverride + "/",
                CDN = "http://localhost:" + PortOverride + "/",
                Storage = "http://localhost:" + PortOverride + "/",
                Matchmaking = "http://localhost:" + PortOverride + "/",
                Leaderboard = "http://localhost:" + PortOverride + "/",
                Link = "http://localhost:" + PortOverride + "/",
                RoomComments = "http://localhost:" + PortOverride + "/",
                Chat = "http://localhost:" + PortOverride + "/",
                Clubs = "http://localhost:" + PortOverride + "/",
                Rooms = "http://localhost:" + PortOverride + "/roomserver",
                WWW = "http://localhost:" + PortOverride + "/"
            };
        }

        [Get("/api/versioncheck/v3")]
        public VersionResponse CheckVersion()
        {
            if(Server != null)
                Server.OnRequest += StartManager.Request;
            return new VersionResponse();
        }
    }
}
