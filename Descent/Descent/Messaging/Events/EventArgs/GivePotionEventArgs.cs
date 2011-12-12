
namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for the GivePotion event.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class GivePotionEventArgs : GameEventArgs
    {
        public GivePotionEventArgs(int playerId, PotionType potionType)
        {
            Contract.Requires(playerId > 0);

            PlayerId = playerId;
            PotionType = potionType;
        }

        public GivePotionEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 2);
            PopulateWithArgs(stringArgs);
        }

        public int PlayerId { get; set; }

        public PotionType PotionType { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);

            PlayerId = int.Parse(stringArgs[0]);
            PotionType = (PotionType)Enum.ToObject(typeof(PotionType), int.Parse(stringArgs[1]));
        }

        public override string ToString()
        {
            return string.Join(",", PlayerId, ((int)PotionType).ToString());
        }
    }
}
