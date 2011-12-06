﻿namespace Descent.GUI
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
            GUIElement result = new GUIElement(game, "state", 0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
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
                case State.InLobby:
                    {
                        GUIElement box = new GUIElement(game, "players", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 80));
                        GUIElement p1 = new GUIElement(game, "player1", RelW(g, 40), RelH(g, 15), RelW(g, 20), RelH(g, 20));
                        GUIElement p2 = new GUIElement(game, "player2", RelW(g, 23), RelH(g, 40), RelW(g, 20), RelH(g, 20));
                        GUIElement p3 = new GUIElement(game, "player3", RelW(g, 56), RelH(g, 40), RelW(g, 20), RelH(g, 20));
                        GUIElement p4 = new GUIElement(game, "player4", RelW(g, 23), RelH(g, 65), RelW(g, 20), RelH(g, 20));
                        GUIElement p5 = new GUIElement(game, "player5", RelW(g, 56), RelH(g, 65), RelW(g, 20), RelH(g, 20));
                        GUIElement ready = new GUIElement(game, "ready", RelW(g, 82), RelH(g, 85), RelW(g, 16), RelH(g,10));

                        root.AddChild(box);
                        root.AddChild(ready);
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
                        root.AddText("ready", "Ready", new Vector2(0, 0));

                        break;
                    }
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
