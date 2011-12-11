
namespace Descent.Model.Event
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// An attack 
    /// </summary>
    public class Attack
    {
        private Figure figure;

        private List<Dice> diceForAttack;

        private List<SurgeAbility> surgeAbilities; 

        /// <summary>
        /// Gets or sets the hero that is attacking
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

        public Point TargetSquare { get; private set; }

        public int DamageBonus { get; set; }

        public int RangeBonus { get; set; }

        public int SurgeBonus { get; set; }

        public int PierceBonus { get; set; }

        public int Damage { get; set; }

        public int Range { get; set; }

        public int Surge { get; set; }

        public int Pierce { get; set; }

        public int UsedSurges { get; set; }

        public List<Dice> DiceForAttack
        {
            get
            {
                return diceForAttack;
            }
        }

        public List<SurgeAbility> SurgeAbilities
        {
            get
            {
                return surgeAbilities;
            }
        } 

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="attackingFigure">
        /// The attacking Figure.
        /// </param>
        public Attack(Figure attackingFigure, Point targetSquare)
        {
            this.figure = attackingFigure;
            diceForAttack = figure.DiceForAttack;
            surgeAbilities = figure.SurgeAbilities;
            this.TargetSquare = targetSquare;
        }

        /// <summary>
        /// Sets all dice to the side of the array given
        /// </summary>
        /// <param name="diceSides"></param>
        public void SetDiceSides(int[] diceSides)
        {
            Contract.Requires(diceSides.Length == DiceForAttack.Count);

            List<Dice> list = DiceForAttack;
            for (int i = 0; i < diceSides.Length; i++)
            {
                list[i].SideIndex = diceSides[i];
            }
        }

        public void RollDice()
        {
            foreach (Dice dice in DiceForAttack)
            {
                dice.RollDice();
                if (dice.Color == EDice.B && dice.SideIndex >= 1 && dice.SideIndex <= 3)
                {
                    int[] side = dice.ActiveSide;
                    Range += side[0];
                    Damage += side[1];
                    Surge += side[2];
                }
            }
        }

        public override string ToString()
        {
            return figure.Name + 
                "\nDamage: " + (DamageBonus + Damage) + 
                "\nRange: " + (RangeBonus + Range) + 
                "\nPierce: " + (PierceBonus + Pierce) +
                "\nSurge: " + (SurgeBonus + Surge);
        }


        /// <summary>
        /// Checks if a list from DiceForAttack is alike every time you call it
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            //Contract.Invariant(DiceForAttack == null ? true : DiceForAttack.Count == DiceForAttack.Count && DiceF);
        }
    }
}
