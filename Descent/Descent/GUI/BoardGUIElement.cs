using System.Collections.Generic;
using Descent.Model.Board;

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
        private static readonly Color NegativeHighlight = new Color(0, 0, 0, 155);
        private static readonly Color PositiveHighlight = new Color(110, 111, 72, 128);

        private Texture2D markTexture;

        private Board board;
        private int xDisp, yDisp;
        private Dictionary<Vector2, bool> markedSquares;

        // for clicks
        private int xClick, yClick;

        public BoardGUIElement(Game game, Board board)
            : base(game, "board", 0, 0, game.GraphicsDevice.DisplayMode.Width, game.GraphicsDevice.DisplayMode.Height)
        {
            this.board = board;
            this.xDisp = 0;
            this.yDisp = 0;

            // marked
            this.markedSquares = new Dictionary<Vector2, bool>();
            this.markTexture = new Texture2D(GraphicsDevice, TileSize, TileSize);
            this.markTexture.SetData(new Color[] { Color.White });

            // event on click
            this.AddClickAction("board", n => System.Diagnostics.Debug.WriteLine("TODO: board clicks")); //TODO
        }

        public override bool HandleClick(int x, int y)
        {
            //TODO:
            //this.xClick = formel for at finde x square
            //this.yClick = formel for at finde y square
            return base.HandleClick(x, y);
        }

        public override void HandleKeyPress(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    {
                        if (xDisp > -BorderTiles * 95)
                        {
                            xDisp -= 10;
                        }
                        break;
                    }

                case Keys.Right:
                    {
                        if (xDisp < (/*TODO: Did you mean width? board.GetLength(0)*/ -1 + BorderTiles) * 95 - this.Bound.Width)
                        {
                            xDisp += 10;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if (yDisp > -BorderTiles * 95)
                        {
                            yDisp -= 10;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (yDisp < (/*TODO: Did you mean height? board.GetLength(1)*/ -1 + BorderTiles) * 95 - this.Bound.Height)
                        {
                            yDisp += 10;
                        }
                        break;
                    }
            }
        }

        private Vector2 CalcVector(int x, int y)
        {
            return new Vector2(x * 95 - xDisp, y * 95 - yDisp);
        }

        public override void Draw(SpriteBatch draw)
        {
            //TODO: Guessed interface from BON
            Vector2 v;
            // Draw floor
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (true)//TODO: FIX board.IsWithin(x, y))
                    {
                        v = CalcVector(x, y);
                        //TODO: FIX draw.Draw(board.FloorTexture, v, Color.White);
                    }
                }
            }

            // Figures and markers
            Square s;

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    /* TODO FIX
                    s = board[x, y];
                    v = CalcVector(x,y);
                    if(s.Marker != null) draw.Draw(s.Marker.Texture, v, Color.White);
                    if(s.Figure != null) draw.Draw(s.Figure.Texture, v, Color.White);
                     */
                }
            }

            // Marks (if any)
            foreach (Vector2 pos in markedSquares.Keys)
            {
                if (markedSquares[pos])
                {
                    draw.Draw(markTexture, pos, PositiveHighlight);
                }
                else
                {
                    draw.Draw(markTexture, pos, NegativeHighlight);
                }
            }
        }

        /// <summary>
        /// Marks a square on the board with a transparent color.
        /// </summary>
        /// <param name="x">The x-coordinate of the square on the board.</param>
        /// <param name="y">The y-coordinate of the square on the board.</param>
        /// <param name="positive">True if the highlight should indicate a eligible. False if it should indicate inaccessibility.</param>
        public void MarkSquare(int x, int y, bool positive)
        {
            markedSquares.Add(new Vector2(x, y), positive);
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
