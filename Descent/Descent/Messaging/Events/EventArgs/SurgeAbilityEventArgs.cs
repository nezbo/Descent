
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
            AbilityId = abilityId;
        }

        public SurgeAbilityEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            PopulateWithArgs(stringArgs);
        }

        public int AbilityId { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length == 1);
            AbilityId = int.Parse(stringArgs[0]);
        }

        public override string ToString()
        {
            return AbilityId.ToString();
        }
    }
}
