using Newtonsoft.Json;
using System.IO;

namespace D.va
{
    public class _Config
    {
        // Define global variables for the bot in here and reference them with _Config.
        public static string ServerInvite = "https://discord.gg/";
        public static string BotInvite = "https://discordapp.com/oauth2/authorize?client_id=388022439378026496&scope=bot&permissions=1342303294";
        public static TokenPlaceholder Token = new TokenPlaceholder();

        #region LoadConfig
        public static void LoadConfig()
        {
            if (File.Exists("Tokens.json"))
            {

                using (StreamWriter file = File.CreateText("Tokens-Example.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Token);
                }
                if (File.Exists("Tokens.json"))
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader("Tokens.json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            Token = (TokenPlaceholder)serializer.Deserialize(reader, typeof(TokenPlaceholder));
                        }
                    }
                    catch { }
                }
            }
            else
            {
                using (StreamWriter w = File.AppendText("Tokens.json"))
                {
                    if (File.Exists("Tokens.json"))
                    {
                        if (new FileInfo("Tokens.json").Length == 0)
                        {
                            string JSONFormat = "{\"Discord\":\"Put your token here\"}";
                            w.WriteLine($@"{JSONFormat}");
                            return;
                        }
                    }
                }
            }
        }
        #endregion
        // Place your token names here
        public class TokenPlaceholder
        {
            public string Discord = "";
            public string Osu = "";
        }
    }
}