using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;

namespace Descent.GUI
{
    public class EquipmentElement : GUIElement
    {
        private static string Marked;
        private string Border;

        public Equipment Equipment { get; internal set; }
        public int Id { get; internal set; }

        public EquipmentElement(Game game, int posX, int posY, int width, int height, Equipment eq, int id)
            : base(game, "item", posX, posY, width, height)
        {
            Equipment = eq;
            Id = id;

            if (Marked == null) Marked = "Images/Other/equipbg-marked";

            if (Equipment == null)
            {
                Border = "Images/Other/equipbg";
                this.AddText(this.Name, "Empty", new Vector2(0, 0));
            }
            else
            {
                switch (Equipment.Rarity)
                {
                    case EquipmentRarity.Common:
                        {
                            Border = "Images/Other/equipbg";

                            break;
                        }
                    case EquipmentRarity.Bronze:
                        {
                            Border = "Images/Other/equipbg-bronze";
                            break;
                        }
                    case EquipmentRarity.Silver:
                        {
                            Border = "Images/Other/equipbg-silver";
                            break;
                        }
                    case EquipmentRarity.Gold:
                        {
                            Border = "Images/Other/equipbg-gold";
                            break;
                        }
                }
                this.AddText(this.Name, Equipment.Name, new Vector2(0, 0));
            }
            SetBackground(Border);
        }

        public override bool HandleClick(int x, int y)
        {
            bool result = base.HandleClick(x, y);
            if (HasPoint(x, y)) SetBackground(HasFocus() ? Marked : Border); // update bg

            return result;
        }
    }
}
