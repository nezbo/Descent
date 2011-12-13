using Descent.GUI.Screens;

namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Descent.GUI.SubElements;
    using Descent.Model;
    using Descent.Model.Board;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure.HeroStuff;
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
        private static Dictionary<EDice, Texture2D> dicetinary;

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

        /// <summary>
        /// Creates a guielement that displays how the board looks like and keeps updated when
        /// the board changes.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="board">The Board to visualize.</param>
        /// <param name="role">The Role to view the board from, for example 
        /// the overlord may see the entire board from the beginning</param>
        /// <returns>A Guielement that displays the board.</returns>
        public static GUIElement CreateBoardElement(Game game, Board board, Role role)
        {
            Contract.Requires(game != null);
            Contract.Requires(board != null);
            Contract.Ensures(Contract.Result<GUIElement>() != null);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.X == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Y == 0);
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Width == (int)(game.GraphicsDevice.Viewport.Width * (3 / 4.0)));
            Contract.Ensures(Contract.Result<GUIElement>().Bound.Height == game.GraphicsDevice.Viewport.Height);

            return new BoardElement(game, board, role);
        }

        /// <summary>
        /// Creates a GUIElement that fits the given parameters.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="state">The State to be visualized.</param>
        /// <param name="role">The Role to view the given state from.</param>
        /// <param name="gameState">An object that holds some game properties that is needed for some States.</param>
        /// <returns>A new GUIElement that visualizes the given State.</returns>
        public static GUIElement CreateStateElement(Game game, State state, Role role, GameState gameState)
        {
            Contract.Requires(game != null);
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
                            foreach (string ip in Player.Instance.Connection.Ips) ipString += (ip + "\n");
                            root.AddText(box.Name, ipString, new Vector2(10, 10));
                        }

                        break;
                    }
                case State.AllBuyEquipment:
                case State.BuyEquipment:
                    {
                        GUIElement box = new GUIElement(game, "shop", RelW(g, 5), RelH(g, 5), RelW(g, 90), RelH(g, 80));

                        int startY = RelH(g, 10);
                        int startX = RelW(g, 10);

                        int spacerX = RelW(g, 2);
                        int spacerY = RelH(g, 5);

                        int width = RelW(g, 12);
                        int height = RelH(g, 16);

                        Equipment[] shopContent = gameState.CurrentEquipment.Where(n => n.Rarity == EquipmentRarity.Common).Distinct().ToArray();
                        for (int y = 0; y < 4; y++)
                        {
                            for (int x = 0; x < 6; x++)
                            {
                                if (shopContent.Length > (x + y * 6))
                                {
                                    Equipment current = shopContent[x + y * 6];
                                    EquipmentElement eq = new EquipmentElement(game, startX + x * width + x * spacerX,
                                                                               startY + y * width + y * spacerY, width, height,
                                                                               "", current, x + y * 6 + 1000);
                                    box.AddChild(eq);
                                }
                            }
                        }

                        if (role != Role.Overlord)
                        {
                            GUIElement done = new GUIElement(game, "done", RelW(g, 85), RelH(g, 90), RelW(g, 10), RelH(g, 5));
                            done.AddText(done.Name, "Done", new Vector2(0, 0));

                            root.AddChild(done);
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
                                EquipmentElement eq = GUIElementFactory.CreateEquipmentElement(game, startX + x * width + x * spacerX, startY, "", current, x + 100);
                                root.AddChild(eq);
                            }

                            GUIElement done = new GUIElement(game, "done", RelW(g, 3), RelW(g, 3), RelW(g, 10), RelH(g, 5));
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
                            GUIElement end = new GUIElement(game, "end", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 8));
                            root.AddChild(end);
                            root.AddText(end.Name, "End Monster Turn", new Vector2(5, 5));
                        }
                        break;
                    }
                case State.WaitForOverlordChooseAction:
                    {
                        if (role == Role.Overlord)
                        {
                            GUIElement end = new GUIElement(game, "end", RelW(g, 3), RelW(g, 3), RelW(g, 15), RelH(g, 8));

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
                case State.EndGameHeroParty:
                    {
                        GUIElement box = new GUIElement(game, "box", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 60));
                        GUIElement inner = new GUIElement(game, "inner", RelW(g, 30), RelH(g, 20), RelW(g, 40), RelH(g, 60));
                        box.AddChild(inner);
                        inner.AddText(inner.Name, "The heroes have triumphed over Joe and won the game!", new Vector2(5, 5));
                        inner.SetDrawBackground(false);

                        root.AddChild(box);
                        break;
                    }
                case State.EndGameOverlord:
                    {
                        GUIElement box = new GUIElement(game, "box", RelW(g, 10), RelH(g, 10), RelW(g, 80), RelH(g, 60));
                        GUIElement inner = new GUIElement(game, "inner", RelW(g, 30), RelH(g, 20), RelW(g, 40), RelH(g, 60));
                        box.AddChild(inner);
                        inner.AddText(inner.Name, "Joe has truimphed over the heroes and won the game!", new Vector2(5, 5));
                        inner.SetDrawBackground(false);

                        root.AddChild(box);
                        break;
                    }
            }

            return root;
        }

        public static GUIElement CreateMenuElement(Game game, Role role)
        {
            Contract.Requires(game != null);
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
            }

            root.AddChild(new PlayersElement(game, Player.Instance.IsOverlord ? null : Player.Instance.Hero, Player.Instance.HeroParty));
            root.AddChild(new ChatElement(game));

            return root;
        }

        /// <summary>
        /// Creates an EquipmentElement for visualization of the properties of the given equipment. Using this method
        /// to create the element makes sure that all EquipmentElements in the game has the same dimensions and are
        /// equipped with proper click events.
        /// </summary>
        /// <param name="game">The current Game object.</param>
        /// <param name="x">Will be the top-left coordinate of the EquipmentElement.</param>
        /// <param name="y">Will be the top-left coordinate of the EquipmentElement.</param>
        /// <param name="slotTitle">In case that the equipment is null it will display this title for the missing equipment.</param>
        /// <param name="equipment">The Equipment to visualize. Null here will indicate that the equipment slot is empty.</param>
        /// <param name="id">The game logic ID of this equipment, will be used for the click event.</param>
        /// <returns>A GUIElement that visualizes the given Equipment and keeps up to date if something within it changes.</returns>
        public static EquipmentElement CreateEquipmentElement(Game game, int x, int y, string slotTitle, Equipment equipment, int id)
        {
            Contract.Requires(game != null);
            Contract.Ensures(Contract.Result<EquipmentElement>().Id == id);
            Contract.Ensures(Contract.Result<EquipmentElement>().Equipment == equipment);

            return new EquipmentElement(game, x, y, RelW(game.GraphicsDevice.Viewport, 12), RelH(game.GraphicsDevice.Viewport, 16), slotTitle, equipment, id);
        }

        /// <summary>
        /// Draws a visualization of a SurgeAbility on a target GUIElement. By using this method
        /// to draw the SurgeAbility, you're sure it's drawn the same way every time.
        /// </summary>
        /// <param name="target">The GUIElement to draw the SurgeAbility on.</param>
        /// <param name="ability">The SurgeAbility to display.</param>
        /// <param name="xPosition">The top-left x-coordinate to start drawing from.</param>
        /// <param name="yPosition">The top-left y-coordinate to start drawing from.</param>
        /// <param name="small">True if the surge ability should be drawn as compact as possible, else false.</param>
        public static void DrawSurgeAbility(GUIElement target, SurgeAbility ability, int xPosition, int yPosition, bool small)
        {
            Contract.Requires(target != null);
            Contract.Requires(ability != null);
            Contract.Requires(target.HasPoint(target.Bound.X + xPosition, target.Bound.Y + yPosition));

            // icons
            int cost = ability.Cost;
            int costX = target.Bound.X + 5;
            while (cost > 0)
            {
                Image img = new Image(target.Game.Content.Load<Texture2D>("Images/Other/surge"));
                target.AddDrawable(target.Name, img, new Vector2(costX, target.Bound.Y + yPosition));
                cost--;
                costX += img.Texture.Width + (small ? -5 : +2);
            }

            // text
            costX += 10;
            string s = ability.Ability.ToString();
            if (small) s = s.Replace("Damage", "Dmg");
            target.AddText(target.Name, ":" + s, new Vector2(costX - target.Bound.X, yPosition));
        }

        /// <summary>
        /// Draws a given dice-type to the target GUIElement. By using this method
        /// to draw the EDice, you're sure it's drawn the same way every time.
        /// </summary>
        /// <param name="target">The GUIElement to display the dice in.</param>
        /// <param name="dice">The dice to display.</param>
        /// <param name="x">The top-left x-coordinate to start drawing from.</param>
        /// <param name="y">The top-left y-coordinate to start drawing from.</param>
        /// <param name="size">The width and height in pixels.</param>
        public static void DrawDice(GUIElement target, EDice dice, int x, int y, int size)
        {
            Contract.Requires(target != null);
            Contract.Requires(target.HasPoint(x, y));
            Contract.Requires(size > 0);
            Contract.Requires(x + size < target.Bound.X + target.Bound.Width);

            if (dicetinary == null) LoadDiceTextures(target.Game);

            target.AddDrawable(target.Name, new Image(dicetinary[dice]), new Rectangle(x, y, size, size));
        }

        private static void LoadDiceTextures(Game game)
        {
            dicetinary = new Dictionary<EDice, Texture2D>();

            dicetinary.Add(EDice.B, game.Content.Load<Texture2D>("Images/Other/dice-black-icon"));
            dicetinary.Add(EDice.G, game.Content.Load<Texture2D>("Images/Other/dice-green-icon"));
            dicetinary.Add(EDice.R, game.Content.Load<Texture2D>("Images/Other/dice-red-icon"));
            dicetinary.Add(EDice.U, game.Content.Load<Texture2D>("Images/Other/dice-blue-icon"));
            dicetinary.Add(EDice.W, game.Content.Load<Texture2D>("Images/Other/dice-white-icon"));
            dicetinary.Add(EDice.Y, game.Content.Load<Texture2D>("Images/Other/dice-yellow-icon"));
        }
    }
}
