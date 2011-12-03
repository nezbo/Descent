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
    class GUIElementFactory
    {
        private static GUIElement CreateRoot(GraphicsDevice graphics)
        {
            return new GUIElement("state", 0, 0, graphics.DisplayMode.Width, graphics.DisplayMode.Height);
        }

        public static GUIElement CreateBoardElement(GraphicsDevice graphics, Board board)
        {
            return new BoardGUIElement(graphics, board);
        }

        public static GUIElement CreateStateElement(GraphicsDevice graphics, State state, Role role)
        {
            GUIElement root = CreateRoot(graphics);

            switch(state)
            {
                // TODO: fill the root here.
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
