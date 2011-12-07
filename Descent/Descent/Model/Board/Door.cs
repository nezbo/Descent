// -----------------------------------------------------------------------
// <copyright file="Door.cs" company="">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Door
    {
        public enum RuneColor
        {
            Red, None
        }

        private Tuple<int, int> betweenZones;

        private RuneColor color;

        private bool opened;

        public bool Opened
        {
            get
            {
                return opened;
            }

            set
            {
                opened = value;
            }
        }

        public bool IsRuneDoor
        {
            get
            {
                return color != RuneColor.None;
            }
        }

        public RuneColor Color
        {
            get
            {
                return color;
            }
        }

        public Door(int zone1, int zone2, RuneColor color)
        {
            Contract.Requires(zone1 != zone2);
            this.betweenZones = Tuple.Create(zone1, zone2);
        }
    }
}
