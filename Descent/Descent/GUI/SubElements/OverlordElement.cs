namespace Descent.GUI.SubElements
 {
     using Descent.Model.Player;
     using Descent.Model.Player.OverlordStuff;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Graphics;

     /// <summary>
     /// The user interface of the overlord player. This is (at the moment) just his
     /// hand of cards. Right now the visualization of the overlords stuff isn't bound
     /// to any backend code so it isn't functional yet.
     /// </summary>
     /// <author>
     /// Emil Juul Jacobsen
     /// </author>

     class OverlordElement : GUIElement
     {
         private int oldHandSize = 0;

         /// <summary>
         /// Creates a new overlord element for the given game.
         /// </summary>
         /// <param name="game">The current Game object.</param>
         public OverlordElement(Game game)
             : base(game, "hero", 0, 0, (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)), game.GraphicsDevice.Viewport.Height)
         {
             SetDrawBackground(false);
             AddDrawable(Name, new Image(game.Content.Load<Texture2D>("Images/Heroes/BIG-0")), new Rectangle(Bound.X, Bound.Y + Bound.Height - 200, 200, 200));
         }

         private void UpdateHand()
         {
             if (Player.Instance.Overlord.Hand.Count != oldHandSize)
             {
                 this.ClearChildren();

                 int cardX = 250;
                 foreach (OverlordCard card in Player.Instance.Overlord.Hand)
                 {
                     AddChild(new OverlordCardElement(Game, cardX, Bound.Height - 25, card));
                     cardX += 50;
                 }

                 oldHandSize = Player.Instance.Overlord.Hand.Count;
             }
         }

         public override void Update(GameTime gameTime)
         {
             UpdateHand();
             base.Update(gameTime);
         }
     }
 }
