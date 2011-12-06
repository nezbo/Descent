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
    /// The event arguments for the RequestBuyEquipment event.
    /// </summary>
    public sealed class GiveEquipmentEventArgs : GameEventArgs
    {
        public GiveEquipmentEventArgs(int playerId, int equipmentId)
        {
            Contract.Requires(playerId > 0);
            Contract.Requires(equipmentId > 0);

            PlayerId = playerId;
            EquipmentId = equipmentId;
        }

        public GiveEquipmentEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public int EquipmentId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            PlayerId = int.Parse(stringArgs[0]);
            EquipmentId = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId, EquipmentId);
        }
    }
}
