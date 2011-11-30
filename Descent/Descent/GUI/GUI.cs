namespace Descent.GUI
{
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Handles the visual aspects of the game and input
    /// from the user.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    class GUI
    {
        private SpriteBatch draw; // the drawing surface

        /// <summary>
        /// The three layers of the GUI:
        /// 0: The board.
        /// 1: The state.
        /// 2: The chat and info
        /// </summary>
        private GUIElement[] layers;

        /// <summary>
        /// Creates a Graphical User Interface.
        /// </summary>
        /// <param name="draw">The surface to draw on.</param>
        public GUI(SpriteBatch draw)
        {
            this.draw = draw;

            layers = new GUIElement[3];
        }

        /// <summary>
        /// Draws the GUI to the screen.
        /// </summary>
        public void Draw()
        {
            draw.Begin();
            foreach (GUIElement element in layers)
            {
                element.Draw(draw);
            }
            draw.End();
        }

        /// <summary>
        /// Lets the topmost element on the screen
        /// react to the given click.
        /// </summary>
        /// <param name="x">The x-coordinate of the click</param>
        /// <param name="y">The y-coordinate of the click</param>
        public void HandleClick(int x, int y)
        {
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                if (layers[i].HandleClick(x, y)) break;
            }
        }

        /// <summary>
        /// Changes the GUIElement of the state layer.
        /// </summary>
        /// <param name="state">The new GUIElement of the State layer</param>
        public void ChangeStateGUI(GUIElement state)
        {
            layers[1] = state;
        }
    }
}