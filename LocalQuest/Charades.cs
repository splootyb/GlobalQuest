using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class Charades
    {
        public static List<CharadesWord>? CharadesWords = new List<CharadesWord>()
        {
            new CharadesWord()
            {
                EN_US = "Jerry Juke",
                Difficulty = CharadesDifficulty.Easy
            },
            new CharadesWord()
            {
                EN_US = "Cat",
                Difficulty = CharadesDifficulty.Easy
            },
            new CharadesWord()
            {
                EN_US = "Box",
                Difficulty = CharadesDifficulty.Easy
            },
            new CharadesWord()
            {
                EN_US = "Sandbox Machine",
                Difficulty = CharadesDifficulty.Easy
            },
            new CharadesWord()
            {
                EN_US = "Maker Pen",
                Difficulty = CharadesDifficulty.Easy
            },
            new CharadesWord()
            {
                EN_US = "Jerry Juke",
                Difficulty = CharadesDifficulty.Easy
            }
        };
        static void Setup()
        {

        }
    }
}
