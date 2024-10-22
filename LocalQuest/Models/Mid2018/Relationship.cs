using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Relationship
    {
        public long PlayerID { get; set; }
        public RelationshipStatus RelationshipType { get; set; }
        public ReciprocalStatus Muted { get; set; }
        public ReciprocalStatus Ignored { get; set; }
        public ReciprocalStatus Favorited { get; set; }
    }

    public enum RelationshipStatus
    {
        None,
        FriendRequestSent,
        FriendRequestReceived,
        Friend
    }

    public enum ReciprocalStatus
    {
        None,
        Local,
        Remote,
        Mutual
    }
}
