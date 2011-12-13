// -----------------------------------------------------------------------
// <copyright file="EventContractHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Messaging.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Helper for contracts in events.
    /// </summary>
    public class EventContractHelper
    {
        public static bool TryParseInt(string str)
        {
            int success;
            return int.TryParse(str, out success);
        }
    }
}
