// -----------------------------------------------------------------------
// <copyright file="ServerConnection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Connection
{
    using System;
    using AsyncSockets;

    using Descent.Model.Player;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ServerConnection : Connection
    {
        private AsyncSocketsServer mServer;

        public ServerConnection(int port)
        {
            ServerPort = port;
        }

        public override int Id { get { return 1; } } // Server is always ID 1

        public override string Ip { get { return mServer.Ip; } }

        private int ServerPort { get; set; }

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
            //Console.WriteLine("SERVER RECEIVED [{0}]: {1}", fromClient.Id, message);
            Player.Instance.EventManager.ParseAndFire(message, false);
            SendString(message);
        }

        /// <summary>
        /// Decides if a new client can join the server.
        /// </summary>
        /// <param name="newClient">The client attempting to join server.</param>
        /// <returns>True to accept the client (leave him connected), false to disconnect him again.</returns>
        private bool AcceptProcedure(ClientInfo newClient)
        {
            if (Player.Instance.NumberOfPlayers < 5)
            {
                // TODO: Check that the game state is open for joining
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
