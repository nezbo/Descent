// -----------------------------------------------------------------------
// <copyright file="ChatMessageEventArgs.cs" company="">
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
    /// This struct is used for representing the players in the <see cref="PlayersInGameEventArgs"/> class.
    /// </summary>
    public struct PlayerInGame
    {
        public int Id;

        public string Nickname;

        public PlayerInGame(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }
    }

    /// <summary>
    /// The event arguments for the PlayersInGame event.
    /// </summary>
    public sealed class PlayersInGameEventArgs : GameEventArgs
    {
        public PlayersInGameEventArgs(PlayerInGame[] playersIngame)
        {
            Contract.Requires(playersIngame != null);
            Contract.Requires(playersIngame.Length > 0);
            NumberOfPlayers = playersIngame.Length;
            Players = playersIngame;
        }

        public PlayersInGameEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int NumberOfPlayers { get; set; }

        public PlayerInGame[] Players { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            Contract.Requires(int.Parse(stringArgs[0]) >= 1);
            Contract.Requires(stringArgs.Length == (int.Parse(stringArgs[0]) * 2) + 1);

            NumberOfPlayers = int.Parse(stringArgs[0]);
            Players = new PlayerInGame[NumberOfPlayers];

            string[] playerStrings = stringArgs.Skip(1).ToArray();

            int currPlayer = 0;
            for (int i = 0; i <= playerStrings.Length / 2; i += 2)
            {
                int id = int.Parse(playerStrings[i]);
                string nick = playerStrings[i + 1];
                Players[currPlayer] = new PlayerInGame(id, nick);
                currPlayer++;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(NumberOfPlayers);
            foreach (PlayerInGame playerInGame in Players)
            {
                sb.Append(",");
                sb.Append(playerInGame.Id);
                sb.Append(",");
                sb.Append(playerInGame.Nickname);
            }

            return sb.ToString();
        }
    }
}
