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
        public Overlord()
        {
            CardsInDeck = new List<OverlordCard>();
            CardsInPlay = new List<OverlordCard>();
            CardsInDiscard = new List<OverlordCard>();   
        }

        /// <summary>
        /// Gets the cards that the overlord can use, but has not put into play yet.
        /// </summary>
        public List<OverlordCard> CardsInDeck { get; private set; }

        /// <summary>
        /// Gets the cards that the overlord currently has in play/in hand.
        /// </summary>
        public List<OverlordCard> CardsInPlay { get; private set; }

        /// <summary>
        /// Gets the cards that the overlord has used and put in his discard pile.
        /// </summary>
        public List<OverlordCard> CardsInDiscard { get; private set; }

        /// <summary>
        /// Gets the number of threattokens the overlord has.
        /// </summary>
        public int ThreatTokens { get; set; }
    }
}
