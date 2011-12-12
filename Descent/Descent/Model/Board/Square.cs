
namespace Descent.Model.Board
{
    using Player.Figure;

    /// <summary>
    /// A single square of the board
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Square
    {
        #region Fields

        private readonly int area;

        /// <summary>
        /// Gets what area is this square in?
        /// </summary>
        public int Area
        {
            get { return area; }
        }

        /// <summary>
        /// Gets or sets the marker on the square
        /// </summary>
        public Marker.Marker Marker { get; set; }

        /// <summary>
        /// Gets or sets the figure on the square
        /// </summary>
        public Figure Figure { get; set; }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="area">
        /// The area where the square is in
        /// </param>
        public Square(int area)
        {
            this.area = area;
        }

        #endregion
    }
}
