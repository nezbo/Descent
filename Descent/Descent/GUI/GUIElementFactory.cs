namespace Descent.GUI
{
    using Descent.Model.Board;
    using Descent.Model.Player;
    using Descent.State;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;


    /// <summary>
    /// Responsible for creating the GUIElements for the different layers of the gui and
    /// for all the different states and roles in the game. This is done as a simple hierarchy
    /// of GUIElements and should be populated with logic (events on click) and Drawables to
    /// be displayed within the respective GUIElements in the tree.
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class GUIElementFactory
    {
        private static GUIElement CreateEmptyRoot(Game game)
        {
            GUIElement result = new GUIElement(game, "state", 0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            result.SetDrawBackground(false);

            return result;
        }

        private static int RelW(Viewport viewport, int percentage)
        {
            return (int)(viewport.Width * (3.0 / 4.0) * (percentage / 100.0));
        }

        private static int RelH(Viewport viewport, int percentage)
        {
            return (int)(viewport.Height * (percentage / 100.0));
        }

        // public

        public static GUIElement CreateBoardElement(Game game, Board board)
        {
            return new BoardGUIElement(game, board);
        }

        public static GUIElement CreateStateElement(Game game, State state, Role role)
        {
            Viewport g = game.GraphicsDevice.Viewport;

            GUIElement root = CreateEmptyRoot(game);

            switch (state)
            {
                // TODO: fill the root here for all states that is drawn
                case State.DrawHeroCard:
                    {
                        GUIElement cardE = new GUIElement(game, "hero", RelW(g, 25), RelH(g, 40), RelW(g, 50), RelH(g, 20)); //TODO: proper values
                        root.AddChild(cardE);
                        break;
                    }
            }

            return root;
        }

        public static GUIElement CreateMenuElement(Game game)
        {
            GUIElement root = CreateEmptyRoot(game);

            root.AddChild(new Chat(game));

            return root;
        }
    }
}
