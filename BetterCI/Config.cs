using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BetterCI
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        /// <summary>
        /// Amount of ChaosCommanders to spawn in each spawn wave.
        /// </summary>
        [Description("Amount of Chaos Commanders to spawn in per spawnwave.")]
        public int ChaosCommanders { get; set; } = 1;
        /// <summary>
        /// The message broadcasted to a player when they become a chaos commander.
        /// </summary>
        [Description("Message to specify to chaos commanders once spawned.")]
        public string ChaosCommanderBroadcast { get; set; } = "You have been selected as Chaos Commander.";
        /// <summary>
        /// How long the broadcast should last when a player becomes a chaos commander.
        /// </summary>
        [Description("How long to broadcast the specified Chaos Commander Broadcast.")]
        public ushort ChaosCommanderBroadcastTime { get; set; } = 5;
        /// <summary>
        /// The Custom info string to set for a player.
        /// </summary>
        [Description("The text to put for the custom role info. This will be displayed like how their name is shown but is displayed right above the name.")]
        public string ChaosCommanderPrefix { get; set; } = "Chaos Commander";
    }
}
