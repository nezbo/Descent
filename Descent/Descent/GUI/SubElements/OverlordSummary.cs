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

            deck = game.Content.Load<Texture2D>("Images/Other/overlorddeck");
            discard = game.Content.Load<Texture2D>("Images/Other/overlorddiscard");
            hand = game.Content.Load<Texture2D>("Images/Other/overlordhand");
            threat = game.Content.Load<Texture2D>("Images/Other/threat1");
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            //icons
            draw.Draw(deck, new Vector2(Bound.X, Bound.Y), Color.White);
            draw.Draw(discard, new Vector2(Bound.X + Bound.Width / 2, Bound.Y), Color.White);
            draw.Draw(hand, new Vector2(Bound.X, Bound.Y + 50), Color.White);
            draw.Draw(threat, new Rectangle(Bound.X + Bound.Width / 2 + 10, Bound.Y + 60, 30, 30), Color.White);

            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.Hand.Count, new Vector2(Bound.X + 60, Bound.Y + 65), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.ThreatTokens, new Vector2(Bound.X + Bound.Width / 2 + 60, Bound.Y + 65), Color.White);
        }
    }
}
