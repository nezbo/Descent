
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for trading hero cards.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class TradeHeroCardEventArgs : GameEventArgs
    {
        public TradeHeroCardEventArgs(int cardId)
        {
            Contract.Requires(cardId > 0);
        }

        public TradeHeroCardEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            PopulateWithArgs(stringArgs);
        }

        public int CardId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            CardId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return CardId.ToString();
        }
    }
}
