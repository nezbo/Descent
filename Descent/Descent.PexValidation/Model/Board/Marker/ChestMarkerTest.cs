// <copyright file="ChestMarkerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;
using Descent.Model.Player.Figure.HeroStuff;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(ChestMarker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChestMarkerTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]ChestMarker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method ChestMarkerTest.PickUp(ChestMarker, Hero)
        }
        [PexMethod]
        public ChestMarker Constructor(
            int id,
            string name,
            int movementCost,
            EquipmentRarity rarity,
            Texture2D texture
        )
        {
            ChestMarker target = new ChestMarker(id, name, movementCost, rarity, texture);
            return target;
            // TODO: add assertions to method ChestMarkerTest.Constructor(Int32, String, Int32, EquipmentRarity, Texture2D)
        }
    }
}
