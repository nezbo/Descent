// -----------------------------------------------------------------------
// <copyright file="Monster.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Descent.GUI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Monster : Figure, Drawable
    {
        #region Static Loading
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
                int armor = int.Parse(data[5]);
                EAttackType type = (data[6].Equals("MELEE")
                                       ? EAttackType.MELEE
                                       : (data[5].Equals("MAGIC") ? EAttackType.MAGIC : EAttackType.RANGED));

                List<Dice> attackDice = (
                    from string dice
                        in data[7].Split(' ')
                    select Dice.GetDice(dice)).ToList();

                monsters.Add(new Monster(id, name, master, speed, health, armor, type, attackDice));
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
        #endregion

        #region Fields

        private bool isMaster;

        private EAttackType attackType;

        private Texture2D texture;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the monster is a master
        /// </summary>
        public bool IsMaster
        {
            get
            {
                return isMaster;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            private set
            {
                texture = value;
            }
        }

        #endregion

        #region Initialization
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
        /// <param name="armor">
        /// The armor.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="dice">
        /// The dice.
        /// </param>
        private Monster(int id, string name, bool master, int speed, string health, int armor, EAttackType type, List<Dice> dice)
            : base(id, name)
        {
            isMaster = master;
            Speed = speed;
            MaxHealth = int.Parse(health.Split('/')[2]); // TODO: Somehow we need to determine how many players there exist.
            Armor = armor;
            attackType = type;
            DiceForAttack = dice;
            texture = null;//FullModel.Game.Content.Load<Texture2D>("Images/Monsters/" + id);
            System.Diagnostics.Debug.WriteLine("Images/Monsters/" + id + " - " + name);
        }
        #endregion
    }
}
