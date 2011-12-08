using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class HeroElement : GUIElement
    {
        private Texture2D health;
        private Texture2D fatigue;
        private Texture2D movement;

        public HeroElement(Game game, Hero hero)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {
            //this.AddDrawable(this.Name, new Image(hero.BigTexture), new Vector2(0, this.Bound.Height - hero.BigTexture.Height));
            health = game.Content.Load<Texture2D>("Images/Other/health-small");
            fatigue = game.Content.Load<Texture2D>("Images/Other/fatigue-small");
            movement = game.Content.Load<Texture2D>("Images/Other/movement-small");
        }
    }
}
