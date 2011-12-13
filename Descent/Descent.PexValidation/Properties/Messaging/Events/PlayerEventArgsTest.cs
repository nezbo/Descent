// <copyright file="PlayerEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PlayerEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlayerEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PlayerEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PlayerEventArgsTest.ToString01(PlayerEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]PlayerEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method PlayerEventArgsTest.PopulateWithArgs(PlayerEventArgs, String[])
        }
        [PexMethod]
        public PlayerEventArgs Constructor01(string[] stringArgs)
        {
            PlayerEventArgs target = new PlayerEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method PlayerEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public PlayerEventArgs Constructor(int playerId)
        {
            PlayerEventArgs target = new PlayerEventArgs(playerId);
            return target;
            // TODO: add assertions to method PlayerEventArgsTest.Constructor(Int32)
        }
    }
}
