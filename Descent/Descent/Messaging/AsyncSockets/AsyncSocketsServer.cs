// -----------------------------------------------------------------------
// <copyright file="AsyncSocketsServer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.AsyncSockets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public delegate bool ClientConnectedHandler(ClientInfo clientInfo);

    /// <summary>
    /// Implementation of the asynchronous sockets server.
    /// </summary>
    public class AsyncSocketsServer
    {
        
        private byte[] bytes = new byte[1024];

        private Socket socket;

        private int port;

        // Contains all the connected clients.
        private Dictionary<int, ClientInfo> clients = new Dictionary<int, ClientInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncSocketsServer"/> class. 
        /// </summary>
        /// <param name="port">
        /// Port that the server should use.
        /// </param>
        public AsyncSocketsServer(int port)
        {
            this.port = port;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// This event will be fired when a client has connected.
        /// </summary>
        public event ClientConnectedHandler ClientConnectedEvent;

        public string Ip { get { return ((IPEndPoint)socket.LocalEndPoint).Address.ToString(); } }

        /// <summary>
        /// Start listening and accepting clients.
        /// </summary>
        public void Start()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(100);

            socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
        }

        /// <summary>
        /// Broadcast a string to all connected clients.
        /// </summary>
        /// <param name="message">The string to broadcast</param>
        public void Broadcast(string message)
        {
            foreach (ClientInfo clientInfo in clients.Values)
            {
                clientInfo.Send(message);
            }
        }

        /// <summary>
        /// Broadcast a string to all connected clients except one.
        /// </summary>
        /// <param name="message">The string to broadcast</param>
        /// <param name="clientId">The client which the server shouldn't send to.</param>
        public void BroadcastExceptClient(string message, int clientId)
        {
            foreach (ClientInfo clientInfo in clients.Values)
            {
                if (clientInfo.Id != clientId) clientInfo.Send(message);
            }
        }

        /// <summary>
        /// Called when a client was connected.
        /// </summary>
        /// <param name="asyncResult">Asynchronous result</param>
        private void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket server = (Socket)asyncResult.AsyncState;
            Socket client = server.EndAccept(asyncResult);

            ClientInfo clientInfo = new ClientInfo(client);

            server.BeginAccept(new AsyncCallback(AcceptCallback), server);

            // If we have a delegate and he returns false, we close the connection.
            if (ClientConnectedEvent != null && !ClientConnectedEvent(clientInfo))
            {
                client.Close();
                return;
            }

            // Add client to collection of clients
            clients.Add(clientInfo.Id, clientInfo);

            clientInfo.ConnectionClosedEvent += new ConnectionClosedHandler(ClientConnectionDisconnected);

            // Start receiving data. See ClientInfo class for details.
            clientInfo.BeginReceive();
        }

        /// <summary>
        /// Called when a client disconnects. Removes the client from the collection.
        /// </summary>
        /// <param name="clientInfo">Disconnected client</param>
        private void ClientConnectionDisconnected(ClientInfo clientInfo)
        {
            clients.Remove(clientInfo.Id);
        }
    }
}
