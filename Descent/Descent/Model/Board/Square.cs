// -----------------------------------------------------------------------
// <copyright file="Square.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Player;
    using Player.Figure;

    /// <summary>
    /// A single square of the board
    /// </summary>
    public class Square
    {
        #region FIELDS

        private readonly int area;

        public int Area
        {
            get { return area; }
        }

        /// <summary>
        /// Gets or sets Marker.
        /// </summary>
        public Marker.Marker Marker { get; set; }

        public Figure Figure { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Square(int area)
        {
            this.area = area;
        }

        #endregion

        #region METHODS

        #endregion

    }
}
