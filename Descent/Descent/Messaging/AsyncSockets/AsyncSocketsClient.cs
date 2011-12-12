
namespace Descent.Messaging.AsyncSockets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public delegate void MessageReceivedHandler(ClientInfo clientInfo, string message);

    public delegate void ConnectionClosedHandler(ClientInfo clientInfo);
 
    /// <summary>
    /// Implementation of the asynchronous sockets client.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public class AsyncSocketsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncSocketsClient"/> class. 
        /// </summary>
        /// <param name="address">Address of the server to connect to.</param>
        /// <param name="port">Port of the server to connect to.</param>
        public AsyncSocketsClient(string address, int port)
        {
            IPAddress host = Dns.GetHostAddresses(address)[0];
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Connect(new IPEndPoint(host, port));
        }

        public Socket Socket { get; private set; }
    }
}
