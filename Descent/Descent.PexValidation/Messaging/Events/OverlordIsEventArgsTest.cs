// <copyright file="OverlordIsEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(OverlordIsEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class OverlordIsEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]OverlordIsEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method OverlordIsEventArgsTest.ToString01(OverlordIsEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]OverlordIsEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method OverlordIsEventArgsTest.PopulateWithArgs(OverlordIsEventArgs, String[])
        }
        [PexMethod]
        public OverlordIsEventArgs Constructor01(string[] stringArgs)
        {
            OverlordIsEventArgs target = new OverlordIsEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method OverlordIsEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public OverlordIsEventArgs Constructor(int playerId)
        {
            OverlordIsEventArgs target = new OverlordIsEventArgs(playerId);
            return target;
            // TODO: add assertions to method OverlordIsEventArgsTest.Constructor(Int32)
        }
    }
}
