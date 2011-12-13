namespace Descent.Messaging.Connection
{
    using System;
    using AsyncSockets;

    using Descent.Model.Player;
    using Descent.State;

    /// <summary>
    /// A TCP server connection.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public class ServerConnection : Connection
    {
        private AsyncSocketsServer mServer;

        public ServerConnection(int port)
        {
            ServerPort = port;
        }

        /// <summary>
        /// Gets the id of the connection. Always 1 for the server!
        /// </summary>
        public override int Id { get { return 1; } }

        /// <summary>
        /// Gets the ips of the server.
        /// </summary>
        public override string[] Ips { get { return mServer.Ips; } }

        /// <summary>
        /// Get or set the server port to use.
        /// </summary>
        private int ServerPort { get; set; }

        /// <summary>
        /// Start the server. Will listen on port for new clients.
        /// </summary>
        public override void Start()
        {
            mServer = new AsyncSocketsServer(ServerPort);
            mServer.ClientConnectedEvent += new ClientConnectedHandler(ClientConnected);
            mServer.Start();
        }

        /// <summary>
        /// Sends a string through the server. Will send to all clients except the sender of the message.
        /// </summary>
        /// <param name="message">The string to send.</param>
        public override void SendString(string message)
        {
            int messageSenderId = int.Parse(message.Split(",".ToCharArray())[0]);
            mServer.BroadcastExceptClient(message, messageSenderId);
        } 

        /// <summary>
        /// Called when a client has connected.
        /// </summary>
        /// <param name="newClient">The new client.</param>
        /// <returns>True to accept the client (leave him connected), false to disconnect him again.</returns>
        private bool ClientConnected(ClientInfo newClient)
        {
            newClient.MessageReceivedEvent += new MessageReceivedHandler(MessageReceived);

            return AcceptProcedure(newClient);
        }

        /// <summary>
        /// Called when a message was received.
        /// </summary>
        /// <param name="fromClient">Sender of the message.</param>
        /// <param name="message">The message string.</param>
        private void MessageReceived(ClientInfo fromClient, string message)
        {
            Player.Instance.EventManager.QueueStringEvent(message, false);
            SendString(message);
        }

        /// <summary>
        /// Decides if a new client can join the server.
        /// </summary>
        /// <param name="newClient">The client attempting to join server.</param>
        /// <returns>True to accept the client (leave him connected), false to disconnect him again.</returns>
        private bool AcceptProcedure(ClientInfo newClient)
        {
            // Only accept the player if we're not full and we're still in the lobby, waiting for the game to start.
            if (Player.Instance.NumberOfPlayers < 5 && Player.Instance.StateManager.CurrentState == State.InLobby)
            {
                newClient.Send("ASSIGNID," + newClient.Id); // Send back the ID to the player.
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
