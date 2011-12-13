// <copyright file="PotionMarkerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework.Graphics;
using Descent.Model.Player.Figure.HeroStuff;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(PotionMarker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PotionMarkerTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]PotionMarker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method PotionMarkerTest.PickUp(PotionMarker, Hero)
        }
        [PexMethod]
        public PotionMarker Constructor(
            int id,
            string name,
            Texture2D texture,
            int movementPoints,
            Equipment potion
        )
        {
            PotionMarker target = new PotionMarker(id, name, texture, movementPoints, potion);
            return target;
            // TODO: add assertions to method PotionMarkerTest.Constructor(Int32, String, Texture2D, Int32, Equipment)
        }
    }
}
