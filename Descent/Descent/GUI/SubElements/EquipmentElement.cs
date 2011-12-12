using System.Collections.Generic;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;

namespace Descent.GUI
{
    public class EquipmentElement : GUIElement
    {
        private static string Marked;
        private Dictionary<EquipmentRarity, string> Border;

        public Equipment Equipment { get; internal set; }
        public int Id { get; internal set; }

        public EquipmentElement(Game game, int posX, int posY, int width, int height, string slotTitle, Equipment eq, int id)
            : base(game, "item", posX, posY, width, height)
        {
            Equipment = eq;
            Id = id;

            if (Marked == null) Marked = "Images/Other/equipbg-marked";
            if (Border == null)
            {
                Border = new Dictionary<EquipmentRarity, string>();
                Border.Add(EquipmentRarity.Common, "Images/Other/equipbg");
                Border.Add(EquipmentRarity.Copper, "Images/Other/equipbg-bronze");
                Border.Add(EquipmentRarity.Silver, "Images/Other/equipbg-silver");
                Border.Add(EquipmentRarity.Gold, "Images/Other/equipbg-gold");
            }

            if (Equipment == null)
            {
                this.AddText(this.Name, slotTitle.Length > 0 ? slotTitle + " (Empty)" : "(Empty)", new Vector2(0, 0));
            }
            else
            {
                this.AddText(this.Name, Equipment.Name, new Vector2(0, 0));
            }
            SetBackground(GetBGString());
        }

        private string GetBGString()
        {
            return (Equipment == null) ? Border[EquipmentRarity.Common] : Border[Equipment.Rarity];
        }

        public override bool HandleClick(int x, int y)
        {
            bool result = base.HandleClick(x, y);
            SetBackground(HasFocus() ? Marked : GetBGString()); // update bg

            return result;
        }
    }
}
