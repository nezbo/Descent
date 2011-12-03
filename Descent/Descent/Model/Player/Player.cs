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
    /// The actual player, playing the game
    /// TODO: Write Player class
    /// </summary>
    public class Player
    {
        #region PlayerSingletonPattern
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

        #endregion PlayerSingletonPattern

        #region CONSTRUCTORS
        /// <summary>
        /// Prevents a default instance of the <see cref="Player"/> class from being created. 
        /// 
        /// </summary>
        private Player()
        {
        }
        #endregion CONSTRUCTORS

        #region FIELDS

        #region StateManagerSingletonPattern
        //************ Singleton Pattern *************//
        /// <summary>
        /// The StateManager field, that makes out the Singleton Pattern
        /// </summary>
        private StateManager stateManager = null;

        /// <summary>
        /// Gets StateManager.
        /// TODO: Atm the Statemanager is empty!
        /// </summary>
        public StateManager StateManager
        {
            get
            {
                return this.stateManager ?? (this.stateManager = new StateManager());
            }
        }

        //*********************************************//
        #endregion StateManagerSingletonPattern

        #region EventManagerSingletonPattern
        //************ Singleton Pattern *************//
        /// <summary>
        /// The EventManager field, that makes out the Singleton Pattern
        /// </summary>
        private EventManager eventManager = null;

        /// <summary>
        /// Gets EventManager.
        /// </summary>
        public EventManager EventManager
        {
            get
            {
                return eventManager ?? (eventManager = new EventManager());
            }
        }

        //*********************************************//
        #endregion EventManagerSingletonPattern

        private Connection connection;

        public Connection Connection { get { return connection; } }

        /// <summary>
        /// What is your role?
        /// If the player is overlord, return true, else false
        /// </summary>
        public bool IsOverlord { get; set; }

        public Hero Hero { get; set; } // stub created by Emil, if it needs to be different change it, then remove this comment

        /// <summary>
        /// Are you client or server
        /// </summary>
        public bool IsServer { get; set; }

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
        /// Start/host a game on the following port.
        /// </summary>
        /// <param name="port">Port to listen on.</param>
        public void StartGame(int port)
        {
            this.connection = new ServerConnection(port);
            this.connection.Start();
        }

        /// <summary>
        /// Join an already started game.
        /// </summary>
        /// <param name="ip">Ip of host.</param>
        /// <param name="port">Port of host.</param>
        public void JoinGame(string ip, int port)
        {
            this.connection = new ClientConnection(ip, port);
            this.connection.Start();
        }
        
        #endregion
    }
}