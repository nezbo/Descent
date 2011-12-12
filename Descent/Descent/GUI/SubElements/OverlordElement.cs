﻿
using Descent.Model.Player;
using Descent.Model.Player.Overlord;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class OverlordElement : GUIElement
    {
        public OverlordElement(Game game)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {
            SetDrawBackground(false);
            AddDrawable(Name, new Image(game.Content.Load<Texture2D>("Images/Heroes/BIG-0")), new Rectangle(Bound.X, Bound.Y + Bound.Height - 200, 200, 200));

            int cardX = 250;
            foreach (OverlordCard card in Player.Instance.Overlord.Hand)
            {
                AddChild(new OverlordCardElement(game, cardX, Bound.Height - 25, card));
                cardX += 50;
            }
        }
    }
}
