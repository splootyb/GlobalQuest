using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class WordFilter
    {
        static List<string> BadWords = new List<string>()
        {
            "fuck",
            "hell",
            "nigger",
            "faggot",
            "fag",
            "tranny",
            "hitler",
            "sex",
            "nazi",
            "penis",
            "bitch",
            "cock",
            "dick",
            "piss"
        };
        public static bool IsPure(string? Content)
        {
            if(string.IsNullOrEmpty(Content))
            {
                return false;
            }
            if (BadWords.Any(A => Content.ToLower().Replace(" ", "").Contains(A.ToLower())))
            {
                return false;
            }
            return true;
        }
    }
}
