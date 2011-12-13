
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the GiveCoins event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class GiveCoinsEventArgs : GameEventArgs
    {
        public GiveCoinsEventArgs(int playerId, int numberOfCoins)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(numberOfCoins > 0);

            PlayerId = playerId;
            NumberOfCoins = numberOfCoins;
        }

        public GiveCoinsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) > 0));

            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int NumberOfCoins { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) > 0));

            PlayerId = int.Parse(stringArgs[0]);
            NumberOfCoins = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId, NumberOfCoins);
        }
    }
}
