using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;

namespace BetterCI.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class BetterCIParentCommand : ParentCommand
    {
        public override string Command { get; } = "BetterCI";
        public override string[] Aliases { get; } = { "BCI" };
        public override string Description { get; } = "The root command for Better Chaos Insurgency.";
        public BetterCIParentCommand() => LoadGeneratedCommands();
        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new ListCommand());
            RegisterCommand(new SpawnParentCommand());
            RegisterCommand(new DespawnCommand());
        }
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string responses)
        {
            responses = $"Please specify a valid subcommand. Subcommands: ";
            return false;
        }
    }
}
