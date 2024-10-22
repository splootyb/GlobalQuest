using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Notification
    {
        public NotificationType Id { get; set; }
        public object? Msg { get; set; }
    }

    public enum NotificationType
    {
        RelationshipChanged = 1,
        MessageReceived,
        MessageDeleted,
        PresenceHeartbeatResponse,
        SubscriptionListUpdated = 9,
        SubscriptionUpdateProfile = 11,
        SubscriptionUpdatePresence,
        SubscriptionUpdateGameSession,
        SubscriptionUpdateRoom,
        ModerationQuitGame = 20,
        ModerationUpdateRequired,
        ModerationKick,
        ModerationKickAttemptFailed,
        GiftPackageReceived = 30,
        ProfileJuniorStatusUpdate = 40,
        RelationshipsInvalid = 50,
        StorefrontBalanceAdd = 60,
        ConsumableMappingAdded = 70,
        ConsumableMappingRemoved,
        PlayerEventCreated = 80,
        PlayerEventUpdated,
        PlayerEventDeleted,
        PlayerEventResponseChanged,
        PlayerEventResponseDeleted,
        ChatMessageReceived = 90
    }
}
