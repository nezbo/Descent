namespace Descent.Model.Board
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Indicates whether an object is horizontal or vertical
    /// </summary>
    public enum Orientation 
    {
        /// <summary>
        /// Horizontal orientation
        /// </summary>
        H, 

        /// <summary>
        /// Vertical orientation
        /// </summary>
        V 
    }

    /// <summary>
    /// A board of 
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk), Martin Marcher
    /// </author>
    public class Board
    {
        #region Fields

        /// <summary>
        /// The board, made up of squares
        /// </summary>
        private readonly Square[,] board;

        private Rectangle bounds;

        private HashSet<int> revealedAreas = new HashSet<int>();

        private List<Door> doors = new List<Door>();

        private Collection<Hero> heroesInTown = new Collection<Hero>();

        private Dictionary<Figure, Point> figuresOnBoard = new Dictionary<Figure, Point>();

        private Texture2D floorTexture;

        private bool boardChanged = true;

        private bool[,] canSpawn;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the width of the board
        /// What is your width?
        /// </summary>
        public int Width
        {
            get { return bounds.Width; }
        }

        /// <summary>
        /// Gets the height of the board
        /// What is your height?
        /// </summary>
        public int Height
        {
            get { return bounds.Height; }
        }

        /// <summary>
        /// Gets the list of heroes in Town
        /// </summary>
        public Hero[] HeroesInTown
        {
            get { return heroesInTown.ToArray(); }
        }

        /// <summary>
        /// Gets the points where all figures are standing
        /// 
        /// </summary>
        public Dictionary<Figure, Point> FiguresOnBoard
        {
            get { return figuresOnBoard; }
        }

        /// <summary>
        /// Gets the texture for the floor of the dungeon
        /// </summary>
        public Texture2D FloorTexture
        {
            get { return floorTexture; }
        }

        /// <summary>
        /// Gets all doors that are revealed at the moment.
        /// </summary>
        public Door[] RelevantDoors
        {
            get
            {
                return
                    doors.Where(door => !door.Opened && door.Areas.Any(area => revealedAreas.Contains(area))).ToArray();
            }
        }

        /// <summary>
        /// Gets an array of all doors on the board
        /// </summary>
        public Door[] AllDoors
        {
            get { return doors.Where(door => !door.Opened).ToArray(); }
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
        /// <returns>
        /// The square at coordinate (x, y)
        /// </returns>
        public Square this[int x, int y]
        {
            get { return board[x, y]; }

            set { board[x, y] = value; }
        }

        /// <summary>
        /// Access a point on the board
        /// </summary>
        /// <param name="p">
        /// The point to be accessed
        /// </param>
        /// <returns>
        /// The square at point p
        /// </returns>
        public Square this[Point p]
        {
            get { return board[p.X, p.Y]; }

            set { board[p.X, p.Y] = value; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="width">
        /// The width of the board
        /// </param>
        /// <param name="height">
        /// The height of the board
        /// </param>
        /// <param name="floorTexture">
        /// The floor Texture.
        /// </param>
        public Board(int width, int height, Texture2D floorTexture)
        {
            bounds = new Rectangle(0, 0, width, height);
            board = new Square[width,height];
            canSpawn = new bool[width,height];
            this.floorTexture = floorTexture;
            revealedAreas.Add(0);
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
            if (board[x, y] == null) return false;
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
            return IsSquareWithinBoard(point.X, point.Y);
        }

        /// <summary>
        /// Determines whether a series of points are with
        /// the board, and if there is a square on that point.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool IsSquareWithinBoard(Point[] points)
        {
            return points.All(IsSquareWithinBoard);
        }

        /// <summary>
        /// Is the square inside the dungeon, and is there no figure?
        /// </summary>
        /// <param name="x">
        /// The x coordinate 
        /// </param>
        /// <param name="y">
        /// The y coordinate
        /// </param>
        /// <returns>
        /// True if the point is within the dungeon, and there is no figure on it
        /// </returns>
        public bool IsStandable(int x, int y)
        {
            return IsSquareWithinBoard(x, y) && SquareVisibleByPlayers(x, y) && board[x, y].Figure == null &&
                   (board[x, y].Marker == null || !board[x, y].Marker.Name.Equals("rock"));
        }

        /// <summary>
        /// Is all points in the array standable?
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool IsStandable(Point[] points)
        {
            return points.All(p => IsStandable(p.X, p.Y));
        }

        /// <summary>
        /// Indicates whether the overlord can spawn on a space
        /// </summary>
        /// <param name="point">
        /// The point
        /// </param>
        /// <returns>
        /// Whether the overlord can spawn on the point
        /// </returns>
        public bool CanOverlordSpawn(Point point)
        {
            if (boardChanged)
            {
                UpdateCanSpawn();
            }
            return canSpawn[point.X, point.Y];
        }

        private void UpdateCanSpawn()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    canSpawn[x, y] = true;
                }
            }

            foreach (Point point in FiguresOnBoard.Where(pair => pair.Key is Hero).Select(pair => pair.Value))
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        canSpawn[x, y] = canSpawn[x, y] && IsStandable(x, y) &&
                                         !IsThereLineOfSight(point, new Point(x, y), true);
                    }
                }
            }
            boardChanged = false;
        }

        /// <summary>
        /// Indicates whether a point is a valid start/spawn point
        /// </summary>
        /// <param name="point">
        /// The point to check
        /// </param>
        /// <returns>
        /// If a hero can spawn on the point, true,
        /// if not, false
        /// </returns>
        public bool IsValidStartSquare(Point point)
        {
            if (!IsStandable(point.X, point.Y)) return false;
            for (int x = point.X - 1; x <= point.X + 1; x++)
            {
                for (int y = point.Y - 1; y <= point.Y + 1; y++)
                {
                    if (IsSquareWithinBoard(x, y) && this[x, y].Marker != null &&
                        this[x, y].Marker.Name.Equals("glyph-open")) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Indicates whether there is nothing in the way from one point to another
        /// Monsters can be ignored, so it can be used to calculate where to spawn monsters
        /// </summary>
        /// <param name="from">
        /// The start point
        /// </param>
        /// <param name="to">
        /// The end point
        /// </param>
        /// <param name="ignoreMonsters">
        /// If true, monsters will be ignored so they do not break line of sight
        /// </param>
        /// <returns>
        /// True if there is a clear line of sight between from and to
        /// </returns>
        public bool IsThereLineOfSight(Point from, Point to, bool ignoreMonsters)
        {
            Contract.Requires(IsSquareWithinBoard(from));
            if (this[from.X, from.Y].Marker != null && this[from.X, from.Y].Marker.Name.Equals("pit"))
            {
                return false;
            }
            foreach (var point in SquaresBetweenPoints(from, to))
            {
                if (
                    !(IsStandable(point.X, point.Y) ||
                      (ignoreMonsters && board[point.X, point.Y] != null && board[point.X, point.Y].Figure is Monster)))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Indicates whethere there's nothing in the way from one figure to another.
        /// Can ignore monsters.
        /// </summary>
        /// <param name="from">"From" figure.</param>
        /// <param name="to">"To" figure.</param>
        /// <param name="ignoreMonsters">Will ignore monsters if true.</param>
        /// <returns></returns>
        public bool IsThereLineOfSight(Figure from, Figure to, bool ignoreMonsters)
        {
            Point[] fromPoints = FullModel.Board.FigureSquares(from);
            Point[] toPoints = FullModel.Board.FigureSquares(to);
            foreach (Point fromPoint in fromPoints)
            {
                foreach (Point toPoint in toPoints)
                {
                    if (IsThereLineOfSight(fromPoint, toPoint, ignoreMonsters)) return true;
                }
            }

            return false;
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

            if (from == to)
            {
                return new Point[] {from};
            }
            // if the lines are completely vertical
            if (from.X == to.X)
            {
                int step = (to.Y - from.Y)/Math.Abs(to.Y - from.Y);
                for (int y = from.Y; y != to.Y; y += step)
                {
                    points.Add(new Point(from.X, y));
                }
            }

                // if the lines are completely horizontal
            else if (from.Y == to.Y)
            {
                int step = (to.X - from.X)/Math.Abs(to.X - from.X);
                for (int x = from.X; x != to.X; x += step)
                {
                    points.Add(new Point(x, from.Y));
                }
            }

                // the line is not straight
            else
            {
                // if we are going left instead of right, switch the from and to
                if (from.X > to.X)
                {
                    var temp = from;
                    from = to;
                    to = temp;
                }

                // calculate the angle of descent/decline
                double a = (double) (to.Y - from.Y)/(to.X - from.X);

                // step by 0.5 from the from x-coordinate to the to x-coordinate
                for (double xn = from.X + .5; xn < to.X; xn++)
                {
                    // calculate the y-value
                    double yn = (xn - from.X)*a + from.Y;
                    if (Math.Abs(yn - Math.Truncate(yn) - .5) < .0000001)
                    {
                        if (a < 0)
                        {
                            points.Add(new Point((int) Math.Truncate(xn), (int) Math.Ceiling(yn)));
                            points.Add(new Point((int) Math.Ceiling(xn), (int) Math.Truncate(yn)));
                        }
                        else
                        {
                            points.Add(new Point((int) Math.Truncate(xn), (int) Math.Truncate(yn)));
                            points.Add(new Point((int) Math.Ceiling(xn), (int) Math.Ceiling(yn)));

                        }
                    }
                    else
                    {
                        points.Add(new Point((int) Math.Truncate(xn), (int) Math.Round(yn)));
                        points.Add(new Point((int) Math.Truncate(xn) + 1, (int) Math.Round(yn)));
                    }
                }

                if (from.Y > to.Y)
                {
                    var temp = from;
                    from = to;
                    to = temp;
                }
                // step by 0.5 from the from y-coordinate to the to y-coordinate
                for (double yn = from.Y + .5; yn < to.Y; yn++)
                {
                    // calculates the x value
                    double xn = (yn - from.Y)/a + from.X;
                    if (Math.Abs(xn - Math.Truncate(xn) - .5) < .000001)
                    {
                        if (a < 0)
                        {
                            points.Add(new Point((int) Math.Truncate(xn), (int) Math.Ceiling(yn)));
                            points.Add(new Point((int) Math.Ceiling(xn), (int) Math.Truncate(yn)));
                        }
                        else
                        {
                            points.Add(new Point((int) Math.Truncate(xn), (int) Math.Truncate(yn)));
                            points.Add(new Point((int) Math.Ceiling(xn), (int) Math.Ceiling(yn)));

                        }
                    }
                    else
                    {
                        points.Add(new Point((int) Math.Round(xn), (int) Math.Truncate(yn)));
                        points.Add(new Point((int) Math.Round(xn), (int) Math.Truncate(yn) + 1));
                    }
                }
            }

            points.Remove(from);
            points.Remove(to);

            return points.ToArray();
        }

        /// <summary>
        /// Should the square be shown on the board?
        /// A square is visible by players if it has something on it,
        /// and if that squares area has been revealed
        /// </summary>
        /// <param name="x">
        /// The x coordinate
        /// </param>
        /// <param name="y">
        /// The y coordinate
        /// </param>
        /// <returns>
        /// Whether a square is visible by players
        /// </returns>
        public bool SquareVisibleByPlayers(int x, int y)
        {
            return IsSquareWithinBoard(x, y) && revealedAreas.Contains(this[x, y].Area);
        }

        /// <summary>
        /// Get the distance between to squares.
        /// This distance does not take blocking into account,
        /// such has there being a wall in the way
        /// </summary>
        /// <param name="here">
        /// The 'here' point
        /// </param>
        /// <param name="there">
        /// The 'there' point
        /// </param>
        /// <returns>
        /// The distance it would take to travel between the points, 
        /// if there are no obstacles
        /// </returns>
        public int Distance(Point here, Point there)
        {
            Contract.Requires(here != null);
            Contract.Requires(there != null);
            return Math.Max(Math.Abs(here.X - there.X), Math.Abs(here.Y - there.Y));
        }

        /// <summary>
        /// Open a door
        /// </summary>
        /// <param name="point">
        /// A point adjacent to a door
        /// </param>
        public void OpenDoor(Point point)
        {
            Contract.Requires(CanOpenDoor(point));
            revealedAreas.Add(GetDoor(point).Areas.Where(area => !revealedAreas.Contains(area)).FirstOrDefault());
            GetDoor(point).Opened = true;
            boardChanged = true;
        }

        /// <summary>
        /// Calculates whether a party 
        /// </summary>
        /// <param name="point">
        /// A point where there should be a door next to
        /// </param>
        /// <returns>
        /// Whether a door next to the point is a runedoor, and if you have the key
        /// </returns>
        [Pure]
        public bool CanOpenDoor(Point point)
        {
            Door door = GetDoor(point);
            if (door == null) return false;
            return !door.IsRuneDoor || Player.Player.Instance.HeroParty.HasRuneKey(door.KeyColor);
        }

        /// <summary>
        /// Adds a door to the board
        /// </summary>
        /// <param name="door">
        /// The door to be added
        /// </param>
        public void AddDoor(Door door)
        {
            doors.Add(door);
        }

        /// <summary>
        /// Gets a door at a specific point, if there is any
        /// </summary>
        /// <param name="point">
        /// The point next to the door
        /// </param>
        /// <returns>
        /// The door
        /// </returns>
        private Door GetDoor(Point point)
        {
            return doors.SingleOrDefault(door => door.IsAdjecentSquare(point));
        }

        public void MoveFigure(Figure figure, Point point)
        {
            // Remove monsters from old position
            Point p = FiguresOnBoard[figure];
            for (int x = p.X;
                 x < p.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = p.Y;
                     y < p.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    board[x, y].Figure = null;
                }
            }

            //this[FiguresOnBoard[figure]].Figure = null;

            for (int x = point.X;
                 x < point.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = point.Y;
                     y < point.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    board[x, y].Figure = figure;
                }
            }
            //this[point].Figure = figure;

            figuresOnBoard[figure] = point;
            boardChanged = true;
        }

        public void PlaceFigure(Figure figure, Point point)
        {
            for (int x = point.X;
                 x < point.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = point.Y;
                     y < point.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    board[x, y].Figure = figure;
                }
            }
            figuresOnBoard[figure] = point;
            boardChanged = true;
        }

        /// <summary>
        /// Creates an array of all points a figure is on
        /// </summary>
        public Point[] FigureSquares(Figure figure)
        {
            List<Point> list = new List<Point>();
            Point point = this.FiguresOnBoard[figure];
            for (int x = point.X;
                 x < point.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = point.Y;
                     y < point.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    list.Add(new Point(x, y));
                }
            }
            return list.ToArray();
        }

        public bool CanFigureMoveToPoint(Figure figure, Point point)
        {
            if (figure.Size.Width == 1 && figure.Size.Height == 1) return IsStandable(point.X, point.Y);

            bool canMove = true;

            List<Point> list = new List<Point>();
            for (int x = point.X;
                 x < point.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = point.Y;
                     y < point.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    canMove &= (IsStandable(x, y) || (IsSquareWithinBoard(x, y) && this[x, y].Figure == figure));
                }
            }

            return canMove;
        }

        #endregion

        /// <summary>
        /// Testing line of sight algorithm.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int w = 10, h = 10;
            var b = new Board(w, h, null);
            var p = b.SquaresBetweenPoints(new Point(0, 0), new Point(1, 3));
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    System.Diagnostics.Debug.Write(p.Contains(new Point(y, x)) ? 1 : 0);
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        internal void RemoveFigure(Point point)
        {
            Contract.Requires(IsSquareWithinBoard(point.X, point.Y));
            Contract.Requires(this[point] != null);
            Contract.Ensures(this[point].Figure == null);

            Figure figure = this[point].Figure;
            point = FiguresOnBoard[figure]; // Get top left corner if big monster
            if (figure is Hero)
            {
                heroesInTown.Add((Hero) figure);
            }
            for (int x = point.X;
                 x < point.X + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Width : figure.Size.Height);
                 x++)
            {
                for (int y = point.Y;
                     y < point.Y + (figure.Orientation.Equals(Orientation.V) ? figure.Size.Height : figure.Size.Width);
                     y++)
                {
                    this[x, y].Figure = null;
                }
            }
            figuresOnBoard.Remove(figure);
        }

        public void RespawnDeadHeroes()
        {
            Contract.Ensures(HeroesInTown.Length == 0);
            foreach (var hero in heroesInTown)
            {
                PlaceDeadHero(hero);
            }
            foreach (var hero in FiguresOnBoard.Keys.Where(figure => figure is Hero))
            {
                heroesInTown.Remove((Hero)hero);
            }
        }

        private void PlaceDeadHero(Hero hero)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (IsValidStartSquare(new Point(x, y)))
                    {
                        PlaceFigure(hero, new Point(x, y));
                        return;
                    }
                }
            }
        }
    }
}
