
namespace Descent.Model.Event
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// An instance of an attack, with all the data necessary
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk) & Martin MArcher
    /// </author>
    public class Attack
    {
        #region Fields
        private Figure figure;

        private List<Dice> diceForAttack;

        private List<SurgeAbility> surgeAbilities;

        private int damage;

        private int range;

        private int surges;

        private int pierce;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the hero that is attacking
        /// </summary>
        public Figure AttackingFigure
        {
            get
            {
                return figure;
            }

            private set
            {
                figure = value;
            }
        }

        /// <summary>
        /// Gets the square which is being attacked
        /// </summary>
        public Point TargetSquare { get; private set; }

        /// <summary>
        /// Gets the range that is needed to fullfill the attack
        /// </summary>
        public int RangeNeeded
        {
            get
            {
                return FullModel.Board.Distance(FullModel.Board.FiguresOnBoard[figure], TargetSquare);
            }
        }

        /// <summary>
        /// Gets or sets the damage bonus for this attack
        /// </summary>
        public int DamageBonus { get; set; }

        /// <summary>
        /// Gets or sets the range bonus for this attack
        /// </summary>
        public int RangeBonus { get; set; }

        /// <summary>
        /// Gets or sets the surge bonus for this attack
        /// </summary>
        public int SurgeBonus { get; set; }

        /// <summary>
        /// Gets or sets the pierce bonus for this attack
        /// </summary>
        public int PierceBonus { get; set; }

        /// <summary>
        /// Gets the total damage for this attack
        /// </summary>
        public int Damage
        {
            get
            {
                return damage + DamageBonus;
            }

            private set
            {
                damage = value;
            }
        }

        /// <summary>
        /// Gets the total range for this attack
        /// </summary>
        public int Range
        {
            get
            {
                return range + RangeBonus;
            }

            private set
            {
                range = value;
            }
        }

        /// <summary>
        /// Gets the total surges for this attack
        /// </summary>
        public int Surge
        {
            get
            {
                return surges + SurgeBonus;
            }

            private set
            {
                surges = value;
            }
        }

        /// <summary>
        /// Gets the total pierce for this attack
        /// </summary>
        public int Pierce
        {
            get
            {
                return pierce + PierceBonus;
            }

            private set
            {
                pierce = value;
            }
        }

        /// <summary>
        /// Gets or sets the total number of used surges for this attack
        /// </summary>
        public int UsedSurges { get; set; }

        /// <summary>
        /// Gets a list of dice that the attack will use when attacking
        /// </summary>
        public List<Dice> DiceForAttack
        {
            get
            {
                return diceForAttack;
            }
        }
        
        /// <summary>
        /// Gets a list of surge abilities that can be bought for this attack
        /// </summary>
        public List<SurgeAbility> SurgeAbilities
        {
            get
            {
                return surgeAbilities;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the attack is missed
        /// </summary>
        public bool MissedAttack { get; private set; }

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="attackingFigure">
        /// The attacking Figure.
        /// </param>
        /// <param name="targetSquare">
        /// The square that is attacked
        /// </param>
        public Attack(Figure attackingFigure, Point targetSquare)
        {
            this.figure = attackingFigure;
            diceForAttack = figure.DiceForAttack;
            surgeAbilities = figure.SurgeAbilities;
            this.TargetSquare = targetSquare;
            MissedAttack = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets all dice to the side of the array given
        /// </summary>
        /// <param name="diceSides">
        /// An array indicating the values of the dice face
        /// </param>
        public void SetDiceSides(int[] diceSides)
        {
            Contract.Requires(diceSides.Length == DiceForAttack.Count);

            List<Dice> list = DiceForAttack;
            for (int i = 0; i < diceSides.Length; i++)
            {
                list[i].SideIndex = diceSides[i];
            }
            this.CalculateStats();
        }

        /// <summary>
        /// Rolls all dice, and determines whether the attack is missed
        /// </summary>
        public void RollDice()
        {
            foreach (Dice dice in DiceForAttack)
            {
                dice.RollDice();
            }

            MissedAttack = !DiceForAttack.All(d => d.ActiveSide[3] == 0);
            this.CalculateStats();
        }

        /// <summary>
        /// Calculates the current values of range, damage, surges and pierce
        /// </summary>
        private void CalculateStats()
        {
            Range = 0;
            Damage = 0;
            Surge = 0;
            Pierce = 0;
            foreach (Dice dice in DiceForAttack)
            {
                if (!(dice.Color == EDice.B && dice.SideIndex >= 1 && dice.SideIndex <= 3))
                {
                    int[] side = dice.ActiveSide;
                    Range += side[0];
                    Damage += side[1];
                    Surge += side[2];
                }
            }
        }

        /// <summary>
        /// Gets the attack instance as a string
        /// </summary>
        /// <returns>
        /// The string of the the attack
        /// </returns>
        public override string ToString()
        {
            this.CalculateStats();
            return figure.Name + 
                "\nDamage: " + Damage + 
                (figure.AttackType != EAttackType.MELEE ? "\nRange: " + Range + " of " + RangeNeeded : string.Empty) + 
                "\nPierce: " + Pierce +
                "\nSurge: " + (Surge - UsedSurges);
        }

        /// <summary>
        /// Checks if a list from DiceForAttack is alike every time you call it
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(DiceForAttack.Count > 0);
            //Contract.Invariant(DiceForAttack == null ? true : DiceForAttack.Count == DiceForAttack.Count && DiceF);
        }

        #endregion
    }
}
