
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events sending a number of tokens.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class TokenEventArgs : GameEventArgs
    {
        public TokenEventArgs(int numberOfTokens)
        {
            Contract.Requires(numberOfTokens > 0);

            NumberOfTokens = numberOfTokens;
        }

        public TokenEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            PopulateWithArgs(stringArgs);
        }

        public int NumberOfTokens { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            NumberOfTokens = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return NumberOfTokens.ToString();
        }
    }
}
