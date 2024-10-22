using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class JoinRoomRequest
    {
        public long RoomId { get; set; }
        public bool Private { get; set; }
        public long[] ExpectedPlayerIds { get; set; } = new long[0];
        // region pings
    }
}
