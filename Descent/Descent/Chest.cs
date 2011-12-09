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
        /// Gets the unique ID of the treasure
        /// </summary>
        public int ID
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

        public Chest(int id, string name, EquipmentRarity rarity, Equipment equipment, Potion potion, int coin)
        {
            this.id = id;
            this.rarity = rarity;
            this.equipment = equipment;
            this.potion = potion;
            this.coin = coin;
        }

        #endregion
    }
}
