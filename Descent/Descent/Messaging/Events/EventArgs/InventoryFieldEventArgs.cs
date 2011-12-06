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
    /// The event arguments for events about a specific invetory field on a hero.
    /// </summary>
    public sealed class InventoryFieldEventArgs : GameEventArgs
    {
        public InventoryFieldEventArgs(int inventoryField)
        {
            Contract.Requires(inventoryField >= 0);
            InventoryField = inventoryField;
        }

        public InventoryFieldEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int InventoryField { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            InventoryField = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return InventoryField.ToString();
        }
    }
}
