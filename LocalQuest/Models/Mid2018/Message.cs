using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Message
    {
        public long Id { get; set; }
        public long FromPlayerId { get; set; }
        public DateTime SentTime { get; set; }
        public MessageType Type { get; set; }
        public string? Data { get; set; }
        public long? RoomId { get; set; }
    }

    public enum MessageType
    {
        GameInvite,
        GameInviteDeclined,
        GameJoinFailed,
        PartyActivitySwitch,
        FriendInvite,
        VoteToKick,
        RequestGameInvite = 10,
        RequestGameInviteDeclined,
        FriendStatusOnline = 20,
        TextMessage = 30,
        FriendRequestAccepted = 40,
        PlayerCheer = 50,
        PlayerCheerAnonymous,
        RoomCoOwnerAdded = 60,
        RoomCoOwnerRemoved,
        CreatorPublishedNewRoom = 70,
        CoachMessage = 100
    }
}
