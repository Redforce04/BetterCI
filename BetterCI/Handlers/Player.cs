using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
namespace BetterCI.Handlers
{
    public class Player
    {
        /// <summary>
        /// Dying event handler.
        /// </summary>
        /// <param name="ev">Event Args</param>
        public void OnDied(DiedEventArgs ev)
        {
            Plugin.SpawnManager.RemoveCICommander(ev.Target);
        }
        /// <summary>
        /// Player Left event handler.
        /// </summary>
        /// <param name="ev">Event Args</param>
        public void OnLeft(DestroyingEventArgs ev)
        {
            Plugin.SpawnManager.RemoveCICommander(ev.Player);
        }
    }
}
