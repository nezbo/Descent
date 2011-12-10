using System.Collections.Generic;

using Descent.Model.Board;

namespace Descent.State
{
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Descent.GUI;
    using Descent.Messaging.Events;
    using Descent.Model;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// The handler of all states. Knows about the current state and what to do next.
    /// </summary>
    /// <author>Martin Marcher & Emil Juul Jacobsen</author>
    public class StateManager
    {
        private readonly StateMachine stateMachine;
        private readonly GUI gui;
        private EventManager eventManager = Player.Instance.EventManager;
        private GameState gameState = new GameState();

        // fields for different game logic variables
        private Hero currentHero;
        private Monster currentMonster;
        private readonly List<int> playersRemaining = new List<int>();

        private List<Monster> monstersRemaining = new List<Monster>();

        private int inventoryFieldMarked = -1;

        public StateManager(GUI gui)
        {
            this.gui = gui;

            // subscribe for events
            eventManager.PlayerJoinedEvent += new PlayerJoinedHandler(PlayerJoined);
            eventManager.PlayersInGameEvent += new PlayersInGameHandler(PlayersInGame);
            eventManager.ReadyEvent += new ReadyHandler(BeginGame);
            eventManager.BeginGameEvent += new BeginGameHandler(BeginGame);
            eventManager.OverlordIsEvent += new OverlordIsHandler(OverLordIs);
            eventManager.GiveOverlordCardsEvent += new GiveOverlordCardsHandler(GiveOverlordCards);
            eventManager.AssignHeroEvent += new AssignHeroHandler(AssignHero);
            eventManager.RequestBuyEquipmentEvent += new RequestBuyEquipmentHandler(RequestBuyEquipment);
            eventManager.GiveEquipmentEvent += new GiveEquipmentHandler(GiveEquipment);
            eventManager.FinishedBuyEvent += new FinishedBuyHandler(FinishedBuy);
            eventManager.FinishedReequipEvent += new FinishedReequipHandler(FinishedReequip);
            eventManager.SwitchItemsEvent += new SwitchItemsHandler(SwitchItems);
            eventManager.RequestPlacementEvent += new RequestPlacementHandler(RequestPlacement);
            eventManager.PlaceHeroEvent += new PlaceHeroHandler(PlaceHero);
            eventManager.NewRoundEvent += new NewRoundHandler(NewRound);
            eventManager.RequestTurnEvent += new RequestTurnHandler(RequestTurn);
            eventManager.TurnChangedEvent += new TurnChangedHandler(TurnChanged);
            eventManager.ChooseActionEvent += new ChooseActionHandler(ChooseAction);
            eventManager.MoveToEvent += new MoveToHandler(MoveTo);
            eventManager.OpenDoorEvent += new OpenDoorHandler(OpenDoor);
            eventManager.FinishedTurnEvent += new FinishedTurnHandler(FinishedTurn);
            eventManager.StartMonsterTurnEvent += new StartMonsterTurnHandler(StartMonsterTurn);
            eventManager.UseOverlordCardEvent += new UseOvelordCardHandler(OverLordPlayCard);


            // Internal events
            eventManager.SquareMarkedEvent += new SquareMarkedHandler(SquareMarked);
            eventManager.InventoryFieldMarkedEvent += new InventoryFieldMarkedHandler(InventoryFieldMarked);

            // initiate start
            stateMachine = new StateMachine(new State[] { State.InLobby, State.Initiation, State.DrawOverlordCards, //TODO DrawSkillCards
                State.BuyEquipment, State.Equip, State.WaitForChooseSquare, State.NewRound, State.NewRound });
            stateMachine.StateChanged += StateChanged;

            StateChanged();
        }


        // stuff?

        public State CurrentState
        {
            get { return stateMachine.CurrentState; }
        }

        public State[] PreviousStates(int count)
        {
            Contract.Requires(count > 0);
            Contract.Ensures(Contract.Result<State[]>().Length <= count);
            return stateMachine.PreviousStates(count);
        }

        // Helper methods for the game

        public bool IsAHeroTurn()
        {
            return Player.Instance.HeroParty.Heroes.Keys.Contains(gameState.CurrentPlayer);
        }

        private Role DetermineRole()
        {
            if (Player.Instance.IsOverlord) return Role.Overlord;

            if (IsAHeroTurn())
            {
                return Player.Instance.Id == gameState.CurrentPlayer ? Role.ActiveHero : Role.InactiveHero;
            }
            return Role.InactiveHero; // its not the hero's turns so they are all inactive
        }

