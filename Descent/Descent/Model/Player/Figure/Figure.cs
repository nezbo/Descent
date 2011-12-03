namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Event;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Any bonus to a hero
    /// </summary>
    /// <typeparam name="T">
    /// The type of the bonus, that defines the returntype
    /// </typeparam>
    public delegate T Bonus<T>();

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Figure
    {
        #region Figure.NONE

        private static Figure none;

        public static Figure NONE
        {
            get
            {
                return none ?? (none = new Figure());
            }
        }

        #endregion Figure.NONE

        #region Events

        public event Bonus<int> MaxHealthContribution;

        public event Bonus<int> ArmorContribution;

        public event Bonus<int> SpeedContribution;

        public event Bonus<int> AttacksLeftContribution;

        public event Bonus<Dice> DiceContribution;

        public event Bonus<Ability> AbilityContribution;

        public event Bonus<Effect> EffectContribution; 

        #endregion

        #region Fields

        private int uniqueID;

        private string name;

        private int maxHealth;

        private int health;

        private int armor;

        private int speed;

        private int speedLeft;

        private int attacksLeft;

        private List<Dice> diceForAttacks = new List<Dice>();

        private List<Ability> abilities = new List<Ability>(); 

        private List<Effect> effects = new List<Effect>();

        #endregion

        #region Properties

        public int ID
        {
            get
            {
                return uniqueID;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int MaxHealth
        {
            get
            {
                int total = this.MaxHealthContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return maxHealth + total;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int Armor
        {
            get
            {
                int total = ArmorContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return armor;
            }
        }

        public int Speed
        {
            get
            {
                int total = SpeedContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return speed;
            }
        }

        public int SpeedLeft 
        { 
            get
            {
                return speedLeft;
            }
        }

        public int AttacksLeft
        {
            get
            {
                int total = AttacksLeftContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return attacksLeft;
            }
        }

        public List<Dice> DiceForAttack
        {
            get
            {
                List<Dice> total = (
                    from Bonus<Dice> dice 
                        in this.DiceContribution.GetInvocationList() 
                    select dice.Invoke()
                    ).ToList();
                total.AddRange(this.diceForAttacks);
                return total;
            }
        } 

        public List<Ability> Abilities
        {
            get
            {
                List<Ability> total = (
                    from Bonus<Ability> ability 
                        in this.DiceContribution.GetInvocationList() 
                    select ability.Invoke()
                    ).ToList();
                total.AddRange(abilities);
                return total;
            }
        }

        public List<Effect> Effects
        {
            get
            {
                List<Effect> total = (
                    from Bonus<Effect> effect 
                        in this.EffectContribution.GetInvocationList() 
                    select effect.Invoke()
                    ).ToList();
                return effects;
            }
        }
        
        #endregion

        #region Initialization

        public Figure(int id, string name)
        {
            this.uniqueID = id;
            this.name = name;
        }

        #endregion

        #region Methods

        public void AddHealth(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(health) - amount < 0 ? 
                Health == 0 : 
                Health == Contract.OldValue(Health) - amount);
            health = (int)MathHelper.Clamp(Health - amount, 0, MaxHealth);
        }

        public void RemoveHealth(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(Health) - amount < 0 ?
                health == 0 : 
                health == Contract.OldValue(health) - amount);
            health = (int)MathHelper.Clamp(health - amount, 0, MaxHealth);
        }

        public void AddSpeed(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(SpeedLeft == Contract.OldValue(SpeedLeft) + amount);
            speedLeft = (int)MathHelper.Clamp(speedLeft + amount, 0, int.MaxValue);
        }

        public void RemoveSpeed(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(SpeedLeft) - amount < 0 ?
                SpeedLeft == 0 :
                SpeedLeft == Contract.OldValue(SpeedLeft) - amount);
            speedLeft = (int)MathHelper.Clamp(SpeedLeft - amount, 0, int.MaxValue);
        }

        [ContractInvariantMethod]
        public void ObjectInvariant()
        {
            Contract.Invariant(Name.Length > 0);
            Contract.Invariant(MaxHealth > 0);
            Contract.Invariant(Speed > 0);
            Contract.Invariant(Armor >= 0);
            Contract.Invariant(SpeedLeft >= 0);
            Contract.Invariant(AttacksLeft >= 0);
        }
        #endregion
    }
}
