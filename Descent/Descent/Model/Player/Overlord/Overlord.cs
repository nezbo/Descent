namespace Descent.Model.Player.Overlord
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The role of a overlord, that a hero can be.
    /// </summary>
    public class Overlord
    {

        #region Fields

        private List<OverlordCard> hand;

        private List<OverlordCard> powers;

        private List<OverlordCard> deck;

        private List<OverlordCard> graveyard;
 
        #endregion

        public Overlord()
        {
            hand = new List<OverlordCard>();
            powers = new List<OverlordCard>();
            deck = new List<OverlordCard>();
            graveyard = new List<OverlordCard>();
        }

        /// <summary>
        /// Gets the cards that the overlord currently has in hand..
        /// </summary>
        public List<OverlordCard> Hand
        {
            get
            {
                return hand;
            }
        }

        public List<OverlordCard> Deck
        {
            get
            {
                return deck;
            }
        }

        public int Graveyard
        {
            get
            {
                return graveyard.Count;
            }
        }

        /// <summary>
        /// Gets the cards that the overlord has put in power.
        /// </summary>
        public List<OverlordCard> Powers
        {
            get
            {
                return powers;
            }
        }

        /// <summary>
        /// Gets the number of threattokens the overlord has.
        /// </summary>
        public int ThreatTokens { get; set; }
    }
}
