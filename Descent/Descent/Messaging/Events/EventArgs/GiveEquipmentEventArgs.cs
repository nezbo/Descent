
namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the GiveEquipment event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class GiveEquipmentEventArgs : GameEventArgs
    {
        public GiveEquipmentEventArgs(int playerId, int equipmentId, bool free = false)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(equipmentId > 0);

            PlayerId = playerId;
            EquipmentId = equipmentId;
            Free = free;
        }

        public GiveEquipmentEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int EquipmentId { get; set; }

        public bool Free { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            PlayerId = int.Parse(stringArgs[0]);
            EquipmentId = int.Parse(stringArgs[1]);
            Free = Convert.ToBoolean(int.Parse(stringArgs[2]));
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId, EquipmentId, Convert.ToInt32(Free));
        }
    }
}
