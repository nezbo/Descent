namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using Descent.Model.Board;
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

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
        /// <param name="draw">The SpriteBatch to draw on.</param>
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
            Contract.Requires(Keyboard.GetState().IsKeyDown(key));

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
        /// <param name="gameTime">The GameTime object for this game.</param>
        public override void Update(GameTime gameTime)
        {
            if (Game.IsActive)
            {
                // mouseclick
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed && !mouseDownBefore)
                {
                    HandleClick(ms.X, ms.Y);
                }
                mouseDownBefore = (ms.LeftButton == ButtonState.Pressed);

                KeyboardState keyState = Keyboard.GetState();

                // key tuped
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
            }

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
        /// <param name="role">The Role determining how much is visible on the board.</param>
        public void CreateBoardGUI(Board board, Role role)
        {
            layers[0] = GUIElementFactory.CreateBoardElement(Game, board, role);
        }

        /// <summary>
        /// Creates (and initiates) the layer of the GUI
        /// that displays the chat and player stats
        /// </summary>
        /// <param name="role">The Role that should be created a menu for.</param>
        public void CreateMenuGUI(Role role)
        {
            layers[2] = GUIElementFactory.CreateMenuElement(Game, role);
        }

        /// <summary>
        /// Marks a square on the board with a transparent color.
        /// </summary>
        /// <param name="x">The x-coordinate of the square on the board.</param>
        /// <param name="y">The y-coordinate of the square on the board.</param>
        /// <param name="positive">True if the highlight should indicate a eligible. False if it should indicate inaccessibility.</param>
        public void MarkSquare(int x, int y, bool positive)
        {
            ((BoardElement)layers[0]).MarkSquare(x, y, positive);
        }

        /// <summary>
        /// Clears the board for all markings.
        /// </summary>
        public void ClearMarks()
        {
            ((BoardElement)layers[0]).ClearMarks();
        }
    }
}