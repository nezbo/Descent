// <copyright file="DoorTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Descent.Model.Board
{
    [TestClass]
    [PexClass(typeof(Door))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DoorTest
    {
        [PexMethod]
        public void OpenedSet([PexAssumeUnderTest]Door target, bool value)
        {
            target.Opened = value;
            // TODO: add assertions to method DoorTest.OpenedSet(Door, Boolean)
        }
        [PexMethod]
        public Point TopLeftCornerGet([PexAssumeUnderTest]Door target)
        {
            Point result = target.TopLeftCorner;
            return result;
            // TODO: add assertions to method DoorTest.TopLeftCornerGet(Door)
        }
        [PexMethod]
        public Texture2D TextureGet([PexAssumeUnderTest]Door target)
        {
            Texture2D result = target.Texture;
            return result;
            // TODO: add assertions to method DoorTest.TextureGet(Door)
        }
        [PexMethod]
        public Orientation OrientationGet([PexAssumeUnderTest]Door target)
        {
            Orientation result = target.Orientation;
            return result;
            // TODO: add assertions to method DoorTest.OrientationGet(Door)
        }
        [PexMethod]
        public bool OpenedGet([PexAssumeUnderTest]Door target)
        {
            bool result = target.Opened;
            return result;
            // TODO: add assertions to method DoorTest.OpenedGet(Door)
        }
        [PexMethod]
        public RuneKey KeyColorGet([PexAssumeUnderTest]Door target)
        {
            RuneKey result = target.KeyColor;
            return result;
            // TODO: add assertions to method DoorTest.KeyColorGet(Door)
        }
        [PexMethod]
        public bool IsRuneDoorGet([PexAssumeUnderTest]Door target)
        {
            bool result = target.IsRuneDoor;
            return result;
            // TODO: add assertions to method DoorTest.IsRuneDoorGet(Door)
        }
        [PexMethod]
        public int[] AreasGet([PexAssumeUnderTest]Door target)
        {
            int[] result = target.Areas;
            return result;
            // TODO: add assertions to method DoorTest.AreasGet(Door)
        }
        [PexMethod]
        public bool IsAdjecentSquare([PexAssumeUnderTest]Door target, Point point)
        {
            bool result = target.IsAdjecentSquare(point);
            return result;
            // TODO: add assertions to method DoorTest.IsAdjecentSquare(Door, Point)
        }
        [PexMethod]
        public Door Constructor(
            int area1,
            Point point1InArea1,
            Point point2InArea1,
            int area2,
            Point point1InArea2,
            Point point2InArea2,
            Orientation orientation,
            RuneKey color,
            Texture2D texture
        )
        {
            Door target = new Door(area1, point1InArea1, point2InArea1, area2,
                                   point1InArea2, point2InArea2, orientation, color, texture);
            return target;
            // TODO: add assertions to method DoorTest.Constructor(Int32, Point, Point, Int32, Point, Point, Orientation, RuneKey, Texture2D)
        }
    }
}
