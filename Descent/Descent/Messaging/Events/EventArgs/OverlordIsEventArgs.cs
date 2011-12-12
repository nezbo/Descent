
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the OverlordIs event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class OverlordIsEventArgs : GameEventArgs
    {
        public OverlordIsEventArgs(int playerId)
        {
            Contract.Requires(playerId > 0);
            PlayerId = playerId;
        }

        public OverlordIsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            this.PlayerId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return this.PlayerId.ToString();
        }
    }
}
