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
    public class Dice
    {
        #region Static Dice Loading

        private static Dictionary<EDice, Dice> diceDictionary = LoadDice();

        private static Dictionary<EDice, Dice> LoadDice()
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("dice.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            Dictionary<EDice, Dice> dice = new Dictionary<EDice, Dice>();
            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                string[] data = line.Split(' ');

                EDice eDice;
                EDice.TryParse(data[0], false,out eDice);

                int[][] sides = AddSides(data);

                dice[eDice] = new Dice(eDice, sides);
            }

            return dice;
        }

        private static int[][] AddSides(string[] data)
        {
            int[][] sides = new int[6][];
            for (int side = 0; side < 6; side++)
            {
                sides[side] = new int[4];

                // If side is X
                if (data[side + 1].Equals("X"))
                {
                    sides[side][0] = 0;
                    sides[side][1] = 0;
                    sides[side][2] = 0;
                    sides[side][3] = 1;
                    continue;
                }

                // If not 'X'
                string[] sideArray = data[side + 1].Split('/');
                for (int value = 0; value < 3; value++)
                {
                    sides[side][value] = int.Parse(sideArray[value]);
                }
                sides[side][3] = 0;
            }
            return sides;
        }

        #endregion

        #region Static Getters
        public static Dice GetDice(EDice dice)
        {
            return diceDictionary[dice];
        }

        public static Dice GetDice(String dice)
        {
            EDice d;
            EDice.TryParse(dice, false, out d);
            return GetDice(d);
        }

        #endregion
        
        #region Fields
        private int[][] sides;

        private EDice color;

        private int activeSideIndex;

        private int[] activeSide;
        #endregion

        #region Properties

        /// <summary>
        /// Returns the up side of the dice
        /// The 4 long array are these values:
        /// Range, Damage, Surges, X´s
        /// </summary>
        public int[] ActiveSide
        {
            get
            {
                activeSide = sides[activeSideIndex];
                return activeSide;
            }
        }

        public int SideIndex
        {
            get
            {
                return activeSideIndex;
            }
        }

        #endregion

        #region Initialization

        private Dice(EDice color, int[][] sides)
        {
            this.color = color;
            this.sides = sides;
            this.activeSide = sides[0];
        }
        #endregion

        #region Method

        /// <summary>
        /// Rolls the dice to a random side
        /// </summary>
        public void RollDice()
        {
            Random r = new Random();
            activeSide = sides[r.Next(6)];
        }

        /// <summary>
        /// Force the dice to a side
        /// </summary>
        /// <param name="side">
        /// The side to be up
        /// </param>
        public void ChangeSide(int side)
        {
            activeSide = sides[side];
        }

        #endregion
    }
}
