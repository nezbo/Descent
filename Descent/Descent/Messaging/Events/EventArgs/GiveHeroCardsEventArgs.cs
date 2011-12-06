// -----------------------------------------------------------------------
// <copyright file="PlayerJoinedEventArgs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for the GiveHeroCards event.
    /// </summary>
    public sealed class GiveHeroCardsEventArgs : GameEventArgs
    {
        public GiveHeroCardsEventArgs(int playerId, int[] heroCardIds)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(heroCardIds.Length > 0);
            PlayerId = playerId;
            HeroCardIds = heroCardIds;
        }

        public GiveHeroCardsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 3);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int[] HeroCardIds { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 3);
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
