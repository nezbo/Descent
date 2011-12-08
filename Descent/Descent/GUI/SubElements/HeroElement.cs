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

        private Texture2D health;
        private Rectangle healthRect;
        private Texture2D fatigue;
        private Rectangle fatigueRect;
        private Texture2D movement;
        private Rectangle movementRect;

        public HeroElement(Game game, Hero hero)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {
            this.hero = hero;
            this.SetBackground("boxbg");

            //this.AddDrawable(this.Name, new Image(hero.BigTexture), new Vector2(0, this.Bound.Height - hero.BigTexture.Height));
            health = game.Content.Load<Texture2D>("Images/Other/health-small");
            fatigue = game.Content.Load<Texture2D>("Images/Other/fatigue-small");
            movement = game.Content.Load<Texture2D>("Images/Other/movement-small");

            healthRect = new Rectangle(210, this.Bound.Height - 200, 66, 66);
            fatigueRect = new Rectangle(210, this.Bound.Height - 200 + 66, 66, 66);
            movementRect = new Rectangle(210, this.Bound.Height - 200 + 132, 66, 66);

            // the equipment panels

            List<Equipment> equipment = new List<Equipment>();
            equipment.Add(hero.Inventory.Weapon);
            equipment.Add(hero.Inventory.Armor);
            equipment.Add(hero.Inventory.Shield);
            equipment.AddRange(hero.Inventory.OtherItems);

            AddChild(new EquipmentPanel(game, 300, Bound.Height - 50, equipment));
        }

        public override void Draw(SpriteBatch draw)
        {
            base.Draw(draw);

            draw.Draw(health, healthRect, Color.White);
            draw.Draw(fatigue, fatigueRect, Color.White);
            draw.Draw(movement, movementRect, Color.White);

            draw.DrawString(GUI.Font, hero.Health + "/" + hero.MaxHealth, new Vector2(healthRect.X, healthRect.Y), Color.White);
            draw.DrawString(GUI.Font, hero.Fatigue + "/" + hero.MaxFatigue, new Vector2(fatigueRect.X, fatigueRect.Y), Color.White);
            draw.DrawString(GUI.Font, hero.SpeedLeft + "/" + hero.Speed, new Vector2(movementRect.X, movementRect.Y), Color.White);
        }
    }
}
