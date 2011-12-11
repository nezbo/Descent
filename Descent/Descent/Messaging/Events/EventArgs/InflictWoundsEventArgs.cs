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
    /// The event arguments for the InflictWounds event;
    /// </summary>
    public sealed class InflictWoundsEventArgs : GameEventArgs
    {
        public InflictWoundsEventArgs(int x, int y, int damage, int pierce)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(damage > 0);
            Contract.Requires(pierce >= 0);

            X = x;
            Y = y;
            Damage = damage;
            Pierce = pierce;
        }

        public InflictWoundsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 4);
            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Damage { get; set; }

        public int Pierce { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 4);
            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
            Damage = int.Parse(stringArgs[2]);
            Pierce = int.Parse(stringArgs[3]);
        }

        public override string ToString()
        {
            return string.Join(",", X, Y, Damage);
        }
    }
}
