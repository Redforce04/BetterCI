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
    public class DespawnCommand : ICommand
    {
        public string Command { get; set; } = "Despawn";
        public string[] Aliases { get; set;  } = { };
        public string Description { get; set; } = $"Depawns a player from their custom class.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(sender, "betterci.spawn"))
            {
                response = $"You do not have permission to execute this command.";
                return false;
            }
            if(arguments.Count == 0)
            {
                response = $"Please specify a valid player.";
                return false;
            }
            if(Player.Get(arguments.At(0)) is null)
            {
                response = $"Could not find {arguments.At(0)}";
            }
            Plugin.SpawnManager.RemoveClass(Player.Get(arguments.At(0)));
            response = $"Despawned {Player.Get(arguments.At(0))}.";
            return true;
        }

    }
}
