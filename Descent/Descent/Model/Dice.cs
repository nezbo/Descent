// -----------------------------------------------------------------------
// <copyright file="Dice.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #region EDice Enum
    /// <summary>
    /// The 6 kinds of dice in the game
    /// R = Red (Melee)
    /// W = White (Magic)
    /// U = blUe (Ranged)
    /// G = Green
    /// </summary>
    public enum EDice
    {
        R,

        W,

        U,

        G,

        Y,

        B
    }
    #endregion

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Dice
    {
        #region Fields
        private int[][] sides;

        private EDice color;

        private int activeSideIndex;

        private Texture2D Sides;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the up side of the dice
        /// The 4 long array are these values:
        /// Range, Damage, Surges, X´s
        /// </summary>
        public int[] ActiveSide
        {
            get
            {
                return sides[activeSideIndex];
            }
        }

        /// <summary>
        /// Gets and sets the index of the upside
        /// </summary>
        public int SideIndex
        {
            get
            {
                return activeSideIndex;
            }

            set
            {
                activeSideIndex = value;
            }
        }

        #endregion

        #region Initialization

        public Dice(EDice color, int[][] sides, Texture2D[] textures)
        {
            this.color = color;
            this.sides = sides;
        }
        #endregion

        #region Method

        /// <summary>
        /// Rolls the dice to a random side
        /// </summary>
        public void RollDice()
        {
            Random r = new Random();
            activeSideIndex = r.Next(6);
        }

        #endregion
    }
}
