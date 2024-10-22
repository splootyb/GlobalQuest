using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class JoinSessionRequest
    {
        public string[] ActivityLevelIds { get; set; } = new string[0];
        public long[] ExpectedPlayerIds { get; set; } = new long[0];
        // region pings too
    }

    public class CreateSessionRequest
    {
        public string ActivityLevelId { get; set; } = "";
        public bool IsSandbox { get; set; }
        public long[] ExpectedPlayerIds { get; set; } = new long[0];
        // region pings too
    }
}
