using Descent;
using Descent.GUI;
using Descent.Model.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EmilTests
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GUI gui;

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
            this.IsMouseVisible = true;
            Player.Instance.Name = "Nezbo";
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
            Descent.GUIHolder.Font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here

            // creation of elements
            this.gui = new GUI(this);
            GUIElement root = GUIElementFactory.CreateStateElement(this, Descent.State.State.ActivateMonsters, Descent.Model.Player.Role.Overlord);
            GUIElement createGame = new GUIElement(this, "create", 100, 50, 300, 100);
            GUIElement joinGame = new GUIElement(this, "join", 100, 350, 300, 100);
            InputElement connectInput = new InputElement(this, "connectInput", joinGame.Bound.X + 10, joinGame.Bound.Y + (joinGame.Bound.Height - 30) / 2, 150, 30);
            GUIElement buttonCreateGame = new GUIElement(this, "doneCreate", createGame.Bound.X + 200, createGame.Bound.Y + (createGame.Bound.Height - 30) / 2, 80, 30);
            GUIElement buttonJoinGame = new GUIElement(this, "doneJoin", joinGame.Bound.X + 200, joinGame.Bound.Y + (joinGame.Bound.Height - 30) / 2, 80, 30);

            buttonCreateGame.SetDrawBackground(true);
            buttonJoinGame.SetDrawBackground(true);
            root.SetDrawBackground(true);
            createGame.SetDrawBackground(true);
            joinGame.SetDrawBackground(true);
            connectInput.SetDrawBackground(true);

            // assembling tree
            root.AddChild(createGame);
            root.AddChild(joinGame);
            createGame.AddChild(buttonCreateGame);
            joinGame.AddChild(connectInput);
            joinGame.AddChild(buttonJoinGame);

            // adding logic to tree
            root.AddClickAction(root.Name, n => System.Diagnostics.Debug.WriteLine("Root clicked"));
            root.AddText("doneCreate", "Create!", new Vector2(0, 0));
            root.AddText("doneJoin", "Join!", new Vector2(0, 0));
            root.AddClickAction("doneCreate", n => n.StartGame(1337));
            root.AddClickAction("doneJoin", n => n.JoinGame(GUIHolder.GetInputFrom("connectInput"), 1337));

            // placing the root in the gui
            gui.ChangeStateGUI(root);

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
            gui.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);

            // TODO: Add your drawing code here
            gui.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
