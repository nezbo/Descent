﻿// -----------------------------------------------------------------------
// <copyright file="Marker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board.Marker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Marker
    {
        #region Marker.NONE

        private static Marker none;
        public static Marker NONE
        {
            get
            {
                return none ?? (none = new Marker());
            }
        }

        #endregion Marker.NONE

        #region FIELDS

        #endregion FIELDS

        #region CONSTRUCTORS

        #endregion CONSTRUCTORS

        #region METHODS

        #endregion METHODS
    }
}