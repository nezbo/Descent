using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Descent.GUI;

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
            Descent.FontHolder.Font = Content.Load<SpriteFont>("font");
            // TODO: use this.Content to load your game content here
            
            // creation of elements
            this.gui = new GUI(this);
            GUIElement root = GUIElementFactory.CreateStateElement(this, Descent.State.State.ActivateMonsters, Descent.Model.Player.Role.Overlord);
            GUIElement stuff = new GUIElement(this, "stuff", 200, 200, 250, 400);
            GUIElement moreStuff = new GUIElement(this, "stuff", 500, 200, 500, 100);
            GUIElement innerStuff = new GUIElement(this, "stuff", 200, 350, 225, 200);
            GUIElement chat = new Chat(this);

            innerStuff.SetDrawBackground(true);
            root.SetDrawBackground(true);
            stuff.SetDrawBackground(true);
            moreStuff.SetDrawBackground(true);

            // assembling tree
            root.AddChild(chat);
            root.AddChild(stuff);
            stuff.AddChild(innerStuff);
            root.AddChild(moreStuff);

            // adding logic to tree
            root.AddClickAction(root.Name, n => System.Diagnostics.Debug.WriteLine("Root clicked"));
            root.AddClickAction("stuff", n => System.Diagnostics.Debug.WriteLine("Stuff clicked"));
            root.AddText("stuff", "Hello World Hello World Hello World Hello World Ho World Hello World Hello World Hello World Hello World", new Vector2(0, 0));

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
