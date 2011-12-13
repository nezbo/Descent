// <copyright file="MoneyMarkerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(MoneyMarker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MoneyMarkerTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]MoneyMarker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method MoneyMarkerTest.PickUp(MoneyMarker, Hero)
        }
        [PexMethod]
        public MoneyMarker Constructor(
            int id,
            string name,
            Texture2D texture,
            int movementPoints
        )
        {
            MoneyMarker target = new MoneyMarker(id, name, texture, movementPoints);
            return target;
            // TODO: add assertions to method MoneyMarkerTest.Constructor(Int32, String, Texture2D, Int32)
        }
    }
}
