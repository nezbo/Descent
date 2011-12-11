using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class MonsterSummary : GUIElement
    {
        public MonsterSummary(Game game, int x, int y, Monster monster)
            : base(game, "monster summary", x, y, 125, 175)
        {
            SetBackground("boxbg");

            // images
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/movement-small")), new Rectangle(Bound.X, Bound.Y + 25, 25, 25));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/health-small")), new Rectangle(Bound.X + Bound.Width / 2, Bound.Y + 25, 25, 25));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/armor-small")), new Rectangle(Bound.X, Bound.Y + 55, 25, 25));

            // text
            AddText(this.Name, monster.Name, new Vector2(0, 0));
            AddText(this.Name, monster.MovementLeft + "/" + monster.Speed, new Vector2(30, 25));
            AddText(this.Name, monster.Health + "/" + monster.MaxHealth, new Vector2(30 + Bound.Width / 2, 25));
            AddText(this.Name, "" + monster.Armor, new Vector2(30, 55));
        }
    }
}
