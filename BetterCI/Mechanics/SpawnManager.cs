using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace BetterCI
{
    /// <summary>
    /// Custom Spawn Manager.
    /// </summary>
    public class SpawnManager
    {
        /// <summary>
        /// Main dictionary of users who are Chaos Commanders. String is userid(steamid64), and their corresponding CICommanderClass.
        /// </summary>
        public Dictionary<string, CICommanderClass> ChaosCommanders = new Dictionary<string, CICommanderClass>();

        /// <summary>
        /// Makes a player a subclass.
        /// </summary>
        /// <param name="ply">The player to make into a subclass.</param>
        /// <param name="Class">The class to make the player.</param>
        public void MakeClass(Player ply, Classes Class)
        {
            switch (Class)
            {
                case Classes.CICommander:
                    MakeCICommander(ply, out CICommanderClass ccccccccccc);
                    break;
            }
        }

        /// <summary>
        /// Makes a player a subclass.
        /// </summary>
        /// <param name="ply">The player to make into a subclass.</param>
        /// <param name="Class">The class to make the player.</param>
        public void MakeClass(Player ply, string Class)
        {
            switch (Class)
            {
                case "Class":
                    break;
                case "CICommander":
                    MakeCICommander(ply, out CICommanderClass ccccccccccc);
                    break;
            }
        }

        /// <summary>
        /// Makes a player a subclass.
        /// </summary>
        /// <param name="ply">The player to make into a subclass.</param>
        /// <param name="Class">The class to make the player.</param>
        public void RemoveClass (Player ply)
        {
            RemoveCICommander(ply);
        }

        /// <summary>
        /// Handles spawning Custom Chaos.
        /// </summary>
        /// <param name="ev"></param>
        public void OnRespawn(RespawningTeamEventArgs ev)
        {
            foreach (Player ply in RandomCICommanders(ev.Players))
            {
                MakeCICommander(ply, out CICommanderClass comm);
            }

        }
        /// <summary>
        /// Makes a player into a CICommander and returns the CICommander Class.
        /// </summary>
        /// <param name="ply"></param>
        public void MakeCICommander(Player ply, out CICommanderClass comm)
        {
            CICommanderClass com = new CICommanderClass() { Id = ply.Id };
            ply.SetRole(RoleType.ChaosInsurgency, false, false);
            ply.ReferenceHub.nicknameSync.Network_customPlayerInfoString = Plugin.Config.ChaosCommanderPrefix;
            if(!ChaosCommanders.ContainsKey(ply.UserId)) ChaosCommanders.Add(ply.UserId, com);
            ply.Broadcast(Plugin.Config.ChaosCommanderBroadcastTime, Plugin.Config.ChaosCommanderBroadcast);
            comm = com;
        }
        /// <summary>
        /// Returns a players <seealso cref="CICommanderClass"/>, if present. Returns <seealso cref="false"/>, and a null commander class if none exist.
        /// </summary>
        /// <param name="ply">The player to get the <seealso cref="CICommanderClass"></seealso>.</param>
        /// <param name="Commander">The <seealso cref="CICommanderClass"/> instance of the player.</param>
        public bool Get(Player ply, out CICommanderClass Commander)
        {
            Commander = null;
            if (!ChaosCommanders.TryGetValue(ply.UserId, out Commander)) return false;
            return true;
        }

        /// <summary>
        /// Removes a player from CICommanders.
        /// </summary>
        /// <param name="ply">The player to remove from CICommanders.</param>
        public void RemoveCICommander(Player ply)
        {
            ply.ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
            ChaosCommanders.Remove(ply.UserId);
        }

        /// <summary>
        /// Removes a player from CICommanders.
        /// </summary>
        /// <param name="comm">The player to remove from CICommanders.</param>
        public void RemoveCICommander(CICommanderClass comm)
        {
            comm.Player().ReferenceHub.nicknameSync.Network_customPlayerInfoString = "";
            ChaosCommanders.Remove(comm.Player().UserId);
        }

        /// <summary>
        /// Takes a list of players and randomly selects the number of specified players at random. Leave amount as 0 to use the config specified number.
        /// </summary>
        /// <param name="plys">List of Players to choose from.</param>
        /// <param name="amount">Amount of CICommanders to randomly select.</param>
        /// <returns></returns>
        public List<Player> RandomCICommanders(List<Player> plys, int amount = 0)
        {
            if(amount == 0) amount = Plugin.Config.ChaosCommanders;
            //List of players spawning that are selected to become commanders. This will eventually be returned as result.
            List<Player> comms = new List<Player>();
            //List of players spawning that aren't yet selected.
            List<Player> playerpool = new List<Player>();
            //Random number generator for random player selector.
            int i;
            for(i = 0; i <= Plugin.Config.ChaosCommanders; i++)
            {
                int plynum = UnityEngine.Random.Range(1, playerpool.Count);
                Player RandPly = playerpool.ToArray()[plynum];
                comms.Add(RandPly);
                playerpool.Remove(RandPly);
            }
            return comms;
        }


    }
}
