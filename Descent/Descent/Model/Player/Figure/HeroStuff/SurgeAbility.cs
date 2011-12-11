// -----------------------------------------------------------------------
// <copyright file="SurgeAbility.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Model.Event;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SurgeAbility
    {
        /// <summary>
        /// Takes a string and returns an SurgeAbility instance
        /// </summary>
        /// <param name="surgeAbility">
        /// The surge ability in raw text format
        /// </param>
        /// <returns>
        /// An instance of SurgeAbility
        /// </returns>
        public static SurgeAbility GetSurgeAbility(string surgeAbility)
        {
            string[] data = surgeAbility.Split(new char[] { ' ' }, 2);
            return new SurgeAbility(int.Parse(data[0]), Ability.GetAbility(data[1]));
        }

        #region Fields

        private int cost;

        private Ability ability;

        #endregion

        #region Properties

        public int Cost
        {
            get
            {
                return cost;
            }
        }

        public Ability Ability
        {
            get
            {
                return ability;
            }
        }

        #endregion

        #region Initialization

        public SurgeAbility(int cost, Ability ability)
        {
            this.cost = cost;
            this.ability = ability;
        }

        #endregion
    }
}
