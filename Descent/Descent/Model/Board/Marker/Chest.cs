// -----------------------------------------------------------------------
// <copyright file="Chest.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board.Marker
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Descent.Model.Player.Figure.HeroStuff;

	/// <summary>
	/// A chest with treasures, coins and tokens
	/// </summary>
		/// <author>
		/// Jonas Breindahl (jobre@itu.dk)
		/// </author>
	public class Chest
	{
		#region Fields

		private int id;

		private EquipmentRarity rarity;

		private int tokens;

		private int coin;

		private int curses;

		private int treasures;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the unique ID of the chest
		/// </summary>
		public int Id
		{
			get
			{
				return id;
			}
		}

		/// <summary>
		/// Gets the rarity of the treasure
		/// </summary>
		public EquipmentRarity Rarity
		{
			get
			{
				return rarity;
			}
		}

		/// <summary>
		/// Gets the number of conquest tokens in the chest,
		/// the party gets this number of tokens.
		/// </summary>
		public int ConquestTokens
		{
			get
				{
					return tokens;
				}
		}

		/// <summary>
		/// Gets the number of coins in the treasure
		/// This is 0 if there is not any
		/// </summary>
		public int Coin
		{
			get
			{
				return coin;
			}
		}

		/// <summary>
		/// Gets the number of curses in the chest,
		/// the overlord gets a threat token for each hero
		/// </summary>
		public int Curses
		{
			get
			{
				return curses;
			}   
		}

		/// <summary>
		/// Gets the number of treasures in the chest,
		/// each hero gets x number of the chests rarity
		/// </summary>
		public int Treasures
		{
			get
			{
				return treasures;
			}
		}

		#endregion

		#region Initialization

		/// <summary>
		/// Initializes a new instance of the <see cref="Chest"/> class.
		/// </summary>
		/// <param name="id">
		/// The id of the chest
		/// </param>
		/// <param name="rarity">
		/// The rarity of the chest (copper, silver and gold)
		/// </param>
		/// <param name="conquestTokens">
		/// The conquest tokens in the chest
		/// </param>
		/// <param name="coin">
		/// The coins in the chest
		/// </param>
		/// <param name="curses">
		/// The curses in the chest
		/// </param>
		/// <param name="treasures">
		/// The treasures in the chest
		/// </param>
		public Chest(int id, EquipmentRarity rarity, int conquestTokens, int coin, int curses, int treasures)
		{
			this.id = id;
			this.rarity = rarity;
			this.tokens = conquestTokens;
			this.coin = coin;
			this.curses = curses;
			this.treasures = treasures;
		}

		#endregion
	}
}
