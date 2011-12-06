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
    /// The event arguments for events sending only coordinates.
    /// </summary>
    public sealed class SpawnMonsterEventArgs : GameEventArgs
    {
        public SpawnMonsterEventArgs(int x, int y, int monsterId)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(monsterId >= 0);
            X = x;
            Y = y;
            MonsterId = monsterId;
        }

        public SpawnMonsterEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int MonsterId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
            MonsterId = int.Parse(stringArgs[2]);
        }

        public override string ToString()
        {
            return string.Join(",", X.ToString(), Y.ToString(), MonsterId);
        }
    }
}
