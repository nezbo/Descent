using System;
using System.Diagnostics.Contracts;
using Descent.GUI.SubElements;
using Descent.Messaging.Events;
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
            Contract.Ensures(Contract.Result<GUIElement>().Bound.X == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Y == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Width == game.GraphicsDevice.Viewport.Width);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Height == game.GraphicsDevice.Viewport.Height);

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
            Contract.Ensures(Contract.Result<GUIElement>() != null);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.X == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Y == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Width == (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)));
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Height == game.GraphicsDevice.Viewport.Height);

            return new BoardGUIElement(game, board, role);
        }

        public static GUIElement CreateStateElement(Game game, State state, Role role, GameState gameState)
        {
            Contract.Ensures(Contract.Result<GUIElement>() != null);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.X == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Y == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Width == game.GraphicsDevice.Viewport.Width);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Height == game.GraphicsDevice.Viewport.Height);

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
                            GUIElement start = new GUIElement(game, "start", RelW(g, 84), RelH(g, 90), RelW(g, 12), RelH(g, 4));
                            root.AddChild(start);
                            root.AddText("start", "Start Game", new Vector2(0, 0));

                            string ipString = "";
                            foreach (string ip in Player.Instance.Connection.Ips) ipString += ip + "\n";
                            root.AddText(box.Name, ipString, new Vector2(10, 10));
                        }

                        break;
                    }
                case State.AllBuyEquipment:
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
                                                                               "Empty", current, x + y * 6 + 1000);
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
                case State.AllEquip:
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
                                EquipmentElement eq = GUIElementFactory.CreateEquipmentElement(game, startX + x * width + x * spacerX, startY, "Empty", current, x + 100);
                                root.AddChild(eq);
                            }

                            GUIElement done = new GUIElement(game, "done", RelW(g, 85), RelH(g, 90), RelW(g, 10), RelH(g, 5));
                            done.AddText(done.Name, "Done", new Vector2(0, 0));
                            root.AddChild(done);
                        }
                        break;
                    }
                case State.WaitForChooseSquare: // hero placement
                    {
                        if (role != Role.Overlord)
                        {
                            GUIElement help = new GUIElement(game, "help", RelW(g, 3), RelW(g, 3), RelW(g, 33), RelH(g, 5));

                            root.AddChild(help);
                            root.AddText(help.Name, "Select a square to place your hero", new Vector2(5, 5));
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
                            GUIElement advance = new GUIElement(game, "advance", RelW(g, 3), RelH(g, 3), RelW(g, 10), RelH(g, 5));
                            GUIElement run = new GUIElement(game, "run", RelW(g, 3), RelH(g, 10), RelW(g, 10), RelH(g, 5));
                            GUIElement battle = new GUIElement(game, "battle", RelW(g, 3), RelH(g, 17), RelW(g, 10), RelH(g, 5));

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
                        else if (role == Role.Overlord && Player.Instance.StateManager.HasTurn())
                        {
                            GUIElement end = new GUIElement(game, "end", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 10));
                            root.AddChild(end);
                            root.AddText(end.Name, "End Monster Turn", new Vector2(5, 5));
                        }
                        break;
                    }
                case State.WaitForOverlordChooseAction:
                    {
                        if (role == Role.Overlord)
                        {
                            GUIElement end = new GUIElement(game, "end", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 10));

                            root.AddChild(end);
                            root.AddText(end.Name, "End Overlord Turn", new Vector2(5, 5));
                        }
                        break;
                    }
                case State.WaitForRollDice:
                    {
                        GUIElement box = new GUIElement(game, "box", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 60));
                        if (gameState.CurrentPlayer == Player.Instance.Id)
                        {
                            GUIElement roll = new GUIElement(game, "roll", RelW(g, 75), RelH(g, 70), RelW(g, 10), RelH(g, 6));
                            root.AddChild(roll);
                            root.AddText(roll.Name, "Roll", new Vector2(5, 5));
                        }
                        root.AddChild(box);

                        break;
                    }
                case State.WaitForDiceChoice:
                    {
                        GUIElement box = new AttackElement(game, gameState.CurrentAttack, RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 60));

                        if (gameState.CurrentPlayer == Player.Instance.Id)
                        {
                            GUIElement finish = new GUIElement(game, "finish", RelW(g, 75), RelH(g, 70), RelW(g, 10), RelH(g, 8));
                            root.AddChild(finish);
                            root.AddText(finish.Name, "Inflict Wounds", new Vector2(5, 5));
                        }
                        root.AddChild(box);

                        break;
                    }
            }

            return root;
        }

        public static GUIElement CreateMenuElement(Game game, Role role)
        {
            Contract.Ensures(Contract.Result<GUIElement>() != null);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.X == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Y == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Width == game.GraphicsDevice.Viewport.Width);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Height == game.GraphicsDevice.Viewport.Height);

            GUIElement root = CreateEmptyRoot(game);

            if (role == Role.Overlord)
            {
                root.AddChild(new OverlordElement(game));
            }
            else
            {
                root.AddChild(new HeroElement(game, Player.Instance.Hero));
                root.SetClickAction("item", (n, g) =>
                {
                    if (g is EquipmentElement)
                    {
                        int id = ((EquipmentElement)g).Id;
                        n.EventManager.QueueEvent(EventType.InventoryFieldMarked, new InventoryFieldEventArgs(id));
                    }
                });
            }

            root.AddChild(new PlayersElement(game, Player.Instance.IsOverlord ? null : Player.Instance.Hero, Player.Instance.HeroParty));
            root.AddChild(new Chat(game));

            return root;
        }

        public static EquipmentElement CreateEquipmentElement(Game game, int x, int y, string slotTitle, Equipment equipment, int id)
        {
            return new EquipmentElement(game, x, y, RelW(game.GraphicsDevice.Viewport, 10), RelW(game.GraphicsDevice.Viewport, 10), slotTitle, equipment, id);
        }
    }
}
