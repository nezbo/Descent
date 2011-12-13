
namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the PlayerJoined event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class AssignHeroEventArgs : GameEventArgs
    {
        public AssignHeroEventArgs(int playerId, int heroId)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(heroId > 0);
            PlayerId = playerId;
            HeroId = heroId;
        }

        public AssignHeroEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) > 0));
            Contract.Ensures(PlayerId > 0);
            Contract.Ensures(HeroId > 0);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int HeroId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) > 0));
            Contract.Ensures(PlayerId > 0);
            Contract.Ensures(HeroId > 0);

            PlayerId = int.Parse(stringArgs[0]);
            HeroId = int.Parse(stringArgs[1]);

        }

        public override string ToString()
        {
            return string.Join(",", PlayerId.ToString(), HeroId.ToString());
        }
    }
}
