using Descent.Model.Player.Figure.HeroStuff;

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
            GUIElement result = new GUIElement(game, "root", 0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
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

        public static GUIElement CreateBoardElement(Game game, Board board, Role role)
        {
            return new BoardGUIElement(game, board, role);
        }

        public static GUIElement CreateStateElement(Game game, State state, Role role, GameState gameState)
        {
            Viewport g = game.GraphicsDevice.Viewport;

            GUIElement root = CreateEmptyRoot(game);

            switch (state)
            {
                // TODO: fill the root here for all states that is drawn
                case State.InLobby:
                    {
                        GUIElement box = new GUIElement(game, "players", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 80));
                        GUIElement p1 = new GUIElement(game, "player1", RelW(g, 40), RelH(g, 15), RelW(g, 20), RelH(g, 20));
                        GUIElement p2 = new GUIElement(game, "player2", RelW(g, 23), RelH(g, 40), RelW(g, 20), RelH(g, 20));
                        GUIElement p3 = new GUIElement(game, "player3", RelW(g, 56), RelH(g, 40), RelW(g, 20), RelH(g, 20));
                        GUIElement p4 = new GUIElement(game, "player4", RelW(g, 23), RelH(g, 65), RelW(g, 20), RelH(g, 20));
                        GUIElement p5 = new GUIElement(game, "player5", RelW(g, 56), RelH(g, 65), RelW(g, 20), RelH(g, 20));

                        root.AddChild(box);
                        box.AddChild(p1);
                        box.AddChild(p2);
                        box.AddChild(p3);
                        box.AddChild(p4);
                        box.AddChild(p5);

                        Vector2 pos = new Vector2(10, 15);
                        root.AddText("player1", "Overlord:", pos);
                        root.AddText("player2", "Hero:", pos);
                        root.AddText("player3", "Hero:", pos);
                        root.AddText("player4", "Hero:", pos);
                        root.AddText("player5", "Hero:", pos);

                        if (role == Role.Overlord)
                        {
                            GUIElement start = new GUIElement(game, "start", RelW(g, 85), RelH(g, 90), RelW(g, 10), RelH(g, 5));
                            root.AddChild(start);
                            root.AddText("start", "Start Game", new Vector2(0, 0));
                        }

                        break;
                    }
                case State.BuyEquipment:
                    {
                        GUIElement money = new GUIElement(game, "money", 0, 0, RelW(g, 8), RelH(g, 8));
                        GUIElement box = new GUIElement(game, "shop", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 80));

                        int startY = RelH(g, 15);
                        int startX = RelW(g, 15);

                        int spacerX = RelW(g, 2);
                        int spacerY = RelH(g, 5);

                        int width = RelW(g, 10);

                        Equipment[] shopContent = gameState.CurrentEquipment;
                        for (int y = 0; y < 4; y++)
                        {
                            for (int x = 0; x < 6; x++)
                            {
                                box.AddChild(new EquipmentElement(game, startX + x * width + x * spacerX, startY + y * width + y * spacerY, width, width, shopContent[x + y]));
                            }
                        }

                        money.AddText(money.Name, "Money:\n300", new Vector2(5, 5));

                        root.AddChild(money);
                        root.AddChild(box);
                        break;
                    }
            }

            return root;
        }

        public static GUIElement CreateMenuElement(Game game, Role role)
        {
            GUIElement root = CreateEmptyRoot(game);

            if (role == Role.Overlord)
            {
                // populate with overlord menus
            }
            else
            {
                // populate with player stuff
            }

            root.AddChild(new Chat(game));

            return root;
        }
    }
}
