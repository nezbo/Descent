
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System.Collections.Generic;

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

        private string description;

        private List<Ability> abilities = new List<Ability>(); 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the skill
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        
        /// <summary>
        /// Gets the type of the skill (Melee, Ranged and Magic)
        /// </summary>
        public EAttackType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Gets the textual description of the skill
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Gets the list of abilities that implement the skill
        /// </summary>
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
        /// <param name="description">
        /// The description, the text on the skill
        /// </param>
        /// <param name="abilities">
        /// The abilities of the skill
        /// </param>
        public Skill(string name, EAttackType type, string description, List<Ability> abilities)
        {
            this.name = name;
            this.type = type;
            this.description = description;
            this.abilities = abilities;
        }

        #endregion
    }
}
