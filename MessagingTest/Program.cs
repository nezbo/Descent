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

            EventManager eventManager = Player.Instance.EventManager;

            eventManager.ChatMessageEvent += new ChatMessageHandler((sender, eventArgs) => Console.WriteLine("Received chat event from {0}: {1}", eventArgs.SenderId, eventArgs));

            eventManager.AllRespondedNoActionEvent += new AllRespondedNoActionHandler((sender, eventArgs) => Console.WriteLine("Received responses from all other players"));

            eventManager.AcceptPlayerEvent += new AcceptPlayerHandler(
                (sender, eventArgs) =>
                    {
                        if (eventArgs.PlayerId == Player.Instance.Id)
                        {
                            Player.Instance.Nickname = "Simon";
                            eventManager.QueueEvent(EventType.PlayerJoined, new PlayerJoinedEventArgs(Player.Instance.Id, Player.Instance.Nickname));
                        }
                    });

            eventManager.PlayerJoinedEvent += new PlayerJoinedHandler(
                (sender, eventArgs) =>
                    {
                        Console.WriteLine("PlayerJoined: " + eventArgs.PlayerNick);
                        Player.Instance.SetPlayerNick(eventArgs.PlayerId, eventArgs.PlayerNick);
                        if (Player.Instance.IsServer) eventManager.FirePlayersInGameEvent();
                        Console.WriteLine("Number of players: " + Player.Instance.NumberOfPlayers);
                    }   
            );

            eventManager.PlayersInGameEvent += new PlayersInGameHandler(
                (sender, eventArgs) =>
                    {
                        foreach (PlayerInGame p in eventArgs.Players)
                        {
                            Player.Instance.SetPlayerNick(p.Id, p.Nickname);
                        }
                        Console.WriteLine("Number of players: " + Player.Instance.NumberOfPlayers);
                    }
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

            if (type.Equals("client"))
            {
                Thread spamThread = new Thread(SpamThread);
                spamThread.Start();
            }

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

        static void SpamThread()
        {
            while (true)
            {
                //Thread.Sleep(10);
                Player.Instance.EventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs("Herp derp derp derp derp derp"));
            }
        }
    }
}
