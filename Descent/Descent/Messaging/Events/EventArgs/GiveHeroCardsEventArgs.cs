
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for the GiveHeroCards event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class GiveHeroCardsEventArgs : GameEventArgs
    {
        public GiveHeroCardsEventArgs(int playerId, int[] heroCardIds)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(heroCardIds != null);
            Contract.Requires(heroCardIds.Length > 0);
            PlayerId = playerId;
            HeroCardIds = heroCardIds;
        }

        public GiveHeroCardsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length >= 3);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) >= 1));
            Contract.Requires(stringArgs.Skip(2).ToArray().Length == int.Parse(stringArgs[1]));

            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int[] HeroCardIds { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length >= 3);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b) && int.Parse(s) >= 1));
            Contract.Requires(stringArgs.Skip(2).ToArray().Length == int.Parse(stringArgs[1]));

            PlayerId = int.Parse(stringArgs[0]);
            int numberOfHeroCards = int.Parse(stringArgs[1]);

            HeroCardIds = new int[numberOfHeroCards];
            string[] cardStrings = stringArgs.Skip(2).ToArray();

            for (int i = 0; i < cardStrings.Length; i++)
            {
                HeroCardIds[i] = int.Parse(cardStrings[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PlayerId.ToString());
            sb.Append(",");
            sb.Append(HeroCardIds.Length);
            foreach (int heroCardId in HeroCardIds)
            {
                sb.Append(",");
                sb.Append(heroCardId);
            }

            return sb.ToString();
        }
    }
}
