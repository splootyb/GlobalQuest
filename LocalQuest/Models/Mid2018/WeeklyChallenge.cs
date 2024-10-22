using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class WeeklyChallenges
    {
        public int ChallengeMapId { get; set; } = 1;
        public bool CompleteAll { get; set; } = true;
        public DateTime StartAt { get; set; } = DateTime.Now;
        public DateTime EndAt { get; set; } = DateTime.Now.AddDays(7);
        public DateTime ServerTime { get; set; } = DateTime.Now;
        public List<WeeklyChallenge> Challenges { get; set; } = new List<WeeklyChallenge>();
        public List<WeeklyGift> Gifts { get; set; } = new List<WeeklyGift>();
        public string ChallengeThemeString { get; set; } = "Theming?!";
        public int? ChallengeThemeId { get; set; } = 1;
    }

    public class WeeklyGift
    {
        public long GiftDropId { get; set; }
        public string AvatarItemDesc { get; set; } = "";
        public string ConsumableItemDesc { get; set; } = "";
        public string EquipmentPrefabName { get; set; } = "";
        public string EquipmentModificationGuid { get; set; } = "";
        public StorefrontType StorefrontType { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public GiftContext GiftContext { get; set; }
        public GiftRarity GiftRarity { get; set; }
    }

    public enum StorefrontType
    {
        None,
        LaserTag,
        RecCenter,
        Watch,
        Quest_LostSkulls = 100,
        RecRoyale = 200
    }

    public class WeeklyChallenge
    {
        public int ChallengeId { get; set; } = new Random().Next();
        public string Name { get; set; } = "Challenge Name";
        public string Config { get; set; } = "{}";
        public string Description { get; set; } = "Challenge Description";
        public string Tooltip { get; set; } = "Challenge Tooltip";
        public bool Complete { get; set; } = false;
    }

    public class BaseChallengeConfig
    {
        public ChallengeTypes ct { get; set; }
        public bool c { get; set; }
    }

    public enum ChallengeTypes
    {
        Challenge,
        ChallengeCountChallenge,
        TimedBufferChallenge,
        DynamicFloatArithmeticChallenge,
        DynamicIntArithmeticChallenge,
        RequiredToolChallenge,
        RequiredEventTypeChallenge,
        RequiredActivityChallenge,
        RequiredEnemyTypeChallenge,
        BoolVarEqualsChallenge,
        DiscGolfFinishUnderParChallenge = 11,
        RequiredGameModeActivityChallenge,
        CompleteGameWithoutChallenge,
        RequiredGestureChallenge,
        HitstreakChallenge,
        HitstreakCountChallenge
    }
}
