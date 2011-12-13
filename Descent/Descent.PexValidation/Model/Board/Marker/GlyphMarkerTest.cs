// <copyright file="GlyphMarkerTest.cs">Copyright ©  2011</copyright>

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
    [PexClass(typeof(GlyphMarker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GlyphMarkerTest
    {
        [PexMethod]
        public void PickUp([PexAssumeUnderTest]GlyphMarker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method GlyphMarkerTest.PickUp(GlyphMarker, Hero)
        }
        [PexMethod]
        public GlyphMarker Constructor(
            int id,
            string name,
            Texture2D texture,
            int movementPoints,
            bool open,
            Texture2D openTexture
        )
        {
            GlyphMarker target = new GlyphMarker(id, name, texture, movementPoints, open, openTexture);
            return target;
            // TODO: add assertions to method GlyphMarkerTest.Constructor(Int32, String, Texture2D, Int32, Boolean, Texture2D)
        }
    }
}