        /// <summary>
        /// Should be called every time the state changes so the GUI can be updated to
        /// display stuff for the new state.
        /// </summary>
        /// <author>
        /// Emil Juul Jacobsen
        /// </author>
        private void StateChanged()
        {
            State newState = stateMachine.CurrentState;

            Role role = DetermineRole();
            GUIElement root = GUIElementFactory.CreateStateElement(gui.Game, stateMachine.CurrentState, role, gameState);

            switch (newState) // Fill in events and drawables
            {
                case State.InLobby:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            root.AddText("player" + i, Player.Instance.GetPlayerNick(i) ?? "", new Vector2(5, 50));
                        }
                        if (Player.Instance.IsServer)
                        {
                            root.AddText("players", "IP: " + Player.Instance.Connection.Ip, new Vector2(50, 50));
                            root.SetClickAction("start", (n, g) =>
                                                             {
#if DEBUG
                                                                 if (n.NumberOfPlayers >= 1) //TODO 3
#else 
                                                                     if (n.NumberOfPlayers >= 3) //TODO 3
#endif
                                                                 {
                                                                     n.EventManager.QueueEvent(
                                                                         EventType.BeginGame, new GameEventArgs());
                                                                     n.EventManager.QueueEvent(EventType.OverlordIs, new OverlordIsEventArgs(Player.Instance.Id));
                                                                 }
                                                                 System.Diagnostics.Debug.WriteLine("Start clicked!");
                                                             });
                        }

                        break;
                    }
                case State.BuyEquipment:
                    {
                        if (role != Role.Overlord && playersRemaining.Contains(Player.Instance.Id))
                        {

                            root.SetClickAction("done", (n, g) =>
                                                            {
                                                                n.EventManager.QueueEvent(EventType.FinishedBuy,
                                                                                          new GameEventArgs());
                                                            });
                            root.SetClickAction("item", (n, g) =>
                                                            {
                                                                if (g is EquipmentElement)
                                                                {
                                                                    EquipmentElement eq = (EquipmentElement)g;
                                                                    n.EventManager.QueueEvent(
                                                                    EventType.RequestBuyEquipment,
                                                                    new RequestBuyEquipmentEventArgs(eq.Equipment.Id));
                                                                }
                                                            });

                        }
                        else
                        {
                            root.Disable(root.Name);
                        }
                        break;
                    }
                case State.Equip:
                    {
                        if (role != Role.Overlord && playersRemaining.Contains(Player.Instance.Id))
                        {

                            root.SetClickAction("item", (n, g) =>
                                                            {
                                                                if (g is EquipmentElement)
                                                                {
                                                                    int id = ((EquipmentElement)g).Id;
                                                                    n.EventManager.QueueEvent(EventType.InventoryFieldMarked, new InventoryFieldEventArgs(id));
                                                                }
                                                            });
                            root.SetClickAction("done", (n, g) =>
                                                            {
                                                                n.EventManager.QueueEvent(EventType.FinishedReequip, new GameEventArgs());
                                                            });
                        }
                        else
                        {
                            root.Disable("item");
                            root.Disable("done");
                        }
                        break;
                    }
                case State.WaitForHeroTurn:
                    {
                        if (role != Role.Overlord)
                        {
                            if (playersRemaining.Contains(Player.Instance.Id))
                            {
                                root.SetClickAction("take turn", (n, g) =>
                                                                     {
                                                                         n.EventManager.QueueEvent(
                                                                             EventType.RequestTurn, new GameEventArgs());
                                                                     });
                            }
                            else
                            {
                                root.Disable("take turn");
                            }
                        }
                        break;
                    }
                case State.WaitForChooseAction:
                    {
                        if (role == Role.ActiveHero)
                        {
                            root.SetClickAction("advance", (n, g) =>
                                                               {
                                                                   n.EventManager.QueueEvent(EventType.ChooseAction, new ChooseActionEventArgs(ActionType.Advance));
                                                               });
                            root.SetClickAction("run", (n, g) =>
                            {
                                n.EventManager.QueueEvent(EventType.ChooseAction, new ChooseActionEventArgs(ActionType.Run));
                            });
                            root.SetClickAction("battle", (n, g) =>
                            {
                                n.EventManager.QueueEvent(EventType.ChooseAction, new ChooseActionEventArgs(ActionType.Battle));
                            });
                        }
                        break;
                    }
                case State.WaitForPerformAction:
                    {
                        if (role == Role.ActiveHero)
                        {
                            root.SetClickAction("end", (n, g) =>
                            {
                                n.EventManager.QueueEvent(EventType.FinishedTurn, new GameEventArgs());
                            });
                        }
                        break;
                    }
                case State.WaitForOverlordChooseAction:
                    {
                        if (role == Role.Overlord)
                        {
                            root.SetClickAction("end", (n, g) =>
                              {
                                  n.EventManager.QueueEvent(EventType.FinishedTurn, new GameEventArgs());
                              });
                        }

                        break;
                    }
            }

