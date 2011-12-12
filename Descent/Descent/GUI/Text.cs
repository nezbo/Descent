namespace Descent.GUI
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
        /// <summary>
        /// The string that the text consists of.
        /// </summary>
        public string Line { get; internal set; }

        /// <summary>
        /// The position to display the text.
        /// </summary>
        public Vector2 Position { get; internal set; }

        /// <summary>
        /// The Color to draw the text in.
        /// </summary>
        public Color Color { get; internal set; }

        /// <summary>
        /// Creates a new Text object with all information present.
        /// </summary>
        /// <param name="line">The string to be displayed as a line on the screen.</param>
        /// <param name="position">The position for the upper-left corner of the drawn text.</param>
        /// <param name="color">The color to draw the text in.</param>
        public Text(string line, Vector2 position, Color color)
        {
            this.Line = line;
            this.Position = position;
            this.Color = color;
        }
    }
}
