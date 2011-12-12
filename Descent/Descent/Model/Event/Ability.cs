
namespace Descent.Model.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.State;

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
    public class Ability
    {
        #region Static

        /// <summary>
        /// Creates an ability by parsing a string
        /// </summary>
        /// <param name="ability"></param>
        /// <returns></returns>
        public static Ability GetAbility(string abilityString)
        {
            // TODO: I am too old for this ... stuff
            string[] data = abilityString.Split(' ');
            Ability ability = new Ability();

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
                    case "Pierce":
                        ability.bonus = AbilityBonus.Pierce;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Range":
                        ability.bonus = AbilityBonus.Range;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "Surge":
                        ability.bonus = AbilityBonus.Surge;
                        ability.amount = int.Parse(data[++i]);
                        break;
                    case "QuickShot":
                        ability.bonus = AbilityBonus.QuickShot;
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

        public void Apply(Figure figure)
        {
            this.figure = figure;
            if (!triggered || trigger.Invoke())
            {
                switch (bonus)
                {
                    case AbilityBonus.Damage:
                        figure.DamageContribution += IntBonus;
                        break;
                    case AbilityBonus.Pierce:
                        figure.PierceContribution += IntBonus;
                        break;
                    case AbilityBonus.Range:
                        figure.RangeContribution += IntBonus;
                        break;
                    case AbilityBonus.Surge:
                        figure.SurgeContribution += IntBonus;
                        break;
                    case AbilityBonus.QuickShot:
                        break;
                    case AbilityBonus.Armor:
                        figure.ArmorContribution += IntBonus;
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
            // TODO: return Player.Instance.StateManager.GameState.CurrentAttack != null && Player.Instance.StateManager.GameState.CurrentPlayer;
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
