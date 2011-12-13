// <copyright file="CoordinatesEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(CoordinatesEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CoordinatesEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]CoordinatesEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method CoordinatesEventArgsTest.ToString01(CoordinatesEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]CoordinatesEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method CoordinatesEventArgsTest.PopulateWithArgs(CoordinatesEventArgs, String[])
        }
        [PexMethod]
        public CoordinatesEventArgs Constructor01(string[] stringArgs)
        {
            CoordinatesEventArgs target = new CoordinatesEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method CoordinatesEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public CoordinatesEventArgs Constructor(int x, int y)
        {
            CoordinatesEventArgs target = new CoordinatesEventArgs(x, y);
            return target;
            // TODO: add assertions to method CoordinatesEventArgsTest.Constructor(Int32, Int32)
        }
    }
}
