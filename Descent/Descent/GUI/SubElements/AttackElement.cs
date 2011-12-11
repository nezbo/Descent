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

        public AttackElement(Game game, Attack attack, int x, int y, int width, int height)
            : base(game, "attack", x, y, width, height)
        {
            this.attack = attack;

            AddChild(new DicesElement(game, attack.DiceForAttack.ToArray(), Bound.X + (int)(Bound.Width * 0.4), Bound.Y, (int)(Bound.Width * 0.6), Bound.Height / 2));

            //TODO: some way to spend surges
            List<SurgeAbility> surge = attack.SurgeAbilities;

            int yPos = Bound.Height / 2;
            int height = 100;
            bool left = true;

            for (int i = 0; i < surge.Count; i++)
            {

            }
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, attack.ToString(), new Vector2(Bound.X + 5, Bound.Y + 5), Color.Black);
        }
    }
}
