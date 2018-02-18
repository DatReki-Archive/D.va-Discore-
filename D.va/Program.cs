using D.va.Basic;
using D.va.Commands;
using Discore;
using Discore.Http;
using Discore.WebSocket;
using System;
using System.Threading.Tasks;

namespace D.va
{
    public class Program
    {
        DiscordHttpClient http;


        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run(args).GetAwaiter().GetResult();
        }

        public async Task Run(string[] args)
        {
            _Config.LoadConfig();

            if (args.Length > 0)
            {
                _Config.Token.Discord = args[0];
            }
            if (string.IsNullOrEmpty(_Config.Token.Discord))
            {
                Console.WriteLine("You haven't added your token in the json file yet!");
                await Task.Delay(-1);
            }

            // This is temp until I can fix the _Config file again cause for some reason it's not working
            string token = "TokenHere";

            // _Config.Token.Discord
            // Create an HTTP client.
            http = new DiscordHttpClient(token);

            // Create a single shard.
            using (Shard shard = new Shard(token, 0, 1))
            {
                // Subscribe to the message creation event.
                //shard.Gateway.OnMessageCreated += Gateway_OnMessageCreated;
                shard.Gateway.OnMessageCreated += CommandParser.ProcessCommand;

                // Start the shard.
                await shard.StartAsync();
                Console.WriteLine("Bot started!");

                CommandFactory.RegisterCommand("ping", new PingCommand());
                CommandFactory.RegisterCommand("info", new InfoCommand());

                // Wait for the shard to end before closing the program.
                await shard.WaitUntilStoppedAsync();
            }
        }

        private async void Gateway_OnMessageCreated(object sender, MessageEventArgs e)
        {
            Shard shard = e.Shard;
            DiscordMessage message = e.Message;


            if (message.Author.Id == shard.UserId)
                // Ignore messages created by our bot.
                return;

            if (message.Content == "ping")
            {
                try
                {
                    // Reply to the user who posted "!ping".
                    await http.CreateMessage(message.ChannelId, $"<@!{message.Author.Id}> Pong!");
                }
                catch (DiscordHttpApiException)
                {
                }
            }
        }
    }
}
