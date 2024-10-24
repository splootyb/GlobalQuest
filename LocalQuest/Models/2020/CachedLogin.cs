using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models._2020
{
    public class CachedLogin
    {
        // NOT the updated platform enum, will fix later
        public Platform platform { get; set; }
        public string platformId { get; set; } = "Not needed :silly:";
        public long accountId { get; set; } = long.Parse(Config.GetString("AccountId"));
        public DateTime lastLoginTime { get; set; }
    }
}
