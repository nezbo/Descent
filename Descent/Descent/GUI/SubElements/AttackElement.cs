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

                GUIElementFactory.DrawSurgeAbility(surgeBox, surge, xPos, 10, false);

                // click event
                surgeBox.SetClickAction(surgeBox.Name, (n, g) =>
                {
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
            else if (square.Figure != null && square.Figure is Hero)
            {
                Image picture = new Image(((Hero)square.Figure).Texture);
                AddDrawable(Name, picture, new Vector2(Bound.X + (int)((Bound.Width * 0.4 - picture.Texture.Width) / 2),
                                                       Bound.Y + Bound.Height / 2 + (int)((Bound.Height / 2 - picture.Texture.Height) / 2)));
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
