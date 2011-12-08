﻿// -----------------------------------------------------------------------
// <copyright file="Hero.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// A hero, made from a hero-sheet
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Hero : Figure
    {
        #region Events

        /// <summary>
        /// This event contributes to the Max Fatigue of this hero
        /// </summary>
        public event Bonus<int> MaxFatigueContribution; 

        #endregion

        #region Fields

        private int cost;

        private int maxFatigue;
        private int fatigue = 0;

        private Dictionary<EAttackType, int> blackDice; 

        private Dictionary<EAttackType, int> numberOfSkills = new Dictionary<EAttackType, int>(); 
        private Dictionary<EAttackType, List<Skill>>  skills = new Dictionary<EAttackType, List<Skill>>();

        private string abilityText;

        private int hands;

        private readonly Inventory inventory;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the max fatique, including all contributors bonus
        /// Sets the internal value, not including any contributors
        /// </summary>
        public int MaxFatigue
        {
            get
            {
                int total = MaxFatigueContribution == null ? 0 : MaxFatigueContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return maxFatigue + total;
            }

            private set
            {
                maxFatigue = value;
            }
        }

        /// <summary>
        /// Gets the fatigue of the figure
        /// </summary>
        public int Fatigue
        {
            get
            {
                return fatigue;
            }
        }

        /// <summary>
        /// Gets the number of hands the hero have to equip weapons in
        /// </summary>
        public int Hands
        {
            get
            {
                return hands;
            }
        }

        /// <summary>
        /// Gets the inventory of the hero
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the hero
        /// </param>
        /// <param name="name">
        /// The name of the hero
        /// </param>
        /// <param name="numberOfSkills">
        /// The number of skills
        /// </param>
        public Hero(int id, string name, int conquest, int health, int fatigue, int armor, int speed, Dictionary<EAttackType, int> blackDice, Dictionary<EAttackType, int> numberOfSkills, int hands, string text)
            : base(id, name)
        {
            this.cost = conquest;
            this.MaxHealth = health;
            this.MaxFatigue = fatigue;
            this.Armor = armor;
            this.Speed = speed;
            this.blackDice = blackDice;
            this.numberOfSkills = numberOfSkills;
            this.hands = hands;
            abilityText = text;
            inventory = new Inventory(this);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds fatigue to the hero, up to max fatigue
        /// </summary>
        /// <param name="amount">
        /// The amount of fatigue to be added
        /// </param>
        public void AddFatigue(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(fatigue) + amount > MaxFatigue ?
                fatigue == MaxFatigue :
                fatigue == Contract.OldValue(fatigue) + amount);
            fatigue = (int)MathHelper.Clamp(fatigue + amount, 0, MaxFatigue);
        }

        /// <summary>
        /// Removes fatigue from the hero, down to 0
        /// </summary>
        /// <param name="amount">
        /// The amount of fatigue to be removed
        /// </param>
        public void RemoveFatigue(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(amount <= Fatigue);
            Contract.Ensures(
                Contract.OldValue(fatigue) - amount < 0 ?
                fatigue == 0 :
                fatigue == Contract.OldValue(fatigue) - amount);
            fatigue = (int)MathHelper.Clamp(fatigue - amount, 0, MaxFatigue);
        }

        /// <summary>
        /// Adds a skill card to the list of skills
        /// Add 'this' skill!
        /// </summary>
        /// <param name="skill">
        /// The Skill card to be added
        /// </param>
        public void AddSkill(Skill skill)
        {
            skills[skill.Type].Add(skill);
        }

        /// <summary>
        /// Removes a skill card from the list of skills
        /// Remove 'this' skill!
        /// </summary>
        /// <param name="skill">
        /// The Skill card to be removed
        /// </param>
        public void RemoveSkill(Skill skill)
        {
            skills[skill.Type].Remove(skill);
        }

        /// <summary>
        /// The invariant of the Hero class
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(fatigue >= 0 && fatigue <= MaxFatigue);
        }
        #endregion
    }
}
