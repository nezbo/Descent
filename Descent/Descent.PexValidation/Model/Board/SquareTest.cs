// <copyright file="SquareTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Model.Board;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Model.Board
{
    [TestClass]
    [PexClass(typeof(Square))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SquareTest
    {
        [PexMethod]
        public int AreaGet([PexAssumeUnderTest]Square target)
        {
            int result = target.Area;
            return result;
            // TODO: add assertions to method SquareTest.AreaGet(Square)
        }
        [PexMethod]
        public Square Constructor(int area)
        {
            Square target = new Square(area);
            return target;
            // TODO: add assertions to method SquareTest.Constructor(Int32)
        }
    }
}
