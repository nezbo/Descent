// <copyright file="EventManagerTest.cs">Copyright ©  2011</copyright>

using System;
using Descent.Messaging.Events;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Descent.Messaging.Events
{
    [TestClass]
    [PexClass(typeof(EventManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EventManagerTest
    {
        [PexMethod]
        public EventManager Constructor()
        {
            EventManager target = new EventManager();
            return target;
            // TODO: add assertions to method EventManagerTest.Constructor()
        }
    }
}
