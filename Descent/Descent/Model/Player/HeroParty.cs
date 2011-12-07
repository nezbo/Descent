
namespace Descent.Model.Player
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class HeroParty
    {
        #region Fields

        public HeroParty()
        {
            Heroes = new Dictionary<int, Hero>();
        }

        /// <summary>
        /// The heroes of players. Key is player id.
        /// </summary>
        public Dictionary<int, Hero> Heroes { get; set; }

        /// <summary>
        /// Gets numberOfHeroes.
        /// How many heroes are in the HeroParty?
        /// </summary>
        public int NumberOfHeroes
        {
            get
            {
                return Heroes.Count;
            }
        }

        /// <summary>
        /// Return all heroes as an array.
        /// </summary>
        public Hero[] AllHeroes
        {
            get
            {
                return Heroes.Values.ToArray();
            }
        }

        /// <summary>
        /// Gets or sets ConquestTokens.
        /// How many conquest tokens do the players have?
        /// </summary>
        public int ConquestTokens { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsConquestPoolEmpty.
        /// </summary>
        public bool IsConquestPoolEmpty
        {
            get
            {
                Contract.Ensures(Contract.Result<bool>() == (ConquestTokens == 0));
                return ConquestTokens == 0;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add a number of tokens to the pool
        /// Add 'this' number of conquest tokens to the pool of tokens!
        /// </summary>
        /// <param name="tokens">
        /// The number of tokens to be added
        /// </param>
        public void AddConquestTokens(int tokens)
        {
            Contract.Requires(tokens > 0);
            Contract.Ensures(ConquestTokens == Contract.OldValue(ConquestTokens) + tokens);
            ConquestTokens += tokens;
        }

        /// <summary>
        /// Removes a number of tokens from the pool
        /// Remove 'this' number of conquest tokens from the pool of tokens!
        /// </summary>
        /// <param name="tokens">
        /// The number of tokens to be removed, must be possitive
        /// </param>
        public void RemoveConquestTokens(int tokens)
        {
            Contract.Requires(tokens > 0);
            Contract.Ensures(ConquestTokens == Contract.OldValue(ConquestTokens) - tokens);
            ConquestTokens -= tokens;
        }

        /// <summary>
        /// The invariant of the HeroParty class
        /// </summary>
        [ContractInvariantMethod]
        public void ObjectInvariant()
        {
            Contract.Invariant(ConquestTokens >= 0);
            Contract.Invariant(NumberOfHeroes >= 2 && NumberOfHeroes <= 4);
        }
        #endregion 
    }
}
