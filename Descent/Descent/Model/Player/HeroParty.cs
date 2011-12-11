
using Descent.Model.Board;

namespace Descent.Model.Player
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Descent.Model.Player.Figure;

    /// <summary>
    /// A party of heroes
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class HeroParty
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeroParty"/> class.
        /// </summary>
        public HeroParty()
        {
            Heroes = new Dictionary<int, Hero>();
            RuneKeys = new HashSet<RuneKey>();
        }

        #region Properties

        /// <summary>
        /// Gets the heroes of players. Key is player id.
        /// Can I have all hero and id's as a map?
        /// </summary>
        public Dictionary<int, Hero> Heroes { get; private set; }

        /// <summary>
        /// Gets all ids of the hero players.
        /// Can I have a list of all heroes id?
        /// </summary>
        public int[] PlayerIds
        {
            get { return Heroes.Keys.ToArray(); }
        }

        /// <summary>
        /// Gets the runekeys of the hero party.
        /// Can I have a list of all rune keys the heroes have?
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
        /// Is the pool of conquest tokens empty?
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
        /// Add 'this' hero to the list of heroes in the HeroParty!
        /// </summary>
        /// <param name="playerId">PlayerId of the player that holds the Hero.</param>
        /// <param name="hero">The hero to add.</param>
        public void AddHero(int playerId, Hero hero)
        {
            Contract.Requires(hero != null);
            Contract.Ensures(AllHeroes.Contains(hero));
            Heroes.Add(playerId, hero);
        }

        /// <summary>
        /// Adds 
        /// </summary>
        /// <param name="runeKey">
        /// The rune key.
        /// </param>
        public void AddRuneKey(RuneKey runeKey)
        {
            Contract.Ensures(HasRuneKey(runeKey));
            RuneKeys.Add(runeKey);
        }

        /// <summary>
        /// Gets whether the party has a already picked up the rune key
        /// </summary>
        /// <param name="runeKey">
        /// The rune key.
        /// </param>
        /// <returns>
        /// True if the party has the key
        /// </returns>
        [Pure]
        public bool HasRuneKey(RuneKey runeKey)
        {
            return RuneKeys.Contains(runeKey);
        }

        /// <summary>
        /// Fetches the player id for a given Hero if it is
        /// in the party.
        /// </summary>
        /// <param name="hero">The hero we want the player id for.</param>
        /// <returns>The player id that controls the given hero, if it isn't found -1.</returns>
        public int GetPlayerId(Hero hero)
        {
            foreach (KeyValuePair<int, Hero> kv in Heroes)
            {
                if (kv.Value.Equals(hero)) return kv.Key;
            }
            return -1;
        }

        /// <summary>
        /// The invariant of the HeroParty class
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(NumberOfHeroes >= 0 && NumberOfHeroes <= 4);
        }
        #endregion
    }
}
