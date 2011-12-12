
namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The event arguments for events sending a number of tokens.
    /// </summary>
    public sealed class ChestEventArgs : GameEventArgs
    {
        public ChestEventArgs(int chestId)
        {
            Contract.Requires(chestId >= 0);

            ChestId = chestId;
        }

        public ChestEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int ChestId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);

            ChestId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return ChestId.ToString();
        }
    }
}
