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
    /// The event arguments for events needing to send some kind of points. Like AddFatigue.
    /// </summary>
    public sealed class PointsEventArgs : GameEventArgs
    {
        public PointsEventArgs(int points)
        {
            Points = points;
        }

        public PointsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int Points { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            Points = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return Points.ToString();
        }
    }
}
