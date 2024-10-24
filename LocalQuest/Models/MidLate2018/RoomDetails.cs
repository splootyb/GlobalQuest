using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class RoomDetails
    {
        public RoomDetails(RoomBase Base) 
        {
            if(string.IsNullOrEmpty(Base.Name))
            {
                Log.Warn("Room base has no name?!");
                Base.Name = "UnknownName" + new Random().Next();
            }
            Room.Name = Base.Name;

            if(string.IsNullOrEmpty(Base.Description))
            {
                Base.Description = "";
            }

            Room.Description = Base.Description;

            if(string.IsNullOrEmpty(Base.ImageName))
            {
                Base.ImageName = "DefaultPFP";
            }

            Room.ImageName = Base.ImageName;
            Room.CreatorPlayerId = Base.CreatorPlayerId;

            Room.RoomId = Base.RoomId;

            int S = 0;
            foreach (var Scene in Base.Scenes)
            {
                if(string.IsNullOrEmpty(Scene.Name))
                {
                    Scene.Name = "UnknownSceneName[|X3]" + new Random().Next(0, 999);
                }
                if(string.IsNullOrEmpty(Scene.DataBlob))
                {
                    Scene.DataBlob = "";
                }
                Scenes.Add(new RoomScene()
                {
                    IsSandbox = Base.Sandbox,
                    RoomSceneId = Scene.SceneId,
                    RoomSceneLocationId = Scene.UnitySceneId,
                    Name = Scene.Name,
                    RoomId = Base.RoomId,
                    CanMatchmakeInto = true,
                    DataBlobName = Scene.DataBlob,
                });
                S++;
            }

            Room.SupportsScreens = true;
            Room.SupportsWalkVR = true;
            Room.SupportsTeleportVR = true;

            if(Base.Accessibility != null)
            {
                Room.Accessibility = (Accessibility)Base.Accessibility;
            }
        }
        public Room Room { get; set; } = new Room();
        public List<RoomScene> Scenes { get; set; } = new List<RoomScene>();
        public List<int> CoOwners { get; set; } = new List<int>();
        public List<int> Hosts { get; set; } = new List<int>();
        public List<int> InvitedCoOwners { get; set; } = new List<int>();
        public List<int> InvitedHosts { get; set; } = new List<int>();
        public List<SearchTag> Tags { get; set; } = new List<SearchTag>();
        public int CheerCount { get; set; }
        public int FavoriteCount { get; set; }
        public int VisitCount { get; set; }
    }

    public class Room
    {
        public long RoomId { get; set; }
        public string Name { get; set; } = "EqName";
        public string Description { get; set; } = "EqDesc";
        // I'm done commenting about this 😿
        public int CreatorPlayerId { get; set; } = 1;
        public string ImageName { get; set; } = "DefaultPFP";
        public RoomState State { get; set; } = RoomState.Active;
        public Models.Mid2018.Accessibility Accessibility { get; set; }
        public bool SupportsLevelVoting { get; set; }
        public int CheerCount { get; set; }
        public int FavoriteCount { get; set; }
        public bool IsAGRoom { get; set; }
        public bool IsDormRoom { get; set; }
        public bool CloningAllowed { get; set; }
        public bool SupportsScreens { get; set; }
        public bool SupportsWalkVR { get; set; }
        public bool SupportsTeleportVR { get; set; }
        public bool AllowsJuniors { get; set; }
        public bool DisableMicAutoMute { get; set; }
        public RoomPersonalDetails? PersonalDetails { get; set; } = null;
    }

    public enum RoomState
    {
        Active,
        PendingJunior = 11,
        Moderation_PendingReview = 100,
        Moderation_Closed,
        MarkedForDelete = 1000
    }

    public class RoomScene
    {
        public long RoomSceneId { get; set; }
        public long RoomId { get; set; }
        public string RoomSceneLocationId { get; set; } = "";
        public string Name { get; set; } = "Home";
        public bool IsSandbox { get; set; }
        public string DataBlobName { get; set; } = "";
        public int MaxPlayers { get; set; }
        public bool CanMatchmakeInto { get; set; }
        public DateTime DataModifiedAt { get; set; }
    }
}
