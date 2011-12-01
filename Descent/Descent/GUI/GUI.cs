using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

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

        //input
        private bool mouseDownBefore = false;
        private Dictionary<Keys, bool> keyDownBefore;

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
            this.keyDownBefore = new Dictionary<Keys, bool>();

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
        private void HandleClick(int x, int y)
        {
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                if (layers[i].HandleClick(x, y)) break;
            }
        }

        private void HandleKeyPress(Keys key)
        {
            foreach (GUIElement e in layers)
            {
                HandleKeyPress(key);
            }
        }

        /// <summary>
        /// Updates the content of the gui by checking for mouse
        /// clicks and key presses.
        /// </summary>
        /// <param name="delta">The number of milliseconds since last update</param>
        public void Update(int delta)
        {
            // mouseclick
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && !mouseDownBefore)
            {
                HandleClick(ms.X, ms.Y);
            }
            mouseDownBefore = (ms.LeftButton == ButtonState.Pressed);

            // keys
            List<Keys> pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                bool isDown = pressed.Contains(key);
                if (isDown && keyDownBefore.ContainsKey(key) && !keyDownBefore[key])
                {
                    HandleKeyPress(key);
                }
                keyDownBefore.Add(key, isDown);
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