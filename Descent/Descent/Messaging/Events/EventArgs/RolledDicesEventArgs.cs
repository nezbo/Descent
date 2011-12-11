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

    using Descent.Model;

    /// <summary>
    /// The event arguments for the RolledDices event.
    /// Example on arguments: 0,2,1,6 - Two dice rolls, dice 0 rolled to side 2, dice 1 rolled to side 6.
    /// </summary>
    public sealed class RolledDicesEventArgs : GameEventArgs
    {
        public RolledDicesEventArgs(int[] rolledSides)
        {
            Contract.Requires(rolledSides.Length > 0);
            RolledSides = rolledSides;
        }

        public RolledDicesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public int[] RolledSides { get; set; }


        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            RolledSides = new int[stringArgs.Length];

            for (int i = 0; i < stringArgs.Length; i++)
            {
                RolledSides[i] = int.Parse(stringArgs[i]);
            }
        }

        public override string ToString()
        {
            return string.Join(",", RolledSides);
        }
    }
}