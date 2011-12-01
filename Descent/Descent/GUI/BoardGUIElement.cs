using System.Collections.Generic;

namespace Descent.GUI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// The element on the screen that visualizes the game board and marking
    /// fields on the board if needed.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class BoardGUIElement : GUIElement
    {
        private static readonly int TileSize = 95;
        private static readonly int BorderTiles = 2;

        private Board board;
        private int xDisp, yDisp;
        private Dictionary<Vector2, Color> markedSquares;

        // for clicks
        private int xClick, yClick;

        public BoardGUIElement(Board board, int x, int y, int width, int height)
            : base("board", x, y, width, height)
        {
            this.board = board;
            this.markedSquares = new Dictionary<Vector2, Color>();
            this.xDisp = 0;
            this.yDisp = 0;

            this.AddClickAction(n => n.SquareMarked(xClick, yClick));
        }

        public override bool HandleClick(int x, int y)
        {
            //TODO:
            //this.xClick = formel for at finde x square
            //this.yClick = formel for at finde y square
            base.HandleClick(x, y);
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

        /// <summary>
        /// Marks a square on the board with a transparent color.
        /// </summary>
        /// <param name="x">The x-coordinate of the square on the board.</param>
        /// <param name="y">The y-coordinate of the square on the board.</param>
        /// <param name="color">The color that should be used to transparently mark the square.</param>
        public void MarkSquare(int x, int y, Color color)
        {
            markedSquares.Add(new Vector2(x, y), color);
        }

        /// <summary>
        /// Clears the board for all markings.
        /// </summary>
        public void ClearMarks()
        {
            markedSquares.Clear();
        }
    }
}
