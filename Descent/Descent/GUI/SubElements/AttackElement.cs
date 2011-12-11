using System.Collections.Generic;
using Descent.Model.Event;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class AttackElement : GUIElement
    {
        private Attack attack;
        private Image surgeImage;

        public AttackElement(Game game, Attack attack, int x, int y, int width, int height)
            : base(game, "attack", x, y, width, height)
        {
            this.attack = attack;

            AddChild(new DicesElement(game, attack.DiceForAttack.ToArray(), Bound.X + (int)(Bound.Width * 0.4), Bound.Y, (int)(Bound.Width * 0.6), Bound.Height / 2));

            //TODO: some way to spend surges
            surgeImage = new Image(game.Content.Load<Texture2D>("Images/Other/surge"));
            List<SurgeAbility> surges = attack.SurgeAbilities;

            int yPos = Bound.Height / 2;
            int xPos = (int)(Bound.Width * 0.4);
            int height = 100;
            int width = (int)(Bound.Width * 0.3);
            bool left = true;

            SurgeAbility surge;
            for (int i = 0; i < surges.Count; i++)
            {
                surge = surges[i];
                GUIElement surgeBox = new GUIElement(game, "surge box", left ? xPos : xPos + width, yPos, width, height);

                // icons
                int cost = surge.Cost;
                int costX = surgeBox.Bound.X + 5;
                while (cost > 0)
                {
                    surgeBox.AddDrawable(surgeBox.Name, surgeImage, new Vector2(costX, surgeBox.Bound.Y + 5));
                    cost--;
                    costX += surgeImage.Texture.Width + 5;
                }

                // text
                costX += 10;
                surgeBox.AddText(surgeBox.Name, ": " + surge.Ability.ToString(), new Vector2(costX, surgeBox.Bound.Y + 5));

                AddChild(surgeBox);

                // ready for next ability
                if (!left) yPos += height;
                left = !left;
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, attack.ToString(), new Vector2(Bound.X + 5, Bound.Y + 5), Color.Black);
        }
    }
}
