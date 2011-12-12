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
            InventoryField = inventoryField;
        }

        public InventoryFieldEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int EquipmentId { get; set; }

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
