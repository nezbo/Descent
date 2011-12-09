﻿namespace Descent.State
{
    public enum State
    {
        InLobby,
        DrawHeroCard,
        DrawSkillCards,
        WaitForTradeCard,
        TradeCard,
        BuyEquipment,
        WaitForBuy,
        BuyItem,
        HoldForServerReady,
        WaitForChooseStart,
        ChooseStart,
        DrawOverlordCards,
        SetupWorld,
        CreateBoard,
        PlaceMonsters,
        PlaceItems,
        GiveTokens,
        RevealStartArea,
        RespondReady,
        HoldForAllReady,
        NewRound,
        HeroPartyTurn,
        HeroPartyInitiation,
        WaitForHeroTurn,
        HeroTurn,
        RefreshCards,
        Equip,
        WaitForItemSwitch,
        SwitchItems,
        TakeAction,
        WaitForChooseAction,
        WaitForPerformAction,
        MovementAction,
        MoveAdjecent,
        DrinkPotion,
        PickupToken,
        CloseDoor,
        OpenDoor,
        RevealArea,
        DropItem,
        OpenChest,
        ReceiveChestContents,
        WaitForAllPlayersEquip,
        RemoveChest,
        UseGlyph,
        GiveItem,
        Jump,
        Attack,
        WaitForChooseSquare,
        ChooseSquare,
        WaitForRollDice,
        RollDice,
        ValidateSuccess,
        WaitForDiceChoice,
        BuyExtraDice,
        UseSurge,
        SwitchPowerEnhancement,
        CalculateRange,
        InflictWounds,
        CalculateDead,
        RemoveTarget,
        CalculateTargetType,
        HeroDead,
        MoveCharacterToTown,
        RemoveHalfMoney,
        RestoreCharacter,
        RemoveConquestTokens,
        ReceiveCoins,
        MissedAttack,
        BuyMovement,
        DeleteHeroTurn,
        OverlordTurn,
        ReceiveTreatTokens,
        WaitForDiscardCard,
        DiscardCard,
        WaitForPlayCard,
        PlayCard,
        SpawnMonsters,
        SpawnInitiation,
        WaitForPlaceMonster,
        PlaceMonster,
        ActivateMonsters,
        ActivateMonstersInitiation,
        WaitForChooseMonster,
        ChooseMonster,
        MonsterTurn,
        MonsterTurnInitiation,
        DeleteMonsterTurn,
        Initiation,
        WaitForOverlordChooseAction
    }
}