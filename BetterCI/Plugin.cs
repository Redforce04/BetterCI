using System.IO;
using System.Net;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled;
using Exiled.API;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.API.Enums;
using Exiled.Events.Handlers;
using Exiled.Events.EventArgs;
using UnityEngine;
using HarmonyLib;
using Serv = Exiled.Events.Handlers.Server;
using Play = Exiled.Events.Handlers.Player;

namespace BetterCI
{
    /// <summary>
    /// Better Chaos Insurgency
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        
        /// <summary>
        /// Name of the plugin. BetterCI
        /// </summary>
        public override string Name { get; } = "BetterCI";
        
        /// <summary>
        /// Prefix of the plugin. BetterChaos
        /// </summary>
        public override string Prefix { get; } = "BetterChaos";
        
        /// <summary>
        /// Author of the plugin. Made by Ace and adapted to Exiled by Redforce04.
        /// </summary>
        public override string Author { get; } = "Ace and Redforce04";
        
        /// <summary>
        /// Load Priority of the plugin. High
        /// </summary>
        public override PluginPriority Priority { get; } = PluginPriority.High;
        
        /// <summary>
        /// Version of the plugin. 1.0 Alpha
        /// </summary>
        public override Version Version { get; } = Version.Parse($"1.0.0");
        
        /// <summary>
        /// Required Exiled version for the plugin to work. 1.1.1
        /// </summary>
        public override Version RequiredExiledVersion { get; } = Version.Parse("1.8.0");
        
        /// <summary>
        /// Plugin Config instance.
        /// </summary>
        public static Config Config;
        
        /// <summary>
        /// Main Harmony instance.
        /// </summary>
        public static Harmony harmony;
        
        /// <summary>
        /// Main SpawnManager instance.
        /// </summary>
        public static SpawnManager SpawnManager;

        /// <summary>
        /// Server Handlers reference.
        /// </summary>
        private Handlers.Server server;
        
        /// <summary>
        /// Player Handlers reference.
        /// </summary>
        private Handlers.Player player;
        
        /// <summary>
        /// Calls events required to enable the plugin.
        /// </summary>
        public override void OnEnabled()
        {
            RegisterEvents();
        }
        
        /// <summary>
        /// Calls events required to disable the plugin.
        /// </summary>
        public override void OnDisabled()
        {
            UnregisterEvents();
        }
        
        /// <summary>
        /// Calls events required to reload the plugin.
        /// </summary>
        public override void OnReloaded()
        {
            
        }

        /// <summary>
        /// Registers events required for the plugin to function properly.
        /// </summary>
        private void RegisterEvents()
        {
            server = new Handlers.Server();
            player = new Handlers.Player();
            Serv.RoundStarted += server.OnRoundStart;
            Serv.RespawningTeam += server.OnRespawnTeam;

            Play.Destroying += player.OnLeft;
            Play.Died += player.OnDied;

        }
        /// <summary>
        /// Unregisters the events required for the plugin to fuction properly.
        /// </summary>
        private void UnregisterEvents()
        {
            server = null;
            player = null;
            Serv.RoundStarted -= server.OnRoundStart;
            Serv.RespawningTeam -= server.OnRespawnTeam;

            Play.Destroying -= player.OnLeft;
            Play.Died -= player.OnDied;
        }
    }
}
