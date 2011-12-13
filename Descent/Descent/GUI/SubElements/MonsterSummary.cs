namespace Descent.GUI.SubElements
{
    using System.Linq;
    using System.Text;
    using Descent.Model;
    using Descent.Model.Event;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The summary of a monsters information to be displayed as a
    /// mouseover effect on the board and when attacking a specific
    /// monster.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class MonsterSummary : GUIElement
    {

        /// <summary>
        /// Creates a new monster summary element to display information about
        /// the given monster starting from the given coordinates.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="x">The top-left x-coordinate of the element.</param>
        /// <param name="y">The top-left y-coordinate of the element.</param>
        /// <param name="monster">The Monster to display information for.</param>
        public MonsterSummary(Game game, int x, int y, Monster monster)
            : base(game, "monster summary", x, y, 125, 175)
        {
            SetBackground("boxbg");

            // top images
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/movement-small")), new Rectangle(Bound.X, Bound.Y + 25, 25, 25));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/health-small")), new Rectangle(Bound.X + Bound.Width / 2, Bound.Y + 25, 25, 25));
            AddDrawable(this.Name, new Image(game.Content.Load<Texture2D>("Images/Other/armor-small")), new Rectangle(Bound.X, Bound.Y + 55, 25, 25));

            // top text
            AddText(this.Name, monster.Name, new Vector2(0, 0));
            AddText(this.Name, monster.MovementLeft + "/" + monster.Speed, new Vector2(30, 25));
            AddText(this.Name, monster.Health + "/" + monster.MaxHealth, new Vector2(30 + Bound.Width / 2, 25));
            AddText(this.Name, "" + monster.Armor, new Vector2(30, 55));

            // icons part
            Texture2D attackType;
            switch (monster.AttackType)
            {
                case EAttackType.MAGIC:
                    {
                        attackType = game.Content.Load<Texture2D>("Images/Other/magic-icon");
                        break;
                    }

                case EAttackType.RANGED:
                    {
                        attackType = game.Content.Load<Texture2D>("Images/Other/ranged-icon");
                        break;
                    }
                default:
                    {
                        attackType = game.Content.Load<Texture2D>("Images/Other/melee-icon");
                        break;
                    }
            }

            AddDrawable(this.Name, new Image(attackType), new Rectangle(Bound.X + 5, Bound.Y + 85, 20, 20));
            int xPos = Bound.X + 35;
            int yPos = Bound.Y + 85;
            foreach (EDice dice in monster.DiceForAttack.Select(n => n.Color))
            {
                if (xPos + 20 >= (Bound.X + Bound.Width))
                {
                    yPos += 20;
                    xPos = Bound.X + 35;
                }

                GUIElementFactory.DrawDice(this, dice, xPos, yPos, 20);
                xPos += 20;
            }

            // abilities
            StringBuilder builder = new StringBuilder();
            foreach (Ability a in monster.Abilities)
            {
                builder.Append(a.ToString());
                builder.Append(',');
            }
            if (builder.Length > 2) builder.Remove(builder.Length - 2, 1);

            AddText(this.Name, builder.ToString(), new Vector2(5, yPos + 25 - Bound.Y));
        }
    }
}
