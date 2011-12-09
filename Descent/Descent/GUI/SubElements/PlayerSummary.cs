using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class PlayerSummary : GUIElement
    {
        private static readonly int Height = 100;

        public PlayerSummary(Game game, int y, Hero hero)
            : base(game, "overlord summary", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), y, game.GraphicsDevice.Viewport.Width / 4, Height)
        {
            this.SetBackground("playerbg");
        }
    }
}
