// <copyright file="ChatMessageEventArgsTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(ChatMessageEventArgs))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ChatMessageEventArgsTest
    {
        [PexMethod]
        public string ToString01([PexAssumeUnderTest]ChatMessageEventArgs target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method ChatMessageEventArgsTest.ToString01(ChatMessageEventArgs)
        }
        [PexMethod]
        public void PopulateWithArgs([PexAssumeUnderTest]ChatMessageEventArgs target, string[] stringArgs)
        {
            target.PopulateWithArgs(stringArgs);
            // TODO: add assertions to method ChatMessageEventArgsTest.PopulateWithArgs(ChatMessageEventArgs, String[])
        }
        [PexMethod]
        public ChatMessageEventArgs Constructor01(string[] stringArgs)
        {
            ChatMessageEventArgs target = new ChatMessageEventArgs(stringArgs);
            return target;
            // TODO: add assertions to method ChatMessageEventArgsTest.Constructor01(String[])
        }
        [PexMethod]
        public ChatMessageEventArgs Constructor(string message)
        {
            ChatMessageEventArgs target = new ChatMessageEventArgs(message);
            return target;
            // TODO: add assertions to method ChatMessageEventArgsTest.Constructor(String)
        }
    }
}
