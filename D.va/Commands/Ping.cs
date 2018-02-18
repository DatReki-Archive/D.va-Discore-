using D.va.Basic;
using Discore;
using Discore.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace D.va.Commands
{
    class PingCommand : Command
    {
        public PingCommand() : base()
        {
            Name = "ping";
            Desc = "Checks the ping of the bot";
        }

        public override async void Execute(ITextChannel Channel, MessageEventArgs e, MatchCollection args)
        {
            await Channel.TriggerTypingIndicator();
            await Channel.CreateMessage("pong");
        }
    }
}
