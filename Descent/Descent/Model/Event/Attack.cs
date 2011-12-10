﻿// -----------------------------------------------------------------------
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
    /// An attack 
    /// </summary>
    public class Attack
    {
        private Figure figure;

        /// <summary>
        /// Gets or sets the hero that is attacking
        /// </summary>
        public Figure AttackingFigure
        {
            get
            {
                return figure;
            }

            set
            {
                figure = value;
            }
        }

        public int DamageBonus { get; set; }

        public int RangeBonus { get; set; }

        public int SurgeBonus { get; set; }

        public int PierceBonus { get; set; }

        public List<Dice> DiceForAttack { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="attackingHero">
        /// The attacking hero
        /// </param>
        /// <param name="attackingSquare">
        /// The point to the square the hero is attacking
        /// </param>
        public Attack(Figure attackingFigure)
        {
            this.figure = attackingFigure;
        }
    }
}
