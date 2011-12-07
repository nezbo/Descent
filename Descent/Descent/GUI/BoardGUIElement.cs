using System.Collections.Generic;
using Descent.Model.Board;
using Microsoft.Xna.Framework.Input;

namespace Descent.GUI
{
    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

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
        private static readonly int BorderTiles = 3;
        private static readonly Color NegativeHighlight = new Color(0, 0, 0, 155);
        private static readonly Color PositiveHighlight = new Color(110, 111, 72, 128);

        private Texture2D markTexture;

        private Board board;
        private int xDisp, yDisp;
        private Dictionary<Vector2, bool> markedSquares;

        // for clicks
        private int xClick, yClick;

        public BoardGUIElement(Game game, Board board)
            : base(game, "board", 0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height)
        {
            this.board = board;
            xDisp = -2 * 95;
            yDisp = 17 * 95;

            // marked
            this.markedSquares = new Dictionary<Vector2, bool>();
            this.markTexture = new Texture2D(this.Game.GraphicsDevice, TileSize, TileSize);

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
                    if (board.IsSquareWithinBoard(x, y))
                    {
                        v = CalcVector(x, y);
                        if (board[x, y] != null) draw.Draw(board.FloorTexture, new Vector2(x * 95 - xDisp, y * 95 - yDisp), Color.White);
                    }
                }
            }

            // Figures and markers
            Square s;

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    s = board[x, y];
                    if (s == null) continue;
                    v = CalcVector(x, y);
                    if (s.Marker != null) draw.Draw(s.Marker.Texture, v, Color.White);

                }
            }

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    s = board[x, y];
                    if (s == null) continue;
                    v = CalcVector(x, y);
                    if (s.Figure != null && s.Figure is Monster && ((Monster)s.Figure).Orientation == Orientation.V)
                        draw.Draw(
                            s.Figure.Texture,
                            v,
                            null,
                            Color.White,
                            (float)(MathHelper.Pi * 0.5),
                            new Vector2(0, s.Figure.Texture.Height),
                            1.0f,
                            SpriteEffects.None,
                            0f);
                    else if (s.Figure != null) draw.Draw(s.Figure.Texture, v, Color.White);

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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left) && xDisp > -BorderTiles * 95) xDisp -= 10;
            if (keyState.IsKeyDown(Keys.Right) && xDisp < (board.Width + BorderTiles - 1) * 95 - Game.GraphicsDevice.Viewport.Width) xDisp += 10;
            if (keyState.IsKeyDown(Keys.Up) && yDisp > -BorderTiles * 95) yDisp -= 10;
            if (keyState.IsKeyDown(Keys.Down) && yDisp < (board.Height + BorderTiles) * 95 - Game.GraphicsDevice.Viewport.Height) yDisp += 10;
        }
    }
}
