
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the PlayerJoined event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class PlayerJoinedEventArgs : GameEventArgs
    {
        public PlayerJoinedEventArgs(int playerId, string playerNick)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(playerNick != null);
            PlayerId = playerId;
            PlayerNick = playerNick;
        }

        public PlayerJoinedEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public string PlayerNick { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            this.PlayerId = int.Parse(stringArgs[0]);
            PlayerNick = stringArgs[1];
        }

        public override string ToString()
        {
            return string.Join(",", this.PlayerId.ToString(), PlayerNick);
        }
    }
}
