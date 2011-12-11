
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class OverlordElement : GUIElement
    {
        public OverlordElement(Game game)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {

        }
    }
}
