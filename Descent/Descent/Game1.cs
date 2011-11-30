using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNATutorials
{
    using System;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private int xDisp, yDisp;
        private Sprite[,] board;

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
            xDisp = 0;
            yDisp = 0;
            this.board = new Sprite[100, 100];

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
            //********** MONSTERS **********//
            /*
            StreamReader reader = File.OpenText("monsters.txt");
            int length = int.Parse(reader.ReadLine());
            for(int i = 0; i < length)
            reader.Close();
            */
             
            //********** LOAD MAP **********//
            SpriteFactory sf = new SpriteFactory(this.Content);

            StreamReader reader = File.OpenText("quest1.map");
            int height = int.Parse(reader.ReadLine());
            int width = int.Parse(reader.ReadLine());

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
                            board[x, y] = sf.GetSprite("floor");
                            break;
                    }

                }
            }
            

            //************* LOAD OTHER STUFF ************//
            int lines = int.Parse(reader.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                line = reader.ReadLine();
                System.Diagnostics.Debug.WriteLine(line);
                string[] data = line.Split(',');
                switch (data[0])
                {
                    case "monster":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite(data[3]);
                        break;
                    case "portal":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("portal");
                        break;
                    case "treasure":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("treasure-" + data[3]);
                        break;
                    case "gold":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("gold");
                        break;
                    case "rock":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("rock1");
                        break;
                    case "pit":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("pit1");
                        break;
                    case "potion":
                        board[int.Parse(data[1]), int.Parse(data[2])] = sf.GetSprite("potion-" + data[3]);
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Left)) xDisp += 10;
            if (keyState.IsKeyDown(Keys.Right)) xDisp -= 10;
            if (keyState.IsKeyDown(Keys.Up)) yDisp += 10;
            if (keyState.IsKeyDown(Keys.Down)) yDisp -= 10;

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
            spriteBatch.Begin();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Sprite cur = board[x, y];
                    if (cur != null) spriteBatch.Draw(cur.Texture, new Vector2(xDisp + x * 95, yDisp + y * 95), Color.White);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
