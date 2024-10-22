using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class NetworkFiles
    {
        static string BaseURL = "https://raw.githubusercontent.com/Epic-Quest/LocalQuest-Data/refs/heads/main/";
        static HttpClient Client = new HttpClient();
        public static async Task<T?> GetData<T>(string Name, bool PauseOnError = false)
        {
            try
            {
                string S = await Client.GetStringAsync(BaseURL + Name + "?v=" + new Random().Next(0,5));
                return JsonSerializer.Deserialize<T>(S);
            }
            catch
            {
                Log.Error("Failed to get network data file.");
                if(PauseOnError)
                    UiTools.WriteControls(new List<string>() { "okay..." });
                return default(T);
            }
        }

        public static async Task<T?> GetFullData<T>(string Url, bool PauseOnError = false)
        {
            try
            {
                string S = await Client.GetStringAsync(Url);
                return JsonSerializer.Deserialize<T>(S);
            }
            catch
            {
                Log.Error("Failed to get network data file.");
                if (PauseOnError)
                    UiTools.WriteControls(new List<string>() { "okay..." });
                return default(T);
            }
        }

        public static async Task<string> GetText(string Name, bool PauseOnError = false)
        {
            try
            {
                string S = await Client.GetStringAsync(BaseURL + Name + "?v=" + new Random().Next(0, 5));
                return S;
            }
            catch
            {
                if (PauseOnError)
                    UiTools.WriteControls(new List<string>() { "okay..." });
                return "";
            }
        }

        public static async Task<byte[]> GetData(string Name)
        {
            try
            {
                HttpResponseMessage Message = await Client.GetAsync(BaseURL + Name + "?v=" + new Random().Next(0, 5));
                return await Message.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                Log.Error("Failed to get network file.");
                return new byte[0];
            }
        }

        public static async Task<byte[]> GetFullData(string Url)
        {
            try
            {
                HttpResponseMessage Message = await Client.GetAsync(Url);
                return await Message.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                Log.Error("Failed to get network file.");
                return new byte[0];
            }
        }
    }
}
