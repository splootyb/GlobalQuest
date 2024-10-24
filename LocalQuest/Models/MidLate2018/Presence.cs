using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class Presence
    {
        public long PlayerId { get; set; }
        public bool IsOnline { get; set; }
        public PlayerType PlayerType { get; set; }
        public PlayerStatusVisibility StatusVisibility { get; set; } 
        public GameSession? GameSession { get; set; }
    }

    public enum PlayerStatusVisibility
    {
        Public,
        FriendsOnly,
        FavoriteFriendsOnly,
        Offline
    }

    public enum PlayerType
    {
        UNINITIALIZED,
        VR_WALK,
        VR_TELEPORT,
        SCREEN
    }
}
