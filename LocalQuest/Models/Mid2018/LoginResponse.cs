using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class LoginResponse
    {
        public string? Error { get; set; }
        public Profile Player { get; set; } = new Profile();
        public string Token { get; set; } = "haha localhost :rotating_light:";
        public bool FirstLoginOfTheDay { get; set; }
        public long AnalyticsSessionId { get; set; }
        public bool CanUseScreenMode { get; set; } = true;
    }
}
