﻿using Descent.Model.Player;
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

            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/health-small")), new Rectangle(Bound.X + Bound.Width / 2, Bound.Y + Height / 2, Height / 4, Height / 4));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/fatigue-small")), new Rectangle(Bound.X + Bound.Width / 2, Bound.Y + (int)(Height * (3 / 4.0)), Height / 4, Height / 4));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/movement-small")), new Rectangle(Bound.X + (int)(Bound.Width * (3 / 4.0)), Bound.Y + Height / 2, Height / 4, Height / 4));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/attacks-small")), new Rectangle(Bound.X + (int)(Bound.Width * (3 / 4.0)), Bound.Y + (int)(Height * (3 / 4.0)), Height / 4, Height / 4));
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.Draw(me.Texture, new Rectangle(Bound.X, Bound.Y, 50, 50), Color.White);
            draw.DrawString(GUI.Font, me.Name, new Vector2(Bound.X + 60, Bound.Y + 15), Color.Black);
            draw.DrawString(GUI.Font, Player.Instance.GetPlayerNick(Player.Instance.HeroParty.GetPlayerId(me)), new Vector2(Bound.X + 5, Bound.Y + 65), Color.White);

            draw.DrawString(GUI.Font, me.Health + "/" + me.MaxHealth, new Vector2(Bound.X + Bound.Width / 2 + 30, Bound.Y + Bound.Height / 2), Color.Black);
            draw.DrawString(GUI.Font, me.Fatigue + "/" + me.MaxFatigue, new Vector2(Bound.X + Bound.Width / 2 + 30, Bound.Y + (int)(Bound.Height * (3 / 4.0))), Color.Black);
            draw.DrawString(GUI.Font, me.MovementLeft + "/" + me.Speed, new Vector2(Bound.X + (int)(Bound.Width * (3 / 4.0)) + 30, Bound.Y + Bound.Height / 2), Color.Black);
            draw.DrawString(GUI.Font, "" + me.AttacksLeft, new Vector2(Bound.X + (int)(Bound.Width * (3 / 4.0)) + 30, Bound.Y + (int)(Bound.Height * (3 / 4.0))), Color.Black);
        }
    }
}
