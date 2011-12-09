// -----------------------------------------------------------------------
// <copyright file="EventManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Descent.Model.Player;

    #region Delegate declarations

    #region Initialization of game

    public delegate void AcceptPlayerHandler(object sender, PlayerEventArgs eventArgs);

    public delegate void PlayerJoinedHandler(object sender, PlayerJoinedEventArgs eventArgs);

    public delegate void PlayersInGameHandler(object sender, PlayersInGameEventArgs eventArgs);

    public delegate void RequestOverlordHandler(object sender, GameEventArgs eventArgs);

    public delegate void OverlordIsHandler(object sender, OverlordIsEventArgs eventArgs);

    public delegate void ReadyHandler(object sender, GameEventArgs eventArgs);

    public delegate void AssignHeroHandler(object sender, AssignHeroEventArgs eventArgs);

    public delegate void GiveHeroCardsHandler(object sender, GiveHeroCardsEventArgs eventArgs);

    public delegate void TradeHeroCardHandler(object sender, TradeHeroCardEventArgs eventArgs);

    public delegate void AcceptHeroCardsHandler(object sender, GameEventArgs eventArgs);

    public delegate void BeginGameHandler(object sender, GameEventArgs eventArgs);

    #endregion

    #region Generic events

    public delegate void NewRoundHandler(object sender, GameEventArgs eventArgs);

    public delegate void NoActionHandler(object sender, GameEventArgs eventArgs);

    public delegate void WaitHandler(object sender, GameEventArgs eventArgs);

    public delegate void ChatMessageHandler(object sender, ChatMessageEventArgs eventArgs);

    #endregion

    #region Trading and item handouts

    public delegate void RequestBuyEquipmentHandler(object sender, RequestBuyEquipmentEventArgs eventArgs);

    public delegate void GiveEquipmentHandler(object sender, GiveEquipmentEventArgs eventArgs);

    public delegate void RequestBuyPotionHandler(object sender, RequestBuyPotionEventArgs eventArgs);

    public delegate void GivePotionHandler(object sender, GivePotionEventArgs eventArgs);

    public delegate void DenyBuyHandler(object sender, PlayerEventArgs eventArgs);

    public delegate void FinishedBuyHandler(object sender, GameEventArgs eventArgs);

    public delegate void GiveConquestTokensHandler(object sender, TokenEventArgs eventArgs);

    public delegate void RemoveConquestTokensHandler(object sender, TokenEventArgs eventArgs);

    public delegate void GiveCoinsHandler(object sender, GiveCoinsEventArgs eventArgs);

    public delegate void GiveOverlordCardsHandler(object sender, GiveOverlordCardsEventArgs eventArgs);

    public delegate void RemoveOverlordCardHandler(object sender, OverlordCardEventArgs eventArgs);

    public delegate void GiveThreatTokensHandler(object sender, TokenEventArgs eventArgs);

    public delegate void RemoveThreatTokensHandler(object sender, TokenEventArgs eventArgs);

    public delegate void GiveTreasureHandler(object sender, TreasureEventArgs eventArgs);

    #endregion

    #region Initiation

    public delegate void StartPlacementHandler(object sender, GameEventArgs eventArgs);

    public delegate void RequestPlacementHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void PlaceHeroHandler(object sender, PlaceHeroEventArgs eventArgs);

    public delegate void DenyPlacementHandler(object sender, PlayerEventArgs eventArgs);

    #endregion

    #region Hero turn

    public delegate void RequestTurnHandler(object sender, GameEventArgs eventArgs);

    public delegate void TurnChangedHandler(object sender, PlayerEventArgs eventArgs);

    public delegate void DenyTurnRequestHandler(object sender, PlayerEventArgs eventArgs);

    public delegate void FinishedTurnHandler(object sender, GameEventArgs eventArgs);

    public delegate void FinishedReequipHandler(object sender, GameEventArgs eventArgs);

    public delegate void ChooseActionHandler(object sender, ChooseActionEventArgs eventArgs);

    public delegate void AddFatigueHandler(object sender, PointsEventArgs eventArgs);

    public delegate void RemoveFatigueHandler(object sender, PointsEventArgs eventArgs);

    public delegate void AddMovementHandler(object sender, PointsEventArgs eventArgs);

    public delegate void EquipHandler(object sender, EquipEventArgs eventArgs);

    public delegate void UnequipHandler(object sender, EquipEventArgs eventArgs);

    #endregion

    #region Overlord turn

    public delegate void UseOvelordCardHandler(object sender, OverlordCardEventArgs eventArgs);

    public delegate void AddPowerOverlordCardHandler(object sender, OverlordCardEventArgs eventArgs);

    public delegate void SpawnMonsterHandler(object sender, SpawnMonsterEventArgs eventArgs);

    public delegate void SpawnFinishedHandler(object sender, GameEventArgs eventArgs);

    public delegate void StartMonsterTurnHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void EndMonsterTurnHandler(object sender, GameEventArgs eventArgs);

    #endregion

    #region Movement types

    public delegate void MoveToHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void OpenChestHandler(object sender, ChestEventArgs eventArgs);

    public delegate void OpenDoorHandler(object sender, CoordinatesEventArgs eventArgs);

    #endregion

    #region Attacking

    public delegate void AttackSquareHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void RolledDicesHandler(object sender, RolledDicesEventArgs eventArgs);

    public delegate void SendDamageHandler(object sender, DamageEventArgs eventArgs);

    public delegate void RerollDicesHandler(object sender, RerollDicesEventArgs eventArgs);

    public delegate void KilledFigureHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void DamageTakenHandler(object sender, DamageEventArgs eventArgs);

    public delegate void MissedAttackHandler(object sender, PlayerEventArgs eventArgs);

    #endregion

    #region Internal only

    public delegate void SquareMarkedHandler(object sender, CoordinatesEventArgs eventArgs);

    public delegate void InventoryFieldMarkedHandler(object sender, InventoryFieldEventArgs eventArgs);

    #endregion

    public delegate void AllRespondedNoActionHandler(object sender, EventArgs eventArgs); // Special delegate, contains no eventArgs info.
    #endregion

    /// <summary>
    /// Takes strings received from the network and fires the appropriate events. Can also convert an event to a text string and send it.
    /// </summary>
    public class EventManager
    {
        private readonly EventType[] localOnly = new EventType[] { EventType.SquareMarked, EventType.InventoryFieldMarked };
        private readonly EventType[] needResponses = new EventType[] { };

        private Queue<string> queue = new Queue<string>();

        private Dictionary<string, int> responses = new Dictionary<string, int>(); // Key is eventid and int is number of players who responded.

        private bool awaitingResponses = false;
        private int responsesReceivedCount = 0;

        private Random random = new Random();

        #region Event declarations

        // Connect players
        public event AcceptPlayerHandler AcceptPlayerEvent;

        public event PlayerJoinedHandler PlayerJoinedEvent;

        public event PlayersInGameHandler PlayersInGameEvent;

        public event RequestOverlordHandler RequestOverlordEvent;

        public event OverlordIsHandler OverlordIsEvent;

        public event ReadyHandler ReadyEvent;

        // Initialize the game
        public event AssignHeroHandler AssignHeroEvent;

        public event GiveHeroCardsHandler GiveHeroCardsEvent;

        public event TradeHeroCardHandler TradeHeroCardEvent;

        public event AcceptHeroCardsHandler AcceptHeroCardsEvent;

        // Begin Game
        public event BeginGameHandler BeginGameEvent;

        public event NewRoundHandler NewRoundEvent;

        public event NoActionHandler NoActionEvent;

        public event WaitHandler WaitEvent;

        public event ChatMessageHandler ChatMessageEvent;

        // Shopping + equipment
        public event RequestBuyEquipmentHandler RequestBuyEquipmentEvent;

        public event GiveEquipmentHandler GiveEquipmentEvent;

        public event RequestBuyPotionHandler RequestBuyPotionEvent;

        public event GivePotionHandler GivePotionEvent;

        public event DenyBuyHandler DenyBuyEvent;

        public event FinishedBuyHandler FinishedBuyEvent;

        public event GiveConquestTokensHandler GiveConquestTokensEvent;

        public event RemoveConquestTokensHandler RemoveConquestTokensEvent;

        public event GiveCoinsHandler GiveCoinsEvent;

        // Overlord
        public event GiveOverlordCardsHandler GiveOverlordCardsEvent;

        public event RemoveOverlordCardHandler RemoveOverlordCardEvent;

        public event GiveThreatTokensHandler GiveThreatTokensEvent;

        public event RemoveThreatTokensHandler RemoveThreatTokensEvent;

        public event GiveTreasureHandler GiveTreasureEvent;

        // Hero placement
        public event StartPlacementHandler StartPlacementEvent;

        public event RequestPlacementHandler RequestPlacementEvent;

        public event PlaceHeroHandler PlaceHeroEvent;

        public event DenyPlacementHandler DenyPlacementEvent;

        // Turn management
        public event RequestTurnHandler RequestTurnEvent;

        public event TurnChangedHandler TurnChangedEvent;

        public event DenyTurnRequestHandler DenyTurnRequestEvent;

        public event FinishedTurnHandler FinishedTurnEvent;

        public event FinishedReequipHandler FinishedReequipEvent;


        public event ChooseActionHandler ChooseActionEvent;

        public event AddFatigueHandler AddFatigueEvent;

        public event RemoveFatigueHandler RemoveFatigueEvent;

        public event AddMovementHandler AddMovementEvent;

        public event EquipHandler EquipEvent;

        public event UnequipHandler UnequipEvent;

        public event UseOvelordCardHandler UseOverlordCardEvent;

        public event AddPowerOverlordCardHandler AddPowerOverlordCardEvent;

        public event SpawnMonsterHandler SpawnMonsterEvent;

        public event SpawnFinishedHandler SpawnFinishedEvent;

        public event StartMonsterTurnHandler StartMonsterTurnEvent;

        public event EndMonsterTurnHandler EndMonsterTurnEvent;

        public event MoveToHandler MoveToEvent;

        public event OpenChestHandler OpenChestEvent;

        public event OpenDoorHandler OpenDoorEvent;

        public event AttackSquareHandler AttackSquareEvent;

        public event RolledDicesHandler RolledDicesEvent;

        public event SendDamageHandler SendDamageEvent;

        public event RerollDicesHandler RerollDicesEvent;

        public event KilledFigureHandler KilledFigureEvent;

        public event DamageTakenHandler DamageTakenEvent;

        public event MissedAttackHandler MissedAttackEvent;

        public event AllRespondedNoActionHandler AllRespondedNoActionEvent;

        #region Internal only

        public event SquareMarkedHandler SquareMarkedEvent;

        public event InventoryFieldMarkedHandler InventoryFieldMarkedEvent;

        #endregion

        #endregion

        /// <summary>
        /// Take an event string and puts it on the event queue.
        /// </summary>
        /// <param name="eventString">Event string to queue.</param>
        public void QueueStringEvent(string eventString)
        {
            lock (queue)
            {
                queue.Enqueue(eventString);
            }
        }

        /// <summary>
        /// Queue an event.
        /// </summary>
        /// <param name="eventType">The type of event to queue.</param>
        /// <param name="eventArgs">The event arguments.</param>
        public void QueueEvent(EventType eventType, GameEventArgs eventArgs)
        {
            AddRequiredEventArgs(eventType, eventArgs);

            lock (queue)
            {
                queue.Enqueue(EncodeMessage(eventType, eventArgs));
            }
        }

        /// <summary>
        /// Process the event queue. Will fire all events in the queue and clear it.
        /// </summary>
        public void ProcessEventQueue()
        {
            // Looping the queue. We try to get a lock beforehand, since items can be added from other threads.
            lock (queue)
            {
                while (queue.Count > 0)
                {
                    string evtStr = queue.Dequeue();
                    ParseAndFire(evtStr, true);
                }
            }
        }

        /// <summary>
        /// Parse an event string and fire the event.
        /// </summary>
        /// <param name="eventString">The event string.</param>
        /// <param name="sendOnNetwork">Should this event be sent to the other players?</param>
        public void ParseAndFire(string eventString, bool sendOnNetwork)
        {
            // Required parts
            string[] messageParts = eventString.Split(",".ToCharArray());
            int sender = int.Parse(messageParts[0]);
            string eventId = messageParts[1];
            EventType eventType = (EventType)Enum.ToObject(typeof(EventType), int.Parse(messageParts[2]));
            bool needResponse = Convert.ToBoolean(int.Parse(messageParts[3]));

            GameEventArgs eventArgs = new GameEventArgs();

            // Optional arguments
            if (messageParts.Length > 4)
            {
                string[] eventArgStrings = new string[messageParts.Length - 4];
                Array.Copy(messageParts, 4, eventArgStrings, 0, messageParts.Length - 4);
                eventArgs = BuildEventArgs(eventType, eventArgStrings);
            }

            eventArgs.SenderId = sender;
            eventArgs.EventId = eventId;
            eventArgs.EventType = eventType;
            eventArgs.NeedResponse = needResponse;

            Fire(eventType, eventArgs, sendOnNetwork);
        }

        #region Helpers for firing specific events
        public void FirePlayersInGameEvent()
        {
            PlayerInGame[] playersInGame = new PlayerInGame[Player.Instance.NumberOfPlayers];

            for (int i = 1; i <= Player.Instance.NumberOfPlayers; i++)
            {
                playersInGame[i - 1] = new PlayerInGame(i, Player.Instance.GetPlayerNick(i));
            }

            QueueEvent(EventType.PlayersInGame, new PlayersInGameEventArgs(playersInGame));
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="eventType">Type of event.</param>
        /// <param name="eventArgs">The event arguments.</param>
        /// <param name="sendOnNetwork">Should this event be sent to the other players?</param>
        private void Fire(EventType eventType, GameEventArgs eventArgs, bool sendOnNetwork)
        {
            #if DEBUG
            System.Diagnostics.Debug.WriteLine("[{0}]: {1} - {2}", eventArgs.SenderId, eventType.ToString(), eventArgs.ToString());
            #endif

            // If I am the player who sent this message (aka it did not come through the network)
            // and the event needs responses, then prepare for collecting responses.
            if (eventArgs.SenderId == Player.Instance.Id && eventArgs.NeedResponse)
            {
                #if DEBUG
                System.Diagnostics.Debug.WriteLine("Awaiting responses from other players");
                #endif

                responses[eventArgs.EventId] = 0;
                awaitingResponses = true;
            }

            // Fire the actual event.
            switch (eventType)
            {
                case EventType.AcceptPlayer:
                    if (AcceptPlayerEvent != null) AcceptPlayerEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.PlayerJoined:
                    if (PlayerJoinedEvent != null) PlayerJoinedEvent(this, (PlayerJoinedEventArgs)eventArgs);
                    break;
                case EventType.PlayersInGame:
                    if (PlayersInGameEvent != null) PlayersInGameEvent(this, (PlayersInGameEventArgs)eventArgs);
                    break;
                case EventType.RequestOverlord:
                    if (RequestOverlordEvent != null) RequestOverlordEvent(this, eventArgs);
                    break;
                case EventType.OverlordIs:
                    if (OverlordIsEvent != null) OverlordIsEvent(this, (OverlordIsEventArgs)eventArgs);
                    break;
                case EventType.Ready:
                    if (ReadyEvent != null) ReadyEvent(this, eventArgs);
                    break;
                case EventType.AssignHero:
                    if (AssignHeroEvent != null) AssignHeroEvent(this, (AssignHeroEventArgs)eventArgs);
                    break;
                case EventType.GiveHeroCards:
                    if (GiveHeroCardsEvent != null) GiveHeroCardsEvent(this, (GiveHeroCardsEventArgs)eventArgs);
                    break;
                case EventType.TradeHeroCard:
                    if (TradeHeroCardEvent != null) TradeHeroCardEvent(this, (TradeHeroCardEventArgs)eventArgs);
                    break;
                case EventType.AcceptHeroCard:
                    if (AcceptHeroCardsEvent != null) AcceptHeroCardsEvent(this, eventArgs);
                    break;
                case EventType.BeginGame:
                    if (BeginGameEvent != null) BeginGameEvent(this, eventArgs);
                    break;
                case EventType.NewRound:
                    if (NewRoundEvent != null) NewRoundEvent(this, eventArgs);
                    break;
                case EventType.NoAction:
                    if (NoActionEvent != null) NoActionEvent(this, eventArgs);
                    AddResponse();
                    break;
                case EventType.Wait:
                    if (WaitEvent != null) WaitEvent(this, eventArgs);
                    awaitingResponses = false;
                    break;
                case EventType.ChatMessage:
                    if (ChatMessageEvent != null) ChatMessageEvent(this, (ChatMessageEventArgs)eventArgs);
                    break;
                case EventType.RequestBuyEquipment:
                    if (RequestBuyEquipmentEvent != null) RequestBuyEquipmentEvent(this, (RequestBuyEquipmentEventArgs)eventArgs);
                    break;
                case EventType.GiveEquipment:
                    if (GiveEquipmentEvent != null) GiveEquipmentEvent(this, (GiveEquipmentEventArgs)eventArgs);
                    break;
                case EventType.RequestBuyPotion:
                    if (RequestBuyPotionEvent != null) RequestBuyPotionEvent(this, (RequestBuyPotionEventArgs)eventArgs);
                    break;
                case EventType.GivePotion:
                    if (GivePotionEvent != null) GivePotionEvent(this, (GivePotionEventArgs)eventArgs);
                    break;
                case EventType.DenyBuy:
                    if (DenyBuyEvent != null) DenyBuyEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.FinishedBuy:
                    if (FinishedBuyEvent != null) FinishedBuyEvent(this, eventArgs);
                    break;
                case EventType.GiveConquestTokens:
                    if (GiveConquestTokensEvent != null) GiveConquestTokensEvent(this, (TokenEventArgs)eventArgs);
                    break;
                case EventType.RemoveConquestTokens:
                    if (RemoveConquestTokensEvent != null) RemoveConquestTokensEvent(this, (TokenEventArgs)eventArgs);
                    break;
                case EventType.GiveCoins:
                    if (GiveCoinsEvent != null) GiveCoinsEvent(this, (GiveCoinsEventArgs)eventArgs);
                    break;
                case EventType.GiveOverlordCards:
                    if (GiveOverlordCardsEvent != null) GiveOverlordCardsEvent(this, (GiveOverlordCardsEventArgs)eventArgs);
                    break;
                case EventType.RemoveOverlordCard:
                    if (RemoveOverlordCardEvent != null) RemoveOverlordCardEvent(this, (OverlordCardEventArgs)eventArgs);
                    break;
                case EventType.GiveThreatTokens:
                    if (GiveThreatTokensEvent != null) GiveThreatTokensEvent(this, (TokenEventArgs)eventArgs);
                    break;
                case EventType.RemoveThreatTokens:
                    if (RemoveThreatTokensEvent != null) RemoveThreatTokensEvent(this, (TokenEventArgs)eventArgs);
                    break;
                case EventType.GiveTreasure:
                    if (GiveTreasureEvent != null) GiveTreasureEvent(this, (TreasureEventArgs)eventArgs);
                    break;
                case EventType.StartPlacement:
                    if (StartPlacementEvent != null) StartPlacementEvent(this, eventArgs);
                    break;
                case EventType.RequestPlacement:
                    if (RequestPlacementEvent != null) RequestPlacementEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.PlaceHero:
                    if (PlaceHeroEvent != null) PlaceHeroEvent(this, (PlaceHeroEventArgs)eventArgs);
                    break;
                case EventType.DenyPlacement:
                    if (DenyPlacementEvent != null) DenyPlacementEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.RequestTurn:
                    if (RequestTurnEvent != null) RequestTurnEvent(this, eventArgs);
                    break;
                case EventType.TurnChanged:
                    if (TurnChangedEvent != null) TurnChangedEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.DenyTurnRequest:
                    if (DenyTurnRequestEvent != null) DenyTurnRequestEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.FinishedTurn:
                    if (FinishedTurnEvent != null) FinishedTurnEvent(this, eventArgs);
                    break;
                case EventType.FinishedReequip:
                    if (FinishedReequipEvent != null) FinishedReequipEvent(this, eventArgs);
                    break;
                case EventType.ChooseAction:
                    if (ChooseActionEvent != null) ChooseActionEvent(this, (ChooseActionEventArgs)eventArgs);
                    break;
                case EventType.AddFatigue:
                    if (AddFatigueEvent != null) AddFatigueEvent(this, (PointsEventArgs)eventArgs);
                    break;
                case EventType.RemoveFatigue:
                    if (RemoveFatigueEvent != null) RemoveFatigueEvent(this, (PointsEventArgs)eventArgs);
                    break;
                case EventType.AddMovement:
                    if (AddMovementEvent != null) AddMovementEvent(this, (PointsEventArgs)eventArgs);
                    break;
                case EventType.Equip:
                    if (EquipEvent != null) EquipEvent(this, (EquipEventArgs)eventArgs);
                    break;
                case EventType.Unequip:
                    if (UnequipEvent != null) UnequipEvent(this, (EquipEventArgs)eventArgs);
                    break;
                case EventType.UseOverlordCard:
                    if (UseOverlordCardEvent != null) UseOverlordCardEvent(this, (OverlordCardEventArgs)eventArgs);
                    break;
                case EventType.AddPowerOverlordCard:
                    if (AddPowerOverlordCardEvent != null) AddPowerOverlordCardEvent(this, (OverlordCardEventArgs)eventArgs);
                    break;
                case EventType.SpawnMonster:
                    if (SpawnMonsterEvent != null) SpawnMonsterEvent(this, (SpawnMonsterEventArgs)eventArgs);
                    break;
                case EventType.SpawnFinished:
                    if (SpawnFinishedEvent != null) SpawnFinishedEvent(this, eventArgs);
                    break;
                case EventType.StartMonsterTurn:
                    if (StartMonsterTurnEvent != null) StartMonsterTurnEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.EndMonsterTurn:
                    if (EndMonsterTurnEvent != null) EndMonsterTurnEvent(this, eventArgs);
                    break;
                case EventType.MoveTo:
                    if (MoveToEvent != null) MoveToEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.OpenChest:
                    if (OpenChestEvent != null) OpenChestEvent(this, (ChestEventArgs)eventArgs);
                    break;
                case EventType.OpenDoor:
                    if (OpenDoorEvent != null) OpenDoorEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.AttackSquare:
                    if (AttackSquareEvent != null) AttackSquareEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.RolledDices:
                    if (RolledDicesEvent != null) RolledDicesEvent(this, (RolledDicesEventArgs)eventArgs);
                    break;
                case EventType.SendDamage:
                    if (SendDamageEvent != null) SendDamageEvent(this, (DamageEventArgs)eventArgs);
                    break;
                case EventType.RerollDices:
                    if (RerollDicesEvent != null) RerollDicesEvent(this, (RerollDicesEventArgs)eventArgs);
                    break;
                case EventType.KilledFigure:
                    if (KilledFigureEvent != null) KilledFigureEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.DamageTaken:
                    if (DamageTakenEvent != null) DamageTakenEvent(this, (DamageEventArgs)eventArgs);
                    break;
                case EventType.MissedAttack:
                    if (MissedAttackEvent != null) MissedAttackEvent(this, (PlayerEventArgs)eventArgs);
                    break;
                case EventType.SquareMarked:
                    if (SquareMarkedEvent != null) SquareMarkedEvent(this, (CoordinatesEventArgs)eventArgs);
                    break;
                case EventType.InventoryFieldMarked:
                    if (InventoryFieldMarkedEvent != null) InventoryFieldMarkedEvent(this, (InventoryFieldEventArgs)eventArgs);
                    break;
            }

            if (sendOnNetwork && !localOnly.Contains(eventType))
            {
                Player.Instance.Connection.SendString(EncodeMessage(eventType, eventArgs));
            }

        }

        /// <summary>
        /// Log a response to an event that requires responses.
        /// TODO: This method is not correct - FIX IT!
        /// </summary>
        /// <param name="eventId">The event id of response.</param>
        private void AddResponse(string eventId)
        {

            // We should only take action if we have prepared to receive the responses by putting the key into the dictionary.
            // If we see the key in there, we know we're supposed to collect responses.
            if (responses.ContainsKey(eventId))
            {
                responses[eventId]++;

                // If we have received responses from everyone but the player itself, we can fire the event and delete from the dictionary.
                if (responses[eventId] >= Player.Instance.NumberOfPlayers - 1)
                {
                    AllRespondedNoActionEvent(this, new EventArgs());
                    responses.Remove(eventId);
                }
            }
        }

        private void AddResponse()
        {

            // We should only take action if we have prepared to receive the responses by putting the key into the dictionary.
            // If we see the key in there, we know we're supposed to collect responses.
            if (awaitingResponses)
            {
                responsesReceivedCount++;

                // If we have received responses from everyone but the player itself, we can fire the event and delete from the dictionary.
                if (responsesReceivedCount >= Player.Instance.NumberOfPlayers - 1)
                {
                    AllRespondedNoActionEvent(this, new EventArgs());
                    awaitingResponses = false;
                }
            }
        }

        /// <summary>
        /// Populate a <see cref="GameEventArgs"/> object with required fields.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventArgs">The <see cref="GameEventArgs"/> object.</param>
        private void AddRequiredEventArgs(EventType eventType, GameEventArgs eventArgs)
        {
            eventArgs.SenderId = Player.Instance.Id;
            eventArgs.EventId = GenerateEventId();
            eventArgs.EventType = eventType;
            eventArgs.NeedResponse = NeedResponse(eventType);
        }

        /// <summary>
        /// Builds the correct type of <see cref="GameEventArgs"/> object based on the event type.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/></param>
        /// <param name="args">The arguments as strings.</param>
        /// <returns>A <see cref="GameEventArgs"/> object of the correct type, with the correct values set.</returns>
        private GameEventArgs BuildEventArgs(EventType eventType, string[] args)
        {
            switch (eventType)
            {
                case EventType.AcceptPlayer:
                    return new PlayerEventArgs(args);
                case EventType.PlayerJoined:
                    return new PlayerJoinedEventArgs(args);
                case EventType.PlayersInGame:
                    return new PlayersInGameEventArgs(args);
                case EventType.OverlordIs:
                    return new OverlordIsEventArgs(args);
                case EventType.AssignHero:
                    return new AssignHeroEventArgs(args);
                case EventType.GiveHeroCards:
                    return new GiveHeroCardsEventArgs(args);
                case EventType.TradeHeroCard:
                    return new TradeHeroCardEventArgs(args);
                case EventType.ChatMessage:
                    return new ChatMessageEventArgs(args);
                case EventType.RequestBuyEquipment:
                    return new RequestBuyEquipmentEventArgs(args);
                case EventType.GiveEquipment:
                    return new GiveEquipmentEventArgs(args);
                case EventType.RequestBuyPotion:
                    return new GiveEquipmentEventArgs(args);
                case EventType.GivePotion:
                    return new GivePotionEventArgs(args);
                case EventType.DenyBuy:
                    return new PlayerEventArgs(args);
                case EventType.GiveConquestTokens:
                    return new TokenEventArgs(args);
                case EventType.RemoveConquestTokens:
                    return new TokenEventArgs(args);
                case EventType.GiveCoins:
                    return new GiveCoinsEventArgs(args);
                case EventType.GiveOverlordCards:
                    return new GiveOverlordCardsEventArgs(args);
                case EventType.RemoveOverlordCard:
                    return new OverlordCardEventArgs(args);
                case EventType.GiveThreatTokens:
                    return new TokenEventArgs(args);
                case EventType.RemoveThreatTokens:
                    return new TokenEventArgs(args);
                case EventType.GiveTreasure:
                    return new TreasureEventArgs(args);
                case EventType.RequestPlacement:
                    return new CoordinatesEventArgs(args);
                case EventType.PlaceHero:
                    return new PlaceHeroEventArgs(args);
                case EventType.DenyPlacement:
                    return new PlayerEventArgs(args);
                case EventType.TurnChanged:
                    return new PlayerEventArgs(args);
                case EventType.DenyTurnRequest:
                    return new PlayerEventArgs(args);
                case EventType.ChooseAction:
                    return new ChooseActionEventArgs(args);
                case EventType.AddFatigue:
                    return new PointsEventArgs(args);
                case EventType.RemoveFatigue:
                    return new PointsEventArgs(args);
                case EventType.AddMovement:
                    return new PointsEventArgs(args);
                case EventType.Equip:
                    return new EquipEventArgs(args);
                case EventType.Unequip:
                    return new EquipEventArgs(args);
                case EventType.UseOverlordCard:
                    return new OverlordCardEventArgs(args);
                case EventType.AddPowerOverlordCard:
                    return new OverlordCardEventArgs(args);
                case EventType.SpawnMonster:
                    return new SpawnMonsterEventArgs(args);
                case EventType.StartMonsterTurn:
                    return new CoordinatesEventArgs(args);
                case EventType.MoveTo:
                    return new CoordinatesEventArgs(args);
                case EventType.OpenChest:
                    return new ChestEventArgs(args);
                case EventType.OpenDoor:
                    return new CoordinatesEventArgs(args);
                case EventType.AttackSquare:
                    return new CoordinatesEventArgs(args);
                case EventType.RolledDices:
                    return new RolledDicesEventArgs(args);
                case EventType.SendDamage:
                    return new DamageEventArgs(args);
                case EventType.RerollDices:
                    return new RerollDicesEventArgs(args);
                case EventType.KilledFigure:
                    return new CoordinatesEventArgs(args);
                case EventType.DamageTaken:
                    return new DamageEventArgs(args);
                case EventType.MissedAttack:
                    return new PlayerEventArgs(args);
                case EventType.SquareMarked:
                    return new CoordinatesEventArgs(args);
                case EventType.InventoryFieldMarked:
                    return new InventoryFieldEventArgs(args);
                default:
                    return new GameEventArgs();
            }
        }

        /// <summary>
        /// Does this kind of <see cref="EventType"/> need a response?
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <returns>True if the event type needs a response, false otherwise.</returns>
        private bool NeedResponse(EventType eventType)
        {
            return needResponses.Contains(eventType);
        }

        /// <summary>
        /// Encode a message to a string.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <param name="eventArgs">The <see cref="GameEventArgs"/> object.</param>
        /// <returns>The message encoded as a string.</returns>
        private string EncodeMessage(EventType eventType, GameEventArgs eventArgs)
        {
            return string.Join(",", eventArgs.SenderId, eventArgs.EventId, (int)eventArgs.EventType, Convert.ToInt32(eventArgs.NeedResponse), eventArgs.ToString());
        }

        /// <summary>
        /// Generates a unique event id. It's based on the current time, the player ip and the player id.
        /// </summary>
        /// <returns></returns>
        private string GenerateEventId()
        {
            string time = DateTime.Now.Ticks.ToString();
            string ip = Player.Instance.Connection.Ip;
            string id = Player.Instance.Id.ToString();

            //Console.WriteLine("Generating MD5 from {0} {1} {2}", time, ip, id);
            return MD5String(time + ip + id);
        }

        /// <summary>
        /// Generate a MD5 hash from a given string.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The MD5 hash as a string.</returns>
        private string MD5String(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
        #endregion
    }
}
