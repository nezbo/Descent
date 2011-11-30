using System;
using System.Collections.Generic;

namespace Descent.GUI
{
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    class GUIElement
    {
        //private static StateManager manager = Player.Instance.StateManager;

        private Rectangle bound;
        public Rectangle Bound { get { return bound; } }

        private string name;
        public string Name { get { return name; } }

        private Collection<GUIElement> children;
        private Dictionary<Drawable, Point> visuals;

        /// <summary>
        /// Creates a GUIElement with the given boundaries.
        /// </summary>
        /// <param name="name">The name of the element</param>
        /// <param name="x">The x-coordinate of the upper-left corner</param>
        /// <param name="y">The y-coordinate of the upper-left corner</param>
        /// <param name="width">The width of the element</param>
        /// <param name="height">The height of the element</param>
        public GUIElement(string name, int x, int y, int width, int height)
        {
            this.name = name;
            bound = new Rectangle(x, y, width, height);
            children = new Collection<GUIElement>();
            visuals = new Dictionary<Drawable, Point>();
        }

        /// <summary>
        /// Checks if the given point is within the boundaries of the GUIElement.
        /// </summary>
        /// <param name="x">The x-coordinate of the point</param>
        /// <param name="y">The y-coordinate of the point</param>
        /// <returns></returns>
        public bool HasPoint(int x, int y)
        {
            return bound.Contains(x, y);
        }

        /// <summary>
        /// Determines if a click is within the GUIElement and acts
        /// upon the click if possible.
        /// </summary>
        /// <param name="x">The x-coordinate of the click</param>
        /// <param name="y">The y-coordinate of the click</param>
        public bool HandleClick(int x, int y)
        {
            if (this.HasPoint(x, y))
            {
                foreach (GUIElement e in children)
                {
                    if (e.HandleClick(x, y))
                    {
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddClickEvent(Action<StateManager> action)
        {

        }
    }
}
