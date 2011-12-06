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

    /// <summary>
    /// The event arguments for the RequestBuyEquipment event.
    /// </summary>
    public sealed class GiveCoinsEventArgs : GameEventArgs
    {
        public GiveCoinsEventArgs(int playerId, int numberOfCoins)
        {
            Contract.Requires(playerId > 0);

            PlayerId = playerId;
            NumberOfCoins = numberOfCoins;
        }

        public GiveCoinsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int NumberOfCoins { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            PlayerId = int.Parse(stringArgs[0]);
            NumberOfCoins = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId, NumberOfCoins);
        }
    }
}
