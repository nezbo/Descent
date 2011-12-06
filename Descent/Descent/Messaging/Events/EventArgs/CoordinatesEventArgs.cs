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
    public sealed class CoordinatesEventArgs : GameEventArgs
    {
        public CoordinatesEventArgs(int x, int y)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            X = x;
            Y = y;
        }

        public CoordinatesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", X.ToString(), Y.ToString());
        }
    }
}
