using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Group
    {
        public long GroupId { get; set; } = 1;
        public string Name { get; set; } = LocalQuest.Config.GetString("CurrentGroup");
        public string Description { get; set; } = "grouping?!";
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public string ImageName { get; set; } = "DefaultPFP";
        public GroupBan BanStatus { get; set; } = GroupBan.GoodStanding;
        public int CreatorId { get; set; } = int.Parse(LocalQuest.Config.GetString("AccountId"));
        public int NumMembers { get; set; } = 1;
        public List<GroupMembership> Members { get; set; } = new List<GroupMembership>()
        {
            new GroupMembership()
        };
    }

    public enum GroupBan
    {
        GoodStanding,
        InReview,
        TempLock,
        Permaban
    }
}
