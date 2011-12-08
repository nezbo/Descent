namespace Descent.Model.Player.Overlord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
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
        public OverlordCard(int id, string name, string description, int playPrice, int sellPrice)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.playPrice = playPrice;
            this.sellPrice = sellPrice;
        }

        #endregion

        #region Methods

        public virtual void PlayCard(){}

        #endregion
    }
}
