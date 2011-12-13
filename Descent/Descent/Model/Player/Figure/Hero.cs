namespace Descent.Model.Player.Figure
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A hero, made from a hero-sheet
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk) & Martin Marcher
    /// </author>
    public class Hero : Figure
    {
        #region Events

        /// <summary>
        /// This event contributes to the Max Fatigue of this hero
        /// </summary>
        public event Bonus<int> MaxFatigueContribution;

        #endregion

        #region Fields

        private int cost;

        private int maxFatigue;
        private int fatigue = 0;

        private Dictionary<EAttackType, int> blackDice;

        private Dictionary<EAttackType, int> numberOfSkills = new Dictionary<EAttackType, int>();
        private Dictionary<EAttackType, List<Skill>> skills = new Dictionary<EAttackType, List<Skill>>();

        private string abilityText;

        private int hands;

        private readonly Inventory inventory;

        private Texture2D bigTexture;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the max fatique, including all contributors bonus
        /// Sets the internal value, not including any contributors
        /// </summary>
        public int MaxFatigue
        {
            get
            {
                int total = MaxFatigueContribution == null ? 0 : MaxFatigueContribution.GetInvocationList().Cast<Bonus<int>>().Sum(bonus => bonus.Invoke());
                return maxFatigue + total;
            }

            private set
            {
                maxFatigue = value;
            }
        }

        /// <summary>
        /// Gets the fatigue of the figure
        /// </summary>
        public int Fatigue
        {
            get
            {
                return fatigue;
            }
        }

        /// <summary>
        /// Gets the conquest token cost of the hero
        /// </summary>
        public int Cost
        {
            get { return cost; }
        }

        /// <summary>
        /// Gets the number of hands the hero have to equip weapons in
        /// </summary>
        public int Hands
        {
            get
            {
                return hands;
            }
        }

        /// <summary>
        /// Gets or sets the number of coins owned by the hero
        /// </summary>
        public int Coins { get; set; }

        /// <summary>
        /// Gets the inventory of the hero
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        /// <summary>
        /// Gets the big texture, used for a heroes own gui
        /// </summary>
        public Texture2D BigTexture
        {
            get
            {
                return bigTexture;
            }
        }

        public override EAttackType AttackType
        {
            get
            {
                return inventory[0] == null ? EAttackType.NONE : inventory[0].AttackType;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the hero
        /// </param>
        /// <param name="name">
        /// The name of the hero
        /// </param>
        /// <param name="conquest">
        /// The conquest token cost of the hero
        /// </param>
        /// <param name="health">
        /// The the starting max health of the hero
        /// </param>
        /// <param name="fatigue">
        /// The fatigue of the hero
        /// </param>
        /// <param name="armor">
        /// The natural armor of the hero
        /// </param>
        /// <param name="speed">
        /// The base speed of the hero
        /// </param>
        /// <param name="blackDice">
        /// The black dice the hero have in each type
        /// </param>
        /// <param name="numberOfSkills">
        /// The number of skills in each type
        /// </param>
        /// <param name="hands">
        /// The number of hands the hero have
        /// </param>
        /// <param name="text">
        /// The text of the hero ability
        /// </param>
        /// <param name="texture">
        /// The small texture of the hero
        /// </param>
        /// <param name="bigTexture">
        /// The big texture for a hero
        /// </param>
        public Hero(int id, string name, int conquest, int health, int fatigue, int armor, int speed, Dictionary<EAttackType, int> blackDice, Dictionary<EAttackType, int> numberOfSkills, int hands, string text, Texture2D texture, Texture2D bigTexture)
            : base(id, name, new Rectangle(0, 0, 1, 1))
        {
            this.cost = conquest;
            this.MaxHealth = health;
            this.MaxFatigue = fatigue;
            this.Armor = armor;
            this.Speed = speed;
            this.blackDice = blackDice;
            this.numberOfSkills = numberOfSkills;
            this.hands = hands;
            abilityText = text;
            this.Texture = texture;
            this.bigTexture = bigTexture;
            inventory = new Inventory(this);

            Coins += 300;
            DiceContribution += this.BlackDice;
        }

        /// <summary>
        /// Call when the game is about to start, so the figure gets life and fatigue
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            fatigue = MaxFatigue;
        }

        #endregion

        #region Public Methods

        public int TrainingTokens(EAttackType attackType)
        {
            return blackDice.ContainsKey(attackType) ? blackDice[attackType] : 0;
        }

        /// <summary>
        /// Adds fatigue to the hero, up to max fatigue
        /// </summary>
        /// <param name="amount">
        /// The amount of fatigue to be added
        /// </param>
        public void AddFatigue(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.OldValue(fatigue) + amount > MaxFatigue ?
                fatigue == MaxFatigue :
                fatigue == Contract.OldValue(fatigue) + amount);
            fatigue = (int)MathHelper.Clamp(fatigue + amount, 0, MaxFatigue);
        }

        /// <summary>
        /// Removes fatigue from the hero, down to 0
        /// </summary>
        /// <param name="amount">
        /// The amount of fatigue to be removed
        /// </param>
        public void RemoveFatigue(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(amount <= Fatigue);
            Contract.Ensures(fatigue == 0 || (fatigue == (Contract.OldValue(fatigue) - amount)));
            fatigue = (int)MathHelper.Clamp(fatigue - amount, 0, MaxFatigue);
        }

        /// <summary>
        /// Adds a skill card to the list of skills
        /// Add 'this' skill!
        /// </summary>
        /// <param name="skill">
        /// The Skill card to be added
        /// </param>
        public void AddSkill(Skill skill)
        {
            Contract.Requires(skill != null);
            if (!skills.ContainsKey(skill.Type))
                skills[skill.Type] = new List<Skill>();
            skills[skill.Type].Add(skill);
        }

        /// <summary>
        /// Removes a skill card from the list of skills
        /// Remove 'this' skill!
        /// </summary>
        /// <param name="skill">
        /// The Skill card to be removed
        /// </param>
        public void RemoveSkill(Skill skill)
        {
            Contract.Requires(skill != null);
            if (!skills.ContainsKey(skill.Type))
                skills[skill.Type] = new List<Skill>();
            skills[skill.Type].Remove(skill);
        }

        /// <summary>
        /// Untaps all skills and equipment that the hero controls
        /// </summary>
        public void UntapAll()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    inventory[i].UntapEquipment();
                }
            }

            foreach (EAttackType attackType in skills.Keys)
            {
                foreach (Skill skill in skills[attackType])
                {
                    skill.Tapped = false;
                }
            }
        }

        /// <summary>
        /// Called when a hero has ended his turn. Removes movement and attacks.
        /// </summary>
        public void EndTurn()
        {
            movementLeft = 0;
            attacksLeft = 0;
        }

        /// <summary>
        /// A method that returns the number of black dice for the weapon type equipped.
        /// This list of black dice is empty if there is now weapon equipped.
        /// </summary>
        /// <returns></returns>
        private List<Dice> BlackDice()
        {
            List<Dice> dice = new List<Dice>();
            if (inventory.Weapon == null) return dice;

            for (int i = 0; i < blackDice[inventory.Weapon.AttackType]; i++)
            {
                dice.Add(FullModel.GetDice(EDice.B));
            }

            return dice;
        }

        /// <summary>
        /// The invariant of the Hero class
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(inventory != null);
            Contract.Invariant(fatigue >= 0 && fatigue <= MaxFatigue);
        }
        #endregion
    }
}
