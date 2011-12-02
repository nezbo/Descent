﻿// -----------------------------------------------------------------------
// <copyright file="PlayerJoinedEventArgs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for the PlayerJoined event.
    /// </summary>
    public sealed class PlayerJoinedEventArgs : GameEventArgs
    {
        public PlayerJoinedEventArgs(int playerId, string playerNick)
        {
            PlayerId = playerId;
            PlayerNick = playerNick;
        }

        public PlayerJoinedEventArgs(string[] stringArgs)
        {
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public string PlayerNick { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            this.PlayerId = int.Parse(stringArgs[0]);
            PlayerNick = stringArgs[1];
        }

        public override string ToString()
        {
            return string.Join(",", this.PlayerId.ToString(), PlayerNick);
        }
    }
}