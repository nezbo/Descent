﻿using System;
using System.Collections.Generic;
using Descent.Model;
using Descent.Model.Board;
using Descent.Model.Player;
using Microsoft.Xna.Framework.Input;

namespace Descent.GUI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Handles the visual aspects of the game and input
    /// from the user.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class GUI : DrawableGameComponent
    {
        // static

        public static SpriteFont Font { get; set; }

        // dynamic

        //input
        private bool mouseDownBefore = false;
        private KeyboardState lastKeyboardState;

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
        public GUI(Game game)
            : base(game)
        {
            this.lastKeyboardState = Keyboard.GetState();

            layers = new GUIElement[3];
        }

        /// <summary>
        /// Draws the GUI to the screen.
        /// </summary>
        public void Draw(SpriteBatch draw)
        {
            draw.Begin();
            foreach (GUIElement element in layers)
            {
                if (element != null) element.Draw(draw);
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
                if (layers[i] != null)
                {
                    if (layers[i].HandleClick(x, y)) break;
                }
            }
        }

        private void HandleKeyPress(Keys key)
        {
            foreach (GUIElement e in layers)
            {
                if (e != null)
                {
                    e.HandleKeyPress(key);
                }
            }
        }

        /// <summary>
        /// Updates the content of the gui by checking for mouse
        /// clicks and key presses.
        /// </summary>
        /// <param name="delta">The number of milliseconds since last update</param>
        public override void Update(GameTime gameTime)
        {
            // mouseclick
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && !mouseDownBefore)
            {
                HandleClick(ms.X, ms.Y);
            }
            mouseDownBefore = (ms.LeftButton == ButtonState.Pressed);

            // key tuped
            KeyboardState keyState = Keyboard.GetState();
            List<Keys> pressed = new List<Keys>(keyState.GetPressedKeys());
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                bool isDown = pressed.Contains(key);
                if (isDown && lastKeyboardState.IsKeyUp(key))
                {
                    HandleKeyPress(key);
                }
            }

            lastKeyboardState = keyState;

            // general update
            foreach (GUIElement l in layers)
            {
                if (l != null) l.Update(gameTime);
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

        /// <summary>
        /// Creates (and initiates) the layer of the GUI
        /// that displays the game board.
        /// </summary>
        /// <param name="board">The board to be displayed.</param>
        public void CreateBoardGUI(Board board, Role role)
        {
            layers[0] = GUIElementFactory.CreateBoardElement(Game, board, role);
        }

        /// <summary>
        /// Creates (and initiates) the layer of the GUI
        /// that displays the chat and player stats
        /// </summary>
        /// <param name="model"></param>
        public void CreateMenuGUI(FullModel model)
        {
            layers[2] = GUIElementFactory.CreateMenuElement(Game);
        }
    }
}