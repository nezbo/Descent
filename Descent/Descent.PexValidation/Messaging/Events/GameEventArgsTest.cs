// <copyright file="GameEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(GameEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class GameEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]GameEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method GameEventArgsTest.ToString01(GameEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]GameEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method GameEventArgsTest.PopulateWithArgs(GameEventArgs, String[])
        }
        [PexMethod]
        public GameEventArgs Constructor(
            int senderID,
            string eventID,
            EventType eventType,
            bool needResponse
        )
        {
            GameEventArgs target = new GameEventArgs(senderID, eventID, eventType, needResponse);
            return target;
            // TODO: add assertions to method GameEventArgsTest.Constructor(Int32, String, EventType, Boolean)
        }
    }
}
