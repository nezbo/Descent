using System.Collections.Generic;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class EquipmentPanel : GUIElement
    {
        private bool expanded;

        public EquipmentPanel(Game game, string title, int x, int y, List<Equipment> content, List<int> ids)
            : base(game, "equipment panel", x, y, 1, 1)
        {
            expanded = false;
            SetBackground("boxbg");

            // create equipment elements
            int innerWidth = 0;
            int height = 0;
            int space = 10;
            for (int i = 0; i < content.Count; i++)
            {
                EquipmentElement e = GUIElementFactory.CreateEquipmentElement(game, Bound.X + 10,
                                                                              Bound.Y + 50 + i * height + i * space,
                                                                              content[i], ids[i]);
                height = e.Bound.Height;
                innerWidth = e.Bound.Width;
                AddChild(e);
            }

            Bound = new Rectangle(Bound.X, Bound.Y, innerWidth + 20, 50 + content.Count * height + (content.Count - 1) * space);

            AddText(this.Name, title, new Vector2(5, 10));
        }

        protected override void ActOnDirectClick(int x, int y)
        {
            Move(0, expanded ? Bound.Height - 50 : -(Bound.Height - 50));
            expanded = !expanded;
        }
    }
}