            gui.ChangeStateGUI(root); // change the GUI's state element.
        }

        private void AllPlayersRemain()
        {
            playersRemaining.AddRange(Player.Instance.HeroParty.PlayerIds);
        }

        private void ResetCurrentPlayer()
        {
            gameState.CurrentPlayer = 0;
        }

        #region Local event listeners
        private void SquareMarked(object sender, CoordinatesEventArgs eventArgs)
        {
            switch (CurrentState)
            {
                case State.WaitForChooseSquare:
                    if (playersRemaining.Contains(Player.Instance.Id))
                    {
                        eventManager.QueueEvent(EventType.RequestPlacement, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                    }

                    break;
                case State.WaitForPerformAction:
                    Figure figure;
                    if (Player.Instance.IsOverlord)
                    {
                        figure = currentMonster;
                    } 
                    else 
                    { 
                        figure = Player.Instance.Hero;
                    }
                    Point standingPoint = FullModel.Board.FiguresOnBoard[figure];

                    if (FullModel.Board.Distance(standingPoint, new Point(eventArgs.X, eventArgs.Y)) == 1)
                    {
                        // Move to adjecent
                        if (FullModel.Board.IsStandable(eventArgs.X, eventArgs.Y) && figure.MovementLeft >= 1)
                        {
                            eventManager.QueueEvent(EventType.MoveTo, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                        // Open door
                        else if (FullModel.Board.CanOpenDoor(new Point(eventArgs.X, eventArgs.Y)) &&
                            FullModel.Board.CanOpenDoor(standingPoint) && figure.MovementLeft >= 2)
                        {
                            eventManager.QueueEvent(EventType.OpenDoor, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                    }

                    break;
                case State.WaitForOverlordChooseAction:

                    // If a square with a monster is pressed in an overlord turn and we are the overlord, a monster turn should begin.
                    Square s = FullModel.Board[eventArgs.X, eventArgs.Y];
                    if (Player.Instance.IsOverlord && s.Figure != null && s.Figure is Monster)
                    {
                        eventManager.QueueEvent(EventType.StartMonsterTurn, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                    }
                    break;
            }
        }

        private void InventoryFieldMarked(object sender, InventoryFieldEventArgs eventArgs)
        {
            switch (CurrentState)
            {
                case State.Equip:
                    if (inventoryFieldMarked == -1)
                    {
                        inventoryFieldMarked = eventArgs.InventoryField;
                    }
                    else
                    {
                        Hero hero = Player.Instance.Hero;
                        Inventory inventory = hero.Inventory;
                        int realId1 = inventoryFieldMarked,
                            realId2 = eventArgs.InventoryField,
                            parsedId1 = (realId1 > 99) ? realId1 - 100 : realId1,
                            parsedId2 = (realId2 > 99) ? realId2 - 100 : realId2;

                        Equipment equipment1 = null;
                        Equipment equipment2 = null;
                        if (realId1 > 99)
                        {
                            if (gameState.UnequippedEquipment(eventArgs.SenderId).Length > 0)
                            {
                                equipment1 = gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId1];
                            }

                        }
                        else
                        {
                            equipment1 = hero.Inventory[parsedId1];
                        }

                        if (realId2 > 99)
                        {
                            if (gameState.UnequippedEquipment(eventArgs.SenderId).Length > 0)
                            {
                                equipment2 = gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId2];
                            }

                        }
                        else
                        {
                            equipment2 = hero.Inventory[parsedId2];
                        }

                        if ((realId2 > 99 || equipment1 == null || inventory.CanEquipAtIndex(parsedId2, equipment1) &&
                        (realId1 > 99 || equipment2 == null || inventory.CanEquipAtIndex(parsedId1, equipment2))))
                        {
                            eventManager.QueueEvent(EventType.SwitchItems, new SwitchItemsEventArgs(realId1, realId2));
                        }

                        inventoryFieldMarked = -1;
                    }
                    break;
            }
        }

        #endregion

        // event handlers

        private void PlayerJoined(object sender, PlayerJoinedEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InLobby);
            Contract.Ensures(CurrentState == State.InLobby);

            Player.Instance.SetPlayerNick(eventArgs.PlayerId, eventArgs.PlayerNick);
            if (Player.Instance.IsServer) eventManager.FirePlayersInGameEvent();
            StateChanged();
        }

        private void PlayersInGame(object sender, PlayersInGameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InLobby);
            Contract.Ensures(CurrentState == State.InLobby);

            foreach (PlayerInGame p in eventArgs.Players)
            {
                Player.Instance.SetPlayerNick(p.Id, p.Nickname);
                Player.Instance.HeroParty.Heroes[p.Id] = null;
            }
            StateChanged();
        }

        private void BeginGame(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InLobby);
            Contract.Ensures(CurrentState == State.Initiation);
            stateMachine.ChangeToNextState();
        }

        private void OverLordIs(object sender, OverlordIsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Initiation);
            Contract.Ensures(CurrentState == State.DrawOverlordCards);

            Player.Instance.OverlordId = eventArgs.PlayerId;

            Player.Instance.HeroParty.Heroes.Remove(Player.Instance.OverlordId);

            if (Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.GiveOverlordCards, new GiveOverlordCardsEventArgs(gameState.GetOverlordCards(3).Select(card => card.Id).ToArray()));
            }

            gui.CreateBoardGUI(FullModel.Board, DetermineRole());

            stateMachine.ChangeToNextState();
        }

        private void GiveOverlordCards(object sender, GiveOverlordCardsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.DrawOverlordCards || CurrentState == State.OverlordTurn);
            Contract.Ensures(CurrentState == (Contract.OldValue(CurrentState) == State.DrawOverlordCards ? State.DrawHeroCard : State.WaitForOverlordChooseAction));
            // Contract.Ensures(CurrentState == (Contract.OldValue(CurrentState) == State.DrawOverlordCards ? State.DrawHeroCard : State.ActivateMonstersInitiation));

            foreach (int overlordCardId in eventArgs.OverlordCardIds)
            {
                Player.Instance.Overlord.Hand.Add(FullModel.GetOverlordCard(overlordCardId));
            }

            if (CurrentState == State.DrawOverlordCards)
            {
                DrawHeroCards();
            }

            stateMachine.ChangeToNextState();
        }

        //Helper method
        private void DrawHeroCards()
        {
            Contract.Requires(CurrentState == State.DrawOverlordCards);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));
            foreach (int playerId in Player.Instance.HeroParty.Heroes.Keys)
            {
                stateMachine.PlaceStates(State.DrawHeroCard);
                int heroId = gameState.getHero().Id;

                if (Player.Instance.IsServer)
                {
                    eventManager.QueueEvent(EventType.AssignHero, new AssignHeroEventArgs(playerId, heroId));
                }

                gameState.RemoveHero(heroId);
            }
        }

        private void AssignHero(object sender, AssignHeroEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.DrawHeroCard);
            Contract.Ensures(CurrentState == State.DrawHeroCard || CurrentState == State.BuyEquipment);

            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId] = FullModel.GetHero(eventArgs.HeroId);
            gameState.RemoveHero(eventArgs.HeroId);

            if (stateMachine.NextState == State.BuyEquipment)
            {
                AllPlayersRemain();
                gui.CreateMenuGUI(DetermineRole());

                foreach (Hero hero in Player.Instance.HeroParty.Heroes.Values)
                {
                    hero.Initialize();
                }
            }

            stateMachine.ChangeToNextState();

            /* TODO Simon -> Martin: har lavet ovenstående i stedet. Giver det mening?
            if (CurrentState == State.BuyEquipment) // TODO Should be DrawSkillCard
            {
                
            }
             * */
        }

        private void RequestBuyEquipment(object sender, RequestBuyEquipmentEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.BuyEquipment);
            Contract.Ensures(CurrentState == State.BuyEquipment);

            if (!Player.Instance.IsServer)
            {
                return;
            }

            if (gameState.CanBuyEquipment(eventArgs.EquipmentId) && Player.Instance.HeroParty.Heroes[eventArgs.SenderId].Coins >= FullModel.GetEquipment(eventArgs.EquipmentId).BuyPrice)
            {
                eventManager.QueueEvent(EventType.GiveEquipment, new GiveEquipmentEventArgs(eventArgs.SenderId, eventArgs.EquipmentId, false));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Buy denied!");
            }
            StateChanged();
        }

        private void GiveEquipment(object sender, GiveEquipmentEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.BuyEquipment);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Equipment equipment = FullModel.GetEquipment(eventArgs.EquipmentId);
            gameState.AddToUnequippedEquipment(eventArgs.PlayerId, equipment);
            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId].Coins -= equipment.BuyPrice;
            System.Diagnostics.Debug.WriteLine(eventArgs.PlayerId + ": " + Player.Instance.HeroParty.Heroes[eventArgs.PlayerId].Coins);
            StateChanged();
        }

        private void FinishedBuy(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.BuyEquipment);
            Contract.Ensures(CurrentState == ((playersRemaining.Count == Player.Instance.HeroParty.NumberOfHeroes) ? State.Equip : State.BuyEquipment));

            playersRemaining.Remove(eventArgs.SenderId);

            if (playersRemaining.Count == 0)
            {
                AllPlayersRemain();
                stateMachine.ChangeToNextState();
            }
            StateChanged();
        }

        private void SwitchItems(object sender, SwitchItemsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Hero hero = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];
            int realId1 = eventArgs.Field1,
                realId2 = eventArgs.Field2,
                parsedId1 = (realId1 > 99) ? realId1 - 100 : realId1,
                parsedId2 = (realId2 > 99) ? realId2 - 100 : realId2;
            Equipment equipment1 = (realId1 > 99) ? gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId1] : hero.Inventory[parsedId1];
            Equipment equipment2 = (realId2 > 99) ? gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId2] : hero.Inventory[parsedId2];

            if (realId1 > 99)
            {
                gameState.RemoveFromUnequippedEquipment(eventArgs.SenderId, equipment1);
                gameState.AddToUnequippedEquipment(eventArgs.SenderId, equipment2);
            }
            else
            {
                hero.Inventory[parsedId1] = equipment2;
            }
            if (realId2 > 99)
            {
                gameState.RemoveFromUnequippedEquipment(eventArgs.SenderId, equipment2);
                gameState.AddToUnequippedEquipment(eventArgs.SenderId, equipment1);
            }
            else
            {
                hero.Inventory[parsedId2] = equipment1;
            }

            StateChanged();
        }

        private void UnequipItem(object sender, EquipEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].Inventory[eventArgs.InventoryField] = null;
            StateChanged();
        }

        private void EquipItem(object sender, EquipEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].Inventory[eventArgs.InventoryField] = FullModel.GetEquipment(eventArgs.EquipmentId);
            StateChanged();
        }

        private void FinishedReequip(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip);
            Contract.Ensures(CurrentState == (gameState.CurrentPlayer != 0 ? State.WaitForChooseAction : (playersRemaining.Count == Player.Instance.HeroParty.NumberOfHeroes) ? State.WaitForChooseSquare : State.Equip));

            gameState.RemoveAllUnequippedEquipment(eventArgs.SenderId);
            playersRemaining.Remove(eventArgs.SenderId);

            if (gameState.CurrentPlayer != 0)
            {
                stateMachine.ChangeToNextState();
            }
            else if (playersRemaining.Count == 0)
            {
                AllPlayersRemain();
                stateMachine.ChangeToNextState();
            }
            StateChanged();
        }

        private void RequestPlacement(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForChooseSquare);
            Contract.Ensures(CurrentState == State.WaitForChooseSquare);

            if (Player.Instance.IsServer && FullModel.Board.IsValidStartSquare(new Point(eventArgs.X, eventArgs.Y)))
            {
                eventManager.QueueEvent(EventType.PlaceHero, new PlaceHeroEventArgs(eventArgs.SenderId, eventArgs.X, eventArgs.Y));
            }
        }

        private void PlaceHero(object sender, PlaceHeroEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForChooseSquare);
            Contract.Ensures(CurrentState == ((playersRemaining.Count == 0) ? State.NewRound : State.WaitForChooseSquare));

            FullModel.Board.PlaceFigure(Player.Instance.HeroParty.Heroes[eventArgs.PlayerId], new Point(eventArgs.X, eventArgs.Y));

            playersRemaining.Remove(eventArgs.PlayerId);

            if (playersRemaining.Count == 0)
            {
                stateMachine.ChangeToNextState();
                if (Player.Instance.IsServer)
                {
                    eventManager.QueueEvent(EventType.NewRound, new GameEventArgs());
                }
            }
        }

        private void NewRound(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.NewRound);
            Contract.Ensures(CurrentState == State.WaitForHeroTurn);

            AllPlayersRemain(); // For WaitForHeroTurn
            ResetCurrentPlayer();

            stateMachine.PlaceStates(State.WaitForHeroTurn);
            stateMachine.ChangeToNextState();
        }

        #region Movement actions

        // Helper method
        private void ActionDone()
        {
            Contract.Ensures(CurrentState == State.WaitForPerformAction);
            stateMachine.PlaceStates(State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
        }

        private void MoveTo(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            //TODO Contract.Requires(Player.Instance.HeroParty.Heroes[eventArgs.SenderId].MovementLeft >= 1);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            Figure figure;
            if (Player.Instance.HeroParty.Heroes.ContainsKey(eventArgs.SenderId))
            {
                figure = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];
            }
            else
            {
                figure = currentMonster;
            }

            FullModel.Board.MoveFigure(figure, new Point(eventArgs.X, eventArgs.Y));
            figure.RemoveMovement(1);

            stateMachine.PlaceStates(State.MoveAdjecent);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void OpenDoor(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(Player.Instance.HeroParty.Heroes[eventArgs.SenderId].MovementLeft >= 2);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            Hero hero = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];

            FullModel.Board.OpenDoor(new Point(eventArgs.X, eventArgs.Y));
            hero.RemoveMovement(2);

            stateMachine.PlaceStates(State.OpenDoor);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        #endregion

        #region Hero methods

        private void RequestTurn(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForHeroTurn);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            if (Player.Instance.IsServer && gameState.CurrentPlayer == 0 && playersRemaining.Contains(eventArgs.SenderId))
            {
                eventManager.QueueEvent(EventType.TurnChanged, new PlayerEventArgs(eventArgs.SenderId));
            }
        }

        private void TurnChanged(object sender, PlayerEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForHeroTurn);
            Contract.Requires(gameState.CurrentPlayer == 0);
            Contract.Requires(playersRemaining.Contains(eventArgs.PlayerId));
            Contract.Ensures(CurrentState == State.Equip);

            gameState.CurrentPlayer = eventArgs.PlayerId;

            //TODO Refresh Hero's cards

            stateMachine.PlaceStates(State.HeroTurn, State.Equip, State.WaitForChooseAction, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void ChooseAction(object sender, ChooseActionEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForChooseAction);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            Hero hero = Player.Instance.HeroParty.Heroes[gameState.CurrentPlayer];
            int movement = 0, attacks = 0;

            switch (eventArgs.ActionType)
            {
                case ActionType.Run:
                    movement = hero.Speed * 2;
                    attacks = 0;
                    break;
                case ActionType.Battle:
                    movement = 0;
                    attacks = 2;
                    break;
                case ActionType.Advance:
                    movement = hero.Speed;
                    attacks = 1;
                    break;
            }

            hero.SetMovement(movement);
            hero.SetAttacks(attacks);

            stateMachine.ChangeToNextState();
        }

        private void BuyMovement()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            /* TODO Contract.Requires(currentHero.Fatique > 0);*/
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove one fatique from hero
            // Add one movement to hero

            stateMachine.PlaceStates(State.BuyMovement, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void FinishedTurn(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(gameState.CurrentPlayer == eventArgs.SenderId);
            Contract.Ensures(CurrentState == (playersRemaining.Count == 0 ? State.OverlordTurn : State.WaitForHeroTurn));

            playersRemaining.Remove(eventArgs.SenderId);
            gameState.CurrentPlayer = 0;

            if (playersRemaining.Count == 0)
            {
                stateMachine.PlaceStates(State.OverlordTurn);
                stateMachine.ChangeToNextState();
                State s = stateMachine.CurrentState;
                OverlordTurnInitiation();
            }
            else
            {
                stateMachine.PlaceStates(State.WaitForHeroTurn);
                stateMachine.ChangeToNextState();
            }
        }

        #endregion

        #region Overlord methods
        private void StartMonsterTurn(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForOverlordChooseAction);
            // TODO Contract.Requires(monsterBag.contains(monster));
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Record monsterId
            currentMonster = (Monster) FullModel.Board.FiguresOnBoard.Single(pair => pair.Value.X == eventArgs.X && pair.Value.Y == eventArgs.Y).Key;

            stateMachine.PlaceStates(State.MonsterTurn);
            stateMachine.ChangeToNextState();
            MonsterTurnInitiation();
        }

        private void MonsterTurnInitiation()
        {
            Contract.Requires(CurrentState == State.MonsterTurn);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            currentMonster.SetAttacks(1);
            currentMonster.SetMovement(currentMonster.Speed);

            stateMachine.PlaceStates(State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
        }

        // Helper method
        private void OverlordTurnInitiation()
        {
            Contract.Requires(CurrentState == State.OverlordTurn);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));
            Contract.Ensures(stateMachine.NextState == State.WaitForOverlordChooseAction);

            Player.Instance.Overlord.ThreatTokens += Player.Instance.HeroParty.NumberOfHeroes;
            if (Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.GiveOverlordCards, new GiveOverlordCardsEventArgs(gameState.GetOverlordCards(2).Select(card => card.Id).ToArray()));
            }

            if (Player.Instance.IsOverlord)
            {
                // Mark monsters that the overlord can select in the WaitForOverlordChooseAction

                monstersRemaining = FullModel.Board.FiguresOnBoard.Where(pair => pair.Key is Monster).Select(pair => (Monster) pair.Key).ToList();
                foreach (Point point in FullModel.Board.FiguresOnBoard.Where(pair => pair.Key is Monster).Select(pair => pair.Value))
                {
                    gui.MarkSquare(point.X, point.Y, true);
                }  
            }
           
            stateMachine.PlaceStates(State.WaitForOverlordChooseAction);
            StateChanged();
        }

        private void OverlordDiscardCard(/* TODO OverlordCard card*/)
        {
            Contract.Requires(CurrentState == State.WaitForDiscardCard);
            Contract.Ensures(CurrentState == State.WaitForDiscardCard);

            // Remove card from hand

            stateMachine.PlaceStates(State.WaitForDiscardCard);
            stateMachine.ChangeToNextState();
        }

        private void OverlordDiscardCardDone()
        {
            Contract.Requires(CurrentState == State.WaitForDiscardCard);
            Contract.Ensures(CurrentState == State.WaitForPlayCard);

            stateMachine.ChangeToNextState();
        }

        private void OverLordPlayCard(object sender, OverlordCardEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPlayCard);
            Contract.Ensures(CurrentState == State.WaitForPlayCard);

            // Check rules for playing cards
            // Play card and invoke changes

            /* TODO if (card.Type == OverlordCardType.Spawn) */
            /*
            {
                //Add monsters to spawn bag
                stateMachine.PlaceStates(State.SpawnMonsters);
            }
             * */
            stateMachine.PlaceStates(State.ActivateMonsters);
        }

        private void OverlordPlayCardDone()
        {
            Contract.Requires(CurrentState == State.WaitForPlayCard);
            Contract.Ensures(CurrentState == State.WaitForChooseMonster || CurrentState == State.WaitForPlaceMonster);
            
            stateMachine.ChangeToNextState();
            if (CurrentState == State.SpawnMonsters)
            {
                SpawnMonstersInitiation();
            }
            else if (CurrentState == State.ActivateMonsters)
            {
                //ActivateMonstersInitiation();
            }
        }

        private void SpawnMonstersInitiation()
        {
            Contract.Requires(CurrentState == State.SpawnMonsters);
            Contract.Ensures(CurrentState == State.WaitForPlaceMonster);

            stateMachine.PlaceStates(State.WaitForPlaceMonster);
            stateMachine.ChangeToNextState();
        }

        private void SpawnMonster(Monster monster, Square square)
        {
            Contract.Requires(CurrentState == State.WaitForPlaceMonster);
            Contract.Requires(monster != null);
            Contract.Requires(square != null);
            /* TODO Contract.Requires(square.canSpawn);*/
            Contract.Ensures(CurrentState == State.WaitForPlaceMonster || CurrentState == State.WaitForChooseMonster);

            // Place monster on the square
            // Remove monster from spawn bag

            // TODO if (spawnBag.Empty)
            {
                SpawnMonstersDone();
            }
            // TODO else
            {
                stateMachine.PlaceStates(State.WaitForPlaceMonster);
                stateMachine.ChangeToNextState();
            }
        }

        private void SpawnMonstersDone()
        {
            Contract.Requires(CurrentState == State.WaitForPlaceMonster);

            stateMachine.PlaceStates(State.ActivateMonsters);
            stateMachine.ChangeToNextState();
        }


        // TODO NOT USED ATM
        private void ChooseMonster(Monster monster)
        {
            Contract.Requires(CurrentState == State.WaitForChooseMonster);
            // TODO Contract.Requires(monsterBag.contains(monster));
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Record monsterId

            stateMachine.PlaceStates(State.MonsterTurn);
            stateMachine.ChangeToNextState();
            MonsterTurnInitiation();
        }

        private void ActivateMonstersDone()
        {
            Contract.Requires(CurrentState == State.WaitForChooseMonster);

        }

        private void MonsterTurnDone()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);

            // Delete monster from monsterBag
            // Remove monsterId

            stateMachine.PlaceStates(State.WaitForChooseMonster);
            stateMachine.ChangeToNextState();

            // TODO if (monsterBag.Empty)
            {
                ActivateMonstersDone();
            }
        }
        #endregion

        private void RevealArea(int areaId)
        {
            Contract.Requires(CurrentState == State.RevealArea);
            Contract.Ensures(CurrentState != State.RevealArea);

            // Reveal area

            stateMachine.ChangeToNextState();
        }

        #region MovementMethods

        private void MoveToAdjecent(Square square)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            // TODO Contract.Requires(currentHero.MovementLeft >= 1);
            // TODO Contract.Requires(Board.isAdjecent(square, heroSquare));
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 1 movement
            // Move Hero to square

            stateMachine.PlaceStates(State.MoveAdjecent);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void DrinkPotion(Potion potion)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            // TODO Contract.Requires(currentHero.MovementLeft >= 1);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 1 movement
            // Apply potion effect
            // Remove potion from inventory

            stateMachine.PlaceStates(State.DrinkPotion);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void PickupToken()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            // TODO Contract.Requires(currentSquare.Token != null);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 0 movement
            // Pickup token and invoke effects
            // Remove token from board

            stateMachine.PlaceStates(State.PickupToken);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void CloseDoor()// TODO Door door)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            // TODO Contract.Requires(currentHero.MovementLeft >= 2);
            // TODO Contract.Requires(door.IsAdjecent);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 2 movement
            // Mark door closed

            stateMachine.PlaceStates(State.CloseDoor);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void DropItem(Equipment item)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            Contract.Requires(item != null);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 0 movement
            // Remove item from inventory
            // Place item on square

            stateMachine.PlaceStates(State.DropItem);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void OpenChest()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            // TODO Contract.Requires(currentSquare.hasChest);
            // TODO  Contract.Requires(currentHero.MovementLeft >= 2);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 2 movement
            // Open chest
            // Remove chest from board

            stateMachine.PlaceStates(State.OpenChest, State.ReceiveChestContents, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
            // TODO ReceiveChestContents(chest);
        }

        #region ChestMethods

        private void ReceiveChestContents()// TODO Chest chest)
        {
            Contract.Requires(CurrentState == State.ReceiveChestContents);
            // TODO Contract.Requires(chest != null);
            Contract.Ensures(CurrentState == State.WaitForAllPlayersEquip);

            // Give contents to all players
            // Add all player to reequipBag

            stateMachine.PlaceStates(State.WaitForAllPlayersEquip);
            stateMachine.ChangeToNextState();
        }

        private void ChestSwitchItems(Equipment item1, Equipment item2)
        {
            Contract.Requires(CurrentState == State.WaitForAllPlayersEquip);
            Contract.Requires(item1 != null);
            Contract.Requires(item2 != null);
            Contract.Ensures(CurrentState == State.WaitForAllPlayersEquip);

            // Switch the two items
        }

        private void ChestEquipDone(Hero hero)
        {
            Contract.Requires(CurrentState == State.WaitForAllPlayersEquip);
            Contract.Requires(hero != null);

            // Remove hero from reequipBag

            // TODO if (reequipBag.Empty)
            {
                stateMachine.ChangeToNextState();
            }
        }

        #endregion

        private void ReEquip()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            // TODO Contract.Requires(currentHero.MovementLeft >= 2);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 2 movement

            stateMachine.PlaceStates(State.Equip, State.WaitForItemSwitch, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void GiveItem(Hero receiver, Equipment item)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(IsAHeroTurn());
            // TODO Contract.Requires(currentHero.MovementLeft >= 1);
            Contract.Requires(receiver != null);
            Contract.Requires(item != null);
            // TODO Contract.Requires(receiver.IsAdjecent);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 1 movement
            // Remove item from currentHero's inventory
            // Add item to receiver's inventory

            stateMachine.PlaceStates(State.GiveItem);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        private void Jump(Square targetSquare)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            // TODO Contract.Requires(currentHero.MovementLeft >= 3);
            Contract.Requires(targetSquare != null);
            // TODO Contract.Requires(HasPit);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Remove 3 movement
            // Move hero to targetSquare

            stateMachine.PlaceStates(State.Jump);
            stateMachine.ChangeToNextState();
            ActionDone();
        }

        #endregion
    }
}
