
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events needing to send some kind of points. Like AddFatigue.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class PointsEventArgs : GameEventArgs
    {
        public PointsEventArgs(int points)
        {
            Points = points;
        }

        public PointsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            PopulateWithArgs(stringArgs);
        }

        public int Points { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            
            Contract.Requires(EventContractHelper.TryParseInt(stringArgs[0]));

            Points = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return Points.ToString();
        }
    }
}
