// <copyright file="RuneMarkerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Descent.Model.Player.Figure;
using Microsoft.Xna.Framework.Graphics;
using Descent.Model.Board;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(RuneMarker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RuneMarkerTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]RuneMarker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method RuneMarkerTest.PickUp(RuneMarker, Hero)
        }
        [PexMethod]
        public RuneMarker Constructor(
            int id,
            string name,
            Texture2D texture,
            int movementPoints,
            RuneKey color
        )
        {
            RuneMarker target = new RuneMarker(id, name, texture, movementPoints, color);
            return target;
            // TODO: add assertions to method RuneMarkerTest.Constructor(Int32, String, Texture2D, Int32, RuneKey)
        }
    }
}
