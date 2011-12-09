using System.Collections.Generic;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class EquipmentPanel : GUIElement
    {
        private bool expanded;

        private Dictionary<int, EquipmentElement> equipments;
        private int[] slots;
        private Inventory inventory;

        public EquipmentPanel(Game game, string title, int x, int y, Inventory inv, int[] slots)
            : base(game, "equipment panel", x, y, 1, 1)
        {
            expanded = false;
            SetBackground("boxbg");

            equipments = new Dictionary<int, EquipmentElement>();
            inventory = inv;
            this.slots = slots;

            UpdateInventory();

            Bound = new Rectangle(Bound.X, Bound.Y, equipments[slots[0]].Bound.Width + 20, 50 + slots.Length * equipments[slots[0]].Bound.Height + (slots.Length - 1) * 10);

            AddText(this.Name, title, new Vector2(5, 10));
        }

        private void UpdateInventory()
        {
            bool changed = false;
            int height = 0;
            int space = 10;
            for (int i = 0; i < slots.Length; i++)
            {
                if (!equipments.ContainsKey(slots[i]) || equipments[slots[i]].Equipment != inventory[slots[i]])
                {
                    if (i != 0 && height == 0)
                    {
                        height = equipments[slots[0]].Bound.Height;
                    }
                    EquipmentElement e = GUIElementFactory.CreateEquipmentElement(Game, Bound.X + 10,
                                                              Bound.Y + 50 + i * height + i * space,
                                                              inventory[slots[i]], slots[i]);
                    equipments.Add(slots[i], e);
                    changed = true;
                }
            }

            if (changed)
            {
                this.ClearChildren();
                foreach (EquipmentElement e in equipments.Values) this.AddChild(e);
            }
        }

        protected override void ActOnDirectClick(int x, int y)
        {
            Move(0, expanded ? Bound.Height - 50 : -(Bound.Height - 50));
            expanded = !expanded;
        }

        public override void Draw(SpriteBatch draw)
        {
            UpdateInventory();
            base.Draw(draw);
        }
    }
}
