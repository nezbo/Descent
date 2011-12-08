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
            Hand = new List<OverlordCard>();
            Power = new List<OverlordCard>();
        }

        /// <summary>
        /// Gets the cards that the overlord currently has in hand..
        /// </summary>
        public List<OverlordCard> Hand { get; private set; }

        /// <summary>
        /// Gets the cards that the overlord has put in power.
        /// </summary>
        public List<OverlordCard> Power { get; private set; }

        /// <summary>
        /// Gets the number of threattokens the overlord has.
        /// </summary>
        public int ThreatTokens { get; set; }
    }
}
