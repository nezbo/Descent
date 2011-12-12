namespace Descent.Model.Player
{
    using Descent.Messaging.Connection;
    using Descent.Messaging.Events;
    using Descent.Model.Player.Figure;
    using Descent.State;

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
        NONE, MAGIC, MELEE, RANGED
    }

    /// <summary>
    /// The actual player, playing the game
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

        private string[] playerNicks;

        /// <summary>
        /// Prevents a default instance of the <see cref="Player"/> class from being created.
        /// </summary>
        private Player()
        {
            eventManager = new EventManager();
            playerNicks = new string[5];
            Overlord = new Overlord();
            HeroParty = new HeroParty();
        }

        /// <summary>
        /// Gets the Player singleton instance
        /// </summary>
        public static Player Instance
        {
            get
            {
                return player ?? (player = new Player());
            }
        }

        /// <summary>
        /// Gets or sets the Players nickname.
        /// </summary>
        public string Nickname
        {
            get
            {
                return GetPlayerNick(Player.Instance.Id);
            }

            set
            {
                SetPlayerNick(Player.Instance.Id, value);
            }
        }

        public bool IsOverlord
        {
            get { return (Id == OverlordId); }
        }

        public int OverlordId { get; set; }

        public Overlord Overlord { get; private set; }

        /// <summary>
        /// Gets the Hero Party.
        /// </summary>
        public HeroParty HeroParty { get; private set; }

        /// <summary>
        /// Gets or sets the Hero of the Player - if the player is not overlord.
        /// </summary>
        public Hero Hero
        {
            get
            {
                return HeroParty.Heroes[Player.Instance.Id];
            }
            
            set
            {
                HeroParty.Heroes[Player.Instance.Id] = value;
            }
        }

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
        public bool IsServer { get; internal set; }

        public void SetPlayerNick(int id, string nickname)
        {
            playerNicks[id - 1] = nickname;
        }

        public string GetPlayerNick(int id)
        {
            return playerNicks[id - 1];
        }

        /// <summary>
        /// Gets the number of other players in the game.
        /// </summary>
        public int NumberOfPlayers
        {
            get
            {
                int c = 0;
                foreach (string playerNick in playerNicks)
                {
                    if (playerNick != null) c++;
                }
                return c;
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
                if (stateManager == null)
                {
                    stateManager = value;
                }
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
            IsServer = true;
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
            IsServer = false;
            Connection = new ClientConnection(ip, port);
            Connection.Start();
        }
    }
}