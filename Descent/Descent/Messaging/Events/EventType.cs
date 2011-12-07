// -----------------------------------------------------------------------
// <copyright file="EventType.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public enum EventType
    {
        PlayerJoined = 1,
        PlayersInGame = 2,
        RequestOverlord = 3,
        OverlordIs = 4,
        Ready = 5,
        AssignHero = 6,
        GiveHeroCards = 7,
        TradeHeroCard = 8,
        AcceptHeroCard = 9,
        BeginGame = 10,
        NewRound = 11,
        NoAction = 12,
        Wait = 13,
        ChatMessage = 14,
        RequestBuyEquipment = 15,
        GiveEquipment = 16,
        RequestBuyPotion = 17,
        GivePotion = 20,
        FinishedBuy = 21,
        GiveConquestToken = 22,
        GiveCoins = 23,
        GiveOverlordCards = 25,
        RemoveOverlordCard = 26,
        GiveThreatTokens = 27,
        RemoveThreatTokens = 28,
        StartPlacement = 29,
        RequestPlacement = 30,
        PlaceHero = 31,
        DenyPlacement = 32,
        RequestTurn = 33,
        TurnChanged = 34,
        DenyTurnRequest = 35,
        FinishedTurn = 36,
        FinishedReequip = 37,
        ChooseAction = 38,
        AddFatigue = 39,
        RemoveFatigue = 40,
        AddMovement = 41,
        RemoveFromInventory = 42,
        UseOverlordCard = 43,
        AddPowerOverlordCard = 44,
        SpawnMonster = 45,
        SpawnFinished = 46,
        StartMonsterTurn = 47,
        EndMonsterTurn = 48,
        MoveTo = 49,
        OpenChest = 50,
        OpenDoor = 51,
        AttackSquare = 52,
        RolledDices = 53,
        SendDamage = 54,
        RerollDices = 55,
        KilledFigure = 56,
        DamageTaken = 57,
        MissedAttack = 58,
        AcceptPlayer = 59
    }
}
