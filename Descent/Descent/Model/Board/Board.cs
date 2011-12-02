// -----------------------------------------------------------------------
// <copyright file="Board.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Board
    {

        #region Properties

        /// <summary>
        /// What is your width?
        /// </summary>
        public int Width 
        { 
            get
            {
                return bounds.Width;
            } 
        }

        /// <summary>
        /// What is your height?
        /// </summary>
        public int Height
        {
            get
            {
                return bounds.Height;
            }
        }

        private Square[,] board;

        private Rectangle bounds;

        #endregion

        #region Indexers

        /// <summary>
        /// Access the (x, y)'th in the board
        /// </summary>
        /// <param name="x">
        /// The x coordinate
        /// </param>
        /// <param name="y">
        /// The y coordinate
        /// </param>
        public Square this[int x, int y]
        {
            get
            {
                return board[x, y];
            }
            set
            {
                board[x, y] = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="width">
        /// The width of the board
        /// </param>
        /// <param name="height">
        /// The height of the board
        /// </param>
        public Board(int width, int height)
        {
            bounds = new Rectangle(0, 0, width, height);
            board = new Square[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = Square.NONE;
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Determines wether the point (x, y) is within the board,
        /// and a square in the dungeon
        /// </summary>
        /// <param name="x">
        /// The x coordinate
        /// </param>
        /// <param name="y">
        /// The y coordinate
        /// </param>
        /// <returns>
        /// True if the point (x, y) is in the dungeon
        /// </returns>
        public bool IsSquareWithinBoard(int x, int y)
        {
            if (!bounds.Contains(x, y)) return false;
            if(board[x, y] == Square.NONE) return false;
            return true;
        }

        /// <summary>
        /// Determines whether the point is within the board,
        /// and if there is a square on that point.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <returns>
        /// True if the point is within the boundries of the board
        /// </returns>
        public bool IsSquareWithinBoard(Vector2 point)
        {
            Contract.Requires(point != null);
            return IsSquareWithinBoard((int)point.X,  (int)point.Y);
        }

        /// <summary>
        /// Is the square inside the dungeon, and is there no figure?
        /// </summary>
        /// <param name="point">
        /// The point
        /// </param>
        /// <returns>
        /// True if the point is within the dungeon, and there is no figure on it
        /// </returns>
        public bool IsSquareMovable(Vector2 point)
        {
            Contract.Requires(point != null);
            Contract.Requires(IsSquareWithinBoard(point));
            if (board[(int)point.X, (int)point.Y].Figure == Figure.NONE) return false;
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <returns>
        /// </returns>
        public bool CanOverlordSpawn(Vector2 point)
        {
            Contract.Requires(point != null);
            if (!IsSquareWithinBoard(point)) return false;
            if (!IsSquareMovable(point)) return false;
            //TODO
            return false;
        }

        public bool IsThereLineOfSight(Point from, Point to, bool ignoreMonsters)
        {
            //TODO
            return false;
        }

        public bool SquareVisibleByPlayers(Point point)
        {
            //TODO
            return false;
        }
        #endregion
    }
}
