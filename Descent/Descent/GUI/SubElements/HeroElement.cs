using System.Collections.Generic;
using Descent.Model.Player.Figure;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI.SubElements
{
    class HeroElement : GUIElement
    {
        private Hero hero;

        private Rectangle healthRect;
        private Rectangle fatigueRect;
        private Rectangle movementRect;

        public HeroElement(Game game, Hero hero)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {
            this.hero = hero;
            this.SetDrawBackground(false);

            healthRect = new Rectangle(210, this.Bound.Height - 200, 66, 66);
            fatigueRect = new Rectangle(210, this.Bound.Height - 200 + 66, 66, 66);
            movementRect = new Rectangle(210, this.Bound.Height - 200 + 132, 66, 66);

            this.AddDrawable(this.Name, new Image(hero.BigTexture), new Vector2(0, this.Bound.Height - hero.BigTexture.Height));
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/health-small")), healthRect);
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/fatigue-small")), fatigueRect);
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/movement-small")), movementRect);

            Vector2 nameV = GUI.Font.MeasureString(hero.Name);
            int nameX = (int)((200 - nameV.X) / 2);
            int nameY = Bound.Height - 30;

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("heroheader")), new Rectangle(nameX - 10, nameY - 5, (int)nameV.X + 20, (int)nameV.Y + 10));
            this.AddText(this.Name, hero.Name, new Vector2(nameX, nameY));

            // the equipment panels

            List<Equipment> equipment = new List<Equipment>();
            equipment.Add(hero.Inventory.Weapon);
            equipment.Add(hero.Inventory.Shield);
            equipment.Add(hero.Inventory.Armor);
            equipment.AddRange(hero.Inventory.OtherItems);

            AddChild(new EquipmentPanel(game, "Equipped", 300, Bound.Height - 50, hero.Inventory, new int[] { 0, 1, 2, 3, 4 }));

            AddChild(new EquipmentPanel(game, "Backpack", 450, Bound.Height - 50, hero.Inventory, new int[] { 8, 9, 10 }));

            AddChild(new EquipmentPanel(game, "Potions", 600, Bound.Height - 50, hero.Inventory, new int[] { 5, 6, 7 }));
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.DrawString(GUI.Font, hero.Health + "/" + hero.MaxHealth, new Vector2(healthRect.X + 15, healthRect.Y + 20), Color.White);
            draw.DrawString(GUI.Font, hero.Fatigue + "/" + hero.MaxFatigue, new Vector2(fatigueRect.X + 20, fatigueRect.Y + 35), Color.White);
            draw.DrawString(GUI.Font, hero.MovementLeft + "/" + hero.Speed, new Vector2(movementRect.X + 20, movementRect.Y + 30), Color.White);
        }
    }
}
