using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class CreateModifyRoomResponse
    {
        public CreateRoomResult Result { get; set; }
        public FullRoom? Room { get; set; }
    }

    public enum CreateRoomResult
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
        RoomUnderModerationReview = 100,
        PlayerHasRoomUnderModerationReview,
        AccessibilityUnderModerationLock,
        JuniorStatusFail = 200
    }
}
