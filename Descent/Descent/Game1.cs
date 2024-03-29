using Descent.GUI;
using Descent.Model;
using Descent.Model.Player;
using Descent.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Descent
{
    using Descent.Messaging.Events;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GUI.GUI gui;

        private int numOfFrames = 0;
        private double FPS = 0;

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
            this.IsMouseVisible = true;
            InputElement.SetInput("nameInput", "Player");
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
            GUI.GUI.Font = Content.Load<SpriteFont>("font");
            FullModel.LoadContent(this);

            // creation of elements
            this.gui = new GUI.GUI(this);
            GUIElement root = GUIElementFactory.CreateStateElement(this, Descent.State.State.ActivateMonsters, Descent.Model.Player.Role.Overlord, null);
            GUIElement createGame = new GUIElement(this, "create", (GraphicsDevice.Viewport.Width - 300) / 2, 400, 300, 100);
            GUIElement joinGame = new GUIElement(this, "join", (GraphicsDevice.Viewport.Width - 300) / 2, 550, 300, 100);
            GUIElement changeName = new GUIElement(this, "changeName", (GraphicsDevice.Viewport.Width - 200) / 2, 250, 200, 100);
            InputElement nameInput = new InputElement(this, "nameInput", changeName.Bound.X + 10, changeName.Bound.Y + (changeName.Bound.Height - 30) / 2, changeName.Bound.Width - 20, 30);
            InputElement connectInput = new InputElement(this, "connectInput", joinGame.Bound.X + 10, joinGame.Bound.Y + (joinGame.Bound.Height - 30) / 2, 150, 30);
            GUIElement buttonCreateGame = new GUIElement(this, "doneCreate", createGame.Bound.X + (createGame.Bound.Width - 100) / 2, createGame.Bound.Y + (createGame.Bound.Height - 30) / 2, 120, 30);
            GUIElement buttonJoinGame = new GUIElement(this, "doneJoin", joinGame.Bound.X + 200, joinGame.Bound.Y + (joinGame.Bound.Height - 30) / 2, 80, 30);

            // assembling tree
            root.AddChild(createGame);
            root.AddChild(joinGame);
            root.AddChild(changeName);
            changeName.AddChild(nameInput);
            createGame.AddChild(buttonCreateGame);
            joinGame.AddChild(connectInput);
            joinGame.AddChild(buttonJoinGame);

            // adding visual to tree
            changeName.SetBackground("boxbg");
            joinGame.SetBackground("boxbg");
            createGame.SetBackground("boxbg");
            nameInput.SetBackground("boxbg");
            connectInput.SetBackground("boxbg");
            buttonCreateGame.SetBackground("boxbg");
            buttonJoinGame.SetBackground("boxbg");
            Image logo = new Image(Content.Load<Texture2D>("logo-descent"));
            root.AddDrawable(root.Name, logo, new Vector2((root.Bound.Width - logo.Texture.Bounds.Width) / 2.0f, 50));

            // adding logic to tree
            root.SetDrawBackground(false);

            root.AddText("changeName", "Name:", new Vector2(5, 0));
            root.AddText("doneCreate", "New Game!", new Vector2(5, 0));
            root.AddText("doneJoin", "Join!", new Vector2(25, 0));
            root.SetClickAction("doneCreate", (n, g) =>
            {
                // Start the game. TODO: Try/catch error handling.
                n.StartGame(1337);

                // Set the nickname. Since this is the server, it will be set on id 1 always.
                if (InputElement.GetInputFrom("nameInput").Length > 0)
                {
                    n.Nickname = InputElement.GetInputFrom("nameInput");
                }

                // Create the state manager.
                n.StateManager = new StateManager(gui);
            });

            root.SetClickAction("doneJoin", (n, g) =>
            {
                g.SetClickAction(g.Name, null);
                n.JoinGame(InputElement.GetInputFrom("connectInput"), 1337);

                Player.Instance.EventManager.AcceptPlayerEvent += new AcceptPlayerHandler((sender, eventArgs) =>
                {
                    if (eventArgs.PlayerId == Player.Instance.Id)
                    {
                        if (InputElement.GetInputFrom("nameInput").Length > 0)
                        {
                            n.Nickname = InputElement.GetInputFrom("nameInput");
                        }

                        n.StateManager = new StateManager(gui);

                        Player.Instance.EventManager.QueueEvent(EventType.PlayerJoined, new PlayerJoinedEventArgs(Player.Instance.Id, Player.Instance.Nickname));
                    }
                });
            });

            Player.Instance.EventManager.PlayerJoinedEvent += new PlayerJoinedHandler((sender, eventArgs) =>
            {
                // If the PlayerJoined event is about our local player(the id will be set just before this, so 

            });

            // placing the root in the gui
            gui.ChangeStateGUI(root);

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //fullscreen
            if (Keyboard.GetState().IsKeyDown(Keys.F11)) graphics.ToggleFullScreen();

            // FPS
            if (gameTime.TotalGameTime.Milliseconds == 0)
            {
                FPS = numOfFrames;
                numOfFrames = 0;
            }

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gui.Update(gameTime);
            Player.Instance.EventManager.ProcessEventQueue();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            gui.Draw(spriteBatch);

            numOfFrames++;
            string header = "Descent - FPS " + FPS;
            Window.Title = header;

            base.Draw(gameTime);
        }
    }
}
