
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the SpawnMonster event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class SpawnMonsterEventArgs : GameEventArgs
    {
        public SpawnMonsterEventArgs(int x, int y, int monsterId)
        {
            Contract.Requires(x >= 0);
            Contract.Requires(y >= 0);
            Contract.Requires(monsterId >= 0);

            X = x;
            Y = y;
            MonsterId = monsterId;
        }

        public SpawnMonsterEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 3);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));

            PopulateWithArgs(stringArgs);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int MonsterId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 3);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));

            X = int.Parse(stringArgs[0]);
            Y = int.Parse(stringArgs[1]);
            MonsterId = int.Parse(stringArgs[2]);
        }

        public override string ToString()
        {
            return string.Join(",", X.ToString(), Y.ToString(), MonsterId);
        }
    }
}
