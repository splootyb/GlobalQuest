using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class Reputation
    {
        public float Noteriety { get; set; }
        public int CheerGeneral { get; set; } = 10;
        public int CheerHelpful { get; set; } = 10;
        public int CheerGreatHost { get; set; } = 10;
        public int CheerSportsman { get; set; } = 10;
        public int CheerCreative { get; set; } = 10;
        public int CheerCredit { get; set; } = 10;
        public int SubscriberCount { get; set; } = 0;
        public int SubscribedCount { get; set; } = 0;
        public CheerType? SelectedCheer  { get; set; } = (CheerType?)LocalQuest.Config.GetInt("CheerCategory");
    }
    public enum CheerType
    {
        General,
        Helpful = 10,
        Sportmanship = 20,
        GreatHost = 30,
        Creative = 40
    }
}
