// -----------------------------------------------------------------------
// <copyright file="Equipment.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Figure.HeroStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class Equipment
    {
        #region Fields

        private bool tapped = false;
        private string name;

        #endregion

        #region Properties

        public bool Tapped
        {
            get
            {
                return tapped;
            }
        }

        public string Name
        {
            get { return name; }
        }

        #endregion
    }
}
