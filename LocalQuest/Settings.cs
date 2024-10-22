using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class Settings
    {
        public static List<PlayerSetting>? GetSettings()
        {
            return FileManager.GetJSON<List<PlayerSetting>>("PlayerData/Settings");
        }

        public static List<PlayerSetting>? SetSetting(string Key, string Value)
        {
            PlayerSetting NewSetting = new PlayerSetting()
            {
                Key = Key,
                Value = Value
            };
            List<PlayerSetting>? Settings = FileManager.GetJSON<List<PlayerSetting>>("PlayerData/Settings");

            // should never be null
            if (Settings == null)
            {
                return null;
            }

            PlayerSetting? Existing = Settings.FirstOrDefault(A => A.Key == NewSetting.Key);
            if (Existing != null)
            {
                Existing.Value = NewSetting.Value;
            }
            else
            {
                Settings.Add(NewSetting);
            }
            FileManager.WriteJSON("PlayerData/Settings", Settings);

            return Settings;
        }
    }
}
