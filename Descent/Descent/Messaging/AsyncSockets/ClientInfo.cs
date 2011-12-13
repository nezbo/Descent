
namespace Descent.Messaging.AsyncSockets
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// Stores information about a client connection.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public class ClientInfo
    {
        private const int BUFSIZE = 1024;

        private readonly Socket socket;

        private static int nextId = 2;

        private StringBuilder str = new StringBuilder();

        private byte[] buf = new byte[BUFSIZE];

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientInfo"/> class. 
        /// </summary>
        /// <param name="clientSocket">Socket of the client.</param>
        public ClientInfo(Socket clientSocket)
        {
            Contract.Requires(clientSocket != null);

            socket = clientSocket;
            Id = nextId++;
        }

        /// <summary>
        /// This event is fired when a message is received.
        /// </summary>
        public event MessageReceivedHandler MessageReceivedEvent;

        /// <summary>
        /// This event is fired when a connection is closed.
        /// </summary>
        public event ConnectionClosedHandler ConnectionClosedEvent;

        /// <summary>
        /// Gets or sets the id of the client.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the ip of the client.
        /// </summary>
        public string Ip { get { return ((IPEndPoint)socket.LocalEndPoint).Address.ToString(); } }

        /// <summary>
        /// Send a string.
        /// </summary>
        /// <param name="message">String to send</param>
        public void Send(string message)
        {
            Contract.Requires(message != null);

            // Sends through the socket. Appends <EOF> to indicate end of message.
            socket.Send(Encoding.UTF8.GetBytes(message + "<EOF>"));
        }

        /// <summary>
        /// Begin receiving data asynchronously.
        /// </summary>
        public void BeginReceive()
        {
            socket.BeginReceive(buf, 0, BUFSIZE, 0, new AsyncCallback(BeginReceiveCallback), this);
        }

        /// <summary>
        /// Called when data was received.
        /// </summary>
        /// <param name="asyncResult">Async result</param>
        private void BeginReceiveCallback(IAsyncResult asyncResult)
        {
            int read = socket.EndReceive(asyncResult);

            if (read > 0)
            {
                // Append to string buffer
                str.Append(Encoding.UTF8.GetString(buf, 0, read));

                string content = str.ToString();

                // If and while we have an EOF marker, we would like to parse messages.
                // When no marker is left, we're done and need to receive more data.
                while (content.IndexOf("<EOF>") > -1)
                {
                    // Gets the first message in the content string.
                    string newMessage = content.Substring(0, content.IndexOf("<EOF>"));
                        
                    // Remove the new message from our content string.
                    content = content.Substring(newMessage.Length + 5, content.Length - newMessage.Length - 5);

                    // Fire message received event.
                    if (MessageReceivedEvent != null)
                    {
                        MessageReceivedEvent(this, newMessage);
                    }
                }

                str.Clear();
                str.Append(content);

                BeginReceive();
            }
            else
            {
                // No data received - connection closed
                ConnectionClosedEvent(this);
            }
        }
    }
}
