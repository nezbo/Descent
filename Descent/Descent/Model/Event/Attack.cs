// -----------------------------------------------------------------------
// <copyright file="AttackStruct.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Attack
    {
        public delegate T Bonus<T>();

        public event Bonus<int> DamageContribution;

        public event Bonus<int> RangeContribution;

        public event Bonus<int> SurgeContribution;

        public event Bonus<int> PierceContribution;

        private Hero hero;

        private Point attackingSquare;

        /// <summary>
        /// Gets or sets the hero that is attacking
        /// </summary>
        public Hero AttackingHero
        {
            get
            {
                return hero;
            }

            set
            {
                hero = value;
            }
        }

        /// <summary>
        /// Gets or sets the point to the square the hero is attacking
        /// </summary>
        public Point AttackingSquare
        {
            get
            {
                return attackingSquare;
            }

            set
            {
                attackingSquare = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="attackingHero">
        /// The attacking hero
        /// </param>
        /// <param name="attackingSquare">
        /// The point to the square the hero is attacking
        /// </param>
        public Attack(Hero attackingHero, Point attackingSquare)
        {
            this.hero = attackingHero;
            this.attackingSquare = attackingSquare;
        }
    }
}
