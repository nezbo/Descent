// -----------------------------------------------------------------------
// <copyright file="GameEventArgs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
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
            this.SenderId = senderID;
            this.EventId = eventID;
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
