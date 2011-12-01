using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent
{
    class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Position, Color.White);
        }
    }
}
