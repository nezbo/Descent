// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using Descent.State;

    /// <summary>
    /// The actual player, playing the game
    /// TODO: Write Player class
    /// </summary>
    public class Player
    {
        //************ Singleton Pattern *************//
        /// <summary>
        /// The static field, holding the player instance
        /// </summary>
        private static Player player = null;

        /// <summary>
        /// Will always return the same Player instance
        /// TODO: At the moment there is no instantiating of the Player object
        /// </summary>
        public static Player Instance
        {
            get
            {
                return player ?? (player = new Player());
            }
        }

        //********************************************//

        /// <summary>
        /// Prevents a default instance of the <see cref="Player"/> class from being created. 
        /// 
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder",
            Justification = "Reviewed. Suppression is OK here.")]
        private Player()
        {
        }

        //************ Singleton Pattern *************//
        /// <summary>
        /// The StateManager field, that makes out the Singleton Pattern
        /// </summary>
        private StateManager manager = null;

        /// <summary>
        /// Gets StateManager.
        /// TODO: Atm the Statemanager is empty!
        /// </summary>
        public StateManager StateManager
        {
            get
            {
                return manager ?? (manager = new StateManager());
            }
        }
    }
}