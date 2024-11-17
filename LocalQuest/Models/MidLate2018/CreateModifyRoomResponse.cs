using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class CreateModifyRoomResponse
    {
        public LateRoomResult Result { get; set; }
        public RoomDetails? RoomDetails { get; set; }
    }

    public enum LateRoomResult
    {
        Success,
        Unknown,
        PermissionDenied,
        RoomNotActive,
        RoomDoesNotExist,
        RoomHasNoDataBlob,
        DuplicateName = 10,
        ReservedName,
        InappropriateName,
        InappropriateDescription,
        TooManyRooms = 20,
        InvalidMaxPlayers = 30,
        DataHistoryDoesNotExist = 40,
        DataHistoryAlreadyActive,
        InvalidTags = 50,
        NoStartingRoomScene = 55,
        RoomUnderModerationReview = 100,
        PlayerHasRoomUnderModerationReview,
        AccessibilityUnderModerationLock,
        JuniorStatusFail = 200
    }

}
