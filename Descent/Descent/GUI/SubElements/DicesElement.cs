namespace Descent.GUI.SubElements
{
    using System;
    using Descent.Messaging.Events;
    using Descent.Model;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Displays a number of dice on their rolled sides.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class DicesElement : GUIElement
    {
        private static readonly int Spacing = 10;
        private int diceWidth;
        private int perLine;

        /// <summary>
        /// Creates a new DIcesElement that displays the given dice within the boundaries.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="dices">The dice to display on the screen.</param>
        /// <param name="x">The top-left x-coordinate of this element.</param>
        /// <param name="y">The top-left y-coordinate of this element.</param>
        /// <param name="width">The width of this element.</param>
        /// <param name="height">The height of this element.</param>
        public DicesElement(Game game, Dice[] dices, int x, int y, int width, int height)
            : base(game, "dice", x, y, width, height)
        {
            // determine how many can be displayed on a line
            if (dices.Length > 0)
            {
                diceWidth = dices[0].Texture.Width + Spacing;
                perLine = 1;
                int widthLeft = Bound.Width - dices[0].Texture.Width - 2 * Spacing;

                while (widthLeft > diceWidth)
                {
                    perLine++;
                    widthLeft -= diceWidth;
                }

                // make the dice displayed in sorted order
                int line = 0;
                int number = 0;
                foreach (EDice diceType in Enum.GetValues(typeof(EDice)))
                {
                    for (int d = 0; d < dices.Length; d++)
                    {
                        if (dices[d].Color == diceType)
                        {
                            Dice die = dices[d];
                            int index = d;
                            GUIElement diceBox = new GUIElement(game, "dice", Bound.X + Spacing + number * die.Texture.Width + number * Spacing,
                                                                Bound.Y + Spacing + line * die.Texture.Height + line * Spacing,
                                                                die.Texture.Width, die.Texture.Height);
                            diceBox.AddDrawable(diceBox.Name, die, new Vector2(diceBox.Bound.X, diceBox.Bound.Y));
                            diceBox.SetClickAction(diceBox.Name, (n, g) =>
                                                                     {
                                                                         n.EventManager.QueueEvent(
                                                                             EventType.DiceClicked,
                                                                             new DiceEventArgs(index, die.SideIndex));
                                                                     });
                            this.AddChild(diceBox);


                            number++;

                            if (number >= perLine)
                            {
                                number = 0;
                                line++;
                            }
                        }
                    }
                }
            }
        }
    }
}
