
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

		/// <summary>
		/// Gets Number of heroes yet to act.
		/// How many heroes have yet to take their turn?
		/// </summary>
		public int NumberOfHeroesYetToAct
		{
			get
			{
				Contract.Ensures(Contract.Result<int>() >= 0);
				Contract.Ensures(Contract.Result<int>() <= NumberOfHeroes);
				
				return heroesYetToAct.Count;
			}
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

		private List<Hero> heroesInHeroParty = new List<Hero>(); 
		private List<Hero> heroesYetToAct = new List<Hero>();
		private int conquestTokens = 0;

		#endregion FIELDS

		#region Initialization

		#endregion 

		#region Methods

		/// <summary>
		/// Has 'this' heroes yet to take their turn? 
		/// </summary>
		/// <param name="hero">
		/// The hero
		/// </param>
		/// <returns>
		/// True if the hero has already had his turn
		/// </returns>
		public bool HasHeroActedYet(Hero hero)
		{
			Contract.Requires(hero != null, "Hero was null");
			return !heroesYetToAct.Contains(hero);
		}

	    /// <summary>
        /// Removes the hero from the list of heroes yet to act
	    /// </summary>
	    /// <param name="hero">
	    /// The hero that has now acted
	    /// </param>
	    public void HeroHasActed(Hero hero)
        {
            Contract.Requires(hero != null);
            Contract.Requires(!HasHeroActedYet(hero));
            Contract.Ensures(HasHeroActedYet(hero));
            Contract.Ensures(NumberOfHeroesYetToAct == Contract.OldValue(NumberOfHeroesYetToAct) - 1);

            heroesYetToAct.Remove(hero);
        }

	    /// <summary>
	    /// Resets the list of heroes yet to act
        /// Reset list of heroes yet to act!
	    /// </summary>
	    public void ResetYetToAct()
        {
            Contract.Requires(NumberOfHeroesYetToAct == 0);
            Contract.Ensures(NumberOfHeroesYetToAct == NumberOfHeroes);
	        heroesYetToAct = heroesInHeroParty;
        }

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
		#endregion METHODS 
	}
}
