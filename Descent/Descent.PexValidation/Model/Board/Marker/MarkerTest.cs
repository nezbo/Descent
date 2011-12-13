// <copyright file="MarkerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board.Marker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using Descent.Model.Player.Figure;

namespace Descent.Model.Board.Marker
{
    [TestClass]
    [PexClass(typeof(global::Descent.Model.Board.Marker.Marker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MarkerTest
    {
        [PexMethod]
        public Texture2D TextureGet([PexAssumeNotNull]global::Descent.Model.Board.Marker.Marker target)
        {
            Texture2D result = target.Texture;
            return result;
            // TODO: add assertions to method MarkerTest.TextureGet(Marker)
        }
        [PexMethod]
        public string NameGet([PexAssumeNotNull]global::Descent.Model.Board.Marker.Marker target)
        {
            string result = target.Name;
            return result;
            // TODO: add assertions to method MarkerTest.NameGet(Marker)
        }
        [PexMethod]
        public int MovementPointsGet([PexAssumeNotNull]global::Descent.Model.Board.Marker.Marker target)
        {
            int result = target.MovementPoints;
            return result;
            // TODO: add assertions to method MarkerTest.MovementPointsGet(Marker)
        }
        [PexMethod]
        public int IdGet([PexAssumeNotNull]global::Descent.Model.Board.Marker.Marker target)
        {
            int result = target.Id;
            return result;
            // TODO: add assertions to method MarkerTest.IdGet(Marker)
        }
        [PexMethod]
        public void PickUp([PexAssumeNotNull]global::Descent.Model.Board.Marker.Marker target, Hero hero)
        {
            target.PickUp(hero);
            // TODO: add assertions to method MarkerTest.PickUp(Marker, Hero)
        }
    }
}
