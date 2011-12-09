
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Treasure
    {
        #region Fields

        private int id;

        private string name;

        private EquipmentRarity rarity;

        private Equipment equipment;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the unique ID of the treasure
        /// </summary>
        public int ID
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

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Treasure"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the treasure
        /// </param>
        /// <param name="rarity">
        /// The rarity of the treasure
        /// </param>
        /// <param name="equipment">
        /// The equipment equipment in the treasure
        /// </param>
        public Treasure(int id, EquipmentRarity rarity, Equipment equipment)
        {
            this.id = id;
            this.name = equipment == null ? "Treasure Cache" : equipment.Name;
            this.rarity = rarity;
            this.equipment = equipment;
        }

        #endregion
    }
}
