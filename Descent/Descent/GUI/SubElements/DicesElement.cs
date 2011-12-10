using System;
using Descent.Model;
using Microsoft.Xna.Framework;

namespace Descent.GUI.SubElements
{
    class DicesElement : GUIElement
    {
        private static readonly int Spacing = 10;

        public DicesElement(Game game, Dice[] dices, int x, int y, int width, int height)
            : base(game, "dice", x, y, width, height)
        {
            // determine how many can be displayed on a line
            int diceWidth = dices[0].Texture.Width + Spacing;
            int perLine = 1;
            int widthLeft = Bound.Width - dices[0].Texture.Width;

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
                foreach (Dice die in dices)
                {
                    if (die.Color == diceType)
                    {
                        this.AddDrawable(this.Name, die, new Vector2(Bound.X + number * die.Texture.Width + number * Spacing, Bound.Y + line * die.Texture.Height + line * Spacing));
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
