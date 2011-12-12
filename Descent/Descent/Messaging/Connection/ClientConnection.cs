
namespace Descent.Messaging.Connection
{
    using System;
    using Descent.Messaging.AsyncSockets;
    using Descent.Messaging.Events;
    using Descent.Model.Player;

    /// <summary>
    /// A TCP client connected to the host server. When sending a message, it will send only to the server at the other end of the connection.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public class ClientConnection : Connection
    {
        private ClientInfo client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientConnection"/> class.
        /// Responsible for client connections to the host/server.
        /// </summary>
        /// <param name="ip">Ips of server.</param>
        /// <param name="port">Port of server.</param>
        public ClientConnection(string ip, int port)
        {
            RemoteIp = ip;
            RemotePort = port;
        }

        /// <summary>
        /// Gets the id of the client.
        /// </summary>
        public override int Id { get { return client.Id; } }

        /// <summary>
        /// Gets the clients ip.
        /// </summary>
        public override string[] Ips { get { return new string[] { client.Ip }; } }

        /// <summary>
        /// Gets or sets the remote ip this client is connected to.
        /// </summary>
        private string RemoteIp { get; set; }

        /// <summary>
        /// Gets or sets the remote port this client is connected to.
        /// </summary>
        private int RemotePort { get; set; }

        /// <summary>
        /// Beging the client connection. Will connect to specified host and begin receiving data.
        /// </summary>
        public override void Start()
        {
            AsyncSocketsClient socketsClient = new AsyncSocketsClient(RemoteIp, RemotePort);
            client = new ClientInfo(socketsClient.Socket);
            client.MessageReceivedEvent += new MessageReceivedHandler(MessageReceived);
            client.BeginReceive();
        }

        /// <summary>
        /// Send a string to the host.
        /// </summary>
        /// <param name="message">Message to send.</param>
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

            /// SPECIAL CASE: ASSIGN ID.
            if (split[0].Equals("ASSIGNID"))
            {
                client.Id = int.Parse(split[1]);
                
                Player.Instance.EventManager.QueueEvent(EventType.AcceptPlayer, new PlayerEventArgs(client.Id));
            }
            else
            {
                // It was not a special message, pass it on to the event manager.
                Player.Instance.EventManager.ParseAndFire(message, false);
            }
        }
    }
}
