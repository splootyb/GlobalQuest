using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.MidLate2018
{
    public class SearchTag
    {
        public string Tag { get; set; } = "EqTag";
        public TagType Type { get; set; }
    }

    public enum TagType
    {
        General,
        Auto,
        AGOnly,
        Banned
    }
}
