// -----------------------------------------------------------------------
// <copyright file="Weapon.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Weapon : Equipment
    {
        #region Fields

        private List<SurgeAbility> surgeAbilities; 
        private int hands;

        #endregion

        #region Properties 

        public List<SurgeAbility> SurgeAbilities;

        #endregion

        #region Initialization
        public Weapon(string name, EquipmentType type, EquipmentRarity rarity, int buyPrice, List<SurgeAbility> surgeAbilities, int hands)
            : base(name, type, rarity, buyPrice)
        {
            this.surgeAbilities = surgeAbilities;
            this.hands = hands;
        }
        #endregion
    }
}
