using Descent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNATutorials
{

    using Descent.GUI;
    using Descent.Model;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private int numOfFrames = 0;
        private double FPS = 0;

        private int xDisp, yDisp;
        private Sprite[,] board;

        private Texture2D highlightTexture;

        private BoardGUIElement boardGui;

        private bool initialized = false;
        private bool contentLoaded = false;
        #endregion

        #region Initialization
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            xDisp = -2 * 95;
            yDisp = 17 * 95;

            //Make the mouse pointer visible in the game window
            this.IsMouseVisible = true;

            base.Initialize();

            initialized = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // for highlighting
            highlightTexture = new Texture2D(GraphicsDevice, 1, 1);
            highlightTexture.SetData(new Color[] { Color.White });

            FullModel.LoadContent(this);
            contentLoaded = true;
            boardGui = new BoardGUIElement(this, FullModel.Board);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

        #region Update and Draw
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            // FPS
            if (gameTime.TotalGameTime.Milliseconds == 0)
            {
                FPS = numOfFrames;
                numOfFrames = 0;

            }

            // Controls

            KeyboardState keyState = Keyboard.GetState();
            /*
            //TODO: Har lavet haxor af controls som føres videre til boardgui klassen
            System.Diagnostics.Debug.WriteLine(keyState.IsKeyDown(Keys.Left) + " - " + boardGui.xDisp);
            if (keyState.IsKeyDown(Keys.Left) && boardGui.xDisp > -2 * 95) boardGui.xDisp -= 10;
            if (keyState.IsKeyDown(Keys.Right) && boardGui.xDisp < (FullModel.Board.Width + 1) * 95 - graphics.PreferredBackBufferWidth) boardGui.xDisp += 10;
            if (keyState.IsKeyDown(Keys.Up) && boardGui.yDisp > -2 * 95) boardGui.yDisp -= 10;
            if (keyState.IsKeyDown(Keys.Down) && boardGui.yDisp < (FullModel.Board.Height + 2) * 95 - graphics.PreferredBackBufferHeight) boardGui.yDisp += 10;
            */

            if (keyState.IsKeyDown(Keys.Escape)) this.Exit();

            base.Update(gameTime);
        }

        /// <summary>   
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            boardGui.Draw(spriteBatch);

            /*
            // Draw Board
            spriteBatch.Begin();
            Board board = FullModel.Board;
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board[x, y] != null) spriteBatch.Draw(board.FloorTexture, new Vector2(x * 95 - xDisp, y * 95 - yDisp), Color.White);
                }
            }
             

            spriteBatch.Draw(highlightTexture, new Rectangle(5 * 95 - xDisp, 18 * 95 - yDisp, 95, 95), new Color(0, 0, 0, 155));
            spriteBatch.Draw(highlightTexture, new Rectangle(5 * 95 - xDisp, 19 * 95 - yDisp, 95, 95), new Color(110, 111, 72, 128));

             * spriteBatch.End();
             */

            // FPS
            numOfFrames++;
            Window.Title = "Descent - " + FPS + " FPS";

            base.Draw(gameTime);
        }
        #endregion
    }
}
