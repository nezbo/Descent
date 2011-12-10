using Descent.Model.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class OverlordSummary : GUIElement
    {
        private static readonly int Height = 100;

        private Texture2D deck;
        private Texture2D discard;
        private Texture2D hand;
        private Texture2D threat;

        public OverlordSummary(Game game, int y)
            : base(game, "overlord summary", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), y, game.GraphicsDevice.Viewport.Width / 4, Height)
        {
            this.SetBackground("overlordbg");

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlorddeck")), new Vector2(Bound.X, Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlorddiscard")), new Vector2(Bound.X + Bound.Width / 3, Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlordhand")), new Vector2(Bound.X + (float)(Bound.Width * (2 / 3.0)), Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/threat1")), new Rectangle(Bound.X + Bound.Width / 3 + 10, Bound.Y + 60, 30, 30));
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, "" + Player.Instance.GetPlayerNick(Player.Instance.OverlordId), new Vector2(Bound.X + 10, Bound.Y + 65), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.Hand.Count, new Vector2(Bound.X + 2 * (Bound.Width / 3) + 60, Bound.Y + 15), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.ThreatTokens, new Vector2(Bound.X + Bound.Width / 3 + 60, Bound.Y + 65), Color.White);
        }
    }
}
