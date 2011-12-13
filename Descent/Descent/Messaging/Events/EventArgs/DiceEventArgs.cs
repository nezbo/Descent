
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for methods regarding one dice.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class DiceEventArgs : GameEventArgs
    {
        public DiceEventArgs(int diceId, int sideId)
        {
            Contract.Requires(diceId >= 0);
            Contract.Requires(sideId >= 0 && sideId <= 7);

            DiceId = diceId;
            SideId = sideId;
        }

        public DiceEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));
            Contract.Requires(int.Parse(stringArgs[0]) >= 0);
            Contract.Requires(int.Parse(stringArgs[1]) >= 0 && int.Parse(stringArgs[1]) <= 7);
            PopulateWithArgs(stringArgs);
        }

        public int DiceId { get; set; }

        public int SideId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            int b;
            Contract.Requires(Contract.ForAll(stringArgs, s => int.TryParse(s, out b)));
            Contract.Requires(int.Parse(stringArgs[0]) >= 0);
            Contract.Requires(int.Parse(stringArgs[1]) >= 0 && int.Parse(stringArgs[1]) <= 7);

            DiceId = int.Parse(stringArgs[0]);
            SideId = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", DiceId, SideId);
        }
    }
}
