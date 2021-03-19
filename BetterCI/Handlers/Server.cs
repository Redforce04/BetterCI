using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs;


namespace BetterCI.Handlers
{
    public class Server
    {
        /// <summary>
        /// Called when the round starts.
        /// </summary>
        public void OnRoundStart()
        {

        }
        /// <summary>
        /// Called when respawning a team.
        /// </summary>
        /// <param name="ev"></param>
        public void OnRespawnTeam(RespawningTeamEventArgs ev)
        {
            if(ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                Plugin.SpawnManager.OnRespawn(ev);
            }
        }
    }
}
