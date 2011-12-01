
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Descent.GUI
{
    class BoardGUIElement : GUIElement
    {
        private static readonly int TileSize = 95;
        private static readonly int BorderTiles = 2;

        private Board board;
        private int xDisp, yDisp;

        public BoardGUIElement(Board board, int x, int y, int width, int height)
            : base("board", x, y, width, height)
        {
            this.board = board;
            this.xDisp = 0;
            this.yDisp = 0;
        }

        public override void HandleKeyPress(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    {
                        if (xDisp > -2 * 95)
                        {
                            xDisp -= 10;
                        }
                        break;
                    }

                case Keys.Right:
                    {
                        if (xDisp < (board.GetLength(0) + 1) * 95 - graphics.PreferredBackBufferWidth)
                        {
                            xDisp += 10;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if (yDisp > -2 * 95)
                        {
                            yDisp -= 10;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (yDisp < (board.GetLength(1) + 2) * 95 - graphics.PreferredBackBufferHeight)
                        {
                            yDisp += 10;
                        }
                        break;
                    }
            }
        }

        public override void Draw(SpriteBatch draw)
        {
            //TODO: Guessed interface from BON
            // TODO Need to draw floor
            Square s;
            Vector2 v;
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    s = board[x, y];
                    v = new Vector2(x * 95 - xDisp, y * 95 - yDisp);
                    draw.Draw(s.Marker.Texture, v, Color.White);
                    draw.Draw(s.Figure, v, Color.White);
                }
            }
        }
    }
}
