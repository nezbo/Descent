﻿
namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for methods regarding one dice.
    /// </summary>
    public sealed class DiceEventArgs : GameEventArgs
    {
        public DiceEventArgs(int diceId, int sideId)
        {
            Contract.Requires(diceId >= 0);
            Contract.Requires(sideId >= 0 && sideId <= 7);

            DiceId = diceId;
            SideId = sideId;
        }

        public DiceEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            PopulateWithArgs(stringArgs);
        }

        public int DiceId { get; set; }

        public int SideId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            DiceId = int.Parse(stringArgs[0]);
            SideId = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", DiceId, SideId);
        }
    }
}
