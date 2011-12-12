
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// A treasure, that can be in a chest, either a 
    /// piece of equipment or a treasure cache
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Treasure
    {
        #region Fields

        private int id;

        private string name;

        private EquipmentRarity rarity;

        private Equipment equipment;

        private int coins;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the unique ID of the treasure
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the name of the treasure
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the rarity of the treasure
        /// </summary>
        public EquipmentRarity Rarity
        {
            get
            {
                return rarity;
            }
        }

        /// <summary>
        /// Gets the equipment of the treasure
        /// This is none, if there is no equipment
        /// </summary>
        public Equipment Equipment
        {
            get
            {
                return equipment;
            }
        }

        /// <summary>
        /// Gets the amount of coins in the treasure
        /// </summary>
        public int Coins
        {
            get
            {
                return coins;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the 
        /// treasure is a treasure cache or an equipment.
        /// </summary>
        public bool IsTreasureCache
        {
            get
            {
                return Name.Equals("Treasure Cache");
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Treasure"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the treasure
        /// </param>
        /// <param name="name">
        /// The name of the treasure
        /// </param>
        /// <param name="rarity">
        /// The rarity of the treasure
        /// </param>
        /// <param name="equipment">
        /// The equipment equipment in the treasure
        /// </param>
        /// <param name="coins">
        /// The amount of coins in the treasure
        /// </param>
        public Treasure(int id, string name, EquipmentRarity rarity, Equipment equipment, int coins)
        {
            this.id = id;
            this.name = name;
            this.rarity = rarity;
            this.equipment = equipment;
            this.coins = coins;
        }

        #endregion

        /// <summary>
        /// Checks whether an equipment is always legal
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Coins >= 0);
        }
    }
}
