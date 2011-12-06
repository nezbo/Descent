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
    /// The event arguments for events sending a number of tokens.
    /// </summary>
    public sealed class TokenEventArgs : GameEventArgs
    {
        public TokenEventArgs(int numberOfTokens)
        {
            Contract.Requires(numberOfTokens > 0);

            NumberOfTokens = numberOfTokens;
        }

        public TokenEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int NumberOfTokens { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            NumberOfTokens = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return NumberOfTokens.ToString();
        }
    }
}
