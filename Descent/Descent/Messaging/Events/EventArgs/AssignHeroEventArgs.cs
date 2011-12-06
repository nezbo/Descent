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
    /// The event arguments for the PlayerJoined event.
    /// </summary>
    public sealed class AssignHeroEventArgs : GameEventArgs
    {
        public AssignHeroEventArgs(int playerId, int heroId)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(heroId > 0);
            PlayerId = playerId;
            HeroId = heroId;
        }

        public AssignHeroEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int HeroId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PlayerId = int.Parse(stringArgs[0]);
            HeroId = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId.ToString(), HeroId.ToString());
        }
    }
}