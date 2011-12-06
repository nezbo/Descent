using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagingTest
{
    using System.Threading;

    using Descent.Messaging.Events;
    using Descent.Model.Player;

    class Program
    {
        static void Main(string[] args)
        {

            RolledDicesEventArgs rEventArgs = new RolledDicesEventArgs(new string[] {"0", "2", "1", "6"});
            Console.WriteLine(rEventArgs);

            Player.Instance.Nickname = "Simon";
            EventManager eventManager = Player.Instance.EventManager;

            eventManager.ChatMessageEvent += new ChatMessageHandler((sender, eventArgs) => Console.WriteLine("Received chat event from {0}: {1}", eventArgs.SenderId, eventArgs));

            eventManager.AllRespondedNoActionEvent += new AllRespondedNoActionHandler((sender, eventArgs) => Console.WriteLine("Received responses from all other players"));

            eventManager.PlayerJoinedEvent += new PlayerJoinedHandler(
                (sender, eventArgs) => 
                    Player.Instance.SetPlayerNick(eventArgs.PlayerId, eventArgs.PlayerNick)
             );

            Console.WriteLine("Enter 'server' for server mode or 'client' for client mode.");
            string type = Console.ReadLine();

            if (type.Equals("server"))
            {
                Console.WriteLine("Enter port");
                int port = int.Parse(Console.ReadLine());
                Player.Instance.StartGame(port);
                Console.WriteLine("Server started");
            }
            else
            {
                Console.WriteLine("Enter ip");
                string ip = Console.ReadLine();
                Console.WriteLine("Enter port");
                int port = int.Parse(Console.ReadLine());
                Player.Instance.JoinGame(ip, port);
                Console.WriteLine("Connection established");
            }

            Thread updateThread = new Thread(Update);
            updateThread.Start();

            while (true)
            {
                string eventString = Console.ReadLine();
                eventManager.ParseAndFire(eventString, true);
            }


            /*
            string type = Console.ReadLine();
            if (type.Equals("server"))
            {
                AsyncSocketsServer server = new AsyncSocketsServer(1234);
                server.Start();  
            }
            else
            {
                AsyncSocketsClient socketClient = new AsyncSocketsClient("127.0.0.1", 1234);
                ClientInfo clientInfo = new ClientInfo(socketClient.Socket);

                while (true)
                {
                    clientInfo.Send(Console.ReadLine());
                }
                
            }
             */


            Console.ReadLine();
        }

        static void Update()
        {
            while (true)
            {
                Player.Instance.EventManager.ProcessEventQueue();
            }
        }
    }
}
