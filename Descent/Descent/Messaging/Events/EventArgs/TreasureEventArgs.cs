
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events about treasures.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class TreasureEventArgs : GameEventArgs
    {
        public TreasureEventArgs(int treasureId)
        {
            Contract.Requires(treasureId > 0);

            TreasureId = treasureId;
        }

        public TreasureEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));
            
            PopulateWithArgs(stringArgs);
        }

        public int TreasureId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            TreasureId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return TreasureId.ToString();
        }
    }
}
