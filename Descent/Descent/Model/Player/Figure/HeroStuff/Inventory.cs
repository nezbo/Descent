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

    public enum EquipmentSlot
    {
        Weapon = 0,
        Shield = 1,
        Armor = 2,
        Other = 3,
        Potion = 5,
        Backpack = 8
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Inventory
    {
        public const int MaxPotions = 3;
        public const int MaxOtherItems = 2;
        public const int MaxInBackpack = 3;

        private readonly Equipment[] inventory = new Equipment[11];
        private readonly Hero hero;

        /*
        private readonly Equipment[] otherItems = new Equipment[MaxOtherItems];
        private readonly Equipment[] potions = new Equipment[MaxPotions];
        private readonly Equipment[] backpack = new Equipment[MaxInBackpack];
        private Equipment _armor;
        private Equipment _weapon;
        private Equipment _shield;
         * */
        
        public Equipment this[int slot]
        {
            get
            {
                Contract.Requires(slot >= 0 && slot <= 10);

                return inventory[slot];
            }

            set
            {
                Contract.Requires(this[slot] == null);
                Contract.Requires(
                    value.Type == EquipmentType.Weapon ?
                    slot == (int)EquipmentSlot.Weapon :
                        value.Type == EquipmentType.Shield ?
                        slot == (int)EquipmentSlot.Shield :
                            value.Type == EquipmentType.Other ?
                            slot >= (int)EquipmentSlot.Other && slot < (int)EquipmentSlot.Potion :
                                value.Type == EquipmentType.Potion ?
                                slot >= (int)EquipmentSlot.Potion && slot < (int)EquipmentSlot.Backpack :
                                    slot >= (int)EquipmentSlot.Backpack && slot < this.Length);
                Contract.Requires(this[slot] == value);

                inventory[slot] = value;
            }
        }

        public int Length
        {
            get
            {
                return inventory.Length;
            }
        }

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
                freeHands -= (inventory[(int)EquipmentSlot.Weapon] != null) ? inventory[(int)EquipmentSlot.Weapon].Hands : 0;
                freeHands -= (inventory[(int)EquipmentSlot.Shield] != null) ? inventory[(int)EquipmentSlot.Shield].Hands : 0;
                return freeHands;
            }
        }

        public Equipment Shield
        {
            get { return inventory[(int)EquipmentSlot.Shield]; }
        }

        public Equipment Armor
        {
            get { return inventory[(int)EquipmentSlot.Armor]; }
        }

        public Equipment Weapon
        {
            get { return inventory[(int)EquipmentSlot.Weapon]; }
        }

        public Equipment[] OtherItems
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxOtherItems);
                return Enumerable.Range((int)EquipmentSlot.Other, 2).Select(i => inventory[i]).ToArray();
            }
        }

        public Equipment[] Potions
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxPotions);
                return Enumerable.Range((int)EquipmentSlot.Potion, 3).Select(i => inventory[i]).ToArray();
            }
        }

        public Equipment[] Backpack
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxInBackpack);
                return Enumerable.Range((int)EquipmentSlot.Backpack, 3).Select(i => inventory[i]).ToArray();
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
            Contract.Ensures(inventory[(int)EquipmentSlot.Weapon] == weapon);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) - weapon.Hands);

            inventory[(int)EquipmentSlot.Weapon] = weapon;
            weapon.EquipToHero(hero);
        }

        /// <summary>
        /// Equip armor.
        /// </summary>
        public void EquipArmor(Equipment armor)
        {
            Contract.Requires(armor != null);
            Contract.Requires(armor.Type == EquipmentType.Armor);
            Contract.Ensures(this[(int)EquipmentSlot.Armor] == armor);

            inventory[(int)EquipmentSlot.Armor] = armor;
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
            Contract.Ensures(this[(int)EquipmentSlot.Shield] == shield);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) - shield.Hands);

            inventory[(int)EquipmentSlot.Shield] = shield;
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
            Contract.Requires(this[(int)EquipmentSlot.Other + index] == null);
            Contract.Ensures(this[(int)EquipmentSlot.Other + index] == item);

            inventory[(int)EquipmentSlot.Other + index] = item;
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
            Contract.Requires(this[(int)EquipmentSlot.Backpack + index] == null);
            Contract.Ensures(this[(int)EquipmentSlot.Backpack + index] == item);

            inventory[(int)EquipmentSlot.Backpack + index] = item;
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
            Contract.Requires(this[(int)EquipmentSlot.Potion + index] == null);
            Contract.Ensures(this[(int)EquipmentSlot.Potion + index] == item);

            inventory[(int)EquipmentSlot.Potion + index] = item;
            item.EquipToHero(hero);
        }

        /// <summary>
        /// Unequip the weapon.
        /// </summary>
        /// <returns>The weapon that was equipped.</returns>
        public Equipment UnequipWeapon()
        {
            Contract.Requires(this[(int)EquipmentSlot.Weapon] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Weapon] == null);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) + Contract.Result<Equipment>().Hands);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(this[(int)EquipmentSlot.Weapon]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Weapon);

            Equipment result = inventory[(int)EquipmentSlot.Weapon];
            inventory[(int)EquipmentSlot.Weapon] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Unequip the armor.
        /// </summary>
        /// <returns>The armor that was equipped.</returns>
        public Equipment UnequipArmor()
        {
            Contract.Requires(this[(int)EquipmentSlot.Armor] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Armor] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(this[(int)EquipmentSlot.Armor]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Armor);

            Equipment result = inventory[(int)EquipmentSlot.Armor];
            inventory[(int)EquipmentSlot.Armor] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        /// <summary>
        /// Unequip the shield.
        /// </summary>
        /// <returns>The weapon that was shield.</returns>
        public Equipment UnequipShield()
        {
            Contract.Requires(this[(int)EquipmentSlot.Shield] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Shield] == null);
            Contract.Ensures(FreeHands == Contract.OldValue(FreeHands) + Contract.Result<Equipment>().Hands);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(this[(int)EquipmentSlot.Shield]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Shield);

            Equipment result = inventory[(int)EquipmentSlot.Shield];
            inventory[(int)EquipmentSlot.Shield] = null;
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
            Contract.Requires(this[(int)EquipmentSlot.Other + index] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Other + index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(inventory[(int)EquipmentSlot.Other + index]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Other);

            Equipment result = inventory[(int)EquipmentSlot.Other + index];
            inventory[(int)EquipmentSlot.Other + index] = null;
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
            Contract.Requires(this[(int)EquipmentSlot.Backpack + index] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Backpack + index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(inventory[(int)EquipmentSlot.Backpack + index]));

            Equipment result = inventory[(int)EquipmentSlot.Backpack + index];
            inventory[(int)EquipmentSlot.Backpack + index] = null;
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
            Contract.Requires(this[(int)EquipmentSlot.Potion + index] != null);
            Contract.Ensures(this[(int)EquipmentSlot.Potion + index] == null);
            Contract.Ensures(Contract.Result<Equipment>() == Contract.OldValue(inventory[(int)EquipmentSlot.Potion + index]));
            Contract.Ensures(Contract.Result<Equipment>().Type == EquipmentType.Potion);

            Equipment result = inventory[(int)EquipmentSlot.Potion + index];
            inventory[(int)EquipmentSlot.Potion + index] = null;
            result.UnequipFromHero(hero);
            return result;
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(inventory[(int)EquipmentSlot.Weapon] == null || inventory[(int)EquipmentSlot.Weapon].Type == EquipmentType.Weapon);
            Contract.Invariant(inventory[(int)EquipmentSlot.Shield] == null || inventory[(int)EquipmentSlot.Shield].Type == EquipmentType.Shield);
            Contract.Invariant(inventory[(int)EquipmentSlot.Armor] == null || inventory[(int)EquipmentSlot.Armor].Type == EquipmentType.Armor);
            Contract.Invariant(Enumerable.Range((int)EquipmentSlot.Other, 2).Select(i => inventory[i]).All(e => e == null || e.Type == EquipmentType.Other));
            Contract.Invariant(Enumerable.Range((int)EquipmentSlot.Potion, 3).Select(i => inventory[i]).All(e => e == null || e.Type == EquipmentType.Potion));

            Contract.Invariant(0 < FreeHands && FreeHands <= MaxHands);
        }
    }
}
