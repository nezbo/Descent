
namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The standard event arguments class. Has sender id, event id, event type and a bool indicating whether the message needs a response.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public class GameEventArgs : EventArgs
    {
        public GameEventArgs()
        {  
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEventArgs"/> class. 
        /// </summary>
        /// <param name="senderID">ID of the sender. See <see cref="Descent.Messaging.Connection"/></param>
        /// <param name="eventID">ID of the event (MD5 hash).</param>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <param name="needResponse">Does this event need a response from the other players?</param>
        public GameEventArgs(int senderID, string eventID, EventType eventType, bool needResponse)
        {
            Contract.Requires(senderID >= 1 && senderID <= 5);
            Contract.Requires(eventID != null);
            SenderId = senderID;
            EventId = eventID;
            EventType = eventType;
            NeedResponse = needResponse;
        }

        public int SenderId { get; set; }

        public string EventId { get; set; }

        public EventType EventType { get; set; }

        public bool NeedResponse { get; set; }

        public virtual void PopulateWithArgs(string[] stringArgs)
        {   
        }
        
        /// <summary>
        /// This should return the special message arguments, seperated by a "," in the right order.
        /// </summary>
        /// <returns>Event arguments as the formated comma-seperated string.</returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
