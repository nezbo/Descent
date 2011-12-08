
using Descent.Model.Board;

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

        public HeroParty()
        {
            Heroes = new Dictionary<int, Hero>();
            RuneKeys = new HashSet<RuneKey>();
        }

        #region Properties

        /// <summary>
        /// Gets the heroes of players. Key is player id.
        /// </summary>
        public Dictionary<int, Hero> Heroes { get; private set; }

        /// <summary>
        /// Gets all ids of the hero players.
        /// </summary>
        public int[] PlayerIds
        {
            get { return Heroes.Keys.ToArray(); }
        }

        /// <summary>
        /// Gets the runekeys of the hero party.
        /// </summary>
        public HashSet<RuneKey> RuneKeys { get; private set; } 

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
        /// Gets all heroes as an array.
        /// </summary>
        public Hero[] AllHeroes
        {
            get
            {
                return Heroes.Values.ToArray();
            }
        }

        /// <summary>
        /// Gets number of ConquestTokens.
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
            Contract.Ensures(ConquestTokens == Contract.OldValue(ConquestTokens) - tokens || ConquestTokens == 0);
            ConquestTokens -= tokens;
        }

        /// <summary>
        /// Add a hero to the hero party.
        /// </summary>
        /// <param name="playerId">PlayerId of the player that holds the Hero.</param>
        /// <param name="hero">The hero to add.</param>
        public void AddHero(int playerId, Hero hero)
        {
            Contract.Requires(hero != null);
            Contract.Ensures(AllHeroes.Contains(hero));
            Heroes.Add(playerId, hero);
        } 

        public void AddRuneKey(RuneKey runeKey)
        {
            Contract.Ensures(HasRuneKey(runeKey));
            RuneKeys.Add(runeKey);
        }

        public bool HasRuneKey(RuneKey runeKey)
        {
            return RuneKeys.Contains(runeKey);
        }

        /// <summary>
        /// The invariant of the HeroParty class
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(ConquestTokens >= 0);
            Contract.Invariant(NumberOfHeroes >= 0 && NumberOfHeroes <= 4);
        }
        #endregion 
    }
}
