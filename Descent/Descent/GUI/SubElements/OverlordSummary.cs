namespace Descent.GUI.SubElements
{
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A short summary of the overlords information, including threat tokens,
    /// deck size, discard size, hand size and the heroes remaining conquest
    /// tokens.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class OverlordSummary : GUIElement
    {
        private static readonly int Height = 100;

        /// <summary>
        /// Creates a new summary of the overlords information for the given game and 
        /// displays it to the right of the screen, at the given y-coordinate (down 
        /// from the top).
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="y">How far down the screen this HeroSummary should be located.</param>
        public OverlordSummary(Game game, int y)
            : base(game, "overlord summary", (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), y, game.GraphicsDevice.Viewport.Width / 4, Height)
        {
            this.SetBackground("overlordbg");

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlorddeck")), new Vector2(Bound.X, Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlorddiscard")), new Vector2(Bound.X + Bound.Width / 3, Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/overlordhand")), new Vector2(Bound.X + (float)(Bound.Width * (2 / 3.0)), Bound.Y));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/threat1")), new Rectangle(Bound.X + Bound.Width / 3 + 10, Bound.Y + 60, 30, 30));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/conquest1")), new Rectangle(Bound.X + (int)(Bound.Width * (2 / 3.0)) + 10, Bound.Y + 60, 30, 30));
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, "" + Player.Instance.GetPlayerNick(Player.Instance.OverlordId), new Vector2(Bound.X + 10, Bound.Y + 65), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.Hand.Count, new Vector2(Bound.X + 2 * (Bound.Width / 3) + 60, Bound.Y + 15), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.Overlord.ThreatTokens, new Vector2(Bound.X + Bound.Width / 3 + 60, Bound.Y + 65), Color.White);
            draw.DrawString(GUI.Font, "" + Player.Instance.HeroParty.ConquestTokens, new Vector2(Bound.X + (int)(Bound.Width * (2 / 3.0)) + 60, Bound.Y + 65), Color.White);
        }
    }
}
