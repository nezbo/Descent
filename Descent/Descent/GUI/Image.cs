
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI
{
    public class Image : Drawable
    {
        private Texture2D tex;

        public Image(Texture2D texture)
        {
            tex = texture;
        }

        public Texture2D Texture
        {
            get { return tex; }
        }
    }
}
