using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class PlayerEvent
    {
        public long PlayerEventId { get; set; }
        public string Name { get; set; } = "Placeholder Event Name?!";
        public string Description { get; set; } = "Event description!!";
        public DateTime StartTime { get; set; }
        // rec room try not to use ints when they should use longs challenge
        public int CreatorPlayerId { get; set; }
        public int AttendeeCount { get; set; }
        public long RoomId { get; set; }
    }
}
