using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.GUI
{
    using System.Collections.ObjectModel;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// A single element of the user interface that, itself, 
    /// can contain sub-elements
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class GUIElement
    {
        private static StateManager manager = Player.Instance.StateManager;

        private Rectangle bound;
        public Rectangle Bound { get { return bound; } }

        private string name;
        public string Name { get { return name; } }

        private Collection<GUIElement> children;

        private Dictionary<Drawable, Vector2> visuals;
        private Action<StateManager> onClick = null;

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
            visuals = new Dictionary<Drawable, Vector2>();
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
            // is it within me
            if (this.HasPoint(x, y))
            {
                // is it within any of my children
                foreach (GUIElement e in children)
                {
                    if (e.HandleClick(x, y))
                    {
                        return true;
                    }
                }

                // ok, its within me, ill handle it!
                if (onClick != null)
                {
                    onClick(manager);
                }
                return true;
            }
            else
            {
                // nope, wasnt me :(
                return false;
            }
        }

        /// <summary>
        /// Replace (if any) the current On Click action with
        /// the one given.
        /// </summary>
        /// <param name="action">The new On Click action</param>
        public void AddClickAction(string target, Action<StateManager> action)
        {
            if (this.name == target)
            {
                this.onClick = action;
            }
            foreach (GUIElement e in children) e.AddClickAction(target, action);
        }

        /// <summary>
        /// Adds the given GUIElement to the set of children within
        /// this one.
        /// </summary>
        /// <param name="child">The new child</param>
        public void AddChild(GUIElement child)
        {
            children.Add(child);
        }

        /// <summary>
        /// Add the drawable to be displayed at the given position
        /// in this GUIElement.
        /// </summary>
        /// <param name="visual">The drawable to display</param>
        /// <param name="position">Where the upper-left corner of the drawable should be</param>
        public void AddDrawable(Drawable visual, Vector2 position)
        {
            visuals.Add(visual, position);
        }

        /// <summary>
        /// Draws this GUIElement and then all children on top of it
        /// </summary>
        /// <param name="draw">The SpriteBatch to draw on</param>
        public void Draw(SpriteBatch draw)
        {
            // draw myself
            foreach (Drawable d in visuals.Keys) draw.Draw(d.Texture, visuals[d], Color.White);

            // draw the children on top
            foreach (GUIElement e in children) e.Draw(draw);
        }
    }
}
