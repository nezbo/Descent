using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;

namespace Descent.GUI
{
    public class EquipmentElement : GUIElement
    {
        public Equipment Equipment { get; set; }

        public EquipmentElement(Game game, int posX, int posY, int width, int height, Equipment eq)
            : base(game, "item", posX, posY, width, height)
        {
            Equipment = eq;

            if (Equipment == null)
            {
                this.SetBackground("Images/Other/equipbg");
                this.AddText(this.Name, "Empty", new Vector2(0, 0));
            }
            else
            {
                switch (Equipment.Rarity)
                {
                    case EquipmentRarity.Common:
                        {
                            this.SetBackground("Images/Other/equipbg");
                            break;
                        }
                    case EquipmentRarity.Bronze:
                        {
                            this.SetBackground("Images/Other/equipbg-bronze");
                            break;
                        }
                    case EquipmentRarity.Silver:
                        {
                            this.SetBackground("Images/Other/equipbg-silver");
                            break;
                        }
                    case EquipmentRarity.Gold:
                        {
                            this.SetBackground("Images/Other/equipbg-gold");
                            break;
                        }
                }
                this.AddText(this.Name, Equipment.Name, new Vector2(0, 0));
            }
        }
    }
}
