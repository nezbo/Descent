// <copyright file="ChestTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure.HeroStuff;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(Chest))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChestTest
    {
        [PexMethod]
        public int TreasuresGet([PexAssumeUnderTest]Chest target)
        {
            int result = target.Treasures;
            return result;
            // TODO: add assertions to method ChestTest.TreasuresGet(Chest)
        }
        [PexMethod]
        public EquipmentRarity RarityGet([PexAssumeUnderTest]Chest target)
        {
            EquipmentRarity result = target.Rarity;
            return result;
            // TODO: add assertions to method ChestTest.RarityGet(Chest)
        }
        [PexMethod]
        public int IdGet([PexAssumeUnderTest]Chest target)
        {
            int result = target.Id;
            return result;
            // TODO: add assertions to method ChestTest.IdGet(Chest)
        }
        [PexMethod]
        public int CursesGet([PexAssumeUnderTest]Chest target)
        {
            int result = target.Curses;
            return result;
            // TODO: add assertions to method ChestTest.CursesGet(Chest)
        }
        [PexMethod]
        public int ConquestTokensGet([PexAssumeUnderTest]Chest target)
        {
            int result = target.ConquestTokens;
            return result;
            // TODO: add assertions to method ChestTest.ConquestTokensGet(Chest)
        }
        [PexMethod]
        public int CoinGet([PexAssumeUnderTest]Chest target)
        {
            int result = target.Coin;
            return result;
            // TODO: add assertions to method ChestTest.CoinGet(Chest)
        }
        [PexMethod]
        public Chest Constructor(
            int id,
            EquipmentRarity rarity,
            int conquestTokens,
            int coin,
            int curses,
            int treasures
        )
        {
            Chest target = new Chest(id, rarity, conquestTokens, coin, curses, treasures);
            return target;
            // TODO: add assertions to method ChestTest.Constructor(Int32, EquipmentRarity, Int32, Int32, Int32, Int32)
        }
    }
}
