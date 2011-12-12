
namespace Descent.Messaging.Connection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Abstraction of a connection. Can send text messages.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public abstract class Connection
    {
        /// <summary>
        /// Gets the id of the connection. See <see cref="Descent.Messaging.AsyncSockets.ClientInfo"/>.
        /// </summary>
        public abstract int Id { get; }

        /// <summary>
        /// Gets the ip of the connection. See <see cref="Descent.Messaging.AsyncSockets.ClientInfo"/>.
        /// </summary>
        public abstract string[] Ips { get; }

        /// <summary>
        /// Initiate connection and start receiving data.
        /// </summary>
        public abstract void Start();

        /// <summary>
        ///  Send a text string.
        /// </summary>
        /// <param name="message">String to send.</param>
        public abstract void SendString(string message);
    }
}
