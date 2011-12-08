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
    public sealed class EquipEventArgs : GameEventArgs
    {
        public EquipEventArgs(int equipmentId, int inventoryField)
        {
            Contract.Requires(equipmentId > 0);
            Contract.Requires(inventoryField >= 0 && inventoryField <= 10);
            EquipmentId = equipmentId;
            InventoryField = inventoryField;
        }

        public EquipEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            PopulateWithArgs(stringArgs);
        }

        public int EquipmentId { get; set; }

        public int InventoryField { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 2);
            EquipmentId = int.Parse(stringArgs[0]);
            InventoryField = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", EquipmentId, InventoryField);
        }
    }
}
