using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Descent
{
    class SpriteFactory
    {
        private ContentManager manager;

        public SpriteFactory(ContentManager manager)
        {
            this.manager = manager;
        }

        public Sprite GetSprite(string sourceName)
        {
            return new Sprite(manager.Load<Texture2D>(sourceName));
        }

        public Sprite GetSprite(string sourceName, int x, int y)
        {
            Sprite s = GetSprite(sourceName);
            s.Position = new Vector2(x, y);
            return s;
        }
    }
}
