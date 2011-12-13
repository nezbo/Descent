
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events sending only coordinates.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class CoordinatesEventArgs : GameEventArgs
    {
        public CoordinatesEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CoordinatesEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));

            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));

            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", X.ToString(), Y.ToString());
        }
    }
}
