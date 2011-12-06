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
    /// The event arguments for PlaceHero event.
    /// </summary>
    public sealed class PlaceHeroEventArgs : GameEventArgs
    {
        public PlaceHeroEventArgs(int playerId, int x, int y)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            PlayerId = playerId;
            X = x;
            Y = y;
        }

        public PlaceHeroEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
            PlayerId = int.Parse(stringArgs[0]);
            X = int.Parse(stringArgs[1]);
            Y = int.Parse(stringArgs[2]);
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId.ToString(), X.ToString(), Y.ToString());
        }
    }
}
