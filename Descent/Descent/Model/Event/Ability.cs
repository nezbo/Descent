
namespace Descent.Model.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Messaging.Events;
    using Descent.Model.Player.Figure;
    using Descent.State;

    public enum AbilityBonus
    {
        Damage,
        Range,
        Pierce,
        Surge,
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

        private bool triggered = false;

        private Func<bool> trigger;

        private AbilityBonus bonus;

        private int amount;

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
            switch (bonus)
            {
                case AbilityBonus.Damage:
                    if (!triggered || trigger.Invoke())
                    {
                        figure.DamageContribution += new Player.Figure.Bonus<int>(IntBonus);
                    }
                    break;
                case AbilityBonus.Pierce:
                    if (!triggered || trigger.Invoke())
                    {
                        figure.PierceContribution += IntBonus;
                    }
                    break;
                case AbilityBonus.Range:
                    if (!triggered || trigger.Invoke())
                    {
                        figure.RangeContribution += IntBonus;
                    }
                    break;
                case AbilityBonus.Surge:
                    if (!triggered || trigger.Invoke())
                    {
                        figure.SurgeContribution += IntBonus;
                    }
                    break;
            }
        }

        int IntBonus()
        {
            return amount;
        }

        bool WhenAttacking()
        {
            return true;
        }
        #endregion
    }
}
