using Descent.Messaging.Events;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;

namespace Descent.GUI
{
    class EquipmentElement : GUIElement
    {
        private Equipment equipment;

        public EquipmentElement(Game game, int posX, int posY, int width, int height, Equipment eq)
            : base(game, "equipment", posX, posY, width, height)
        {
            equipment = eq;

            switch (equipment.Rarity)
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

            this.AddClickAction(this.Name, n => n.EventManager.QueueEvent(EventType.RequestBuyEquipment, new RequestBuyEquipmentEventArgs(equipment.Id)));
            this.AddText(this.Name, equipment.Name, new Vector2(0, 0));
        }
    }
}
