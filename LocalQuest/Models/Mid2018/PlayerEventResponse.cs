using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class PlayerEventResponse
    {
        public long PlayerEventResponseId { get; set; }
        public long PlayerEventId { get; set; }
        public int PlayerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public PlayerEventResponseType Type { get; set; }
    }

    public enum PlayerEventResponseType
    {
        Yes,
        Maybe,
        No
    }
}
