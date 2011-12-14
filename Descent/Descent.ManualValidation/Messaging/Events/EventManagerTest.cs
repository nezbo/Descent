using NUnit.Framework;

namespace Descent.ManualValidation.Messaging.Events
{
    using Descent.Messaging.Connection;
    using Descent.Messaging.Events;
    using Descent.Model.Player;

    [TestFixture]
    public class EventManagerTest
    {
        private Connection serverConnection;

        private EventManager eventManager;

        [SetUp]
        public void Setup()
        {
            serverConnection = new ServerConnection(1337);
            serverConnection.Start();
            Player.Instance.JoinGame("127.0.0.1", 1337);
            eventManager = Player.Instance.EventManager;
        }

        [TearDown]
        public void Teardown()
        {
            serverConnection.Close();
            Player.Instance.Connection.Close();
        }

        [Test]
        public void TestEventQueueNormal()
        {
            bool eventFired = false;

            eventManager.GiveCoinsEvent += (sender, eventArgs) => eventFired = true;
            
            eventManager.QueueEvent(EventType.GiveCoins, new GiveCoinsEventArgs(1, 100));
            
            eventManager.ProcessEventQueue();

            Assert.True(eventFired);
        }

        [Test]
        public void TestEventQueueString()
        {
            bool eventFired = false;

            eventManager.ChatMessageEvent += (sender, eventArgs) => eventFired = true;

            eventManager.QueueStringEvent("2,id,14,0,chatmessage");

            eventManager.ProcessEventQueue();

            Assert.True(eventFired);
        }
    }
}
