
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for events about surge abilities.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class SurgeAbilityEventArgs : GameEventArgs
    {
        public SurgeAbilityEventArgs(int abilityId)
        {
            Contract.Requires(abilityId > 1);
            AbilityId = abilityId;
        }

        public SurgeAbilityEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));

            PopulateWithArgs(stringArgs);
        }

        public int AbilityId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 1);
            int b;
            Contract.Requires(int.TryParse(stringArgs[0], out b));

            AbilityId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return AbilityId.ToString();
        }
    }
}
