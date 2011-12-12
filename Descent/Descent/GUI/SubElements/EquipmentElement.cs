using System.Collections.Generic;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI
{
    public class EquipmentElement : GUIElement
    {
        private static string Marked;
        private static SpriteFont EquipmentFont { get; set; }

        private Dictionary<EquipmentRarity, string> Border;

        private Image Coin;

        public Equipment Equipment { get; internal set; }
        public int Id { get; internal set; }

        public EquipmentElement(Game game, int posX, int posY, int width, int height, string slotTitle, Equipment eq, int id)
            : base(game, "item", posX, posY, width, height)
        {
            Equipment = eq;
            Id = id;

            if (Coin == null) Coin = new Image(game.Content.Load<Texture2D>("Images/Other/25gold"));

            if (EquipmentFont == null) EquipmentFont = game.Content.Load<SpriteFont>("fontSmall");
            SetFont(EquipmentFont);

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
                PopulateItem();
            }
            SetBackground(GetBGString());
        }

        private void PopulateItem()
        {
            int yPos = 2;
            this.AddText(this.Name, Equipment.Name, new Vector2(4, yPos));

            Vector2 nameSize = this.Font.MeasureString(texts[0].Line);
            yPos += (int)nameSize.Y + 5;

            this.AddText(this.Name, Equipment.Type.ToString() == "Weapon" ? "Wpn" : Equipment.Type.ToString(), new Vector2(4, yPos));

            // specifics
            switch (Equipment.Type)
            {
                case EquipmentType.Weapon:
                    {
                        this.AddText(Name, "(" + Equipment.AttackType.ToString() + ")", new Vector2((int)(Bound.Width * (1 / 3.0)), yPos));
                        yPos += 20;
                        foreach (SurgeAbility ability in Equipment.SurgeAbilities)
                        {
                            GUIElementFactory.DrawSurgeAbility(this, ability, 2, yPos, true);
                            yPos += (int)Font.MeasureString(texts[texts.Count - 1].Line).Y;
                        }


                        break;
                    }
            }

            // price
            this.AddDrawable(Name, Coin, new Rectangle(Bound.X + 4, Bound.Y + Bound.Height - 19, 15, 15));
            this.AddText(Name, "" + Equipment.BuyPrice, new Vector2(22, Bound.Height - 19));
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
