using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class FileManager
    {
        static string Path = "";
        public static void Setup()
        {
            Path = Directory.GetCurrentDirectory() + "/Data/";
            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            if (!Directory.Exists(Path + "Avatar/"))
            {
                Directory.CreateDirectory(Path + "Avatar/");
            }
            if (!Directory.Exists(Path + "PlayerData/"))
            {
                Directory.CreateDirectory(Path + "PlayerData/");
            }
            if (!Directory.Exists(Path + "Images/"))
            {
                Directory.CreateDirectory(Path + "Images/");
            }
            if (!Directory.Exists(Path + "RoomData/"))
            {
                Directory.CreateDirectory(Path + "RoomData/");
            }
        }

        public static byte[] GetBytes(string Name)
        {
            Log.Debug("Getting file: " + Path + Name);
            if(File.Exists(Path + Name))
            {
                return File.ReadAllBytes(Path + Name);
            }
            else
            {
                return new byte[0];
            }
        }

        public static void WriteBytes(string Name, byte[] Data)
        {
            if (File.Exists(Path + Name))
            {
                File.WriteAllBytes(Path + Name, Data);
            }
            else
            {
                using (FileStream FS = File.Create(Path + Name))
                {
                    FS.Write(Data);
                    FS.Close();
                    FS.Dispose();
                }
            }
        }
        public static T? GetJSON<T>(string Name)
        {
            Name = Name + ".json";
            if(File.Exists(Path + Name))
            {
                string FileData = File.ReadAllText(Path + Name);
                try
                {
                    return JsonSerializer.Deserialize<T>(FileData);
                }
                catch
                {
                    return default(T);
                }
            }
            else
            {
                using (StreamWriter SW = File.CreateText(Path + Name))
                {
                    SW.Write(JsonSerializer.Serialize(default(T)));
                }
                return default(T);
            }
        }

        public static T? WriteJSON<T>(string Name, T NewValue)
        {
            try
            {
                Name = Name + ".json";
                if (File.Exists(Path + Name))
                {
                    File.WriteAllText(Path + Name, JsonSerializer.Serialize(NewValue));
                    return NewValue;
                }
                else
                {
                    using (StreamWriter SW = File.CreateText(Path + Name))
                    {
                        SW.Write(NewValue);
                        SW.Close();
                        SW.Dispose();
                    }
                    return NewValue;
                }
            }
            catch
            {
                Log.Error("Failed to write to file!? " + Name);
                return default(T);
            }
        }
    }
}
