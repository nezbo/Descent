// -----------------------------------------------------------------------
// <copyright file="Ability.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Messaging.Events;
    using Descent.State;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Ability
    {
        #region Static
        public static Ability GetAbility(string ability)
        {
            return new Ability(false, isTrue);
        }

        private static bool GetTrigger(string trigger)
        {
            bool triggerFunc;

            if (trigger.StartsWith("WhenAttacking"))
            {
                //triggerFunc = IfAttacking();
            }

            return false;
        }

        private static bool isTrue()
        {
            return true;
        }

        private static Func<bool> IfAttacking()
        {
            return null;
        }
        #endregion

        #region Fields

        private bool triggered;

        private Func<bool> trigger; 

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
        public Ability(bool isTriggered, Func<bool> trigger)
        {
            this.triggered = isTriggered;
            this.trigger = trigger;
        }
        #endregion
    }
}
