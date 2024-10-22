using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class CharadesWord
    {
        public string? EN_US { get; set; }
        public CharadesDifficulty Difficulty { get; set; }
    }

    public enum CharadesDifficulty
    {
        Easy,
        Hard,
        Impossible
    }
}
