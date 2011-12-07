﻿namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Descent.GUI;
    using Descent.Model.Event;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Effect = Descent.Model.Event.Effect;

    /// <summary>
    /// Any bonus to a hero
    /// </summary>
    /// <typeparam name="T">
    /// The type of the bonus, that defines the returntype
    /// </typeparam>
    /// <returns>
    /// The bonus, of type T
    /// </returns>
    public delegate T Bonus<T>();

    /// <summary>
    /// A generic figure, either a hero or a monster
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public abstract class Figure : Drawable
    {
        #region Events

        /// <summary>
        /// This event contributes to the Max Health of the figure
        /// </summary>
        public event Bonus<int> MaxHealthContribution;

        /// <summary>
        /// This event contributes to the Armor of the figure
        /// </summary>
        public event Bonus<int> ArmorContribution;

        /// <summary>
        /// This event contributes to the speed of the figure
        /// </summary>
        public event Bonus<int> SpeedContribution;

        /// <summary>
        /// This event contributes to the number of attacks of the figure
        /// </summary>
        public event Bonus<int> AttacksLeftContribution;

        /// <summary>
        /// This event contributes lists of dice for making attacks with the figure
        /// </summary>
        public event Bonus<List<Dice>> DiceContribution;

        /// <summary>
        /// This event contributes lists of abilities to the figure
        /// </summary>
        public event Bonus<List<Ability>> AbilityContribution;

        /// <summary>
        /// This event contributes lists of effects to the figure
        /// </summary>
        public event Bonus<List<Effect>> EffectContribution; 

        #endregion

        #region Fields

        private int uniqueID;

        private string name;

        private int maxHealth;

        private int health;

        private int armor;

        private int speed;

        private int speedLeft;

        private int attacksLeft;

        private List<Dice> diceForAttacks = new List<Dice>();

        private List<Ability> abilities = new List<Ability>(); 

        private List<Effect> effects = new List<Effect>();

        private Texture2D texture;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a unique ID of this figure
        /// </summary>
        public int Id
        {
            get
            {
                return uniqueID;
            }
        }

        /// <summary>
        /// Gets the name of the figure
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the max health, including all contributors
        /// Sets the internal value, not including all contributors.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                int total = MaxHealthContribution == null ? 0 : MaxHealthContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return maxHealth + total;
            }

            protected set
            {
                maxHealth = value;
            }
        }

        /// <summary>
        /// Gets the current health of the figure
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
        }

        /// <summary>
        /// Gets the armor of the figure, including all contributors bonus
        /// Sets the internal armor, not including any contributors
        /// </summary>
        public int Armor
        {
            get
            {
                int total = ArmorContribution == null ? 0 : ArmorContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return armor + total;
            }

            protected set
            {
                armor = value;
            }
        }

        /// <summary>
        /// Gets the speed of the figure, included all contributors
        /// Sets the internal speed of the figure, contributors not included
        /// </summary>
        public int Speed
        {
            get
            {
                int total = SpeedContribution == null ? 0 : SpeedContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return speed + total;
            }

            protected set
            {
                speed = value;
            }
        }

        /// <summary>
        /// Gets the total amount of speed left
        /// </summary>
        public int SpeedLeft 
        { 
            get
            {
                return speedLeft;
            }

            private set
            {
                speedLeft = value;
            }
        }

        /// <summary>
        /// Gets the total amount of attacks left, including any contributors
        /// </summary>
        public int AttacksLeft
        {
            get
            {
                int total = AttacksLeftContribution == null ? 0 : AttacksLeftContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return attacksLeft + total;
            }
        }

        /// <summary>
        /// Gets a list of all Dice for attacking, including all contributors
        /// Sets the internal list of Dice, not including contributors
        /// </summary>
        public List<Dice> DiceForAttack
        {
            get
            {
                List<Dice> total = new List<Dice>();
                if (DiceContribution != null)
                {
                    foreach (Bonus<List<Dice>> bonus in DiceContribution.GetInvocationList())
                    {
                        total.AddRange(bonus.Invoke());
                    }
                }

                total.AddRange(this.diceForAttacks);
                return total;
            }

            protected set
            {
                diceForAttacks = value;
            }
        } 

        /// <summary>
        /// Gets the figures list of abilities, including all contributors
        /// Sets the internal list, not including contributors
        /// </summary>
        public List<Ability> Abilities
        {
            get
            {
                List<Ability> total = new List<Ability>();
                if (AbilityContribution != null)
                {
                    foreach (Bonus<List<Ability>> bonus in AbilityContribution.GetInvocationList())
                    {
                        total.AddRange(bonus.Invoke());
                    }
                }

                total.AddRange(abilities);
                return total;
            }

            protected set
            {
                abilities = value;
            }
        }

        /// <summary>
        /// Gets the figures list of effects, including contributors
        /// Sets the figures internal list of effect, external contributors not included
        /// </summary>
        public List<Effect> Effects
        {
            get
            {
                List<Effect> total = new List<Effect>();
                if (EffectContribution != null)
                {
                    foreach (Bonus<List<Effect>> bonus in EffectContribution.GetInvocationList())
                    {
                        total.AddRange(bonus.Invoke());
                    }
                }

                return effects;
            }

            protected set
            {
                effects = value;
            }
        }


        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            protected set
            {
                texture = value;
            }
        }
        
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the figure
        /// </param>
        /// <param name="name">
        /// The name of the figure
        /// </param>
        public Figure(int id, string name)
        {
            this.uniqueID = id;
            this.name = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a number of health to the health total, up to the max health
        /// </summary>
        /// <param name="amount">
        /// The amount to be added
        /// </param>
        public void AddHealth(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(health) - amount < 0 ? 
                Health == 0 : 
                Health == Contract.OldValue(Health) - amount);
            health = (int)MathHelper.Clamp(Health - amount, 0, MaxHealth);
        }

        /// <summary>
        /// Removes a number of health to the health total, down to 0
        /// </summary>
        /// <param name="amount">
        /// The amount to be removed
        /// </param>
        public void RemoveHealth(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(Health) - amount < 0 ?
                health == 0 : 
                health == Contract.OldValue(health) - amount);
            health = (int)MathHelper.Clamp(health - amount, 0, MaxHealth);
        }

        /// <summary>
        /// Adds speed to the speed total
        /// </summary>
        /// <param name="amount">
        /// The amount to be added
        /// </param>
        public void AddSpeed(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(SpeedLeft == Contract.OldValue(SpeedLeft) + amount);
            speedLeft = (int)MathHelper.Clamp(speedLeft + amount, 0, int.MaxValue);
        }

        /// <summary>
        /// Removes speed to the speed total, down to 0
        /// </summary>
        /// <param name="amount">
        /// The amount to be removed
        /// </param>
        public void RemoveSpeed(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(SpeedLeft) - amount < 0 ?
                SpeedLeft == 0 :
                SpeedLeft == Contract.OldValue(SpeedLeft) - amount);
            speedLeft = (int)MathHelper.Clamp(SpeedLeft - amount, 0, int.MaxValue);
        }

        /// <summary>
        /// Adds an ability to the list of abilities for this figure
        /// </summary>
        /// <param name="ability">
        /// The ability to be added
        /// </param>
        public void AddAbility(Ability ability)
        {
            abilities.Add(ability);
        }

        /// <summary>
        /// Gets the type of attack this figure would do if it attacked right now.
        /// </summary>
        /// <returns>
        /// Returns the EAttackType of this figure
        /// </returns>
        public virtual EAttackType AttackType()
        {
            return EAttackType.NONE;
        }

        /// <summary>
        /// Checks that a lot of numbers are zero or 
        /// </summary>
        [ContractInvariantMethod]
        public void ObjectInvariant()
        {
            Contract.Invariant(Name.Length > 0);
            Contract.Invariant(MaxHealth > 0);
            Contract.Invariant(Health >= 0 && Health <= MaxHealth);
            Contract.Invariant(Speed > 0);
            Contract.Invariant(Armor >= 0);
            Contract.Invariant(SpeedLeft >= 0);
            Contract.Invariant(AttacksLeft >= 0);
        }
        #endregion

    }
}
