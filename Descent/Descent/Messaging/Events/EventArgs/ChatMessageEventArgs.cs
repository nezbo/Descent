﻿
namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for the ChatMessage event.
    /// </summary>
    public sealed class ChatMessageEventArgs : GameEventArgs
    {
        public ChatMessageEventArgs(string message)
        {
            Contract.Requires(message != null);
            Message = message;
        }

        public ChatMessageEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public string Message { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            Message = string.Concat(stringArgs);
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
