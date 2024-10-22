using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class GameSession
    {
        public long GameSessionId { get; set; }
        public string RegionId { get; set; } = "us";
        public string RoomId { get; set; } = "";
        public long? EventId { get; set; }
        public long? RecRoomId { get; set; }
        public long? CreatorPlayerId { get; set; }
        public string? ActivityLevelId { get; set; }
        public bool Private { get; set; }
        public bool Sandbox { get; set; }
        public bool SupportsVR { get; set; }
        public bool SupportsScreens { get; set; }
        public bool GameInProgress { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsFull { get; set; }
    }
}
