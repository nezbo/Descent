
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the InflictWounds event;
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class InflictWoundsEventArgs : GameEventArgs
    {
        public InflictWoundsEventArgs(int x, int y, int damage, int pierce)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(damage >= 0);
            Contract.Requires(pierce >= 0);

            X = x;
            Y = y;
            Damage = damage;
            Pierce = pierce;
        }

        public InflictWoundsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 4);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));
            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Damage { get; set; }

        public int Pierce { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 4);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));
            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
            Damage = int.Parse(stringArgs[2]);
            Pierce = int.Parse(stringArgs[3]);
        }

        public override string ToString()
        {
            return string.Join(",", X, Y, Damage, Pierce);
        }
    }
}
