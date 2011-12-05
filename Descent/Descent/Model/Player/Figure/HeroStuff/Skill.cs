// -----------------------------------------------------------------------
// <copyright file="Skill.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Event;

    /// <summary>
    /// A Skill is an ability with a type.
    /// These skills come from special decks of the given type.
    /// </summary>
    public class Skill
    {
        #region Fields

        private string name;

        private EAttackType type;

        private List<Ability> abilities = new List<Ability>(); 

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return name;
            }
        }

        public EAttackType Type
        {
            get
            {
                return type;
            }
        }

        public List<Ability> Abilities
        {
            get
            {
                return abilities;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the skill
        /// </param>
        /// <param name="type">
        /// The type of the skill
        /// </param>
        public Skill(string name, EAttackType type)
        {
            this.name = name;
            this.type = type;
        }

        #endregion
    }
}
