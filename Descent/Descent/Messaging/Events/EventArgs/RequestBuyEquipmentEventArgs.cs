
﻿namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the RequestBuyEquipment event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class RequestBuyEquipmentEventArgs : GameEventArgs
    {
        public RequestBuyEquipmentEventArgs(int equipmentId)
        {
            Contract.Requires(equipmentId > 0);
            EquipmentId = equipmentId;
        }

        public RequestBuyEquipmentEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));

            PopulateWithArgs(stringArgs);
        }

        public int EquipmentId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));

            EquipmentId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return EquipmentId.ToString();
        }
    }
}
