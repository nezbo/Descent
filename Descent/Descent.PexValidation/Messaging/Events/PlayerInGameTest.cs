// <copyright file="PlayerInGameTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(PlayerInGame))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PlayerInGameTest
    {
        [PexMethod]
        public PlayerInGame Constructor(int id, string nickname)
        {
            PlayerInGame target = new PlayerInGame(id, nickname);
            return target;
            // TODO: add assertions to method PlayerInGameTest.Constructor(Int32, String)
        }
    }
}
