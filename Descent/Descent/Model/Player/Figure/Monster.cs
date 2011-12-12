// -----------------------------------------------------------------------
// <copyright file="Monster.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Descent.Model.Board;

namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Descent.GUI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A monster, controlled by the Overlord
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Monster : Figure
    {
        #region Fields

        private bool isMaster;

        private EAttackType attackType;

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

        public override EAttackType AttackType
        {
            get
            {
                return attackType;
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
        public Monster(int id, string name, bool master, int speed, int health, int armor, EAttackType type, List<Dice> dice, Rectangle size, Texture2D texture)
            : base(id, name, size)
        {
            isMaster = master;
            Speed = speed;
            MaxHealth = health;
            this.health = health;
            Armor = armor;
            attackType = type;
            DiceForAttack = dice;
            this.Texture = texture;
        }
        #endregion

        #region Methods

        public Monster Clone(int newID)
        {
            return new Monster(newID, Name, isMaster, Speed, MaxHealth, Armor, attackType, new List<Dice>(DiceForAttack), Size, Texture);
        }

        #endregion
    }
}
