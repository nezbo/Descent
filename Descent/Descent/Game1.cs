using Descent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNATutorials
{
    using System.IO;

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

            //********** MONSTERS **********//
            /*
            StreamReader reader = File.OpenText("monsters.txt");
            int length = int.Parse(reader.ReadLine());
            for(int i = 0; i < length)
            reader.Close();
            */

            StreamReader reader = new System.IO.StreamReader(TitleContainer.OpenStream("quest1.map"));
            SpriteFactory sf = new SpriteFactory(this.Content);

            // ORDER IS VERY IMPORTANT! Map first, then other!
            this.LoadMap(reader, sf);
            this.LoadOther(reader, sf);

        }

        private void LoadMap(StreamReader reader, SpriteFactory sf)
        {
            //********** LOAD MAP **********//

            int height = int.Parse(reader.ReadLine());
            int width = int.Parse(reader.ReadLine());
            this.board = new Sprite[width, height];

            this.board = new Sprite[width, height];

            string line = null;
            for (int y = 0; y < height; y++)
            {
                line = reader.ReadLine();
                System.Diagnostics.Debug.WriteLine(line);
                for (int x = 0; x < line.Length; x++)
                {
                    if (line.StartsWith("#")) continue;

                    switch (line.Substring(x, 1))
                    {
                        case " ":
                            break;
                        default:
                            board[x, y] = sf.GetSprite("Images/Board/floor");
                            break;
                    }

                }
            }
        }
        
        private void LoadOther(StreamReader reader, SpriteFactory sf)
        {
            //************* LOAD OTHER STUFF ************//
            string line;
            int lines = int.Parse(reader.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                line = reader.ReadLine();
                System.Diagnostics.Debug.WriteLine(line);
                string[] data = line.Split(',');
                switch (data[0])
                {
                    case "monster":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Monsters/" + data[3]);
                        break;
                    case "glyph":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/portal-" + data[3]);
                        break;
                    case "treasure":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/treasure-" + data[3]);
                        break;
                    case "gold":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/gold");
                        break;
                    case "rock":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/rock1");
                        break;
                    case "pit":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/pit1");
                        break;
                    case "potion":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/potion-" + data[3]);
                        break;
                    case "rune":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("Images/Board/rune-" + data[3]);
                        break;
                }
            }
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
            if (keyState.IsKeyDown(Keys.Left) && xDisp > -2 * 95) xDisp -= 10;
            if (keyState.IsKeyDown(Keys.Right) && xDisp < (board.GetLength(0) + 1) * 95 - graphics.PreferredBackBufferWidth) xDisp += 10;
            if (keyState.IsKeyDown(Keys.Up) && yDisp > -2 * 95) yDisp -= 10;
            if (keyState.IsKeyDown(Keys.Down) && yDisp < (board.GetLength(1) + 2) * 95 - graphics.PreferredBackBufferHeight) yDisp += 10;
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


            // Draw screen
            spriteBatch.Begin();

            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Sprite cur = board[x, y];
                    if (cur != null) spriteBatch.Draw(cur.Texture, new Vector2(x * 95 - xDisp, y * 95 - yDisp), Color.White);
                }
            }

            spriteBatch.Draw(highlightTexture, new Rectangle(5 * 95 - xDisp, 18 * 95 - yDisp, 95, 95), new Color(0,0,0,155));
            spriteBatch.Draw(highlightTexture, new Rectangle(5 * 95 - xDisp, 19 * 95 - yDisp, 95, 95), new Color(110, 111, 72, 128));

            // FPS
            numOfFrames++;
            Window.Title = "Descent - " + FPS + " FPS";
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
