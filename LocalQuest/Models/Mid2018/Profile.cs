using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Profile
    {
        public Profile()
        {
            string Group = LocalQuest.Config.GetString("CurrentGroup");
            if(!string.IsNullOrEmpty(Group))
            {
                GroupMemberships.Add(new GroupMembership());
            }
            int? CustomLevel = LocalQuest.Config.GetInt("Level");
            if(CustomLevel != null)
            {
                Level = (int)CustomLevel;
            }
        }
        // id can't ACTUALLY be larger than int32 in this build for some apis to work loll (such as CHATS)
        public long Id { get; set; } = long.Parse(LocalQuest.Config.GetString("AccountId"));
        public string Username { get; set; } = LocalQuest.Config.GetString("Username");
        public string DisplayName { get; set; } = LocalQuest.Config.GetString("DisplayName");
        public string Bio { get; set; } = LocalQuest.Config.GetString("Bio");
        public int XP { get; set; }
        public int Level { get; set; } = 1;
        public RegistrationStatus RegistrationStatus { get; set; } = RegistrationStatus.Registered;
        public bool Developer { get; set; } = true;
        public bool CanReceiveInvites { get; set; } = false;
        public string ProfileImageName { get; set; } = LocalQuest.Config.GetString("PFP");
        public bool JuniorProfile { get; set; } = false;
        public bool ForceJuniorImages { get; set; } = false;
        public bool PendingJunior { get; set; } = false;
        public bool HasBirthday { get; set; } = true;
        public bool AvoidJuniors { get; set; } = false;
        public Reputation PlayerReputation { get; set; } = new Reputation();
        public List<PlayerPlatform> PlatformIds { get; set; } = new List<PlayerPlatform>();
        public List<GroupMembership> GroupMemberships { get; set; } = new List<GroupMembership>();
    }

    public enum RegistrationStatus
    {
        Unregistered,
        PendingEmailVerification,
        Registered
    }
}
