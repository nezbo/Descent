﻿namespace Descent.GUI
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Information about a text to be displayed on the screen.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class Text
    {
        public string Line { get; internal set; }
        public Vector2 Position { get; internal set; }
        public Color Color { get; internal set; }

        /// <summary>
        /// Creates a new Text object with all information present.
        /// </summary>
        /// <param name="line">The string to be displayed as a line on the screen.</param>
        /// <param name="position">The position for the upper-left corner of the drawn text.</param>
        public Text(string line, Vector2 position, Color color)
        {
            this.Line = line;
            this.Position = position;
            this.Color = color;
        }
    }
}
