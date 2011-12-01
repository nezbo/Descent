namespace Descent.GUI
{
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Something that should be able to be drawn on the screen
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    interface Drawable
    {
        Texture2D Texture { get; }
    }
}
