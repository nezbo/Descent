// <copyright file="OtherMarkersTest.cs">Copyright ©  2011</copyright>

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
    [PexClass(typeof(OtherMarkers))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class OtherMarkersTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]OtherMarkers target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method OtherMarkersTest.PickUp(OtherMarkers, Hero)
        }
        [PexMethod]
        public OtherMarkers Constructor(
            int id,
            string name,
            Texture2D texture,
            int movementPoints
        )
        {
            OtherMarkers target = new OtherMarkers(id, name, texture, movementPoints);
            return target;
            // TODO: add assertions to method OtherMarkersTest.Constructor(Int32, String, Texture2D, Int32)
        }
    }
}
