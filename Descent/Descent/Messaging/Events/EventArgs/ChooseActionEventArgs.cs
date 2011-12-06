// -----------------------------------------------------------------------
// <copyright file="PlayerJoinedEventArgs.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Helper enum to make the type of action typesafe in the event scheme.
    /// </summary>
    public enum ActionType
    {
        Advance = 1,
        Run = 2,
        Battle = 3   
    }

    /// <summary>
    /// The event arguments for the ChooseAction event.
    /// </summary>
    public sealed class ChooseActionEventArgs : GameEventArgs
    {
        public ChooseActionEventArgs(ActionType actionType)
        {
            ActionType = actionType;
        }

        public ChooseActionEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public ActionType ActionType { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);

            ActionType = (ActionType)Enum.ToObject(typeof(ActionType), int.Parse(stringArgs[0]));
        }

        public override string ToString()
        {
            return ((int)ActionType).ToString();
        }
    }
}
