namespace Descent.Model.Player.OverlordStuff
{
    #region Enum

    /// <summary>
    /// An enum of all overlord types
    /// </summary>
    public enum OverlordCardType
    {
        /// <summary>
        /// A card that will let the overlord spawn more monsters
        /// </summary>
        Spawn,
        
        /// <summary>
        /// A card that will let the overlord create traps for the heroes
        /// </summary>
        Trap,

        /// <summary>
        /// A card that will let the overlord gain new continous powers
        /// </summary>
        Power,

        /// <summary>
        /// A card that will let the overlords 
        /// monsters gain one time abilities
        /// </summary>
        Event
    }

    #endregion

    /// <summary>
    /// Cards that the overlord draws each turn
    /// </summary>
    /// <author>
    /// Martin Marcher, Jonas Breindahl
    /// </author>
    public abstract class OverlordCard
    {
        #region Fields

        private int id;

        private string name;

        private string description;

        private int playPrice;

        private int sellPrice;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the id of the overlord card
        /// </summary>
        public int Id 
        { 
            get
            {
                return id;
            }

            private set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets the name of the overlord card
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets the description of the overlord card
        /// </summary>
        public string Decription
        {
            get
            {
                return description;
            }

            private set
            {
                description = value;
            }
        }

        /// <summary>
        /// Gets the price to play the overlordcard
        /// </summary>
        public int PlayPrice
        {
            get
            {
                return playPrice;
            }

            private set
            {
                playPrice = value;
            }
        }

        /// <summary>
        /// Gets the sell price for the overlord card
        /// </summary>
        public int SellPrice
        {
            get
            {
                return sellPrice;
            }

            private set
            {
                sellPrice = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of overlord card the card is
        /// </summary>
        public OverlordCardType Type { get; protected set; }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="OverlordCard"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the card
        /// </param>
        /// <param name="name">
        /// The name of the card
        /// </param>
        /// <param name="description">
        /// The description of the card
        /// </param>
        /// <param name="playPrice">
        /// The play price of the card
        /// </param>
        /// <param name="sellPrice">
        /// The sell price of the card
        /// </param>
        /// <param name="type">
        /// The type of overlordcard
        /// </param>
        public OverlordCard(int id, string name, string description, int playPrice, int sellPrice, OverlordCardType type)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.playPrice = playPrice;
            this.sellPrice = sellPrice;
            this.Type = type;
        }

        #endregion

        #region Methods

        public virtual void PlayCard(){}

        public virtual bool CanPlay()
        {
            return true;
        }

        #endregion
    }
}
