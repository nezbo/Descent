﻿// -----------------------------------------------------------------------
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

    /// <summary>
    /// The event arguments for the RerollDices event.
    /// </summary>
    public sealed class RerollDicesEventArgs : GameEventArgs
    {
        public RerollDicesEventArgs(int[] diceIds)
        {
            Contract.Requires(diceIds.Length > 0);
            DiceIds = diceIds;
        }

        public RerollDicesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length > 0);
            PopulateWithArgs(stringArgs);
        }

        public int[] DiceIds { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 3);

            DiceIds = new int[stringArgs.Length];

            for (int i = 0; i < stringArgs.Length; i++)
            {
                DiceIds[i] = int.Parse(stringArgs[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < DiceIds.Length; i++)
            {
                if(i != 0) sb.Append(",");
                sb.Append(DiceIds[i]);
            }

            return sb.ToString();
        }
    }
}