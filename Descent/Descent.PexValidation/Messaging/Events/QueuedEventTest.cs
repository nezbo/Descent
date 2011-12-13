// <copyright file="QueuedEventTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(QueuedEvent))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class QueuedEventTest
    {
        [PexMethod]
        public string ToString01(QueuedEvent target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method QueuedEventTest.ToString01(QueuedEvent)
        }
        [PexMethod]
        public QueuedEvent Constructor(string eventString, bool broadcast)
        {
            QueuedEvent target = new QueuedEvent(eventString, broadcast);
            return target;
            // TODO: add assertions to method QueuedEventTest.Constructor(String, Boolean)
        }
    }
}
