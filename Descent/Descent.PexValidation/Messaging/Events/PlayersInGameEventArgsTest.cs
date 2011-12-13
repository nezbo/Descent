// <copyright file="PlayersInGameEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PlayersInGameEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlayersInGameEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]PlayersInGameEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PlayersInGameEventArgsTest.ToString01(PlayersInGameEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]PlayersInGameEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method PlayersInGameEventArgsTest.PopulateWithArgs(PlayersInGameEventArgs, String[])
        }
        [PexMethod]
        public PlayersInGameEventArgs Constructor01(string[] stringArgs)
        {
            PlayersInGameEventArgs target = new PlayersInGameEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method PlayersInGameEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public PlayersInGameEventArgs Constructor(PlayerInGame[] playersIngame)
        {
            PlayersInGameEventArgs target = new PlayersInGameEventArgs(playersIngame);
            return target;
            // TODO: add assertions to method PlayersInGameEventArgsTest.Constructor(PlayerInGame[])
        }
    }
}
