
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events sending a chest.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class ChestEventArgs : GameEventArgs
    {
        public ChestEventArgs(int chestId)
        {
            Contract.Requires(chestId >= 0);
            Contract.Ensures(ChestId == chestId);

            ChestId = chestId;
        }

        public ChestEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) > 0));
            PopulateWithArgs(stringArgs);
        }

        public int ChestId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) > 0));

            ChestId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return ChestId.ToString();
        }
    }
}
