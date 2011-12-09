using Descent.Model.Player;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class HeroSummary : GUIElement
    {
        private static readonly int Height = 100;

        private Hero me;

        public HeroSummary(Game game, int y, Hero hero)
            : base(game, "overlord summary", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), y, game.GraphicsDevice.Viewport.Width / 4, Height)
        {
            this.me = hero;
            this.SetBackground("playerbg");
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.Draw(me.Texture, new Rectangle(Bound.X, Bound.Y, 50, 50), Color.White);
            draw.DrawString(GUI.Font, me.Name, new Vector2(Bound.X + 60, Bound.Y + 15), Color.Black);
            draw.DrawString(GUI.Font, Player.Instance.GetPlayerNick(Player.Instance.HeroParty.GetPlayerId(me)), new Vector2(Bound.X + 5, Bound.Y + 65), Color.White);
        }
    }
}
