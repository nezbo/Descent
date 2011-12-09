using Descent.Model.Player;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class PlayersElement : GUIElement
    {
        public PlayersElement(Game game, HeroParty party)
            : base(game, "players", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), 0, game.GraphicsDevice.Viewport.Width / 4, game.GraphicsDevice.Viewport.Height / 2)
        {

        }
    }
}
