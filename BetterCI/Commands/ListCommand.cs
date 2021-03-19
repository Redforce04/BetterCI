using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
namespace BetterCI.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ListCommand : ICommand
    {
        public string Command { get; } = "List";
        public string[] Aliases { get; } = { "l" };
        public string Description { get; } = "Lists all of the ChaosCommanders alive.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(sender, "betterci.list"))
            {
                response = $"You do not have permission to execute this command.";
                return false;
            }
            string Players = "ChaosCommanders: ";
            foreach (CICommanderClass comm in Plugin.SpawnManager.ChaosCommanders.Values)
            {
                Players += $"\n{comm.Player().Nickname}";
            }
            response = Players;
            return true;
        }

    }
}
