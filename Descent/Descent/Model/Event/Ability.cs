﻿
namespace Descent.Model.Event
{
    using System;

    using Descent.Model.Player;
    using Descent.Model.Player.Figure;

    public enum AbilityBonus
    {
        None,
        Armor,
        Aura,
        Breath,
        Burn,
        Command,
        Damage,
        Fear,
        Fly,
        Grapple,
        Knockback,
        Pierce,
        Poison,
        QuickShot,
        Range,
        Reach,
        Sorcery,
        Stun,
        Surge,
        Sweep,
        Undying,
        Web
    }

    /// <summary>
    /// Any ability, that have an effect on figures, heroes and the overlord.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Ability
    {
        #region Static

        /// <summary>
        /// Creates an ability by parsing a string
        /// </summary>
        /// <param name="abilityString">
        /// An ability as a string
        /// </param>
        /// <returns>
        /// An ability
        /// </returns>
        public static Ability GetAbility(string abilityString)
        {
            Ability ability = new Ability();

            if (abilityString == null || abilityString == string.Empty) return ability;

            string[] data = abilityString.Split(' ');

            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case "When":
                        ability.triggered = true;
                        break;
                    case "MakingAttacking":
                        ability.trigger += ability.WhenAttacking;
                        break;
                    case "IfType":
                        EAttackType.TryParse(data[++i], true, out ability.type);
                        ability.trigger += ability.IfType;
                        break;
                    case "Armor":
                        ability.bonus = AbilityBonus.Armor;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Aura":
                        ability.bonus = AbilityBonus.Aura;
                        break;
                    case "Breath":
                        ability.bonus = AbilityBonus.Breath;
                        break;
                    case "Burn":
                        ability.bonus = AbilityBonus.Burn;
                        break;
                    case "Command":
                        ability.bonus = AbilityBonus.Command;
                        break;
                    case "Damage":
                        ability.bonus = AbilityBonus.Damage;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Fear":
                        ability.bonus = AbilityBonus.Fear;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Fly":
                        ability.bonus = AbilityBonus.Fly;
                        break;
                    case "Grapple":
                        ability.bonus = AbilityBonus.Grapple;
                        break;
                    case "Knockback":
                        ability.bonus = AbilityBonus.Grapple;
                        break;
                    case "Pierce":
                        ability.bonus = AbilityBonus.Pierce;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Poison":
                        ability.bonus = AbilityBonus.Poison;
                        break;
                    case "QuickShot":
                        ability.bonus = AbilityBonus.QuickShot;
                        break;
                    case "Range":
                        ability.bonus = AbilityBonus.Range;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Reach":
                        ability.bonus = AbilityBonus.Reach;
                        break;
                    case "Sorcery":
                        ability.bonus = AbilityBonus.Sorcery;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Stun":
                        ability.bonus = AbilityBonus.Stun;
                        break;
                    case "Surge":
                        ability.bonus = AbilityBonus.Surge;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Sweep":
                        ability.bonus = AbilityBonus.Sweep;
                        break;
                    case "Undying":
                        ability.bonus = AbilityBonus.Undying;
                        break;
                }
            }



            return ability;
        }

        private static Func<bool> GetTrigger(string trigger, Ability ability)
        {
            bool triggerFunc;

            if (trigger.StartsWith("WhenAttacking"))
            {
                return ability.WhenAttacking;
            }

            return isTrue;
        }

        private static bool isTrue()
        {
            return true;
        }

        #endregion

        #region Fields

        private Figure figure = null;

        private bool triggered = false;

        private Func<bool> trigger;

        private AbilityBonus bonus;

        private int amount;

        private EAttackType type;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the ability is 
        /// triggered by something, or always active?
        /// </summary>
        public bool Triggered
        {
            get
            {
                return triggered;
            }
        }

        public bool Available
        {
            get
            {
                return !Triggered || trigger.Invoke();
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Applys the ability to a figure
        /// </summary>
        /// <param name="figure">
        /// The figure to apply the figure to
        /// </param>
        public void Apply(Figure figure, bool remove = false)
        {
            this.figure = figure;
            if (!triggered || trigger.Invoke())
            {
                switch (bonus)
                {
                    case AbilityBonus.Damage:
                        if (!remove) figure.DamageContribution += IntBonus;
                        else figure.DamageContribution -= IntBonus;
                        break;
                    case AbilityBonus.Pierce:
                        if (!remove) figure.PierceContribution += IntBonus;
                        else figure.PierceContribution -= IntBonus;
                        break;
                    case AbilityBonus.Range:
                        if (!remove) figure.RangeContribution += IntBonus;
                        else figure.RangeContribution -= IntBonus;
                        break;
                    case AbilityBonus.Surge:
                        if (!remove) figure.SurgeContribution += IntBonus;
                        else figure.SurgeContribution -= IntBonus;
                        break;
                    case AbilityBonus.QuickShot:
                        break;
                    case AbilityBonus.Armor:
                        if (!remove) figure.ArmorContribution += IntBonus;
                        else figure.ArmorContribution -= IntBonus;
                        break;
                }
            }
        }

        int IntBonus()
        {
            return amount;
        }

        void QuickShot()
        {
            // TODO: After calculating number of attacks, double it
        }

        bool WhenAttacking()
        {
            // TODO: A trigger that returns true when attacking
            return true;
        }

        bool IfType()
        {
            return figure.AttackType.Equals(type);
        }



        #endregion

        #region Methods

        /// <summary>
        /// Prints an ability as a 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (amount > 0 ? "+" + amount + " " : string.Empty) + bonus.ToString();
        }

        #endregion
    }
}
