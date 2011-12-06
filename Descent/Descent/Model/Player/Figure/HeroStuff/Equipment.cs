
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A set of all types of equipment
    /// </summary>
    public enum EquipmentType
    {
        /// <summary>
        /// An equipment of type weapon, that can be used
        /// for attacks, and have surge abilites
        /// </summary>
        Weapon,

        /// <summary>
        /// An equipment of type armor, that give armor,
        /// and different abilities that prevent damage
        /// </summary>
        Armor,

        /// <summary>
        /// Other items that grant different abilities
        /// </summary>
        Other,

        /// <summary>
        /// Potions can be used to heal damage or gain fatigue
        /// </summary>
        Potion
    }

    public enum EquipmentRarity
    {
        Common,
        Bronze,
        Silver,
        Gold
    }

    /// <summary>
    /// Equipment can be worn by the hero
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public abstract class Equipment
    {
        #region Fields

        private bool tapped = false;
        private string name;
        private EquipmentType type;
        private EquipmentRarity rarity;
        private int buyPrice;

        #endregion

        #region Properties

        public bool Tapped
        {
            get
            {
                return tapped;
            }
        }

        /// <summary>
        /// Gets the name of the equipment
        /// What is your name?
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets the type of the equipment
        /// What type of equipment are you?
        /// </summary>
        public EquipmentType Type
        {
            get
            {
                return type;
            }
        }

        public EquipmentRarity Rarity
        {
            get
            {
                return rarity;
            }
        }

        /// <summary>
        /// Gets the buy price of the equipment
        /// </summary>
        public int BuyPrice
        {
            get
            {
                return buyPrice;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the equipment
        /// </param>
        /// <param name="type">
        /// The equipments type
        /// </param>
        /// <param name="rarity">
        /// The rarity of the equipment
        /// </param>
        /// <param name="buyPrice">
        /// The buy price of the equipment
        /// This is 0 if the equipments rarity is not common
        /// </param>
        public Equipment(string name, EquipmentType type, EquipmentRarity rarity, int buyPrice)
        {
            this.name = name;
            this.type = type;
            this.rarity = rarity;
            this.buyPrice = rarity == EquipmentRarity.Common ? buyPrice : 0;
            tapped = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Taps the piece of equipment
        /// </summary>
        public void TapEquipment()
        {
            Contract.Requires(Tapped == false);
            tapped = true;
        }

        /// <summary>
        /// Untaps the piece of equipment,
        /// even if not tapped
        /// </summary>
        public void UntapEquipment()
        {
            tapped = false;
        }

        /// <summary>
        /// The equipment will pass abilities on, so
        /// the hero is able to use them.
        /// </summary>
        /// <param name="hero">
        /// The hero that equips the equipment
        /// </param>
        public void EquipToHero(Hero hero)
        {
            //TODO: Code to pass abilities on?
        }

        /// <summary>
        /// The equipment will unattach from a hero
        /// </summary>
        /// <param name="hero">
        /// The hero to 
        /// </param>
        public void UnequipFromHero(Hero hero)
        {
            //TODO: Code to take abilities back!
        }

        #endregion
    }
}
