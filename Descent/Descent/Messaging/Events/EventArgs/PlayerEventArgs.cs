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
    /// The event arguments for events having only a player id as argument.
    /// </summary>
    public sealed class PlayerEventArgs : GameEventArgs
    {
        public PlayerEventArgs(int playerId)
        {
            Contract.Requires(playerId > 0);
            PlayerId = playerId;
        }

        public PlayerEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PlayerId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return PlayerId.ToString();
        }
    }
}
