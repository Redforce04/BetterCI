using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;

namespace BetterCI.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SpawnParentCommand : ParentCommand
    {
        public override string Command { get; } = "Spawn";
        public override string[] Aliases { get; } = {  };
        public override string Description { get; } = "Spawns a player as a subclass.";
        public SpawnParentCommand() => LoadGeneratedCommands();
        public sealed override void LoadGeneratedCommands()
        {
            foreach (Classes Class in (Classes[])Enum.GetValues(typeof(Classes)))
            {
                RegisterCommand(new SpawnCommand() { Command = Class.ToString(), Description = $"Spawns a player in as a {Class.ToString()}" });
            }
        }
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string responses)
        {
            string subclasses = $"Please specify a valid subclass. Subclasses:";
            foreach (Classes Class in (Classes[])Enum.GetValues(typeof(Classes)))
            {
                subclasses += $" {Class},";
            }
            responses = subclasses.Remove(subclasses.Length - 1, 1);
            return false;
        }
    }
}
