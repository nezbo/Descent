
namespace Descent.Model
{
    using System;
    using System.Diagnostics.Contracts;

    using Descent.GUI;

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
        /// <summary>
        /// A Red dice
        /// </summary>
        R,

        /// <summary>
        /// A White dice
        /// </summary>
        W,

        /// <summary>
        /// A Blue dice
        /// </summary>
        U,

        /// <summary>
        /// A Green dice
        /// </summary>
        G,

        /// <summary>
        /// A Yellow dice
        /// </summary>
        Y,

        /// <summary>
        /// A Black dice
        /// </summary>
        B
    }
    #endregion

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Dice : Drawable
    {
        #region Fields
        private int[][] sides;

        private EDice color;

        private int activeSideIndex;

        private Texture2D[] textures;

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
        /// Gets or sets the index of the upside
        /// </summary>
        public int SideIndex
        {
            get
            {
                return activeSideIndex;
            }

            set
            {
                Contract.Requires(value > 5 ? Color == EDice.B : true);
                activeSideIndex = value;
            }
        }

        /// <summary>
        /// Gets the color of the dice
        /// </summary>
        public EDice Color
        {
            get
            {
                return color;
            }
        }

        /// <summary>
        /// Gets the texture of the current side of the dice
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return textures[activeSideIndex];
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <param name="sides">
        /// The sides.
        /// </param>
        /// <param name="textures">
        /// The textures.
        /// </param>
        public Dice(EDice color, int[][] sides, Texture2D[] textures)
        {
            this.color = color;
            this.sides = sides;
            this.textures = textures;
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


        /// <summary>
        /// Returns a copy of the Dice
        /// </summary>
        /// <returns></returns>
        public Dice Clone()
        {
            return new Dice(color, sides, textures);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Dice)) return false;
            Dice d = (Dice)obj;
            if (d.ActiveSide == ActiveSide && d.Color == Color && d.SideIndex == SideIndex) return true;
            return false;
        }

        #endregion
    }
}
