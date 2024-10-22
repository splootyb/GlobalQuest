using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class GroupMembership
    {
        public long GroupId { get; set; } = 1;
        // rr use int challenge 🚨 (they won)
        public int PlayerId { get; set; } = int.Parse(LocalQuest.Config.GetString("AccountId"));
        public GroupPermissions Permissions { get; set; } = GroupPermissions.Creator;
    }

    [Flags]
    public enum GroupPermissions
    {
        None = 0,
        Creator = 1,
        GroupDelete = 2,
        GroupModify = 4,
        MemberInvite = 8,
        MemberRemoval = 16,
        ModeratorAssign = 32,
        ModeratorRemove = 64,
        Pending = 128,
        Member = 0,
        Moderator = 24,
        CoOwner = 124,
        Owner = 127
    }
}
