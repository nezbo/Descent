namespace Descent.GUI.SubElements
{
    using System;
    using System.Collections.Generic;
    using Descent.Messaging.Events;
    using Descent.Model.Player.Figure.HeroStuff;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// A panel of EquipmentElements that expands and hides by user clicks.
    /// The panel links to a range of slots in an inventory and updates itself
    /// whenever the equipment at the slots change.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class EquipmentPanel : GUIElement
    {
        private bool expanded;

        private Dictionary<int, EquipmentElement> equipments;
        private int[] slots;
        private Inventory inventory;

        /// <summary>
        /// Creates an EquipmentPanel that can be expanded and hidden by being
        /// clicked on by the user.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="title">The title to display at the top.</param>
        /// <param name="x">The top-left x-coordinate of the EquipmentPanel when hidden.</param>
        /// <param name="y">The top-left y-coordinate of the EquipmentPanel when hidden.</param>
        /// <param name="inv">The inventory to show equipment from.</param>
        /// <param name="slots">The indexes (slots) of the inventory to visualize.</param>
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

        private string GetSlotType(int index)
        {
            string name = "";
            foreach (EquipmentSlot e in Enum.GetValues(typeof(EquipmentSlot)))
            {
                int value = (int)e;
                if (value > index)
                {
                    break;
                }
                else
                {
                    name = e.ToString();
                }
            }
            return name;
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
                                                              GetSlotType(slots[i]), inventory[slots[i]], slots[i]);

                    e.SetClickAction("item", (n, g) =>
                    {
                        if (g is EquipmentElement)
                        {
                            int id = ((EquipmentElement)g).Id;
                            n.EventManager.QueueEvent(EventType.InventoryFieldMarked, new InventoryFieldEventArgs(id));
                        }
                    });

                    equipments[slots[i]] = e;
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

        public override void Update(GameTime gameTime)
        {
            UpdateInventory();
            base.Update(gameTime);
        }
    }
}
