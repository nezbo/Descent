// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics.Contracts;

namespace Descent.Model.Player
{
    using System.Collections.Generic;

    using Descent.Messaging.Connection;
    using Descent.Messaging.Events;
    using Descent.State;
    using Figure;

    /// <summary>
    /// Describes the current role of a Player in the game. The Overlord's
    /// role will not change throughout the game, but the Hero's will frequently
    /// change from the ActiveHero to the InactiveHero denoting wether or not
    /// they are allowed to do stuff in the game.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public enum Role
    {
        Overlord,
        ActiveHero,
        InactiveHero
    }

    /// <summary>
    /// There are 3 different kinds of attack,
    /// Magic, Melee and Ranged. 
    /// An attack have to be one of these 3 types.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public enum EAttackType
    {
        MAGIC, MELEE, RANGED, NONE
    }

    /// <summary>
    /// The actual player, playing the game
    /// TODO: Write Player class
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Player
    {
        /// <summary>
        /// The static field, holding the player instance
        /// </summary>
        private static Player player;

        private StateManager stateManager;

        private EventManager eventManager;

        private Dictionary<int, string> otherPlayers;

        /// <summary>
        /// Prevents a default instance of the <see cref="Player"/> class from being created.
        /// </summary>
        private Player()
        {
            eventManager = new EventManager();
            otherPlayers = new Dictionary<int, string>();
        }

        /// <summary>
        /// Gets the Player singleton instance
        /// TODO: At the moment there is no instantiating of the Player object
        /// </summary>
        public static Player Instance
        {
            get
            {
                return player ?? (player = new Player());
            }
        }

        public string Name { get; set; }

        /// <summary>
        /// What is your role?
        /// If the player is overlord, return true, else false
        /// </summary>
        public bool IsOverlord { get; set; }

        /// <summary>
        /// Gets or sets the Hero of the Player - if the player is not overlord.
        /// </summary>
        public Hero Hero { get; set; }

        /// <summary>
        /// Gets the unique ID.
        /// What is your unique player ID?
        /// </summary>
        public int Id
        {
            get
            {
                return Connection.Id;
            }
        }

        /// <summary>
        /// Are you client or server?
        /// </summary>
        public bool IsServer { get; set; }

        /// <summary>
        /// Gets the other players. Key is id of the player, value is name.
        /// </summary>
        public Dictionary<int, string> OtherPlayers
        {
            get
            {
                return otherPlayers;
            }
        } 

        /// <summary>
        /// Gets or sets the StateManager.
        /// </summary>
        public StateManager StateManager
        {
            get
            {
                return stateManager;
            }

            set
            {
                Contract.Requires(stateManager == null);
                stateManager = value;
            }
        }

        /// <summary>
        /// Gets EventManager.
        /// </summary>
        public EventManager EventManager
        {
            get
            {
                return eventManager;
            }
        }

        /// <summary>
        /// Gets or sets the Connection.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// Start/host a game on the following port.
        /// </summary>
        /// <param name="port">Port to listen on.</param>
        public void StartGame(int port)
        {
            Connection = new ServerConnection(port);
            Connection.Start();
        }

        /// <summary>
        /// Join an already started game.
        /// </summary>
        /// <param name="ip">Ip of host.</param>
        /// <param name="port">Port of host.</param>
        public void JoinGame(string ip, int port)
        {
            Connection = new ClientConnection(ip, port);
            Connection.Start();
        }
    }
}