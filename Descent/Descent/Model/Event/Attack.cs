// -----------------------------------------------------------------------
// <copyright file="AttackStruct.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Event
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Descent.Model.Player.Figure;


    /// <summary>
    /// An attack 
    /// </summary>
    public class Attack
    {
        private Figure figure;

        private List<Dice> diceForAttack;

        /// <summary>
        /// Gets or sets the hero that is attacking
        /// </summary>
        public Figure AttackingFigure
        {
            get
            {
                return figure;
            }

            set
            {
                figure = value;
            }
        }

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
            get { return diceForAttack; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="attackingHero">
        /// The attacking hero
        /// </param>
        /// <param name="attackingSquare">
        /// The point to the square the hero is attacking
        /// </param>
        public Attack(Figure attackingFigure)
        {
            this.figure = attackingFigure;
            diceForAttack = figure.DiceForAttack;
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
            }
        }

        public override string ToString()
        {
            return figure.Name + "\nDamage: " + DamageBonus + "\nRange: " + RangeBonus + "\nPierce: "
                   + PierceBonus + "\nSurge: " + SurgeBonus;
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
