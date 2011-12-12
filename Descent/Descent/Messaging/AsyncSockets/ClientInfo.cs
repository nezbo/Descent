
namespace Descent.Messaging.AsyncSockets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// Stores information about a client connection.
    /// </summary>
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
            socket = clientSocket;
            Id = nextId++;
        }

        public event MessageReceivedHandler MessageReceivedEvent;

        public event ConnectionClosedHandler ConnectionClosedEvent;

        public int Id { get; set; }

        public string Ip { get { return ((IPEndPoint)socket.LocalEndPoint).Address.ToString(); } }

        /// <summary>
        /// Send a string.
        /// </summary>
        /// <param name="message">String to send</param>
        public void Send(string message)
        {
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

                // Check for end of message
                if (content.IndexOf("<EOF>") > -1)
                {

                    while (content.IndexOf("<EOF>") > -1)
                    {
                        string newMessage = content.Substring(0, content.IndexOf("<EOF>"));
                        content = content.Substring(newMessage.Length + 5, content.Length - newMessage.Length - 5);

                        System.Console.WriteLine("Message: " + newMessage);

                        if (MessageReceivedEvent != null)
                        {
                            MessageReceivedEvent(this, newMessage);
                        }
                    }

                    str.Clear();
                }

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
