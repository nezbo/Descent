// -----------------------------------------------------------------------
// <copyright file="Inventory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics.Contracts;

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Inventory
    {
        public const int MaxPotions = 3;
        public const int MaxOtherItems = 2;
        public const int MaxInBackpack = 3;

        private Equipment armor;
        private Equipment weapon;
        private Equipment shield;
        private readonly Equipment[] otherItems = new Equipment[MaxOtherItems];
        private readonly Equipment[] potions    = new Equipment[MaxPotions];
        private readonly Equipment[] backpack   = new Equipment[MaxInBackpack];
        private Hero hero;
        
        public int MaxHands
        {
            get { return hero.Hands; }
        }

        public int FreeHands
        {
            get
            {
                int freeHands = MaxHands;
                freeHands -= (Weapon != null) ? Weapon.Hands : 0;
                freeHands -= (Shield != null) ? Shield.Hands : 0;
                return freeHands;
            }
        }

        public Equipment Shield
        {
            get { return shield; }
        }

        public Equipment Armor
        {
            get { return armor; }
        }

        public Equipment Weapon
        {
            get { return weapon; }
        }

        public Equipment[] OtherItems
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxOtherItems);
                return otherItems.ToArray();
            }
        }

        public Equipment[] Potions
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxPotions);
                return potions.ToArray();
            }
        }

        public Equipment[] Backpack
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxInBackpack);
                return backpack.ToArray();
            }
        }

        /// <summary>
        /// Returns a removes an item from 'other'.
        /// </summary>
        /// <param name="index">The index from where to remove.</param>
        public Equipment UnequipFromOther(int index)
        {
            Contract.Requires(0 < index && index < MaxOtherItems);
            Contract.Requires(OtherItems[index] != null);
            Contract.Ensures(OtherItems[index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(OtherItems[index]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Other);

            Equipment result = OtherItems[index];
            otherItems[index] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Returns a removes an item from backpack.
        /// </summary>
        /// <param name="index">The index from where to remove.</param>
        public Equipment UnequipFromBackpack(int index)
        {
            Contract.Requires(0 < index && index < MaxInBackpack);
            Contract.Requires(Backpack[index] != null);
            Contract.Ensures(Backpack[index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(Backpack[index]));
      
            Equipment result = Backpack[index];
            backpack[index] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Returns a removes an item from potions.
        /// </summary>
        /// <param name="index">The index from where to remove.</param>
        public Equipment UnequipFromPotions(int index)
        {
            Contract.Requires(0 < index && index < MaxPotions);
            Contract.Requires(Potions[index] != null);
            Contract.Ensures(Potions[index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(Potions[index]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Potion);

            Equipment result = Potions[index];
            potions[index] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Equip an item to 'other'.
        /// </summary>
        /// <param name="index">The index where the item should be placed.</param>
        /// <param name="item">The item to place.</param>
        public void EquipToOther(int index, Equipment item)
        {
            Contract.Requires(0 < index && index < MaxOtherItems);
            Contract.Requires(item != null);
            Contract.Requires(item.Type == EquipmentType.Other);
            Contract.Requires(OtherItems[index] == null);
            Contract.Ensures(OtherItems[index] == item);

            otherItems[index] = item;
            item.EquipToHero(hero);
        }

        /// <summary>
        /// Equip an item to backpack.
        /// </summary>
        /// <param name="index">The index where the item should be placed.</param>
        /// <param name="item">The item to place.</param>
        public void EquipToBackpacke(int index, Equipment item)
        {
            Contract.Requires(0 < index && index < MaxInBackpack);
            Contract.Requires(item != null);
            Contract.Requires(Backpack[index] == null);
            Contract.Ensures(Backpack[index] == item);

            backpack[index] = item;
            item.EquipToHero(hero);
        }

        /// <summary>
        /// Equip an item to potions.
        /// </summary>
        /// <param name="index">The indexwhere the item should be placed.</param>
        /// <param name="item">The item to place.</param>
        public void EquipToPotions(int index, Equipment item)
        {
            Contract.Requires(0 < index && index < MaxPotions);
            Contract.Requires(item != null);
            Contract.Requires(item.Type == EquipmentType.Potion);
            Contract.Requires(Potions[index] == null);
            Contract.Ensures(Potions[index] == item);

            potions[index] = item;
            item.EquipToHero(hero);
        }


    }
}
