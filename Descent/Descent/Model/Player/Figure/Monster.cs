// -----------------------------------------------------------------------
// <copyright file="Monster.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Descent.GUI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Monster : Figure, Drawable
    {
        /// <summary>
        /// The list of unique standard monsters
        /// </summary>
        private static List<Monster> monsters = LoadMonsters();
 
        /// <summary>
        /// Loads the monsters from the file monsters.txt
        /// </summary>
        /// <returns>
        /// The list of loaded monsters
        /// </returns>
        private static List<Monster> LoadMonsters()
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream("monsters.txt"));

            int n = int.Parse(reader.ReadLine());
            string line;

            List<Monster> monsters = new List<Monster>();
            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                string[] data = line.Split(',');

                int id = int.Parse(data[0]);
                string name = data[1].Substring(1, data[1].Length - 2);
                bool master = bool.Parse(data[2]);
                int speed = int.Parse(data[3]);
                string health = data[4];
                EAttackType type = (data[5].Equals("MELEE")
                                       ? EAttackType.MELEE
                                       : (data[5].Equals("MAGIC") ? EAttackType.MAGIC : EAttackType.RANGED));
               
                List<Dice> attackDice = (
                    from string dice 
                        in data[6].Split(' ') 
                    select Dice.GetDice(dice)).ToList();

                monsters.Add(new Monster(id, name, master, speed, health, type, attackDice));
            }
            return monsters;
        }

        /// <summary>
        /// Gets the standard instance of 
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// The standard id of the mosnter
        /// <returns>
        /// The monster, as a new monster
        /// </returns>
        public static Monster GetMonster(int id)
        {
            return monsters.Single(monster => monster.Id == id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class.
        /// </summary>
        /// <param name="id">
        /// The monster id
        /// This is unique for all monsters, even several instances of
        /// the same monster.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="master">
        /// The master.
        /// </param>
        /// <param name="speed">
        /// The speed.
        /// </param>
        /// <param name="health">
        /// The health.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="dice">
        /// The dice.
        /// </param>
        private Monster(int id, string name, bool master, int speed, string health, EAttackType type, List<Dice> dice)
            : base(id, name)
        {
           
        }

        public Texture2D Texture
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
