namespace Descent.GUI.SubElements
{
    using System.Collections.Generic;
    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The specialized user interface for a hero player. It displays most of
    /// the hero's belongings and scores along with an image of the hero.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class HeroElement : GUIElement
    {
        private Hero hero;

        private Texture2D meleeT;
        private Texture2D rangedT;
        private Texture2D magicT;

        private Texture2D coin25;
        private Texture2D coin100;
        private Texture2D coin500;

        private Rectangle healthRect;
        private Rectangle fatigueRect;
        private Rectangle armorRect;
        private Rectangle movementRect;
        private Rectangle attacksRect;

        /// <summary>
        /// Creates a new HeroElement to visualize the given hero.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="hero">The hero to display.</param>
        public HeroElement(Game game, Hero hero)
            : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
        {
            this.hero = hero;
            this.SetDrawBackground(false);

            meleeT = game.Content.Load<Texture2D>("Images/Other/training-melee");
            rangedT = game.Content.Load<Texture2D>("Images/Other/training-ranged");
            magicT = game.Content.Load<Texture2D>("Images/Other/training-magic");

            coin25 = game.Content.Load<Texture2D>("Images/Other/25gold");
            coin100 = game.Content.Load<Texture2D>("Images/Other/100gold");
            coin500 = game.Content.Load<Texture2D>("Images/Other/500gold");

            healthRect = new Rectangle(225, this.Bound.Height - 150, 50, 50);
            fatigueRect = new Rectangle(225, this.Bound.Height - 100, 50, 50);
            armorRect = new Rectangle(225, this.Bound.Height - 50, 50, 50);
            movementRect = new Rectangle(275, this.Bound.Height - 100, 50, 50);
            attacksRect = new Rectangle(275, this.Bound.Height - 50, 50, 50);

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/health-small")), healthRect);

            GUIElement fatigueBox = new GUIElement(game, "fatigue", fatigueRect.X, fatigueRect.Y, fatigueRect.Width, fatigueRect.Height);
            fatigueBox.SetDrawBackground(false);
            fatigueBox.AddDrawable(fatigueBox.Name, new Image(game.Content.Load<Texture2D>("Images/Other/fatigue-small")), fatigueRect);
            fatigueBox.SetClickAction(fatigueBox.Name, (n, g) =>
                                                         {
                                                             n.EventManager.QueueEvent(EventType.FatigueClicked, new GameEventArgs());
                                                         });
            AddChild(fatigueBox);

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/movement-small")), movementRect);
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/attacks-small")), attacksRect);
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/armor-small")), armorRect);

            Vector2 nameV = GUI.Font.MeasureString(hero.Name);
            int nameX = (int)((200 - nameV.X) / 2);
            int nameY = Bound.Height - 30;

            // cost stuff
            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/cost-small")), new Rectangle(0, Bound.Height - 70, 40, 40));

            string cost = "" + hero.Cost;
            Vector2 size = GUI.Font.MeasureString(cost);
            this.AddText(this.Name, cost, new Vector2((40 - size.X) / 2, Bound.Height - 70 + (40 - size.Y) / 2), Color.White);

            this.AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("heroheader")), new Rectangle(nameX - 10, nameY - 5, (int)nameV.X + 20, (int)nameV.Y + 10));
            this.AddText(this.Name, hero.Name, new Vector2(nameX, nameY));

            // the equipment panels

            List<Equipment> equipment = new List<Equipment>();
            equipment.Add(hero.Inventory.Weapon);
            equipment.Add(hero.Inventory.Shield);
            equipment.Add(hero.Inventory.Armor);
            equipment.AddRange(hero.Inventory.OtherItems);

            AddChild(new EquipmentPanel(game, "Equipped", 350, Bound.Height - 50, hero.Inventory, new int[] { 0, 1, 2, 3, 4 }));

            AddChild(new EquipmentPanel(game, "Backpack", 500, Bound.Height - 50, hero.Inventory, new int[] { 8, 9, 10 }));

            AddChild(new EquipmentPanel(game, "Potions", 650, Bound.Height - 50, hero.Inventory, new int[] { 5, 6, 7 }));
        }

        public override void Draw(SpriteBatch draw)
        {
            // face
            draw.Draw(hero.BigTexture, new Rectangle(0, Bound.Height - 200, 200, 200), Color.White);

            // coin icon
            Texture2D chosen = hero.Coins <= 100 ? coin25 : (hero.Coins < 500 ? coin100 : coin500);
            draw.Draw(chosen, new Rectangle(45, Bound.Height - 70, 40, 40), Color.White);

            string coins = "" + hero.Coins;
            Vector2 coinSize = GUI.Font.MeasureString(coins);
            draw.DrawString(GUI.Font, coins, new Vector2(45 + (40 - coinSize.X) / 2, Bound.Height - 70 + (40 - coinSize.Y) / 2), Color.Black);

            base.Draw(draw);

            // training
            int yPos = Bound.Height - 25;
            int number;

            number = hero.TrainingTokens(EAttackType.MELEE);
            while (number > 0)
            {
                draw.Draw(meleeT, new Rectangle(200, yPos, 25, 25), Color.White);
                yPos -= 25;
                number--;
            }
            number = hero.TrainingTokens(EAttackType.RANGED);
            while (number > 0)
            {
                draw.Draw(rangedT, new Rectangle(200, yPos, 25, 25), Color.White);
                yPos -= 25;
                number--;
            }
            number = hero.TrainingTokens(EAttackType.MAGIC);
            while (number > 0)
            {
                draw.Draw(magicT, new Rectangle(200, yPos, 25, 25), Color.White);
                yPos -= 25;
                number--;
            }

            // values
            string healthString = hero.Health + "/" + hero.MaxHealth;
            int healthX = healthRect.X + (int)(healthRect.Width - GUI.Font.MeasureString(healthString).X) / 2;
            draw.DrawString(GUI.Font, healthString, new Vector2(healthX, healthRect.Y + 16), Color.White);

            draw.DrawString(GUI.Font, hero.Fatigue + "/" + hero.MaxFatigue, new Vector2(fatigueRect.X + 12, fatigueRect.Y + 25), Color.White);
            draw.DrawString(GUI.Font, "" + hero.Armor, new Vector2(armorRect.X + 20, armorRect.Y + 12), Color.White);
            draw.DrawString(GUI.Font, hero.MovementLeft + "/" + hero.Speed, new Vector2(movementRect.X + 15, movementRect.Y + 20), Color.White);
            draw.DrawString(GUI.Font, "" + hero.AttacksLeft, new Vector2(attacksRect.X + 35, attacksRect.Y + 28), Color.White);
        }
    }
}
