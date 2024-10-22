using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Mid2018
{
    public class GiftPackage
    {
        public long Id { get; set; }
        public string? AvatarItemDesc { get; set; }
        public string? ConsumableItemDesc { get; set; }
        public string? EquipmentPrefabName { get; set; }
        public string? EquipmentModificationGuid { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public int Currency { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public GiftRarity GiftRarity { get; set; }
        public string Message { get; set; } = "gifting gifting gifting [|X3]";
        public GiftContext GiftContext { get; set; }
    }

    public enum GiftContext
    {
        None = -1,
        Default,
        First_Activity,
        Game_Drop,
        All_Daily_Challenges_Complete,
        All_Weekly_Challenge_Complete,
        Daily_Challenge_Complete,
        Weekly_Challenge_Complete,
        Unassigned_Equipment = 10,
        Unassigned_Avatar,
        Unassigned_Consumable,
        Reacquisition = 20,
        Membership,
        LevelUp = 100,
        LevelUp_2 = 102,
        LevelUp_3,
        LevelUp_4,
        LevelUp_5,
        LevelUp_6,
        LevelUp_7,
        LevelUp_8,
        LevelUp_9,
        LevelUp_10,
        LevelUp_11,
        LevelUp_12,
        LevelUp_13,
        LevelUp_14,
        LevelUp_15,
        LevelUp_16,
        LevelUp_17,
        LevelUp_18,
        LevelUp_19,
        LevelUp_20,
        LevelUp_21,
        LevelUp_22,
        LevelUp_23,
        LevelUp_24,
        LevelUp_25,
        LevelUp_26,
        LevelUp_27,
        LevelUp_28,
        LevelUp_29,
        LevelUp_30,
        Event_RawData = 1000,
        SFVRCC_Promo,
        HelixxVR_Promo,
        Paintball_ClearCut = 2000,
        Paintball_Homestead,
        Paintball_Quarry,
        Paintball_River,
        Paintball_Dam,
        Discgolf_Propulsion = 3000,
        Discgolf_Lake,
        Discgolf_Mode_CoopCatch = 3500,
        Quest_Goblin_A = 4000,
        Quest_Goblin_B,
        Quest_Goblin_C,
        Quest_Goblin_S,
        Quest_Goblin_Consumable,
        Quest_Cauldron_A = 4010,
        Quest_Cauldron_B,
        Quest_Cauldron_C,
        Quest_Cauldron_S,
        Quest_Cauldron_Consumable,
        Quest_Pirate1_A = 4100,
        Quest_Pirate1_B,
        Quest_Pirate1_C,
        Quest_Pirate1_S,
        Quest_Pirate1_X,
        Quest_Pirate1_Consumable,
        Quest_SciFi_A = 4500,
        Quest_SciFi_B,
        Quest_SciFi_C,
        Quest_SciFi_S,
        Quest_scifi_Consumable,
        Charades = 5000,
        Soccer = 6000,
        Paddleball = 7000,
        Dodgeball = 8000,
        Lasertag = 9000,
        Store_LaserTag = 100000,
        Store_RecCenter = 100010,
        Consumable = 110000,
        Token = 110100,
        Punchcard_Challenge_Complete = 110200,
        All_Punchcard_Challenges_Complete
    }

    public enum GiftRarity
    {
        None = -1,
        // 1 star
        Common,
        // 2 star
        Uncommon = 10,
        // 3 star
        Rare = 20,
        // 4 star
        Epic = 30,
        // 5 star
        Legendary = 50
    }

    public enum CurrencyType
    {
        Invalid,
        LaserTagTickets,
        RecCenterTokens,
        LostSkullsGold = 100,
        RecRoyale_Season1 = 200
    }
}
