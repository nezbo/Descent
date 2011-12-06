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
    /// The event arguments for the GiveOverlordCards event.
    /// </summary>
    public sealed class GiveOverlordCardsEventArgs : GameEventArgs
    {
        public GiveOverlordCardsEventArgs(int[] overlordCardIds)
        {
            Contract.Requires(overlordCardIds.Length > 0);
            OverlordCardIds = overlordCardIds;
        }

        public GiveOverlordCardsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int[] OverlordCardIds { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            int numberOfOverlordCards = int.Parse(stringArgs[0]);

            OverlordCardIds = new int[numberOfOverlordCards];
            string[] cardStrings = stringArgs.Skip(1).ToArray();

            for (int i = 0; i < cardStrings.Length; i++)
            {
                OverlordCardIds[i] = int.Parse(cardStrings[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(OverlordCardIds.Length);
            foreach (int overlordCardId in OverlordCardIds)
            {
                sb.Append(",");
                sb.Append(overlordCardId);
            }

            return sb.ToString();
        }
    }
}
