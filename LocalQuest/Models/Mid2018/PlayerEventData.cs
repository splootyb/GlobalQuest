using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class PlayerEventData
    {
        public List<PlayerEvent> Created { get; set; } = new List<PlayerEvent>();
        public List<PlayerEventResponseData> Responses { get; set; } = new List<PlayerEventResponseData>();
    }
}
