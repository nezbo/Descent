namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;
    using Descent.Model.Board;
    using Descent.Model.Player;
    using Descent.State;


    /// <summary>
    /// Responsible for creating the GUIElements for the different layers of the gui and
    /// for all the different states and roles in the game. This is done as a simple hierarchy
    /// of GUIElements and should be populated with logic (events on click) and Drawables to
    /// be displayed within the respective GUIElements in the tree.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class GUIElementFactory
    {
        private static GUIElement CreateRoot(GraphicsDevice graphics)
        {
            return new GUIElement("state", 0, 0, graphics.DisplayMode.Width, graphics.DisplayMode.Height);
        }

        private static int RelW(GraphicsDevice graphics, int percentage)
        {
            return (int) (graphics.DisplayMode.Width*(3.0/4.0) * (percentage/100.0));
        }

        private static int RelH(GraphicsDevice graphics, int percentage)
        {
            return (int)(graphics.DisplayMode.Height * (percentage / 100.0));
        }

        // public

        public static GUIElement CreateBoardElement(GraphicsDevice graphics, Board board)
        {
            return new BoardGUIElement(graphics, board);
        }

        public static GUIElement CreateStateElement(GraphicsDevice g, State state, Role role)
        {
            GUIElement root = CreateRoot(g);

            switch(state)
            {
                // TODO: fill the root here for all states that is drawn
                case State.DrawHeroCard:
                    {
                        GUIElement cardE = new GUIElement("hero", RelW(g,25), RelH(g,40), RelW(g,50), RelH(g,20)); //TODO: proper values
                        root.AddChild(cardE);
                        break;
                    }
                default: { break; }
            }

            return root;
        }

        public static GUIElement CreateMenuElement(GraphicsDevice graphics)
        {
            GUIElement root = CreateRoot(graphics);

            //TODO: Fill with stuff to draw.

            return root;
        }
    }
}
