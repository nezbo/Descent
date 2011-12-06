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
    /// The event arguments for the GiveOverlordCards event.
    /// </summary>
    public sealed class DamageEventArgs : GameEventArgs
    {
        public DamageEventArgs(int x, int y, int damage)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(damage >= 0);

            X = x;
            Y = y;
            Damage = damage;
        }

        public DamageEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Damage { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 3);
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
