// -----------------------------------------------------------------------
// <copyright file="ChatMessageEventArgs.cs" company="">
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
    /// The event arguments for the ChatMessage event.
    /// </summary>
    public sealed class ChatMessageEventArgs : GameEventArgs
    {
        public ChatMessageEventArgs(string message)
        {
            Message = message;
        }

        public ChatMessageEventArgs(string[] stringArgs)
        {
            PopulateWithArgs(stringArgs);
        }

        public string Message { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Message = string.Concat(stringArgs);
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
