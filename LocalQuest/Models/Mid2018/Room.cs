using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Room
    {
        public long RoomId { get; set; } = new Random().Next();
        public string Name { get; set; } = "InvalidName";
        public string? Description { get; set; }
        // rec room challenge use long when they should
        public int CreatorPlayerId { get; set; }
        public string? ImageName { get; set; }
        public string ActivityLevelId { get; set; } = "InvalidRoom";
        public RoomState State { get; set; }
        public Accessibility Accessibility { get; set; }
        public bool IsSandbox { get; set; }
        public bool Instanced { get; set; } = true;
        public ScreenSupport ScreenModeSupport { get; set; }
    }

    public enum ScreenSupport
    {
        Isolated,
        Mixed,
        Blocked
    }

    public enum Accessibility
    {
        Private,
        Public,
        Unlisted
    }

    public enum RoomState
    {
        Active,
        PendingJunior = 11,
        Moderation_PendingReview = 100,
        Moderation_Closed,
        MarkedForDelete = 1000
    }
}
