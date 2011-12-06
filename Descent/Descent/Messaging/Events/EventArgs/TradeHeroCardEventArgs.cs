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
    /// The event arguments for the PlayerJoined event.
    /// </summary>
    public sealed class TradeHeroCardEventArgs : GameEventArgs
    {
        public TradeHeroCardEventArgs(int cardId)
        {
            Contract.Requires(cardId > 0);
        }

        public TradeHeroCardEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int CardId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            CardId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return CardId.ToString();
        }
    }
}
