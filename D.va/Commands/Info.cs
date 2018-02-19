using D.va.Basic;
using Discore;
using Discore.WebSocket;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace D.va.Commands
{

    class InfoCommand : Command
    {
        public InfoCommand() : base()
        {
            Name = "info";
            Desc = "Information about the bot";
        }
        public override async void Execute(ITextChannel Channel, MessageEventArgs e, MatchCollection args)
        {

            try
            {
                await Channel.TriggerTypingIndicator();
                await Channel.CreateMessage($"Hello I'm D.va and I'm created by {BotOwner.BotOwnerName + BotOwner.BotOwnerDiscrim}\nOwner ID: {BotOwner.BotOwnerID}\nServerID: {BotOwner.BotOwnerServerID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
