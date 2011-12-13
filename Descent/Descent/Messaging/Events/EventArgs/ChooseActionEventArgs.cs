
namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Helper enum to make the type of action typesafe in the event scheme.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public enum ActionType
    {
        Advance = 1,
        Run = 2,
        Battle = 3   
    }

    /// <summary>
    /// The event arguments for the ChooseAction event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class ChooseActionEventArgs : GameEventArgs
    {
        public ChooseActionEventArgs(ActionType actionType)
        {
            ActionType = actionType;
        }

        public ChooseActionEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b) && int.Parse(stringArgs[0]) > 0 && int.Parse(stringArgs[0]) < 4);

            PopulateWithArgs(stringArgs);
        }

        public ActionType ActionType { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b) && int.Parse(stringArgs[0]) > 0 && int.Parse(stringArgs[0]) < 4);

            ActionType = (ActionType)Enum.ToObject(typeof(ActionType), int.Parse(stringArgs[0]));
        }

        public override string ToString()
        {
            return ((int)ActionType).ToString();
        }
    }
}
