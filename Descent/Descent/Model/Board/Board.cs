// -----------------------------------------------------------------------
// <copyright file="Board.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;

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
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Board
    {

        #region Fields

        /// <summary>
        /// The board, made up of squares
        /// </summary>
        private Square[,] board;

        private Rectangle bounds;

        private List<Hero> town = new List<Hero>();

        private Texture2D floorTexture;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the width of the board
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
        /// Gets the height of the board
        /// What is your height?
        /// </summary>
        public int Height
        {
            get
            {
                return bounds.Height;
            }
        }

        /// <summary>
        /// Gets the list of heroes in Town
        /// </summary>
        public List<Hero> HeroesInTown
        {
            get
            {
                return town;
            }
        } 

        public Texture2D FloorTexture
        {
            get
            {
                return floorTexture;
            }
        }

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
            board = new Square[width, height];
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
            if(board[x, y] == null) return false;
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
        public bool IsSquareWithinBoard(Point point)
        {
            Contract.Requires(point != null);
            return IsSquareWithinBoard(point.X,  point.Y);
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
        public bool IsStandable(Point point)
        {
            Contract.Requires(point != null);
            return IsSquareWithinBoard(point) && SquareVisibleByPlayers(point) && board[point.X, point.Y].Figure == null;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <returns>
        /// </returns>
        public bool CanOverlordSpawn(Point point)
        {
            Contract.Requires(point != null);
            //TODO
            return false;
        }

        public bool IsThereLineOfSight(Point from, Point to, bool ignoreMonsters)
        {
            return SquaresBetweenPoints(from, to).Count(
                point => !(IsStandable(point) || (ignoreMonsters && (board[point.X, point.Y].Figure is Monster)))) == 0;
        }

        /// <summary>
        /// Get a (non-sorted) array of squares between two squares.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private Point[] SquaresBetweenPoints(Point from, Point to)
        {
            var points = new HashSet<Point>();

            if (from.X == to.X)
            {
                for (int y = from.Y; y <= to.Y; y++)
                {
                    points.Add(new Point(from.X, y));
                }
            }
            else if (from.Y == to.Y)
            {
                for (int x = from.X; x <= to.X; x++)
                {
                    points.Add(new Point(x, from.Y));
                }
            }
            else
            {
                if(from.X > to.X)
                {
                    var temp = from;
                    from = to;
                    to = temp;
                }

                double a = (double) (to.Y - from.Y)/(to.X - from.X);

                for (double xn = from.X + .5; xn < to.X; xn++)
                {
                    double yn = (xn - from.X)*a + from.Y;
                    if (Math.Abs(yn - Math.Truncate(yn) - .5) < .0000001)
                    {
                        int plus = (a > 0) ? 1 : -1;
                        points.Add(new Point((int)Math.Truncate(xn), (int)Math.Truncate(yn)));
                        points.Add(new Point((int)Math.Truncate(xn) + 1, (int)Math.Truncate(yn) + plus));
                    }
                    else
                    {
                        points.Add(new Point((int) Math.Truncate(xn), (int) Math.Round(yn)));
                        points.Add(new Point((int) Math.Truncate(xn) + 1, (int) Math.Round(yn)));
                    }
                }

                for (double yn = from.Y + .5; yn < to.Y; yn++)
                {
                    double xn = (yn - from.Y) / a + from.X;
                    if (Math.Abs(xn - Math.Truncate(xn) - .5) < .000001)
                    {
                        int plus = (a > 0) ? 1 : -1;
                        points.Add(new Point((int)Math.Truncate(xn), (int)Math.Truncate(yn)));
                        points.Add(new Point((int)Math.Truncate(xn) + 1, (int)Math.Truncate(yn) + plus));
                    }
                    else
                    {
                        points.Add(new Point((int)Math.Round(xn), (int)Math.Truncate(yn)));
                        points.Add(new Point((int)Math.Round(xn), (int)Math.Truncate(yn) + 1));
                    }
                }
            }

            return points.ToArray();
        }

        public bool SquareVisibleByPlayers(Point point)
        {
            //TODO
            return false;
        }

        /// <summary>
        /// Get the distance between to squares.
        /// </summary>
        public int Distance(Point here, Point there)
        {
            Contract.Requires(here != null);
            Contract.Requires(there != null);
            return Math.Max(Math.Abs(here.X - there.X), Math.Abs(here.Y - there.Y));
        }

        #endregion

        public static void Main(string[] args)
        {
            var b = new Board(20, 20);
            var a = new int[30, 30];
            var points = b.SquaresBetweenPoints(new Point(26, 6), new Point(1, 26));
            foreach (Point p in points)
            {
                a[p.X, p.Y] = 1;
            }
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    System.Diagnostics.Debug.Write(a[x, y]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }
}
