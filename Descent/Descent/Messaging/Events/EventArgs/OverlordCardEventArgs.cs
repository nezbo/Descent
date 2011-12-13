
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events regarding overlord cards.
    /// </summary>
    public sealed class OverlordCardEventArgs : GameEventArgs
    {
        public OverlordCardEventArgs(int overlordCardId)
        {
            Contract.Requires(overlordCardId > 0);

            OverlordCardId = overlordCardId;
        }

        public OverlordCardEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));
            PopulateWithArgs(stringArgs);
        }

        public int OverlordCardId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));

            OverlordCardId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return OverlordCardId.ToString();
        }
    }
}
