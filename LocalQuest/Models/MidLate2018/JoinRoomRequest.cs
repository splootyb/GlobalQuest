using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class JoinRoomRequest
    {
        public List<long> ExpectedPlayerIds { get; set; } = new List<long>();
        // region pings
        public string? RoomName { get; set; }
        public string? SceneName { get; set; }
        public bool Private { get; set; }
        // additional join mode
    }
}
