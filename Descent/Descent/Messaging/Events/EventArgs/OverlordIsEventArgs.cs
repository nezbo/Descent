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
    public sealed class OverlordIsEventArgs : GameEventArgs
    {
        public OverlordIsEventArgs(int playerId)
        {
            Contract.Requires(playerId > 0);
            PlayerId = playerId;
        }

        public OverlordIsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            this.PlayerId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return this.PlayerId.ToString();
        }
    }
}
