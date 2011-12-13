
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events having only a player id as argument.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class PlayerEventArgs : GameEventArgs
    {
        public PlayerEventArgs(int playerId)
        {
            Contract.Requires(playerId > 0);

            PlayerId = playerId;
        }

        public PlayerEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));
            PlayerId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return PlayerId.ToString();
        }
    }
}
