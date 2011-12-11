
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Descent.Model.Event;

    using Microsoft.Xna.Framework;

    #region Enums
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
        Potion,

        /// <summary>
        /// Shield can be used to protect in attacks.
        /// </summary>
        Shield
    }

    /// <summary>
    /// A set of all 
    /// </summary>
    public enum EquipmentRarity
    {
        Common,
        Bronze,
        Silver,
        Gold
    }
    #endregion

    /// <summary>
    /// Equipment can be worn by the hero
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Equipment
    {

        #region Fields

        private int id;
        private bool tapped = false;
        private string name;
        private EquipmentType type;
        private EquipmentRarity rarity;
        private EAttackType attackType;
        private int buyPrice;
        private List<SurgeAbility> surgeAbilities;
        private int hands;
        private List<Ability> abilities;
        private List<Dice> dice; 
        private bool equipped = false;

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the unique ID of the equipment
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the equipment is tapped / used
        /// </summary>
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

        public EAttackType AttackType
        {
            get
            {
                return attackType;
            }
        }

        /// <summary>
        /// Gets the rarity of an equipment
        /// </summary>
        public EquipmentRarity Rarity
        {
            get
            {
                return rarity;
            }
        }

        /// <summary>
        /// Gets the surge abilities that the weapon has
        /// </summary>
        public List<SurgeAbility> SurgeAbilities
        {
            get
            {
                return surgeAbilities;
            }
        }

        /// <summary>
        /// Gets the number of hands it takes to wield
        /// </summary>
        public int Hands
        {
            get
            {
                return hands;
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

        /// <summary>
        /// Gets the list of abilities on the equipment
        /// </summary>
        public List<Ability> Abilities
        {
            get
            {
                return abilities;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the equipment
        /// is equipped to a hero.
        /// </summary>
        public bool Equipped
        {
            get
            {
                return equipped;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name of the equipment
        /// </param>
        /// <param name="type">
        /// The equipments type
        /// </param>
        /// <param name="attackType">
        /// The attack Type.
        /// </param>
        /// <param name="rarity">
        /// The rarity of the equipment
        /// </param>
        /// <param name="buyPrice">
        /// The buy price of the equipment
        /// This is 0 if the equipments rarity is not common
        /// </param>
        /// <param name="surgeAbilities">
        /// The surge abilities, if the equipment is a weapon
        /// </param>
        /// <param name="hands">
        /// The number of hands it takes to wield, if the equipment is a weapon
        /// </param>
        /// <param name="abilities">
        /// The abilities.
        /// </param>
        public Equipment(int id, string name, EquipmentType type, EAttackType attackType, EquipmentRarity rarity, int buyPrice, List<SurgeAbility> surgeAbilities, int hands, List<Ability> abilities, List<Dice> dice)
        {
            Contract.Requires(surgeAbilities != null);
            Contract.Requires(abilities != null);
            this.id = id;
            this.name = name;
            this.type = type;
            this.attackType = attackType;
            this.rarity = rarity;
            this.buyPrice = rarity == EquipmentRarity.Common ? buyPrice : 0;
            this.surgeAbilities = surgeAbilities;
            this.hands = hands;
            this.abilities = abilities;
            this.dice = dice ?? new List<Dice>();
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
            Contract.Requires(!Equipped);
            Contract.Ensures(Equipped);
            /*
            Contract.Ensures(
                this.type == EquipmentType.Weapon ? 
                hero.Inventory.Weapon.Equals(this) :
                    this.type == EquipmentType.Armor ?
                    hero.Inventory.Armor.Equals(this) :
                        this.type == EquipmentType.Other ?
                        hero.Inventory.OtherItems.Contains(this) :
                            this.type == EquipmentType.Potion && hero.Inventory.Potions.Contains(this));
             * */
            //TODO: Code to pass abilities on?
            hero.DiceContribution += diceContribution;
            equipped = true;
        }

        /// <summary>
        /// The equipment will unattach from a hero
        /// </summary>
        /// <param name="hero">
        /// The hero to 
        /// </param>
        public void UnequipFromHero(Hero hero)
        {
            Contract.Requires(Equipped);
            Contract.Ensures(!Equipped);
            //TODO: Code to take abilities back!
            equipped = false;
        }

        /// <summary>
        /// Returns a clone of the equipment.
        /// The data, and the index will be the same, 
        /// but the pointer to the object itself will be different
        /// </summary>
        /// <returns>
        /// The clone
        /// </returns>
        public Equipment Clone()
        {
            return new Equipment(
                id, 
                name, 
                type, 
                attackType, 
                rarity, 
                buyPrice, 
                surgeAbilities.Select(e => e).ToList(), 
                hands, 
                abilities.Select(e => e).ToList(),
                dice.Select(d => d).ToList());
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Equipment)) return false;
            if (((Equipment)obj).Id == Id) return true;
            return false;
        }

        private List<Dice> diceContribution()
        {
            return dice;
        }
        #endregion
    }
}
