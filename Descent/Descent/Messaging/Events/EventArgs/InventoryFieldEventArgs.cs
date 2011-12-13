namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events about equipping and unequipping equipments at a special inventory fields.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class InventoryFieldEventArgs : GameEventArgs
    {
        public InventoryFieldEventArgs(int inventoryField)
        {
            Contract.Requires(inventoryField >= 0);
            InventoryField = inventoryField;
        }

        public InventoryFieldEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s)));
            Contract.Requires(int.Parse(stringArgs[0]) >= 0);

            PopulateWithArgs(stringArgs);
        }

        public int EquipmentId { get; set; }

        public int InventoryField { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s)));
            Contract.Requires(int.Parse(stringArgs[0]) >= 0);
            InventoryField = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return InventoryField.ToString();
        }
    }
}
