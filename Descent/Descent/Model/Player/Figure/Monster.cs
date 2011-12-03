// -----------------------------------------------------------------------
// <copyright file="Monster.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Monster : Figure
    {
        private static List<Monster> monsters = LoadMonsters();
 
        private static List<Monster> LoadMonsters()
        {
            
        } 

        public static Monster GetMonster(int id)
        {
            
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
        public Monster(int id, string name)
            : base(id, name)
        {
        }
    }
}
