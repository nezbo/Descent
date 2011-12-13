
﻿namespace Descent.Messaging.Events

{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the RolledDices event.
    /// Example on arguments: 1,4,4,2
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class RolledDicesEventArgs : GameEventArgs
    {
        public RolledDicesEventArgs(int[] rolledSides)
        {
            Contract.Requires(rolledSides != null);
            Contract.Requires(rolledSides.Length > 0);

            RolledSides = rolledSides;
        }

        public RolledDicesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length >= 1);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));

            PopulateWithArgs(stringArgs);
        }

        public int[] RolledSides { get; set; }


        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length >= 1);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));

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