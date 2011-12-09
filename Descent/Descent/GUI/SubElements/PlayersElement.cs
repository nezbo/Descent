using System.Collections.Generic;
using Descent.Model.Player;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class PlayersElement : GUIElement
    {
        /// <summary>
        /// Creates a new instance of a PlayerElement that display summaries
        /// of the players in the game.
        /// </summary>
        /// <param name="game">The game object</param>
        /// <param name="yourself">The hero that shouldn't be displayed in the summary, null if youre the Overlord.</param>
        /// <param name="party">The hero party to display.</param>
        public PlayersElement(Game game, Hero yourself, HeroParty party)
            : base(game, "players", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), 0, game.GraphicsDevice.Viewport.Width / 4, game.GraphicsDevice.Viewport.Height / 2)
        {
            if (yourself != null) AddChild(new OverlordSummary(game, 0));

            List<Hero> heroes = new List<Hero>(Player.Instance.HeroParty.Heroes.Values);
            if (yourself != null) heroes.Remove(yourself);

            int startY = (yourself == null) ? 0 : 100;
            for (int i = 0; i < heroes.Count; i++)
            {
                AddChild(new PlayerSummary(game, startY + i * 100, heroes[i]));
            }
        }
    }
}
