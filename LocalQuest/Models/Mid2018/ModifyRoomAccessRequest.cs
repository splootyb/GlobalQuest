using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class ModifyRoomAccessRequest
    {
        public Accessibility Accessibility { get; set; }
        public long RoomId { get; set; }
    }
}
