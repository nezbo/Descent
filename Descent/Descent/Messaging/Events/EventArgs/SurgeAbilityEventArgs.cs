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
    public sealed class SurgeAbilityEventArgs : GameEventArgs
    {
        public SurgeAbilityEventArgs(int abilityId)
        {
            AbilityId = abilityId;
        }

        public SurgeAbilityEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int AbilityId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            AbilityId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return AbilityId.ToString();
        }
    }
}
