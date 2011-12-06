﻿// -----------------------------------------------------------------------
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
    public sealed class RequestBuyEquipmentEventArgs : GameEventArgs
    {
        public RequestBuyEquipmentEventArgs(int equipmentId)
        {
            Contract.Requires(equipmentId > 0);
            EquipmentId = equipmentId;
        }

        public RequestBuyEquipmentEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int EquipmentId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            EquipmentId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return EquipmentId.ToString();
        }
    }
}