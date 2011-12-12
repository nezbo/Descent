
namespace Descent.Model.Player.Figure.HeroStuff
{
    using Descent.Model.Event;

    /// <summary>
    /// A surge ability is an ability with a cost
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class SurgeAbility
    {
        /// <summary>
        /// Takes a string and returns an SurgeAbility instance
        /// </summary>
        /// <param name="surgeAbility">
        /// The surge ability in raw text format
        /// </param>
        /// <returns>
        /// An instance of SurgeAbility
        /// </returns>
        public static SurgeAbility GetSurgeAbility(string surgeAbility)
        {
            string[] data = surgeAbility.Split(new char[] { ' ' }, 2);
            return new SurgeAbility(int.Parse(data[0]), Ability.GetAbility(data[1]));
        }

        #region Fields

        private int cost;

        private Ability ability;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the cost of the ability
        /// </summary>
        public int Cost
        {
            get
            {
                return cost;
            }
        }

        /// <summary>
        /// Gets the ability to be gained if the cost is payed.
        /// </summary>
        public Ability Ability
        {
            get
            {
                return ability;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="SurgeAbility"/> class.
        /// </summary>
        /// <param name="cost">
        /// The cost of the ability
        /// </param>
        /// <param name="ability">
        /// The ability to be bought
        /// </param>
        public SurgeAbility(int cost, Ability ability)
        {
            this.cost = cost;
            this.ability = ability;
        }

        #endregion
    }
}
