// <copyright file="PlayerJoinedEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PlayerJoinedEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlayerJoinedEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PlayerJoinedEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PlayerJoinedEventArgsTest.ToString01(PlayerJoinedEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]PlayerJoinedEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method PlayerJoinedEventArgsTest.PopulateWithArgs(PlayerJoinedEventArgs, String[])
        }
        [PexMethod]
        public PlayerJoinedEventArgs Constructor01(string[] stringArgs)
        {
            PlayerJoinedEventArgs target = new PlayerJoinedEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method PlayerJoinedEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public PlayerJoinedEventArgs Constructor(int playerId, string playerNick)
        {
            PlayerJoinedEventArgs target = new PlayerJoinedEventArgs(playerId, playerNick);
            return target;
            // TODO: add assertions to method PlayerJoinedEventArgsTest.Constructor(Int32, String)
        }
    }
}
