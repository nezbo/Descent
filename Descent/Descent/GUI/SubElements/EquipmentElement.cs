namespace Descent.GUI.SubElements
{
    using System.Collections.Generic;
    using System.Linq;
    using Descent.Model;
    using Descent.Model.Event;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure.HeroStuff;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Displays a single Equipment to the screen.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class EquipmentElement : GUIElement
    {
        private static string Marked;
        private static SpriteFont EquipmentFont { get; set; }

        private Dictionary<EquipmentRarity, string> Border;

        private Image Coin;
        private Texture2D Hand;

        /// <summary>
        /// The Equipment that this element displays.
        /// </summary>
        public Equipment Equipment { get; internal set; }

        /// <summary>
        /// The Id of the Equipment that this element displays.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Creates a new Equipment element to display the given Equipment at the given position.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="posX">The top-left x-coordinate of this element.</param>
        /// <param name="posY">The top-left y-coordinate of this element.</param>
        /// <param name="width">The width of this element.</param>
        /// <param name="height">The height of this element.</param>
        /// <param name="slotTitle">The title of this slot, in case the Equipment isn't there (null).</param>
        /// <param name="eq">The Equipment to visualize.</param>
        /// <param name="id">The Id of the given Equipment.</param>
        public EquipmentElement(Game game, int posX, int posY, int width, int height, string slotTitle, Equipment eq, int id)
            : base(game, "item", posX, posY, width, height)
        {
            Equipment = eq;
            Id = id;

            if (Coin == null) Coin = new Image(game.Content.Load<Texture2D>("Images/Other/25gold"));
            if (Hand == null) Hand = game.Content.Load<Texture2D>("Images/Other/hand");

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

            Vector2 nameSize = this.Font.MeasureString(texts[0].Message);
            yPos += (int)nameSize.Y + 5;

            this.AddText(this.Name, Equipment.Type.ToString(), new Vector2(4, yPos));

            yPos += 20;

            // specifics
            switch (Equipment.Type)
            {
                case EquipmentType.Weapon:
                    {
                        Rectangle wpnTypeRect = new Rectangle(Bound.X + Bound.Width / 2 + 10, Bound.Y + yPos - 20, 15, 15);
                        switch (Equipment.AttackType)
                        {
                            case EAttackType.MAGIC: AddDrawable(Name, new Image(Game.Content.Load<Texture2D>("Images/Other/magic-icon")), wpnTypeRect);
                                break;
                            case EAttackType.MELEE: AddDrawable(Name, new Image(Game.Content.Load<Texture2D>("Images/Other/melee-icon")), wpnTypeRect);
                                break;
                            case EAttackType.RANGED: AddDrawable(Name, new Image(Game.Content.Load<Texture2D>("Images/Other/ranged-icon")), wpnTypeRect);
                                break;
                        }

                        foreach (SurgeAbility ability in Equipment.SurgeAbilities)
                        {
                            GUIElementFactory.DrawSurgeAbility(this, ability, 2, yPos, true);
                            yPos += (int)Font.MeasureString(texts[texts.Count - 1].Message).Y;
                        }

                        int xHand = 45;
                        for (int i = 0; i < Equipment.Hands; i++)
                        {
                            AddDrawable(Name, new Image(Hand), new Rectangle(Bound.X + xHand, Bound.Y + Bound.Height - 19, 15, 15));
                            xHand += 15;
                        }

                        int yDice = Bound.Y + Bound.Height - 19;
                        int xDice = Bound.X + xHand;
                        EDice[] dices = Equipment.DiceForAttack.Select(n => n.Color).ToArray();
                        foreach (EDice dice in dices)
                        {
                            GUIElementFactory.DrawDice(this, dice, xDice, yDice, 15);
                            if (xDice + 15 > Bound.X + Bound.Width)
                            {
                                xDice = Bound.X + xHand;
                                yDice -= 15;
                            }
                            xDice += 15;
                        }

                        break;
                    }
                default:
                    {
                        foreach (Ability a in Equipment.Abilities)
                        {
                            string s = a.ToString();
                            AddText(Name, s, new Vector2(4, yPos));
                            yPos += (int)Font.MeasureString(s).Y;
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
