namespace Descent.GUI
{
    using System.Diagnostics.Contracts;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The simplest possible Drawable that only implements the interface.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class Image : Drawable
    {
        private Texture2D tex;

        /// <summary>
        /// Creates an Image with the given texture.
        /// </summary>
        /// <param name="texture">The texture that the Image should hold.</param>
        public Image(Texture2D texture)
        {
            tex = texture;
        }

        /// <summary>
        /// The visualization of the Image.
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                Contract.Ensures(Contract.Result<Texture2D>() != null);
                return tex;
            }
        }
    }
}
