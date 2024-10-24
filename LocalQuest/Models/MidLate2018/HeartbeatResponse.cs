using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class HeartbeatResponse
    {
        public string? Error { get; set; }
        public Presence? Presence { get; set; }
    }
}
