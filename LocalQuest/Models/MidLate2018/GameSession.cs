using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class GameSession
    {
        public long GameSessionId { get; set; }
        public string PhotonRegionId { get; set; } = "us";
        public string PhotonRoomId { get; set; } = "";
        public string Name { get; set; } = "^LocalQuestSessionName";
        public long RoomId { get; set; }
        public long RoomSceneId { get; set; }
        public string RoomSceneLocationId { get; set; } = "";
        public bool IsSandbox { get; set; }
        public string DataBlobName { get; set; } = "";
        public long? EventId { get; set; } = null;
        public bool Private { get; set; }
        public bool GameInProgress { get; set; }
        public int MaxCapacity { get; set; } = 12;
        public bool IsFull { get; set; }
    }
}
