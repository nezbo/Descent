// -----------------------------------------------------------------------
// <copyright file="EventManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    #region Delegate declarations
    public delegate void AllRespondedNoActionHandler(object sender, EventArgs eventArgs); // Special delegate, contains no eventArgs info.

    public delegate void ChatMessageHandler(object sender, ChatMessageEventArgs eventArgs);
    #endregion

    /// <summary>
    /// Takes strings received from the network and fires the appropriate events. Can also convert an event to a text string and send it.
    /// </summary>
    public class EventManager
    {
        private readonly EventType[] needResponses = new EventType[] { };

        private LinkedList<string> queue = new LinkedList<string>();
        private Dictionary<string, int> responses = new Dictionary<string, int>(); // Key is eventid and int is number of players who responded.
        private int playerCount = 4; // TODO: Get from elsewhere

        private Random random = new Random();

        #region Event declarations

        public event AllRespondedNoActionHandler AllRespondedNoActionEvent;

        public event ChatMessageHandler ChatMessageEvent;

        #endregion

        /// <summary>
        /// Take an event string and puts it on the event queue.
        /// </summary>
        /// <param name="eventString">Event string to queue.</param>
        public void QueueStringEvent(string eventString)
        {
            queue.AddLast(eventString);
        }

        /// <summary>
        /// Queue an event.
        /// </summary>
        /// <param name="eventType">The type of event to queue.</param>
        /// <param name="eventArgs">The event arguments.</param>
        public void QueueEvent(EventType eventType, GameEventArgs eventArgs)
        {
            AddRequiredEventArgs(eventType, eventArgs);
            queue.AddLast(EncodeMessage(eventType, eventArgs));
        }

        /// <summary>
        /// Process the event queue. Will fire all events in the queue and clear it.
        /// </summary>
        public void ProcessEventQueue()
        {

            // Converting to array before looping. If the collection is looped on the state-thread while the
            // gui thread adds a new event, an InvalidOperationException will be thrown. TODO: Should we use a synclock instead?
            foreach (string s in queue.ToArray())
            {
                ParseAndFire(s, true);
            }
            
            queue.Clear();
        }

        /// <summary>
        /// Parse an event string and fire the event.
        /// </summary>
        /// <param name="eventString">The event string.</param>
        /// <param name="sendOnNetwork">Should this event be sent to the other players?</param>
        public void ParseAndFire(string eventString, bool sendOnNetwork)
        {
            // Required parts
            string[] messageParts = eventString.Split(",".ToCharArray());
            int sender = int.Parse(messageParts[0]);
            string eventId = messageParts[1];
            EventType eventType = (EventType)Enum.ToObject(typeof(EventType), int.Parse(messageParts[2]));
            bool needResponse = Convert.ToBoolean(int.Parse(messageParts[3]));
            
            GameEventArgs eventArgs = new GameEventArgs();

            // Optional arguments
            if (messageParts.Length > 4)
            {
                string[] eventArgStrings = new string[messageParts.Length - 4];
                Array.Copy(messageParts, 4, eventArgStrings, 0, messageParts.Length - 4);
                eventArgs = BuildEventArgs(eventType, eventArgStrings);  
            }

            eventArgs.SenderId = sender;
            eventArgs.EventId = eventId;
            eventArgs.EventType = eventType;
            eventArgs.NeedResponse = needResponse;
            
            Fire(eventType, eventArgs, sendOnNetwork);
        }

        #region Private methods
        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="eventType">Type of event.</param>
        /// <param name="eventArgs">The event arguments.</param>
        /// <param name="sendOnNetwork">Should this event be sent to the other players?</param>
        private void Fire(EventType eventType, GameEventArgs eventArgs, bool sendOnNetwork)
        {
            Console.WriteLine("[{0}]: {1}", eventArgs.SenderId, eventType.ToString());

            switch (eventType)
            {
                case EventType.NoAction:
                    AddResponse(eventArgs.EventId);
                    break;
                case EventType.ChatMessage:
                    ChatMessageEvent(this, (ChatMessageEventArgs)eventArgs);
                    break;
            }

            if (sendOnNetwork)
            {
                Player.Instance.Connection.SendString(EncodeMessage(eventType, eventArgs, true)); 
            }
            
        }

        /// <summary>
        /// Log a response to an event that requires responses.
        /// TODO: This method is not correct - FIX IT!
        /// </summary>
        /// <param name="eventId">The event id of response.</param>
        private void AddResponse(string eventId)
        {
            if (!responses.ContainsKey(eventId))
            {
                responses.Add(eventId, 0);
            }
            responses[eventId]++;

            // If we have received responses from everyone but the player itself, we can fire the event and delete from the dictionary.
            if (responses[eventId] >= playerCount - 1)
            {
                this.AllRespondedNoActionEvent(this, new EventArgs());
                responses.Remove(eventId);
            }
        }

        /// <summary>
        /// Populate a <see cref="GameEventArgs"/> object with required fields.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventArgs">The <see cref="GameEventArgs"/> object.</param>
        private void AddRequiredEventArgs(EventType eventType, GameEventArgs eventArgs)
        {
            eventArgs.SenderId = Player.Instance.ID;
            eventArgs.EventId = GenerateEventId();
            eventArgs.EventType = eventType;
            eventArgs.NeedResponse = NeedResponse(eventType);
        }

        /// <summary>
        /// Builds the correct type of <see cref="GameEventArgs"/> object based on the event type.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/></param>
        /// <param name="args">The arguments as strings.</param>
        /// <returns>A <see cref="GameEventArgs"/> object of the correct type, with the correct values set.</returns>
        private GameEventArgs BuildEventArgs(EventType eventType, string[] args)
        {
            switch (eventType)
            {
                case EventType.ChatMessage:
                    return new ChatMessageEventArgs(args);
                default:
                    return new GameEventArgs();
            }
        }

        /// <summary>
        /// Does this kind of <see cref="EventType"/> need a response?
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <returns>True if the event type needs a response, false otherwise.</returns>
        private bool NeedResponse(EventType eventType)
        {
            return needResponses.Contains(eventType);
        }

        /// <summary>
        /// Encode a message to a string.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/>.</param>
        /// <param name="eventArgs">The <see cref="GameEventArgs"/> object.</param>
        /// <returns>The message encoded as a string.</returns>
        private string EncodeMessage(EventType eventType, GameEventArgs eventArgs)
        {
            return string.Join(",", eventArgs.SenderId, eventArgs.EventId, (int)eventArgs.EventType, Convert.ToInt32(eventArgs.NeedResponse), eventArgs.ToString());
        }

        /// <summary>
        /// Generates a unique event id. It's based on the current time, the player ip and the player id.
        /// </summary>
        /// <returns></returns>
        private string GenerateEventId()
        {
            string time = DateTime.Now.Ticks.ToString();
            string ip = Player.Instance.Connection.Ip;
            string id = Player.Instance.ID.ToString();

            //Console.WriteLine("Generating MD5 from {0} {1} {2}", time, ip, id);
            return MD5String(time + ip + id);
        }

        /// <summary>
        /// Generate a MD5 hash from a given string.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The MD5 hash as a string.</returns>
        private string MD5String(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
        #endregion
    }
}
