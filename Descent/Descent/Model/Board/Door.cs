// -----------------------------------------------------------------------
// <copyright file="Door.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.Xna.Framework;

namespace Descent.Model.Board
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    public enum RuneKey
    {
        Red, None
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Door
    {
        private readonly int[] areas;

        private readonly Point[,] points;

        private readonly Orientation orientation;

        private readonly RuneKey keyColor;

        private bool opened = false;

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
                return keyColor != RuneKey.None;
            }
        }

        public RuneKey KeyColor
        {
            get
            {
                return keyColor;
            }
        }

        public Orientation Orientation
        {
            get { return orientation; }
        }

        public int[] Areas
        {
            get { return areas; }
        }

        public Point TopLeftCorner
        {
            get
            {
                Point topLeft = points[0, 0];
                foreach (var point in points)
                {
                    if (point.X <= topLeft.X && point.Y <= topLeft.Y)
                    {
                        topLeft = point;
                    }
                }
                return topLeft;
            }
        }

        public Door(int area1, Point point1InArea1, Point point2InArea1, int area2, Point point1InArea2, Point point2InArea2, Orientation orientation, RuneKey color)
        {
            Contract.Requires(area1 != area2);

            // Make sure zone1 is always smaller
            if (area1 > area2)
            {
                int temp = area1;
                area1 = area2;
                area2 = area1;
            }
            areas = new int[] { area1, area2 };
            points = new Point[,] { { point1InArea1, point2InArea1 }, { point1InArea2, point2InArea2 } };
            this.orientation = orientation;
            this.keyColor = color;
        }

        public bool IsAdjecentSquare(Point point)
        {
            foreach (var p in points)
            {
                if (p == point) return true;
            }
            return false;
        }
    }
}
