using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class FeaturedRoomGroup
    {
        public string Name { get; set; } = "New rooms!";
        public List<FeaturedRoom> FeaturedRooms { get; set; } = new List<FeaturedRoom>();
    }

    public class FeaturedRoom
    {
        public string RoomName { get; set; } = "Invalid Room";
        public long RoomId { get; set; }
        public string ImageName { get; set; } = "DefaultPFP";
    }
}
