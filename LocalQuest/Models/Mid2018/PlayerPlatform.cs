using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class PlayerPlatform
    {
        public Platform Platform { get; set; }
        public string? PlatformId { get; set; }
    }

    public enum Platform
    {
        STEAM,
        OCULUS,
        PS4,
        MICROSOFT
    }
}
