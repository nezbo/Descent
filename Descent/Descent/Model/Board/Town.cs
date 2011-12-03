// -----------------------------------------------------------------------
// <copyright file="Town.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure;

    /// <summary>
    /// When in town the players can buy, they also go there when they die
    /// </summary>
    public class Town
    {
        #region Fields

        List<Hero> heroes = new List<Hero>();
        
        #endregion

        #region Properties

        public List<Hero> HeroesInTown
        {
            get{}
        } 

        #endregion
    }
}
