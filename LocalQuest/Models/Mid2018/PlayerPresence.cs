using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class PlayerPresence
    {
        public long PlayerId { get; set; }
        public bool IsOnline { get; set; }
        public bool InScreenMode { get; set; }
        public GameSession? GameSession { get; set; }
    }
}
