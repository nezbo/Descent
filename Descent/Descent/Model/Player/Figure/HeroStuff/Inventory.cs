
namespace Descent.Model.Player.Figure.HeroStuff
{
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// An enum of all equipment types,
    /// which can be cast to int, for the start
    /// position of the slot in the inventory.
    /// </summary>
    public enum EquipmentSlot
    {
        /// <summary>
        /// There is only one weapon slot
        /// </summary>
        Weapon = 0,

        /// <summary>
        /// There is only one shield slot
        /// </summary>
        Shield = 1,

        /// <summary>
        /// There is only one armor slot
        /// </summary>
        Armor = 2,

        /// <summary>
        /// There are two other item slots
        /// </summary>
        Other = 3,

        /// <summary>
        /// There are three potion slots
        /// </summary>
        Potion = 5,

        /// <summary>
        /// There are three backpack slots
        /// </summary>
        Backpack = 8
    }

    /// <summary>
    /// The inventory of a hero
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk) & Martin MArcher
    /// </author>
    public class Inventory
    {
        #region Fields

        public const int MaxPotions = 3;
        public const int MaxOtherItems = 2;
        public const int MaxInBackpack = 3;

        private readonly Equipment[] inventory = new Equipment[11];
        private readonly Hero hero;

        #endregion

        #region Indexer

        /// <summary>
        /// Gets an equipment at a 
        /// </summary>
        /// <param name="slot">
        /// The slot to access in the inventory
        /// </param>
        /// <returns>
        /// The equipment at that slot
        /// </returns>
        public Equipment this[int slot]
        {
            get
            {
                Contract.Requires(slot >= 0 && slot <= 10);

                return inventory[slot];
            }

            set
            {
                Contract.Requires(this.CanEquipAtIndex(slot, value));
                Contract.Ensures(this[slot] == value);

                if (this[slot] != null && slot < 5)
                    this[slot].UnequipFromHero(hero);
                if (value != null && slot < 5)
                    value.EquipToHero(hero);

                inventory[slot] = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the size of the inventory,
        /// This is always 13
        /// </summary>
        public int Length
        {
            get
            {
                return inventory.Length;
            }
        }

        /// <summary>
        /// Gets the max number of hands 
        /// the hero owning the inventory has
        /// </summary>
        public int MaxHands
        {
            get { return hero.Hands; }
        }

        /// <summary>
        /// Gets how many free hands the hero has left
        /// </summary>
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

        /// <summary>
        /// Gets the equipped weapon, null if there isnt any
        /// </summary>
        public Equipment Weapon
        {
            get { return inventory[(int)EquipmentSlot.Weapon]; }
        }

        /// <summary>
        /// Gets the equipped shield, null if there is no shield equipped
        /// </summary>
        public Equipment Shield
        {
            get { return inventory[(int)EquipmentSlot.Shield]; }
        }

        /// <summary>
        /// Gets the equipped armor, null if there isnt any
        /// </summary>
        public Equipment Armor
        {
            get { return inventory[(int)EquipmentSlot.Armor]; }
        }

        /// <summary>
        /// Gets an array of equipped other items.
        /// If some slots are empty, null will be there instead
        /// </summary>
        public Equipment[] OtherItems
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxOtherItems);
                return Enumerable.Range((int)EquipmentSlot.Other, 2).Select(i => inventory[i]).ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all equipped potions
        /// If some slots are empty, null will be there instead
        /// </summary>
        public Equipment[] Potions
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxPotions);
                return Enumerable.Range((int)EquipmentSlot.Potion, 3).Select(i => inventory[i]).ToArray();
            }
        }

        /// <summary>
        /// Gets a list of all items in the backpack
        /// If some slots are empty, null will be there
        /// </summary>
        public Equipment[] Backpack
        {
            get
            {
                Contract.Ensures(Contract.Result<Equipment[]>().Length == MaxInBackpack);
                return Enumerable.Range((int)EquipmentSlot.Backpack, 3).Select(i => inventory[i]).ToArray();
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class. 
        /// The inventory of a hero
        /// </summary>
        /// <param name="hero">
        /// The hero, that has this inventory.
        /// </param>
        public Inventory(Hero hero)
        {
            this.hero = hero;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Do you have enough hands left to equip this weapon?
        /// </summary>
        /// <param name="equipment">
        /// A piece of equipment.
        /// </param>
        /// <returns>
        /// Whether there are enough hands to equip this weapon
        /// </returns>
        public bool CanEquipWeapon(Equipment equipment)
        {
            return equipment.Hands <= FreeHands;
        }

        /// <summary>
        /// Gets a value indicating whether there is room for
        /// a potion in either the potion slots, or the backpack.
        /// </summary>
        public bool CanEquipPotion
        {
            get
            {
                bool result = false;
                for (int n = (int)EquipmentSlot.Potion; !result && n < (int)EquipmentSlot.Potion + 6; n++)
                {
                    result = this[n] == null;
                }

                return result;
            }
        }

        /// <summary>
        /// Equip a weapon
        /// </summary>
        /// <param name="weapon">
        /// The weapon to be equipped
        /// </param>
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
        /// Equip an armor
        /// </summary>
        /// <param name="armor">
        /// The armor to be equipped
        /// </param>
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
        /// <param name="shield">
        /// The shield to be equipped
        /// </param>
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
        /// Places a potion in the first 
        /// </summary>
        /// <param name="potion">
        /// The potion to be equipped
        /// </param>
        public void EquipPotion(Equipment potion)
        {
            Contract.Requires(potion != null);
            Contract.Requires(CanEquipPotion);
            Contract.Requires(potion.Type == EquipmentType.Potion);

            for (int n = (int)EquipmentSlot.Potion; n < (int)EquipmentSlot.Potion + 6; n++)
            {
                if (this[n] == null)
                {
                    this[n] = potion;
                    return;
                }
            }
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
        /// Unequips an other item, and returns it
        /// </summary>
        /// <param name="index">
        /// The index from where to remove.
        /// </param>
        /// <returns>
        /// The unequipped equipment
        /// </returns>
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
        /// Returns and removes a equipment from the backpack.
        /// </summary>
        /// <param name="index">
        /// The index from where to remove.
        /// </param>
        /// <returns>
        /// The unequipped equipment.
        /// </returns>
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
        /// Returns and removes a potion from the inventory
        /// </summary>
        /// <param name="index">
        /// The index from where to remove the potion
        /// </param>
        /// <returns>
        /// The unequipped potion
        /// </returns>
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

        /// <summary>
        /// Gets whether a piece of equipment can 
        /// be equipped at a specific slot.
        /// </summary>
        /// <param name="slot">
        /// The slot to equip the equipment
        /// </param>
        /// <param name="equipment">
        /// The equipment to equip
        /// </param>
        /// <returns>
        /// Whether there is room in the inventory, 
        /// and if that room is legal
        /// </returns>
        [Pure]
        public bool CanEquipAtIndex(int slot, Equipment equipment)
        {
            if (equipment == null) return true;
            return slot == (int)EquipmentSlot.Weapon ?
                equipment.Type == EquipmentType.Weapon && this.CanEquipWeapon(equipment) :
                        slot == (int)EquipmentSlot.Shield ?
                        equipment.Type == EquipmentType.Shield && CanEquipWeapon(equipment) :
                               slot == (int)EquipmentSlot.Armor ?
                               equipment.Type == EquipmentType.Armor :
                                    slot >= (int)EquipmentSlot.Other && slot < (int)EquipmentSlot.Potion ?
                                    equipment.Type == EquipmentType.Other :
                                        slot >= (int)EquipmentSlot.Potion && slot < (int)EquipmentSlot.Backpack ?
                                        equipment.Type == EquipmentType.Potion :
                                            slot >= (int)EquipmentSlot.Backpack && slot < this.Length;
        }

        #endregion

        /// <summary>
        /// Ensures that all types of equipment are in the correct positions,
        /// and that there er never more or less hands than max and 0.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(inventory[(int)EquipmentSlot.Weapon] == null || inventory[(int)EquipmentSlot.Weapon].Type == EquipmentType.Weapon);
            Contract.Invariant(inventory[(int)EquipmentSlot.Shield] == null || inventory[(int)EquipmentSlot.Shield].Type == EquipmentType.Shield);
            Contract.Invariant(inventory[(int)EquipmentSlot.Armor] == null || inventory[(int)EquipmentSlot.Armor].Type == EquipmentType.Armor);
            Contract.Invariant(Enumerable.Range((int)EquipmentSlot.Other, 2).Select(i => inventory[i]).All(e => e == null || e.Type == EquipmentType.Other));
            Contract.Invariant(Enumerable.Range((int)EquipmentSlot.Potion, 3).Select(i => inventory[i]).All(e => e == null || e.Type == EquipmentType.Potion));

            Contract.Invariant(0 <= FreeHands && FreeHands <= MaxHands);
        }
    }
}