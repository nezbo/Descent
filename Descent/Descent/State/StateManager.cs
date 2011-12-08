using System.Collections.ObjectModel;

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
        private readonly FullModel model;
        private HeroParty heroParty;
        private EventManager eventManager = Player.Instance.EventManager;
        private GameState gameState = new GameState();

        // fields for different game logic variables
        // server only
        private int ReadyCount = 0;

        // other
        private Hero currentHero;
        private Collection<Hero> heroesYetToAct;

        public StateManager(GUI gui, FullModel model)
        {
            this.gui = gui;
            this.model = model;

            // subscribe for events
            eventManager.PlayerJoinedEvent += new PlayerJoinedHandler(PlayerJoined);
            eventManager.PlayersInGameEvent += new PlayersInGameHandler(PlayersInGame);
            eventManager.ReadyEvent += new ReadyHandler(BeginGame);
            eventManager.BeginGameEvent += new BeginGameHandler(BeginGame);
            eventManager.OverlordIsEvent += new OverlordIsHandler(OverLordIs);
            eventManager.GiveOverlordCardsEvent += new GiveOverlordCardsHandler(GiveOverlordCards);
            eventManager.AssignHeroEvent += new AssignHeroHandler(AssignHero);

            // initiate start
            stateMachine = new StateMachine(new State[] { State.InLobby, State.Initiation, State.DrawOverlordCards, //TODO DrawSkillCards
                State.BuyEquipment, State.NewRound, State.NewRound });
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
            return stateMachine.IsOneMoreRecentThanOther(State.HeroTurn, State.OverlordTurn);
        }

        private Role DetermineRole()
        {
            if (Player.Instance.IsOverlord) return Role.Overlord;

            if (IsAHeroTurn())
            {
                return Player.Instance.Hero == currentHero ? Role.ActiveHero : Role.InactiveHero;
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
                            root.AddClickAction("start", n =>
                                                             {
#if DEBUG
                                                                 if (Player.Instance.NumberOfPlayers >= 1) //TODO 3
#else 
                                                                     if (Player.Instance.NumberOfPlayers >= 3) //TODO 3
#endif
                                                                 {
                                                                     Player.Instance.EventManager.QueueEvent(
                                                                         EventType.BeginGame, new GameEventArgs());
                                                                     Player.Instance.EventManager.QueueEvent(EventType.OverlordIs, new OverlordIsEventArgs(Player.Instance.Id));
                                                                 }
                                                                 System.Diagnostics.Debug.WriteLine("Start clicked!");
                                                             });
                        }

                        break;
                    }
                case State.BuyEquipment:
                    {
                        if (role != Role.Overlord)
                        {
                            root.AddClickAction("done",n => n.EventManager.QueueEvent(EventType.FinishedBuy, new GameEventArgs()));
                        }
                        break;
                    }
            }

            gui.ChangeStateGUI(root); // change the GUI's state element.
        }

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
            gui.CreateMenuGUI(model, DetermineRole());

            stateMachine.ChangeToNextState();
        }

        private void GiveOverlordCards(object sender, GiveOverlordCardsEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.DrawOverlordCards);
            Contract.Ensures(CurrentState == State.DrawHeroCard);

            foreach (int overlordCardId in eventArgs.OverlordCardIds)
            {
                Player.Instance.Overlord.Hand.Add(FullModel.GetOverlordCard(overlordCardId));
            }

            if (Player.Instance.IsServer)
            {
                foreach (int playerId in Player.Instance.HeroParty.Heroes.Keys)
                {
                    stateMachine.PlaceStates(State.DrawHeroCard);
                    int heroId = gameState.getHero().Id;
                    eventManager.QueueEvent(EventType.AssignHero, new AssignHeroEventArgs(playerId, heroId));
                    gameState.RemoveHero(heroId);
                }
            }

            stateMachine.ChangeToNextState();
        }

        private void AssignHero(object sender, AssignHeroEventArgs eventArgs)
        {
            Contract.Requires(CurrentState == State.DrawHeroCard);
            Contract.Ensures(CurrentState == State.DrawHeroCard || CurrentState == State.BuyEquipment);
            
            Player.Instance.HeroParty.Heroes[eventArgs.PlayerId] = FullModel.GetHero(eventArgs.HeroId);
            gameState.RemoveHero(eventArgs.HeroId);
            stateMachine.ChangeToNextState();
            
            if (CurrentState == State.BuyEquipment) // TODO Should be DrawSkillCard
            {
                System.Diagnostics.Debug.WriteLine("done " + CurrentState);
            }
        }

        private void NewRound()
        {
            Contract.Requires(CurrentState == State.InLobby); // TODO: Find the right state(s)
            Contract.Ensures(CurrentState == State.WaitForHeroTurn);

            heroesYetToAct = new Collection<Hero>(heroParty.AllHeroes);

            stateMachine.PlaceStates(State.WaitForHeroTurn);
            stateMachine.ChangeToNextState();
        }

        #region Hero methods

        private void HeroTurnChosen(Hero hero)
        {
            Contract.Requires(CurrentState == State.WaitForHeroTurn);
            Contract.Requires(heroesYetToAct.Contains(hero));

            currentHero = hero;

            stateMachine.PlaceStates(State.HeroTurn);
            stateMachine.ChangeToNextState();
            HeroTurnInitiation();
        }

        private void HeroTurnInitiation()
        {
            Contract.Requires(CurrentState == State.HeroTurn);
            Contract.Ensures(CurrentState == State.WaitForItemSwitch);

            // Refresh cards

            stateMachine.PlaceStates(State.WaitForItemSwitch, State.WaitForChooseAction, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
        }

        private void SwitchItems(Equipment item1, Equipment item2)
        {
            Contract.Requires(CurrentState == State.WaitForItemSwitch);
            Contract.Requires(item1 != null);
            Contract.Requires(item2 != null);
            Contract.Ensures(CurrentState == State.WaitForItemSwitch);

            // Switch the two items
        }

        private void SwitchitemDone()
        {
            Contract.Requires(CurrentState == State.WaitForItemSwitch);
            Contract.Ensures(CurrentState != State.WaitForItemSwitch);

            stateMachine.ChangeToNextState();
        }

        private void ChooseAction(/* TODO HeroAction action*/)
        {
            Contract.Requires(CurrentState == State.WaitForChooseAction);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Add movement and battle points to hero(?) object

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

        private void HeroTurnDone()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);

            heroesYetToAct.Remove(currentHero);
            currentHero = null;

            if (heroesYetToAct.Count == 0)
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
        #endregion

        #region Overlord methods
        private void OverlordTurnInitiation()
        {
            Contract.Requires(CurrentState == State.OverlordTurn);
            Contract.Ensures(CurrentState == State.WaitForDiscardCard);

            // Receive threat tokens
            // Draw two overlord cards

            stateMachine.PlaceStates(State.WaitForDiscardCard, State.WaitForPlayCard, State.ActivateMonstersInitiation);
            stateMachine.ChangeToNextState();
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

        private void OverLordPlayCard()
        {
            Contract.Requires(CurrentState == State.WaitForPlayCard);
            Contract.Ensures(CurrentState == State.WaitForPlayCard);

            // Check rules for playing cards
            // Play card and invoke changes

            /* TODO if (card.Type == OverlordCardType.Spawn) */
            {
                //Add monsters to spawn bag
                stateMachine.PlaceStates(State.SpawnMonsters);
            }
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
                ActivateMonstersInitiation();
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
            ActivateMonstersInitiation();
        }

        private void ActivateMonstersInitiation()
        {
            Contract.Requires(CurrentState == State.ActivateMonsters);
            Contract.Ensures(CurrentState == State.WaitForChooseMonster);

            // Add all monsters to monster bag

            stateMachine.PlaceStates(State.WaitForChooseMonster);
            stateMachine.ChangeToNextState();
        }

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

            NewRound();
        }

        private void MonsterTurnInitiation()
        {
            Contract.Requires(CurrentState == State.MonsterTurn);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);

            // Add movement and 1 attack

            stateMachine.PlaceStates(State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
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

        private void MoveDone()
        {
            Contract.Ensures(CurrentState == State.WaitForPerformAction);
            stateMachine.PlaceStates(State.MoveAdjecent, State.WaitForPerformAction);
            stateMachine.ChangeToNextState();
        }

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
            MoveDone();
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
            MoveDone();
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
            MoveDone();
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
            MoveDone();
        }

        private void OpenDoor()
        {
            Contract.Requires(CurrentState == State.WaitForPerformAction);
            // TODO Contract.Requires(currentHero.MovementLeft >= 2);
            Contract.Ensures(CurrentState == State.WaitForPerformAction);
            // TODO Contract.Requires(IsAHeroTurn() || otherArea.IsRevealed);


            // Remove 2 movement
            // Mark door opened

            stateMachine.PlaceStates(State.OpenDoor);
            stateMachine.ChangeToNextState();

            // TODO if (area.Unrevealed)
            {
                stateMachine.PlaceStates(State.RevealArea, State.WaitForPerformAction);
                // TODO RevealArea(areaId);
            }
            // TODO else
            {
                MoveDone();
            }
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
            MoveDone();
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
            MoveDone();
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
            MoveDone();
        }

        #endregion
    }
}
