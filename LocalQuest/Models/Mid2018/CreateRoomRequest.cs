using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class CreateRoomRequest
    {
        public string ActivityLevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Accessibility Accessibility { get; set; }
        public bool IsSandbox { get; set; }
        public ScreenSupport ScreenModeSupport { get; set; }
        public bool Instanced { get; set; }
        public long GameSessionId { get; set; }
        public int MaxPlayers { get; set; }
    }
}
