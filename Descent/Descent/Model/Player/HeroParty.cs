
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
		#region Fields

        private List<Hero> heroesInHeroParty = new List<Hero>();
        private int conquestTokens = 0;
        private HashSet<RuneKey> runeKeys = new HashSet<RuneKey>();

		/// <summary>
		/// Gets numberOfHeroes.
		/// How many heroes are in the HeroParty?
		/// </summary>
		public int NumberOfHeroes
		{
			get
			{
				return heroesInHeroParty.Count;
			}
		}

	    public Hero[] AllHeroes
	    {
	        get { return heroesInHeroParty.ToArray(); }
	    }

	    /// <summary>
		/// Gets or sets ConquestTokens.
		/// How many conquest tokens do the players have?
		/// </summary>
		public int ConquestTokens
		{
			get
			{
				return conquestTokens;
			}

			private set
			{
				conquestTokens = value;
			}
		}

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

		#endregion FIELDS

		#region Initialization

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

        public void AddHero(Hero hero)
        {
            Contract.Requires(hero != null);
            Contract.Ensures(AllHeroes.Contains(hero));
            heroesInHeroParty.Add(hero);
        } 

        public void AddRuneKey(RuneKey runeKey)
        {
            Contract.Ensures(HasRuneKey(runeKey));
            runeKeys.Add(runeKey);
        }

        public bool HasRuneKey(RuneKey runeKey)
        {
            return runeKeys.Contains(runeKey);
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

		#endregion METHODS 
	}
}
