// -----------------------------------------------------------------------
// <copyright file="PlayerJoinedEventArgs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model;

    /// <summary>
    /// The event arguments for the RolledDices event.
    /// Example on arguments: 0,2,1,6 - Two dice rolls, dice 0 rolled to side 2, dice 1 rolled to side 6.
    /// </summary>
    public sealed class RolledDicesEventArgs : GameEventArgs
    {
        public RolledDicesEventArgs(int[] diceIds, int[] rolledSides)
        {
            Contract.Requires(diceIds.Length > 0);
            Contract.Requires(rolledSides.Length > 0);
            Contract.Requires(diceIds.Length == rolledSides.Length);
            DiceIds = diceIds;
            RolledSides = rolledSides;
        }

        public RolledDicesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int[] DiceIds { get; set; }

        public int[] RolledSides { get; set; }


        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);

            DiceIds = new int[stringArgs.Length / 2];
            RolledSides = new int[stringArgs.Length / 2];

            int currDice = 0;
            for (int i = 0; i < stringArgs.Length; i += 2)
            {
                DiceIds[currDice] = int.Parse(stringArgs[i]);
                RolledSides[currDice] = int.Parse(stringArgs[i + 1]);
                currDice++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < DiceIds.Length; i++)
            {
                if(i != 0) sb.Append(",");
                sb.Append(DiceIds[i]);
                sb.Append(",");
                sb.Append(RolledSides[i]);
            }

            return sb.ToString();
        }
    }
}