using LocalQuest.Models.MidLate2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class MatchmakeResponse
    {
        public MatchmakeResult Result { get; set; }
        public GameSession? GameSession { get; set; }
        public RoomDetails? RoomDetails { get; set; }
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
        UpdateRequired,
        AlreadyInTargetGameSession,
        NoSuchRoom = 20,
        RoomCreatorNotReady,
        RoomIsNotActive,
        RoomBlockedByCreator,
        RoomBlockingCreator,
        RoomIsPrivate,
        PlayerTypeNotSupported = 30
    }
}
