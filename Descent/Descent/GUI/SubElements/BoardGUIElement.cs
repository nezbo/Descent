using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Descent.Messaging.Events;
using Descent.Model.Board;
using Descent.Model.Player;
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
        private static readonly int BorderTiles = 2;
        private static readonly Color NegativeHighlight = new Color(0, 0, 0, 155);
        private static readonly Color PositiveHighlight = new Color(110, 111, 72, 128);

        private Texture2D markTexture;

        private Board board;
        private Role role;
        private int xDisp, yDisp;
        private Dictionary<Vector2, bool> markedSquares;

        public BoardGUIElement(Game game, Board board, Role role)
            : base(game, "board", 0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height)
        {
            this.board = board;
            xDisp = -2 * TileSize;
            yDisp = 17 * TileSize;
            this.role = role;

            // marked
            this.markedSquares = new Dictionary<Vector2, bool>();
            this.markTexture = new Texture2D(Game.GraphicsDevice, 1, 1);
            this.markTexture.SetData(new Color[] { Color.White });

            // event on click
            this.SetClickAction("board", (n, g) => System.Diagnostics.Debug.WriteLine("TODO: board clicks")); //TODO
        }

        public override bool HandleClick(int x, int y)
        {
            int xClick = (int)Math.Floor((xDisp + x) / (double)TileSize);
            int yClick = (int)Math.Floor((yDisp + y) / (double)TileSize);

            Player.Instance.EventManager.QueueEvent(EventType.SquareMarked, new CoordinatesEventArgs(xClick, yClick));

            return true;
        }

        private Vector2 CalcVector(int x, int y)
        {
            return new Vector2(x * TileSize - xDisp, y * TileSize - yDisp);
        }

        public override void Draw(SpriteBatch draw)
        {
            Vector2 v;
            // Draw floor
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.SquareVisibleByPlayers(x, y) || (role == Role.Overlord && board.IsSquareWithinBoard(x, y)))
                    {
                        if (board[x, y] != null) draw.Draw(board.FloorTexture, CalcVector(x, y), Color.White);
                    }
                }
            }

            // Figures and markers
            Square s;

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (role == Role.Overlord || board.SquareVisibleByPlayers(x, y))
                    {
                        s = board[x, y];
                        if (s == null) continue;
                        v = CalcVector(x, y);
                        if (s.Marker != null) draw.Draw(s.Marker.Texture, v, Color.White);
                    }
                }
            }

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (role == Role.Overlord || board.SquareVisibleByPlayers(x, y))
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
            }

            // Marks (if any)
            Rectangle r;
            foreach (Vector2 pos in markedSquares.Keys)
            {
                DrawMark(draw, (int)pos.X, (int)pos.Y, markedSquares[pos]);
            }

            // overlord fog
            if (role == Role.Overlord)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        if (board.IsSquareWithinBoard(x, y) && !board.SquareVisibleByPlayers(x, y))
                        {
                            DrawMark(draw, x, y, false);
                        }
                    }
                }
            }

            // doors
            foreach (Door d in (role == Role.Overlord ? board.AllDoors : board.RelevantDoors))
            {
                float rotation = d.Orientation == Orientation.H ? MathHelper.Pi * 0.5f : 0.0f;
                Point position = d.TopLeftCorner;
                draw.Draw(d.Texture,
                    CalcVector(d.TopLeftCorner.X + 1, d.TopLeftCorner.Y + 1),
                    null,
                    Color.White,
                    rotation,
                    new Vector2(d.Texture.Width / 2, d.Texture.Height / 2),
                    1.0f,
                    SpriteEffects.None,
                    0f);
            }
        }

        private void DrawMark(SpriteBatch draw, int boardX, int boardY, bool positiveMark)
        {
            Vector2 screenPoint = CalcVector(boardX, boardY);
            Rectangle r = new Rectangle((int)screenPoint.X, (int)screenPoint.Y, TileSize, TileSize);
            if (positiveMark)
            {
                draw.Draw(markTexture, r, PositiveHighlight);
            }
            else
            {
                draw.Draw(markTexture, r, NegativeHighlight);
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
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);

            markedSquares[new Vector2(x, y)] = positive;

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
            if (keyState.IsKeyDown(Keys.Left) && xDisp > -BorderTiles * TileSize) xDisp -= 10;
            if (keyState.IsKeyDown(Keys.Right) && xDisp < (board.Width + BorderTiles - 1) * TileSize - Game.GraphicsDevice.Viewport.Width) xDisp += 10;
            if (keyState.IsKeyDown(Keys.Up) && yDisp > -BorderTiles * TileSize) yDisp -= 10;
            if (keyState.IsKeyDown(Keys.Down) && yDisp < (board.Height + BorderTiles) * TileSize - Game.GraphicsDevice.Viewport.Height) yDisp += 10;
        }
    }
}
