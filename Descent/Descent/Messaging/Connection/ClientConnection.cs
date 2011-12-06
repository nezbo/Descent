// -----------------------------------------------------------------------
// <copyright file="ClientConnection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Connection
{
    using System;
    using Descent.Messaging.AsyncSockets;
    using Descent.Messaging.Events;
    using Descent.Model.Player;

    /// <summary>
    /// A TCP client connected to the host server. When sending a message, it will send only to the server at the other end of the connection.
    /// </summary>
    public class ClientConnection : Connection
    {
        private ClientInfo client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientConnection"/> class. 
        /// </summary>
        /// <param name="ip">Ip of server.</param>
        /// <param name="port">Port of server.</param>
        public ClientConnection(string ip, int port)
        {
            RemoteIp = ip;
            RemotePort = port;
        }

        public override int Id { get { return client.Id; } }

        public override string Ip { get { return client.Ip; } }

        private string RemoteIp { get; set; }

        private int RemotePort { get; set; }

        public override void Start()
        {
            AsyncSocketsClient socketsClient = new AsyncSocketsClient(RemoteIp, RemotePort);
            client = new ClientInfo(socketsClient.Socket);
            client.MessageReceivedEvent += new MessageReceivedHandler(MessageReceived);
            client.BeginReceive();
        }

        public override void SendString(string message)
        {
            client.Send(message);
        }

        /// <summary>
        /// Called when a message was received from the connection.
        /// </summary>
        /// <param name="clientInfo"><see cref="ClientInfo"/> object</param>
        /// <param name="message">String that was received.</param>
        private void MessageReceived(ClientInfo clientInfo, string message)
        {
            // Split up the message to check for special messages.
            string[] split = message.Split(",".ToCharArray());

            if (split[0].Equals("ASSIGNID"))
            {
                client.Id = int.Parse(split[1]);
                Console.WriteLine("RECEIVED ID: " + client.Id);
                
                // PlayerJoined event
                Player.Instance.EventManager.QueueEvent(EventType.PlayerJoined, new PlayerJoinedEventArgs(client.Id, Player.Instance.Name)); // TODO: Insert player nickname
            }
            else
            {
                // It was not a special message, pass it on to the event manager.
                Player.Instance.EventManager.ParseAndFire(message, false);
            }
        }
    }
}
