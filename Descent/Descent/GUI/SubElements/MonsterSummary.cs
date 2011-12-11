using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class MonsterSummary : GUIElement
    {
        public MonsterSummary(Game game, int x, int y, Monster monster)
            : base(game, "monster summary", x, y, 150, 250)
        {
            SetBackground("boxbg");
        }
    }
}
