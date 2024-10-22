using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class BlockDetails
    {
        public ReportCategory ReportCategory { get; set; }
        public int Duration { get; set; }
        public long GameSessionId { get; set; }
        public string Message { get; set; } = "";
    }

    public enum ReportCategory
    {
        Moderator = -1,
        Unknown,
        DEPRECATED_MicrophoneAbuse,
        Harassment,
        Cheating,
        DEPRECATED_ImmatureBehavior,
        AFK,
        Misc,
        Underage
    }
}
