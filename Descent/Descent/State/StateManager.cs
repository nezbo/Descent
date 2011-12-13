using Descent.GUI.SubElements;

namespace Descent.State
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Model.Board.Marker;
    using Model.Player.OverlordStuff;

    using GUI;
    using Messaging.Events;

    using Microsoft.Xna.Framework;
    using Model;
    using Model.Board;
    using Model.Event;
    using Model.Player;
    using Model.Player.Figure;
    using Model.Player.Figure.HeroStuff;

    /// <summary>
    /// The handler of all states. Knows about the current state and what to do next.
    /// </summary>
    /// <author>Martin Marcher</author>
    public class StateManager
    {
        private readonly StateMachine stateMachine;
        private readonly GUI gui;
        private EventManager eventManager = Player.Instance.EventManager;
        private GameState gameState = new GameState();

        // fields for different game logic variables
        private Monster currentMonster;
        private readonly List<int> playersRemainingTurn = new List<int>();
        private readonly List<int> playersRemainingEquip = new List<int>();
        private readonly List<Point> damageTargetsRemaining = new List<Point>();

        private List<Monster> monstersRemaining = new List<Monster>();

        private int inventoryFieldMarked = -1;

        public StateManager(GUI gui)
        {
            this.gui = gui;

            // subscribe for events
            eventManager.PlayerJoinedEvent += PlayerJoined;
            eventManager.PlayersInGameEvent += PlayersInGame;
            eventManager.ReadyEvent += BeginGame;
            eventManager.BeginGameEvent += BeginGame;
            eventManager.OverlordIsEvent += OverLordIs;
            eventManager.GiveOverlordCardsEvent += GiveOverlordCards;
            eventManager.AssignHeroEvent += AssignHero;
            eventManager.RequestBuyEquipmentEvent += RequestBuyEquipment;
            eventManager.GiveEquipmentEvent += GiveEquipment;
            eventManager.GiveCoinsEvent += GiveCoins;
            eventManager.FinishedBuyEvent += FinishedBuy;
            eventManager.FinishedReequipEvent += FinishedReequip;
            eventManager.SwitchItemsEvent += SwitchItems;
            eventManager.RequestPlacementEvent += RequestPlacement;
            eventManager.PlaceHeroEvent += PlaceHero;
            eventManager.NewRoundEvent += NewRound;
            eventManager.RequestTurnEvent += RequestTurn;
            eventManager.TurnChangedEvent += TurnChanged;
            eventManager.ChooseActionEvent += ChooseAction;
            eventManager.MoveToEvent += MoveTo;
            eventManager.OpenDoorEvent += OpenDoor;
            eventManager.FinishedTurnEvent += FinishedTurn;
            eventManager.StartMonsterTurnEvent += StartMonsterTurn;
            eventManager.UseOverlordCardEvent += OverLordPlayCard;
            eventManager.EndMonsterTurnEvent += EndMonsterTurn;
            eventManager.AttackSquareEvent += AttackSquare;
            eventManager.RolledDicesEvent += RolledDices;
            eventManager.BoughtDiceEvent += BoughtDice;
            eventManager.BoughtMovementEvent += BoughtMovement;
            eventManager.ChangedBlackDiceSideEvent += ChangedBlackDiceSide;
            eventManager.InflictWoundsEvent += InflictWounds;
            eventManager.DamageTakenEvent += DamageTaken;
            eventManager.WasKilledEvent += WasKilled;
            eventManager.MissedAttackEvent += MissedAttack;
            eventManager.FinishedAttackEvent += FinishedAttack;
            eventManager.PickupMarkerEvent += PickupMarker;
            eventManager.OpenChestEvent += OpenChest;
            eventManager.RemoveOverlordCardEvent += RemoveOverlordCard;
            eventManager.AddHealthEvent += AddHealth;
            eventManager.RemoveHealthEvent += RemoveHealth;
            eventManager.AddFatigueEvent += AddFatigue;
            eventManager.RemoveFatigueEvent += RemoveFatigue;
            eventManager.AddMovementEvent += AddMovement;
            eventManager.RemoveMovementEvent += RemoveMovement;

            // Internal events
            eventManager.SquareMarkedEvent += SquareMarked;
            eventManager.InventoryFieldMarkedEvent += InventoryFieldMarked;
            eventManager.FatigueClickedEvent += FatiqueClicked;
            eventManager.DiceClickedEvent += DiceClicked;
            eventManager.DoAttackEvent += DoAttack;

            // initiate start
            stateMachine = new StateMachine(new State[]
                                                {
                                                    State.InLobby, State.Initiation, State.DrawOverlordCards,
                                                    State.AllBuyEquipment, State.AllEquip, State.WaitForChooseSquare,
                                                    State.NewRound, State.NewRound
                                                });
            stateMachine.StateChanged += StateChanged;

            StateChanged();
        }

        [Pure]
        public GameState GameState
        {
            get { return gameState; }
        }

        [Pure]
        public State CurrentState
        {
            get { return stateMachine.CurrentState; }
        }

        // Helper methods for the game
        [Pure]
        public bool HasTurn()
        {
            return gameState.CurrentPlayer == Player.Instance.Id;
        }

        [Pure]
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
                            root.SetClickAction("start", (n, g) =>
                                                             {
#if DEBUG
                                                                 if (n.NumberOfPlayers > 1)
#else 
                                                                     if (n.NumberOfPlayers >= 3)
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
                case State.AllBuyEquipment:
                case State.BuyEquipment:
                    {
                        if (role != Role.Overlord && ((CurrentState == State.AllBuyEquipment && playersRemainingTurn.Contains(Player.Instance.Id)) || (CurrentState == State.BuyEquipment && HasTurn())))
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
                case State.AllEquip:
                case State.Equip:
                    {
                        if (role != Role.Overlord && ((CurrentState == State.AllEquip && playersRemainingEquip.Contains(Player.Instance.Id)) || (CurrentState == State.Equip && HasTurn())))
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
                            root.Disable("root");
                        }
                        break;
                    }
                case State.WaitForHeroTurn:
                    {
                        if (role != Role.Overlord)
                        {
                            if (playersRemainingTurn.Contains(Player.Instance.Id))
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
                        else if (role == Role.Overlord && HasTurn())
                        {
                            root.SetClickAction("end", (n, g) =>
                                                           {
                                                               n.EventManager.QueueEvent(EventType.EndMonsterTurn, new GameEventArgs());
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
                case State.WaitForRollDice:
                    {
                        if (gameState.CurrentPlayer == Player.Instance.Id)
                        {
                            root.SetClickAction("roll", (n, g) =>
                                                            {
                                                                gameState.CurrentAttack.RollDice();
                                                                n.EventManager.QueueEvent(EventType.RolledDices, new RolledDicesEventArgs(gameState.CurrentAttack.DiceForAttack.Select(d => d.SideIndex).ToArray()));
                                                            });
                        }
                        break;
                    }
                case State.WaitForDiceChoice:
                    {
                        if (gameState.CurrentPlayer == Player.Instance.Id)
                        {
                            root.SetClickAction("finish", (n, g) =>
                                                              {
                                                                  n.EventManager.QueueEvent(EventType.DoAttack, new GameEventArgs());
                                                              });
                        }
                        break;
                    }
            }

            gui.ChangeStateGUI(root); // change the GUI's state element.
        }

        private void AllPlayersRemainTurn()
        {
            playersRemainingTurn.AddRange(Player.Instance.HeroParty.PlayerIds);
        }

        private void AllPlayersRemainEquip()
        {
            playersRemainingEquip.AddRange(Player.Instance.HeroParty.PlayerIds);
        }

        private void ResetCurrentPlayer()
        {
            gameState.CurrentPlayer = 0;
        }

        #region Local event listeners
        private void SquareMarked(object sender, CoordinatesEventArgs eventArgs)
        {
            if (!HasTurn() && CurrentState != State.WaitForChooseSquare)
            {
                return;
            }
            switch (CurrentState)
            {
                case State.WaitForChooseSquare:
                    if (playersRemainingTurn.Contains(Player.Instance.Id))
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

                    if (FullModel.Board.IsSquareWithinBoard(new Point(eventArgs.X, eventArgs.Y)) && FullModel.Board.Distance(standingPoint, new Point(eventArgs.X, eventArgs.Y)) == 1)
                    {
                        //if(FullModel.Board[eventArgs.X, eventArgs.Y].Marker != null && figure.Size.Equals(new Rectangle(0, 0, 1, 1)) && FullModel.Board[eventArgs.X, eventArgs.Y].Marker.Name.Equals("pit"))
                        //{
                        //  
                        // Move to adjecent
                        // If a an entire figure can move to the square
                        if (FullModel.Board.CanFigureMoveToPoint(figure, new Point(eventArgs.X, eventArgs.Y)) && figure.MovementLeft >= 1)
                        {
                            eventManager.QueueEvent(EventType.MoveTo, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                        // Open door
                        else if (figure is Hero && FullModel.Board.CanOpenDoor(new Point(eventArgs.X, eventArgs.Y)) &&
                            FullModel.Board.CanOpenDoor(standingPoint) && figure.MovementLeft >= 2)
                        {
                            eventManager.QueueEvent(EventType.OpenDoor, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                    }
                    else if (FullModel.Board.Distance(standingPoint, new Point(eventArgs.X, eventArgs.Y)) == 0 && figure is Hero && FullModel.Board[eventArgs.X, eventArgs.Y].Marker != null)
                    {
                        Marker marker = FullModel.Board[eventArgs.X, eventArgs.Y].Marker;

                        if (figure.MovementLeft >= marker.MovementPoints)
                        {
                            if (marker is PotionMarker)
                            {
                                if (!Player.Instance.Hero.Inventory.CanEquipPotion) return;
                            }
                            eventManager.QueueEvent(EventType.PickupMarker, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                    }

                    if (figure.AttacksLeft > 0 && FullModel.Board.IsSquareWithinBoard(new Point(eventArgs.X, eventArgs.Y)) &&
                        FullModel.Board.Distance(standingPoint, new Point(eventArgs.X, eventArgs.Y)) >= 1 &&
                        (FullModel.Board[eventArgs.X, eventArgs.Y] != null &&
                        (FullModel.Board[eventArgs.X, eventArgs.Y].Figure != null &&
                        FullModel.Board.IsThereLineOfSight(figure, FullModel.Board[eventArgs.X, eventArgs.Y].Figure, false))))
                    {
                        // A figure is trying to attack another figure.

                        if (Player.Instance.HeroParty.Heroes.ContainsKey(eventArgs.SenderId))
                        {
                            // A player is attacking
                            Hero hero = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];
                            Figure target = FullModel.Board[eventArgs.X, eventArgs.Y].Figure;

                            if (target is Hero)
                            {
                                return; // Do not allow attack if target is hero.
                            }

                            if (hero.Inventory.Weapon == null)
                            {
                                return; // Do not allow attack if hero does not have weapon
                            }

                            if (hero.AttackType == EAttackType.MELEE)
                            {
                                // If the player has a melee weapon, he should be adjacent to the figure he is attacking.
                                if (FullModel.Board.Distance(FullModel.Board.FiguresOnBoard[hero], new Point(eventArgs.X, eventArgs.Y)) == 1)
                                {
                                    // Hero is adjacent to target figure, carry on with attack.
                                    eventManager.QueueEvent(EventType.AttackSquare, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                                }
                            }
                            else if (hero.AttackType == EAttackType.MAGIC || hero.AttackType == EAttackType.RANGED)
                            {
                                // If attack type is magic or ranged, always allow attack.
                                eventManager.QueueEvent(EventType.AttackSquare, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                            }
                            else
                            {
                                // Attack type is not melee, magic or ranged - do not perform attack.
                            }
                        }
                        else
                        {
                            if (FullModel.Board[eventArgs.X, eventArgs.Y].Figure is Monster)
                            {
                                return; // A monster is trying to attack another monster. No go!
                            }

                            if (figure.AttackType == EAttackType.MELEE)
                            {
                                // If the monster has a melee weapon, he should be adjacent to the gero he is attacking.
                                if (FullModel.Board.Distance(FullModel.Board.FiguresOnBoard[figure], new Point(eventArgs.X, eventArgs.Y)) == 1)
                                {
                                    // Monster is adjacent to target figure, carry on with attack.
                                    eventManager.QueueEvent(EventType.AttackSquare, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                                }
                            }
                            else if (figure.AttackType == EAttackType.MAGIC || figure.AttackType == EAttackType.RANGED)
                            {
                                // If attack type is magic or ranged, always allow attack.
                                eventManager.QueueEvent(EventType.AttackSquare, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                            }
                            else
                            {
                                // Attack type is not melee, magic or ranged - do not perform attack.
                            }
                        }
                    }

                    break;
                case State.WaitForOverlordChooseAction:

                    if (FullModel.Board.IsSquareWithinBoard(eventArgs.X, eventArgs.Y))
                    {
                        Square s = FullModel.Board[eventArgs.X, eventArgs.Y];

                        // If a square with a monster is pressed in an overlord turn and we are the overlord, a monster turn should begin.
                        if (Player.Instance.IsOverlord && s.Figure != null && s.Figure is Monster && FullModel.Board.SquareVisibleByPlayers(eventArgs.X, eventArgs.Y) && monstersRemaining.Contains(s.Figure))
                        {
                            eventManager.QueueEvent(EventType.StartMonsterTurn, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                        }
                    }

                    break;
            }
        }

        private void InventoryFieldMarked(object sender, InventoryFieldEventArgs eventArgs)
        {
            Hero hero = Player.Instance.Hero;
            Inventory inventory = hero.Inventory;

            switch (CurrentState)
            {
                case State.Equip:
                case State.AllEquip:
                    if (CurrentState == State.Equip && !HasTurn())
                    {
                        break;
                    }
                    if (inventoryFieldMarked == -1)
                    {
                        inventoryFieldMarked = eventArgs.InventoryField;
                    }
                    else
                    {

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

                        if ((realId2 > 99 || equipment1 == null || inventory.CanEquipAtIndex(parsedId2, equipment1)) &&
                        (realId1 > 99 || equipment2 == null || inventory.CanEquipAtIndex(parsedId1, equipment2)))
                        {
                            eventManager.QueueEvent(EventType.SwitchItems, new SwitchItemsEventArgs(realId1, realId2));
                        }

                        inventoryFieldMarked = -1;
                    }
                    break;
                case State.WaitForPerformAction:
                    if (eventArgs.InventoryField >= 5 && eventArgs.InventoryField <= 7 && hero.MovementLeft >= 1)
                    {
                        // A hero can keep chucking potions as long as he has movement.

                        // There's a potion on the inventory field clicked
                        if (inventory[eventArgs.InventoryField] != null)
                        {
                            Equipment equipment = inventory[eventArgs.InventoryField];

                            if (equipment.Id == 11)
                            {
                                // Health potion
                                eventManager.QueueEvent(EventType.AddHealth, new PointsEventArgs(3));
                                eventManager.QueueEvent(EventType.RemoveMovement, new PointsEventArgs(1));
                                inventory[eventArgs.InventoryField] = null;
                            }
                            else if (equipment.Id == 12)
                            {
                                // Vitality potion
                                eventManager.QueueEvent(EventType.AddFatigue, new PointsEventArgs(hero.MaxFatigue));
                                eventManager.QueueEvent(EventType.RemoveMovement, new PointsEventArgs(1));
                                inventory[eventArgs.InventoryField] = null;
                            }

                        }
                    }

                    break;
            }
        }

        private void FatiqueClicked(object sender, GameEventArgs eventArgs)
        {
            if (Player.Instance.Hero.Fatigue == 0)
            {
                return;
            }

            switch (CurrentState)
            {
                case State.WaitForPerformAction:
                    eventManager.QueueEvent(EventType.BoughtMovement, new GameEventArgs());
                    break;

                case State.WaitForDiceChoice:
                    if (gameState.CurrentAttack.DiceForAttack.Count(dice => dice.Color == EDice.B) < 5)
                    {
                        Dice dice = FullModel.GetDice(EDice.B);
                        dice.RollDice();
                        eventManager.QueueEvent(EventType.BoughtDice, new DiceEventArgs(100000, dice.SideIndex)); // Dice Id is not used
                    }
                    break;
            }
        }

        private void DiceClicked(object sender, DiceEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForDiceChoice);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            // Do not act on dice click if it's not the players turn.
            if (!HasTurn()) return;

            Dice dice = gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId];
            if (dice.Color == EDice.B)
            {
                switch (dice.SideIndex)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 6:
                        eventManager.QueueEvent(EventType.ChangedBlackDiceSide, new DiceEventArgs(eventArgs.DiceId, 7));
                        break;
                    case 7:
                        eventManager.QueueEvent(EventType.ChangedBlackDiceSide, new DiceEventArgs(eventArgs.DiceId, 6));
                        break;
                }
            }
        }

        private void DoAttack(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForDiceChoice);
            Contract.Ensures(CurrentState == State.WaitForDiceChoice);

            damageTargetsRemaining.Clear();

            Attack attack = gameState.CurrentAttack;
            Point targetSquare = attack.TargetSquare;

            if (attack.MissedAttack || (attack.AttackingFigure.AttackType != EAttackType.MELEE && FullModel.Board.Distance(FullModel.Board.FiguresOnBoard[attack.AttackingFigure], targetSquare) > attack.Range))
            {
                eventManager.QueueEvent(EventType.MissedAttack, new GameEventArgs());
                eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs(attack.AttackingFigure.Name + " missed the attack!"));
                return;
            }

            damageTargetsRemaining.Add(targetSquare);

            eventManager.QueueEvent(EventType.InflictWounds, new InflictWoundsEventArgs(targetSquare.X, targetSquare.Y, attack.Damage, attack.Pierce));
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

            Player.Instance.HeroParty.AddConquestTokens(5);
            gameState.LegendaryMonsters = FullModel.AllLengendaryMonsters.ToList();

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

            // Remove overlord cards from state
            gameState.RemoveOverlordCards(eventArgs.OverlordCardIds);

            if (CurrentState == State.DrawOverlordCards)
            {
                DrawHeroCards();
            }
            else
            {
                stateMachine.PlaceStates(State.WaitForOverlordChooseAction);
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
            Contract.Ensures(CurrentState == State.DrawHeroCard || CurrentState == State.AllBuyEquipment);

            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId] = FullModel.GetHero(eventArgs.HeroId);
            gameState.RemoveHero(eventArgs.HeroId);

            if (stateMachine.NextState == State.AllBuyEquipment)
            {
                AllPlayersRemainTurn();
                gui.CreateMenuGUI(DetermineRole());

                foreach (Hero hero in Player.Instance.HeroParty.Heroes.Values)
                {
                    hero.Initialize();
                }
            }

            stateMachine.ChangeToNextState();

        }

        private void RequestBuyEquipment(object sender, RequestBuyEquipmentEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.BuyEquipment || CurrentState == State.AllBuyEquipment);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

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
            Contract.Requires(CurrentState == State.BuyEquipment || CurrentState == State.AllBuyEquipment || CurrentState == State.AllEquip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Equipment equipment = FullModel.GetEquipment(eventArgs.EquipmentId);
            gameState.AddToUnequippedEquipment(eventArgs.PlayerId, equipment);
            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId].Coins -= equipment.BuyPrice;
            System.Diagnostics.Debug.WriteLine(eventArgs.PlayerId + ": " + Player.Instance.HeroParty.Heroes[eventArgs.PlayerId].Coins);
            StateChanged();
        }

        private void FinishedBuy(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.BuyEquipment || CurrentState == State.AllBuyEquipment);
            Contract.Ensures(CurrentState == ((Contract.OldValue(CurrentState) == State.BuyEquipment) ? State.Equip :
                (playersRemainingTurn.Count == 0) ? State.AllEquip : State.AllBuyEquipment));

            playersRemainingTurn.Remove(eventArgs.SenderId);

            if (playersRemainingTurn.Count == 0)
            {
                AllPlayersRemainEquip();
                stateMachine.ChangeToNextState();
            }
            StateChanged();
        }

        private void SwitchItems(object sender, SwitchItemsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip || CurrentState == State.AllEquip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Hero hero = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];
            int realId1 = eventArgs.Field1,
                realId2 = eventArgs.Field2,
                parsedId1 = (realId1 > 99) ? realId1 - 100 : realId1,
                parsedId2 = (realId2 > 99) ? realId2 - 100 : realId2;
            Equipment equipment1 = (realId1 > 99) ? gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId1] : hero.Inventory[parsedId1];
            Equipment equipment2 = (realId2 > 99) ? gameState.UnequippedEquipment(eventArgs.SenderId)[parsedId2] : hero.Inventory[parsedId2];

            if (realId1 < 100)
            {
                hero.Inventory[parsedId1] = null;
            }

            if (realId2 < 100)
            {
                hero.Inventory[parsedId2] = null;
            }


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

        private void FinishedReequip(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.Equip || CurrentState == State.AllEquip);
            Contract.Ensures(CurrentState == (Contract.OldValue(CurrentState) == State.Equip ? State.WaitForChooseAction :
                (playersRemainingEquip.Count == 0 ?
                Contract.OldValue(stateMachine.NextState) : Contract.OldValue(CurrentState))));

            gameState.RemoveAllUnequippedEquipment(eventArgs.SenderId);
            playersRemainingEquip.Remove(eventArgs.SenderId);

            if (CurrentState == State.AllEquip && Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs(Player.Instance.GetPlayerNick(eventArgs.SenderId) + " has finished re-equipping."));
            }

            if (gameState.CurrentPlayer != 0 && stateMachine.IsOneMoreRecentThanOther(State.WaitForHeroTurn, State.OpenChest))
            {
                stateMachine.ChangeToNextState();
            }
            else if (playersRemainingEquip.Count == 0)
            {
                if (stateMachine.NextState == State.WaitForChooseSquare)
                {
                    AllPlayersRemainTurn();
                }
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
            Contract.Ensures(CurrentState == ((playersRemainingTurn.Count == 0) ? State.NewRound : State.WaitForChooseSquare));

            FullModel.Board.PlaceFigure(Player.Instance.HeroParty.Heroes[eventArgs.PlayerId], new Point(eventArgs.X, eventArgs.Y));

            playersRemainingTurn.Remove(eventArgs.PlayerId);

            if (playersRemainingTurn.Count == 0)
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

            // Place dead heroes on board
            FullModel.Board.RespawnDeadHeroes();

            AllPlayersRemainTurn(); // For WaitForHeroTurn
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
            Contract.Requires(IsAHeroTurn() ? Player.Instance.HeroParty.Heroes[eventArgs.SenderId].MovementLeft >= 1 :
                              currentMonster.MovementLeft >= 1);
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

            // The current monster should be marked both for overlord and player.
            MarkMonsters();

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
            Contract.Requires(CurrentState == State.WaitForHeroTurn || CurrentState == State.Equip);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            if (Player.Instance.IsServer && gameState.CurrentPlayer == 0 && playersRemainingTurn.Contains(eventArgs.SenderId))
            {
                eventManager.QueueEvent(EventType.TurnChanged, new PlayerEventArgs(eventArgs.SenderId));
                gameState.CurrentPlayer = eventArgs.SenderId;
            }
        }

        private void TurnChanged(object sender, PlayerEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForHeroTurn);
            Contract.Requires(gameState.CurrentPlayer == 0 || Player.Instance.IsServer);
            Contract.Requires(playersRemainingTurn.Contains(eventArgs.PlayerId));
            Contract.Ensures(CurrentState == State.Equip);

            gameState.CurrentPlayer = eventArgs.PlayerId;

            if (Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs(Player.Instance.GetPlayerNick(eventArgs.SenderId) + " has started his turn."));
            }

            Player.Instance.HeroParty.Heroes[gameState.CurrentPlayer].UntapAll();

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

        private void BoughtMovement(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Requires(Player.Instance.HeroParty.Heroes[eventArgs.SenderId].Fatigue > 0);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Hero hero = Player.Instance.HeroParty.Heroes[eventArgs.SenderId];
            hero.AddMovement(1);
            hero.RemoveFatigue(1);

            stateMachine.PlaceStates(State.BuyMovement, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void FinishedTurn(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == (IsAHeroTurn() ? State.WaitForPerformAction : State.WaitForOverlordChooseAction));
            Contract.Requires(gameState.CurrentPlayer == eventArgs.SenderId);
            Contract.Ensures(CurrentState == (playersRemainingTurn.Count == 0 ? ((eventArgs.SenderId == Player.Instance.OverlordId) ? State.NewRound : State.OverlordTurn) : State.WaitForHeroTurn));

            playersRemainingTurn.Remove(eventArgs.SenderId);
            gameState.CurrentPlayer = 0;

            // If the player ending the game was a hero, reset his movement.
            if (Player.Instance.HeroParty.Heroes.ContainsKey(eventArgs.SenderId))
            {
                Player.Instance.HeroParty.Heroes[eventArgs.SenderId].EndTurn();
            }

            if (CurrentState == State.WaitForOverlordChooseAction)
            {
                stateMachine.PlaceStates(State.NewRound);
                stateMachine.ChangeToNextState();
                if (Player.Instance.IsServer)
                {
                    eventManager.QueueEvent(EventType.NewRound, new GameEventArgs());
                }
            }
            else
            {
                if (playersRemainingTurn.Count == 0)
                {
                    stateMachine.PlaceStates(State.OverlordTurn);
                    stateMachine.ChangeToNextState();
                    OverlordTurnInitiation();
                }
                else
                {
                    stateMachine.PlaceStates(State.WaitForHeroTurn);
                    stateMachine.ChangeToNextState();
                }
            }
        }

        private void PickupMarker(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);
            FullModel.Board[eventArgs.X, eventArgs.Y].Marker.PickUp(Player.Instance.HeroParty.Heroes[eventArgs.SenderId]);
            if (!(FullModel.Board[eventArgs.X, eventArgs.Y].Marker is GlyphMarker))
            {
                FullModel.Board[eventArgs.X, eventArgs.Y].Marker = null;
            }

        }

        private void OpenChest(object sender, ChestEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Ensures(CurrentState == State.AllEquip);

            Chest chest = gameState.getChest(eventArgs.ChestId);

            // Remove movement
            Player.Instance.HeroParty.Heroes[gameState.CurrentPlayer].RemoveMovement(2);

            // Give conquest tokens to the hero party
            Player.Instance.HeroParty.AddConquestTokens(chest.ConquestTokens);

            // Give coins to each hero
            foreach (Hero hero in Player.Instance.HeroParty.Heroes.Values)
            {
                hero.Coins += chest.Coin;
            }

            // Give threat tokens to the overlord
            Player.Instance.Overlord.ThreatTokens += Player.Instance.HeroParty.Heroes.Count * chest.Curses;

            // Go into equip
            stateMachine.PlaceStates(State.OpenChest, State.AllEquip, State.WaitForPerformAction);
            AllPlayersRemainEquip();
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();

            // If we are the server, we are responsible for giving out treasures in the chest.
            if (Player.Instance.IsServer)
            {
                // Get a treasure for each hero
                Treasure[] treasures = gameState.getTreasures(Player.Instance.HeroParty.Heroes.Count, chest.Rarity);

                int treasureCount = 0;
                foreach (int heroPlayerId in Player.Instance.HeroParty.Heroes.Keys)
                {
                    GiveTreasure(heroPlayerId, treasures[treasureCount]);
                    treasureCount++;
                }
            }
        }

        private void GiveTreasure(int playerId, Treasure treasure)
        {
            // Treasure may have coins
            if (treasure.Coins > 0) eventManager.QueueEvent(EventType.GiveCoins, new GiveCoinsEventArgs(playerId, treasure.Coins));

            // Treasure may have equipment
            if (treasure.Equipment != null) eventManager.QueueEvent(EventType.GiveEquipment, new GiveEquipmentEventArgs(playerId, treasure.Equipment.Id, true));

            if (treasure.IsTreasureCache)
            {
                // If treasure is a cache
                GiveTreasure(playerId, gameState.getTreasures(1, treasure.Rarity).First());
            }
            else
            {
                return; // We are done here!
            }
        }

        private void GiveCoins(object sender, GiveCoinsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId].Coins += eventArgs.NumberOfCoins;
        }

        private void AddHealth(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].AddHealth(eventArgs.Points);
        }

        private void RemoveHealth(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].RemoveHealth(eventArgs.Points);
        }

        private void AddFatigue(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].AddFatigue(eventArgs.Points);
        }

        private void RemoveFatigue(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].RemoveFatigue(eventArgs.Points);
        }

        private void AddMovement(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].AddMovement(eventArgs.Points);
        }

        private void RemoveMovement(object sender, PointsEventArgs eventArgs)
        {
            Player.Instance.HeroParty.Heroes[eventArgs.SenderId].RemoveMovement(eventArgs.Points);
        }

        #endregion

        #region Overlord methods
        private void StartMonsterTurn(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForOverlordChooseAction);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Record monsterId
            currentMonster = (Monster)FullModel.Board[eventArgs.X, eventArgs.Y].Figure;

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

            MarkMonsters();

            stateMachine.PlaceStates(State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
        }

        // Helper method
        private void OverlordTurnInitiation()
        {
            Contract.Requires(CurrentState == State.OverlordTurn);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));
            Contract.Ensures(stateMachine.NextState == State.WaitForOverlordChooseAction);

            gameState.CurrentPlayer = Player.Instance.OverlordId;

            Player.Instance.Overlord.ThreatTokens += Player.Instance.HeroParty.NumberOfHeroes;
            if (Player.Instance.IsServer)
            {
                int[] overlordCardIds = gameState.GetOverlordCards(2).Select(card => card.Id).ToArray();
                eventManager.QueueEvent(EventType.GiveOverlordCards, new GiveOverlordCardsEventArgs(overlordCardIds));
            }

            monstersRemaining = FullModel.Board.FiguresOnBoard.Where(pair => pair.Key is Monster && FullModel.Board.SquareVisibleByPlayers(pair.Value.X, pair.Value.Y)).Select(pair => (Monster)pair.Key).ToList();

            if (Player.Instance.IsOverlord)
            {
                // Mark monsters that the overlord can select in the WaitForOverlordChooseAction
                MarkMonsters();
            }

            stateMachine.PlaceStates(State.WaitForOverlordChooseAction);
            StateChanged();
        }

        private void MarkMonsters()
        {
            gui.ClearMarks();

            // Spawn darkness
            if (!IsAHeroTurn())
            {
                for (int x = 0; x < FullModel.Board.Width; x++)
                {
                    for (int y = 0; y < FullModel.Board.Height; y++)
                    {
                        if (FullModel.Board.CanOverlordSpawn(new Point(x, y)))
                        {
                            gui.MarkSquare(x, y, false);
                        }
                    }
                }
            }

            if (currentMonster == null)
            {
                if (Player.Instance.IsOverlord)
                {
                    // If we're not in a monster turn, all monsters should be marked to indicate all monsters can be chosen, but only for the overlord.
                    foreach (Point point in FullModel.Board.FiguresOnBoard.Where(pair => monstersRemaining.Contains(pair.Key)).Select(pair => pair.Value))
                    {
                        Figure monster = FullModel.Board[point].Figure;

                        for (int x = point.X; x < point.X + (monster.Orientation.Equals(Orientation.V) ? monster.Size.Width : monster.Size.Height); x++)
                        {
                            for (int y = point.Y; y < point.Y + (monster.Orientation.Equals(Orientation.V) ? monster.Size.Height : monster.Size.Width); y++)
                            {
                                gui.MarkSquare(point.X, point.Y, true);
                            }
                        }
                    }
                }
            }
            else
            {
                // We have a current monster, mark only this monster indicate that the overlord can only perform actions with this monster.
                Point monsterpoint = FullModel.Board.FiguresOnBoard[currentMonster];
                for (int x = monsterpoint.X; x < monsterpoint.X + (currentMonster.Orientation.Equals(Orientation.V) ? currentMonster.Size.Width : currentMonster.Size.Height); x++)
                {
                    for (int y = monsterpoint.Y; y < monsterpoint.Y + (currentMonster.Orientation.Equals(Orientation.V) ? currentMonster.Size.Height : currentMonster.Size.Width); y++)
                    {
                        gui.MarkSquare(monsterpoint.X, monsterpoint.Y, true);
                    }
                }

            }

        }

        private void OverLordPlayCard(object sender, OverlordCardEventArgs eventArgs)
        {
            /* Not implemented yet
            Contract.Requires(CurrentState == State.WaitForPlayCard);
            Contract.Ensures(CurrentState == State.WaitForPlayCard);

            // Check rules for playing cards
            // Play card and invoke changes

            if (card.Type == OverlordCardType.Spawn)
           
            {
                //Add monsters to spawn bag
                stateMachine.PlaceStates(State.SpawnMonsters);
            }
            
            stateMachine.PlaceStates(State.ActivateMonsters);
             */
        }

        private void RemoveOverlordCard(object sender, OverlordCardEventArgs eventArgs)
        {
            OverlordCard overlordCard = FullModel.GetOverlordCard(eventArgs.OverlordCardId);
            Player.Instance.Overlord.Hand.Remove(overlordCard);
            Player.Instance.Overlord.ThreatTokens += overlordCard.SellPrice;

            if (Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs("The overlord sold a card."));
            }
        }

        private void EndMonsterTurn(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Ensures(CurrentState == (monstersRemaining.Count == 0 ? State.NewRound : State.WaitForOverlordChooseAction));

            monstersRemaining.Remove(currentMonster);
            currentMonster = null;

            MarkMonsters();

            stateMachine.PlaceStates(State.WaitForOverlordChooseAction);
            stateMachine.ChangeToNextState();

            if (monstersRemaining.Count == 0)
            {
                FinishedTurn(sender, eventArgs);
            }
        }

        #endregion

        #region Attack
        private void AttackSquare(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(eventArgs.SenderId == gameState.CurrentPlayer);
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            Contract.Ensures(CurrentState == State.WaitForRollDice);

            Figure attacker;
            if (IsAHeroTurn())
            {
                attacker = Player.Instance.HeroParty.Heroes[gameState.CurrentPlayer];
            }
            else
            {
                attacker = currentMonster;
            }

            gameState.CurrentAttack = attacker.GetAttack(new Point(eventArgs.X, eventArgs.Y));

            attacker.RemoveAttack();

            stateMachine.PlaceStates(State.Attack, State.WaitForRollDice, State.WaitForDiceChoice, State.InflictWounds, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void RolledDices(object sender, RolledDicesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForRollDice);
            Contract.Ensures(CurrentState == State.WaitForDiceChoice);

            gameState.CurrentAttack.SetDiceSides(eventArgs.RolledSides);
            stateMachine.ChangeToNextState();
        }

        private void BoughtDice(object sender, DiceEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForDiceChoice);
            Contract.Requires(gameState.CurrentAttack.DiceForAttack.Count(d => d.Color == EDice.B) < 5);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            Dice dice = FullModel.GetDice(EDice.B);
            dice.SideIndex = eventArgs.SideId;
            gameState.CurrentAttack.DiceForAttack.Add(dice);
            Player.Instance.HeroParty.Heroes[gameState.CurrentPlayer].RemoveFatigue(1);

            stateMachine.PlaceStates(State.BuyExtraDice, State.WaitForDiceChoice);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void ChangedBlackDiceSide(object sender, DiceEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForDiceChoice);
            Contract.Requires(gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].Color == EDice.B);
            Contract.Requires(gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex != 0 &&
                             (gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex < 4 ||
                              gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex > 5));
            Contract.Requires(gameState.CurrentPlayer == eventArgs.SenderId);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));
            Contract.Ensures(gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex ==
                            (Contract.OldValue(gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex) < 7 ? 7 : 6));

            gameState.CurrentAttack.DiceForAttack[eventArgs.DiceId].SideIndex = eventArgs.SideId;
            StateChanged();
        }

        private void InflictWounds(object sender, InflictWoundsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InflictWounds || CurrentState == State.WaitForDiceChoice);
            Contract.Requires(FullModel.Board[eventArgs.X, eventArgs.Y].Figure != null);
            Contract.Ensures(CurrentState == State.InflictWounds);

            if (CurrentState == State.WaitForDiceChoice)
            {
                stateMachine.ChangeToNextState();
            }

            Figure figure = FullModel.Board[eventArgs.X, eventArgs.Y].Figure;

            // Check only on own figure
            if ((Player.Instance.IsOverlord && !(figure is Monster)) ||
               (!Player.Instance.IsOverlord && figure != Player.Instance.Hero))
            {
                return;
            }

            int damage = eventArgs.Damage - (int)MathHelper.Clamp(figure.Armor - eventArgs.Pierce, 0, figure.Armor);

            // Check if hero has untapped shield
            if (!Player.Instance.IsOverlord &&
                Player.Instance.Hero.Inventory.Shield != null &&
                !Player.Instance.Hero.Inventory.Shield.Tapped &&
                damage >= 1)
            {
                damage -= 1;
            }
            damage = damage < 0 ? 0 : damage;

            string status = figure.Name + " ";
            if (damage >= figure.Health)
            {
                eventManager.QueueEvent(EventType.WasKilled, new CoordinatesEventArgs(eventArgs.X, eventArgs.Y));
                status += "was killed!";
            }
            else
            {
                eventManager.QueueEvent(EventType.DamageTaken, new DamageTakenEventArgs(eventArgs.X, eventArgs.Y, damage));
                status += "lost " + damage + " health!";
            }
            eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs(status));
        }

        private void DamageTaken(object sender, DamageTakenEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InflictWounds);
            Contract.Requires(FullModel.Board[eventArgs.X, eventArgs.Y].Figure != null);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            FullModel.Board[eventArgs.X, eventArgs.Y].Figure.RemoveHealth(eventArgs.Damage);
            if (HasTurn())
            {
                DamageDone(new Point(eventArgs.X, eventArgs.Y));
            }
        }

        private void WasKilled(object sender, CoordinatesEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InflictWounds);
            Contract.Requires(FullModel.Board[eventArgs.X, eventArgs.Y].Figure != null);
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState) || CurrentState == State.EndGameHeroParty || CurrentState == State.EndGameOverlord);

            Figure figure = FullModel.Board[eventArgs.X, eventArgs.Y].Figure;

            FullModel.Board.RemoveFigure(new Point(eventArgs.X, eventArgs.Y));

            if (figure is Hero)
            {
                Hero hero = (Hero)figure;
                hero.Initialize();
                hero.Coins = (int)Math.Floor((double)hero.Coins / 2 / 25) * 25; // Floor to nearest % 25;
                Player.Instance.HeroParty.RemoveConquestTokens(hero.Cost);
                if (Player.Instance.HeroParty.IsConquestPoolEmpty)
                {
                    GameWon(false);
                    return;
                }
            }
            else
            {
                gameState.LegendaryMonsters.Remove((Monster)figure);
                if (gameState.LegendaryMonsters.Count == 0)
                {
                    GameWon(true);
                    return;
                }
            }

            if (HasTurn())
            {
                DamageDone(new Point(eventArgs.X, eventArgs.Y));
            }
        }

        private void DamageDone(Point point)
        {
            Contract.Requires(CurrentState == State.InflictWounds);
            Contract.Requires(HasTurn());
            Contract.Ensures(CurrentState == Contract.OldValue(CurrentState));

            damageTargetsRemaining.Remove(point);
            if (damageTargetsRemaining.Count == 0)
            {
                eventManager.QueueEvent(EventType.FinishedAttack, new GameEventArgs());
            }
        }

        private void MissedAttack(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.WaitForDiceChoice);
            Contract.Requires(eventArgs.SenderId == gameState.CurrentPlayer);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
            stateMachine.ChangeToNextState();
        }

        private void FinishedAttack(object sender, GameEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.InflictWounds);
            Contract.Requires(eventArgs.SenderId == gameState.CurrentPlayer);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            gameState.CurrentAttack = null;
            stateMachine.ChangeToNextState();
        }

        #endregion

        private void GameWon(bool HeroPartyWon)
        {
            Contract.Requires(CurrentState == State.InflictWounds);
            Contract.Ensures(CurrentState == State.EndGameHeroParty || CurrentState == State.EndGameOverlord);

            if (Player.Instance.IsServer)
            {
                eventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs("The " + (HeroPartyWon ? "hero party" : "overlord") + " wins!!!"));
            }

            stateMachine.PlaceStates(HeroPartyWon ? State.EndGameHeroParty : State.EndGameOverlord);
            stateMachine.ChangeToNextState();
        }
    }
}
