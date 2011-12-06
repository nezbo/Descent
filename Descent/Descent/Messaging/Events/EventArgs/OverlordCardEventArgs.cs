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
    /// The event arguments for the RemoveOverlordCard event.
    /// </summary>
    public sealed class OverlordCardEventArgs : GameEventArgs
    {
        public OverlordCardEventArgs(int overlordCardId)
        {
            Contract.Requires(overlordCardId > 0);

            OverlordCardId = overlordCardId;
        }

        public OverlordCardEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int OverlordCardId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            OverlordCardId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return OverlordCardId.ToString();
        }
    }
}
