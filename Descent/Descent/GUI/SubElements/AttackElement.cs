using System.Collections.Generic;
using System.Collections.ObjectModel;
using Descent.Messaging.Events;
using Descent.Model;
using Descent.Model.Board;
using Descent.Model.Event;
using Descent.Model.Player.Figure;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class AttackElement : GUIElement
    {
        private Attack attack;

        public AttackElement(Game game, Attack attack, int x, int y, int width, int height)
            : base(game, "attack", x, y, width, height)
        {
            this.attack = attack;

            AddChild(new DicesElement(game, attack.DiceForAttack.ToArray(), Bound.X + (int)(Bound.Width * 0.4), Bound.Y, (int)(Bound.Width * 0.6), Bound.Height / 2));

            //TODO: some way to spend surges
            List<SurgeAbility> surges = attack.SurgeAbilities;

            int yPos = Bound.Y + Bound.Height / 2;
            int xPos = Bound.X + (int)(Bound.Width * 0.4);
            int surgeHeight = 50;
            int surgeWidth = (int)(Bound.Width * 0.3);
            bool left = true;

            // Surge abilities
            SurgeAbility surge;
            for (int i = 0; i < surges.Count; i++)
            {
                int id = i;
                surge = surges[i];
                GUIElement surgeBox = new GUIElement(game, "surge box", left ? xPos : xPos + surgeWidth, yPos, surgeWidth, surgeHeight);
                surgeBox.SetBackground("boxbg");

                // icons
                int cost = surge.Cost;
                int costX = surgeBox.Bound.X + 5;
                while (cost > 0)
                {
                    Image img = new Image(game.Content.Load<Texture2D>("Images/Other/surge"));
                    surgeBox.AddDrawable(surgeBox.Name, img, new Vector2(costX, surgeBox.Bound.Y + 10));
                    cost--;
                    costX += img.Texture.Width + 2;
                }

                // text
                costX += 10;
                string s = surge.Ability.ToString();
                surgeBox.AddText(surgeBox.Name, ": " + surge.Ability.ToString(), new Vector2(costX - surgeBox.Bound.X, 5));

                // click event
                surgeBox.SetClickAction(surgeBox.Name, (n, g) =>
                {
                    System.Diagnostics.Debug.WriteLine(id);
                    n.EventManager.QueueEvent(EventType.SurgeAbilityClicked, new SurgeAbilityEventArgs(id));
                });

                AddChild(surgeBox);

                // ready for next ability
                if (!left) yPos += height;
                left = !left;
            }

            // target monster (if any)
            Square square = FullModel.Board[attack.TargetSquare.X, attack.TargetSquare.Y];
            if (square.Figure != null && square.Figure is Monster)
            {
                GUIElement target = new MonsterSummary(game, Bound.X + (int)((Bound.Width * 0.4 - 125) / 2), Bound.Y + Bound.Height / 2 + (int)((Bound.Height / 2 - 175) / 2), (Monster)square.Figure);
                AddChild(target);
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);
            Collection<GUIElement> guiElements = children;

            draw.DrawString(GUI.Font, attack.ToString(), new Vector2(Bound.X + 5, Bound.Y + 5), Color.Black);
        }
    }
}
