using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;
namespace BetterCI
{
    /// <summary>
    /// ChaosInsurgency Commander Info.
    /// </summary>

    public class CICommanderClass
    {
        /// <summary>
        /// The <seealso cref="Exiled.API.Features.Player.Id"/> of the CICommander.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets the <seealso cref="Exiled.API.Features.Player"/> of the CICommander.
        /// </summary>
        /// <returns>Returns the <seealso cref="Exiled.API.Features.Player"/> instance of the CICommander.</returns>
        public Exiled.API.Features.Player Player()
        {
            return Exiled.API.Features.Player.Get(Id);
        }
    }
    public enum Classes
    {
        CICommander
    }
}
