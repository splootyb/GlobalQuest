using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class FullRoom : Room
    {
        public FullRoom(RoomBase Data)
        {
            if(Data.Scenes.Count() == 0)
            {
                Log.Warn("Room has no scenes!");
                Name = "InvalidRoom";
                ActivityLevelId = "";
                return;
            }
            DataBlobName = Data.Scenes[0].DataBlob;
            if(string.IsNullOrEmpty(Data.Name))
            {
                Data.Name = "RoomWithNoName" + new Random().Next();
            }
            Name = Data.Name;
            ActivityLevelId = Data.Scenes[0].UnitySceneId;
            if (string.IsNullOrEmpty(Data.ImageName))
            {
                // Data.ImageName = "DefaultPFP";
            }
            ImageName = Data.ImageName;
            CreatorPlayerId = Data.CreatorPlayerId;
            Description = Data.Description;
            RoomId = Data.RoomId;
            IsSandbox = Data.Sandbox;
            if(Data.CreationTime != null)
            {
                CreatedAt = (DateTime)Data.CreationTime;
            }

            if(Data.AllowScreenMode != null && Data.AllowScreenMode == true)
            {
                ScreenModeSupport = ScreenSupport.Mixed;
            }

            if(Data.Accessibility != null)
            {
                Accessibility = (Accessibility)Data.Accessibility;
            }
        }
        public string? DataBlobName { get; set; }
        public int MaxPlayers { get; set; } = 12;
        public bool AccessibilityLocked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime ModifiedAt { get; set; } = DateTime.MinValue;
        public DateTime StateModifiedAt { get; set; } = DateTime.MinValue;
        public DateTime DataModifiedAt { get; set; } = DateTime.MinValue;
        public DateTime LastVisitedAt { get; set; } = DateTime.MinValue;
        public int VisitorCount { get; set; }
        public int VisitCount { get; set; }
        public int CheerCount { get; set; }
        public int ReportCount { get; set; }
        public List<int> CoOwners { get; set; } = new List<int>();
        public List<int> Hosts { get; set; } = new List<int>();
    }
}
