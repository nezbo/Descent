﻿using System;
using Descent.GUI.SubElements;
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

                        if (Player.Instance.IsServer)
                        {
                            GUIElement start = new GUIElement(game, "start", RelW(g, 84), RelH(g, 90), RelW(g, 12), RelH(g, 5));
                            root.AddChild(start);
                            root.AddText("start", "Start Game", new Vector2(0, 0));
                        }

                        break;
                    }
                case State.BuyEquipment:
                    {
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
                                if (shopContent.Length > (x + y * 6))
                                {
                                    Equipment current = shopContent[x + y * 6];
                                    EquipmentElement eq = new EquipmentElement(game, startX + x * width + x * spacerX,
                                                                               startY + y * width + y * spacerY, width, width,
                                                                               current, x + y * 6 + 1000);
                                    box.AddChild(eq);
                                }
                            }
                        }

                        if (role != Role.Overlord)
                        {
                            GUIElement done = new GUIElement(game, "done", RelW(g, 85), RelH(g, 90), RelW(g, 10), RelH(g, 5));
                            GUIElement money = new GUIElement(game, "money", 0, 0, RelW(g, 8), RelH(g, 8));

                            money.AddText(money.Name, "Money:\n" + Player.Instance.Hero.Coins, new Vector2(5, 5));
                            done.AddText(done.Name, "Done", new Vector2(0, 0));

                            root.AddChild(done);
                            root.AddChild(money);
                        }
                        root.AddChild(box);
                        break;
                    }
                case State.Equip:
                    {

                        if (role != Role.Overlord)
                        {
                            int startX = RelW(g, 15);
                            int startY = RelH(g, 15);
                            int spacerX = RelW(g, 2);
                            int width = RelW(g, 10);

                            Equipment[] unequipped = gameState.UnequippedEquipment(Player.Instance.Id);
                            int boxes = Math.Max(1, unequipped.Length);

                            for (int x = 0; x < boxes; x++)
                            {
                                Equipment current = (x < unequipped.Length) ? unequipped[x] : null;
                                EquipmentElement eq = GUIElementFactory.CreateEquipmentElement(game, startX + x * width + x * spacerX, startY, current, x + 100);
                                root.AddChild(eq);
                            }

                            GUIElement done = new GUIElement(game, "done", RelW(g, 85), RelH(g, 90), RelW(g, 10), RelH(g, 5));
                            done.AddText(done.Name, "Done", new Vector2(0, 0));
                            root.AddChild(done);
                        }
                        break;
                    }
                case State.WaitForHeroTurn:
                    {
                        if (role != Role.Overlord)
                        {
                            GUIElement takeTurn = new GUIElement(game, "take turn", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 5));
                            root.AddChild(takeTurn);
                            root.AddText(takeTurn.Name, "Take Turn", new Vector2(5, 5));
                        }
                        break;
                    }
                case State.WaitForChooseAction:
                    {
                        if (role == Role.ActiveHero)
                        {
                            GUIElement advance = new GUIElement(game, "advance", RelW(g, 45), RelH(g, 40), RelW(g, 10), RelH(g, 5));
                            GUIElement run = new GUIElement(game, "run", RelW(g, 45), RelH(g, 47), RelW(g, 10), RelH(g, 5));
                            GUIElement battle = new GUIElement(game, "battle", RelW(g, 45), RelH(g, 54), RelW(g, 10), RelH(g, 5));

                            Vector2 v = new Vector2(5, 5);
                            advance.AddText(advance.Name, "Advance", v);
                            run.AddText(run.Name, "Run", v);
                            battle.AddText(battle.Name, "Battle", v);

                            root.AddChild(advance);
                            root.AddChild(run);
                            root.AddChild(battle);
                        }
                        break;
                    }
                case State.WaitForPerformAction:
                    {
                        if (role == Role.ActiveHero)
                        {
                            GUIElement end = new GUIElement(game, "end", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 5));

                            root.AddChild(end);
                            root.AddText(end.Name, "End Turn", new Vector2(5, 5));
                        }
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
                root.AddChild(new HeroElement(game, Player.Instance.Hero));
            }

            root.AddChild(new Chat(game));

            return root;
        }

        public static EquipmentElement CreateEquipmentElement(Game game, int x, int y, Equipment equipment, int id)
        {
            return new EquipmentElement(game, x, y, RelW(game.GraphicsDevice.Viewport, 10), RelW(game.GraphicsDevice.Viewport, 10), equipment, id);
        }
    }
}
