// -----------------------------------------------------------------------
// <copyright file="Treasure.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Treasure
    {
        #region Fields

        private int id;

        private string name;

        private EquipmentRarity rarity;

        private Equipment equipment;

        private Potion potion;

        private int coin;

        private Treasure treasure;

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
        /// Gets the name of the treasure
        /// </summary>
        public string Name
        {
            get
            {
                return name;
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
        /// Gets the equipment of the treasure
        /// This is none, if there is no equipment
        /// </summary>
        public Equipment Equipment
        {
            get
            {
                return equipment;
            }
        }

        /// <summary>
        /// Gets the potion from the treasure
        /// This is none, if there is no equipment
        /// </summary>
        public Potion Potion
        {
            get
            {
                return potion;
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
        /// Gets a new treasure
        /// This is used for treasure caches
        /// This is null if there is no new treasure
        /// </summary>
        public Treasure NewTreasure
        {
            get
            {
                return treasure;
            }
        }

        #endregion

        #region Initialization


        public Treasure(int id, string name, EquipmentRarity rarity, Equipment equipment, Potion potion, int coin)
        {
            this.id = id;
            this.name = name;
            this.rarity = rarity;
            this.equipment = equipment;
            this.potion = potion;
            this.coin = coin;
        }

        #endregion
    }
}
