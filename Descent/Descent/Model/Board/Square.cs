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
        #region Square.NONE

        private static Square none;
        public static Square NONE
        {
            get
            {
                return none ?? (none = new Square());
            }
        }
        #endregion SQUARE.NONE

        #region FIELDS

        /// <summary>
        /// Gets or sets Marker.
        /// </summary>
        public Marker.Marker Marker { get; set; }

        public Figure Figure { get; set; }

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion

    }
}
