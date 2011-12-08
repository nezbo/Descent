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

        private readonly Equipment[] otherItems = new Equipment[MaxOtherItems];
        private readonly Equipment[] potions = new Equipment[MaxPotions];
        private readonly Equipment[] backpack = new Equipment[MaxInBackpack];
        private readonly Hero hero;
        private Equipment _armor;
        private Equipment _weapon;
        private Equipment _shield;
        
        /// <param name="hero">The hero, that has this inventory.</param>
        public Inventory(Hero hero)
        {
            this.hero = hero;
        }

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
            get { return _shield; }
        }

        public Equipment Armor
        {
            get { return _armor; }
        }

        public Equipment Weapon
        {
            get { return _weapon; }
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
        /// Equip a weapon.
        /// </summary>
        public void EquipWeapon(Equipment weapon)
        {
            Contract.Requires(weapon != null);
            Contract.Requires(weapon.Type == EquipmentType.Weapon);
            Contract.Requires(weapon.Hands <= FreeHands);
            Contract.Ensures(Weapon == weapon);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) - weapon.Hands);

            _weapon = weapon;
            weapon.EquipToHero(hero);
        }

        /// <summary>
        /// Equip armor.
        /// </summary>
        public void EquipArmor(Equipment armor)
        {
            Contract.Requires(armor != null);
            Contract.Requires(armor.Type == EquipmentType.Armor);
            Contract.Ensures(Armor == armor);

            _armor = armor;
            armor.EquipToHero(hero);
        }

        /// <summary>
        /// Equip a shield.
        /// </summary>
        public void EquipShield(Equipment shield)
        {
            Contract.Requires(shield != null);
            Contract.Requires(shield.Type == EquipmentType.Shield);
            Contract.Requires(shield.Hands <= FreeHands);
            Contract.Ensures(Shield == shield);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) - shield.Hands);

            _shield = shield;
            shield.EquipToHero(hero);
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
        public void EquipToBackpack(int index, Equipment item)
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

        /// <summary>
        /// Unequip the weapon.
        /// </summary>
        /// <returns>The weapon that was equipped.</returns>
        public Equipment UnequipWeapon()
        {
            Contract.Requires(Weapon != null);
            Contract.Ensures(Weapon == null);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) + Contract.Result<Equipment>().Hands);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(Weapon));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Weapon);

            Equipment result = Weapon;
            _weapon = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Unequip the armor.
        /// </summary>
        /// <returns>The armor that was equipped.</returns>
        public Equipment UnequipArmor()
        {
            Contract.Requires(Armor != null);
            Contract.Ensures(Armor == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(Armor));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Armor);

            Equipment result = Armor;
            _armor = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Unequip the shield.
        /// </summary>
        /// <returns>The weapon that was shield.</returns>
        public Equipment UnequipShield()
        {
            Contract.Requires(Shield != null);
            Contract.Ensures(Shield == null);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) + Contract.Result<Equipment>().Hands);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(Shield));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Shield);

            Equipment result = Shield;
            _shield = null;
            result.UnequipFromHero(hero);
            return result;
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

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(0 < FreeHands && FreeHands <= MaxHands);
        }
    }
}
