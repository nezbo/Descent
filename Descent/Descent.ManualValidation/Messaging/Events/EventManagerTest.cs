using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Descent.ManualValidation.Messaging.Events
{
    using Descent.Messaging.Events;

    [TestFixture]
    public class EventManagerTest
    {
        [Test]
        public void TestEventQueue()
        {
            EventManager eventManager = new EventManager();

            bool eventFired = false;

            eventManager.GiveCoinsEvent += (sender, eventArgs) => eventFired = true;

            eventManager.QueueEvent(EventType.GiveCoins, new GiveCoinsEventArgs(1, 100));

            eventManager.ProcessEventQueue();

            Assert.True(eventFired);
        }
    }
}
