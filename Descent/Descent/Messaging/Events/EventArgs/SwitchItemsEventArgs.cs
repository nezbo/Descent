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
    /// The event arguments for events about equipping and unequipping equipments at a special inventory fields.
    /// </summary>
    public sealed class SwitchItemsEventArgs : GameEventArgs
    {
        public SwitchItemsEventArgs(int field1, int field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        public SwitchItemsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            PopulateWithArgs(stringArgs);
        }

        public int Field1 { get; set; }

        public int Field2 { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            Field1 = int.Parse(stringArgs[0]);
            Field2 = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", Field1, Field2);
        }
    }
}
