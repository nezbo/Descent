﻿
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the GiveOverlordCards event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class DamageTakenEventArgs : GameEventArgs
    {
        public DamageTakenEventArgs(int x, int y, int damage)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(damage >= 0);

            X = x;
            Y = y;
            Damage = damage;
        }

        public DamageTakenEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 3);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) >= 0));

            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Damage { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 3);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) >= 0));

            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
            Damage = int.Parse(stringArgs[2]);
        }

        public override string ToString()
        {
            return string.Join(",", X, Y, Damage);
        }
    }
}
