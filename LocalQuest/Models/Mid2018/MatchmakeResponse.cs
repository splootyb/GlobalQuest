using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class MatchmakeResponse
    {
        public MatchmakeResult Result { get; set; }
        public GameSession? GameSession { get; set; }
    }

    public enum MatchmakeResult
    {
        Success,
        NoSuchGame,
        PlayerNotOnline,
        InsufficientSpace,
        EventNotStarted,
        EventAlreadyFinished,
        EventCreatorNotReady,
        BlockedFromRoom,
        ProfileLocked,
        NoBirthday,
        MarkedForDelete,
        JuniorNotAllowed,
        Banned,
        AlreadyInBestGameSession,
        ScreenModeNotAllowed,
        VRModeNotAllowed,
        NoSuchRoom = 20,
        RoomCreatorNotReady,
        RoomIsNotActive,
        RoomBlockedByCreator,
        RoomBlockingCreator,
        RoomIsPrivate
    }
}
