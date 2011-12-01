// -----------------------------------------------------------------------
// <copyright file="Figure.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Figure
    {
        #region Figure.NONE

        private static Figure none;

        public static Figure NONE
        {
            get
            {
                return none ?? (none = new Figure());
            }
        }

        #endregion Figure.NONE
    }
}
