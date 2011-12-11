
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
        Damage,
        Range,
        Pierce,
        Surge,
        QuickShot,
        None
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

            if (abilityString.StartsWith("When"))
            {
                ability.trigger = GetTrigger(abilityString, ability);
                ability.triggered = true;
            }

            switch (data[0])
            {
                case "WhenAttacking":
                    ability.trigger += ability.WhenAttacking;
                    ability.triggered = true;
                    break;
                case "IfType":
                    EAttackType.TryParse(data[1], true, out ability.type);
                    ability.trigger += ability.IfType;
                    break;
                case "Damage":
                    ability.bonus = AbilityBonus.Damage;
                    ability.amount = int.Parse(data[1]);
                    break;
                case "Pierce":
                    ability.bonus = AbilityBonus.Pierce;
                    ability.amount = int.Parse(data[1]);
                    break;
                case "Range":
                    ability.bonus = AbilityBonus.Range;
                    ability.amount = int.Parse(data[1]);
                    break;
                case "Surge":
                    ability.bonus = AbilityBonus.Surge;
                    ability.amount = int.Parse(data[1]);
                    break;
                case "QuickShot":
                    ability.bonus = AbilityBonus.QuickShot;
                    break;
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
            figure = figure;
            if (!triggered || trigger.Invoke())
            {
                switch (bonus)
                {
                    case AbilityBonus.Damage:
                        figure.DamageContribution += new Model.Player.Figure.Bonus<int>(IntBonus);
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
            return true;
        }

        bool IfType()
        {
            return figure.AttackType().Equals(type);
        }


        #endregion

        #region Methods

        public override string ToString()
        {
            return "+" + amount + " " + bonus.ToString();
        }

        #endregion
    }
}
