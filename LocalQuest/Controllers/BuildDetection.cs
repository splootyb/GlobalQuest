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

        [Get("/api/versioncheck/v3")]
        public VersionResponse CheckVersion()
        {
            if(Server != null)
                Server.OnRequest += StartManager.Request;
            return new VersionResponse();
        }
    }
}
