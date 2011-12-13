namespace Descent.Messaging.Events
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Helper enum to make the type of a potion typesafe in the event scheme.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public enum PotionType
    {
        Health = 1,
        Fatigue = 2
    }

    /// <summary>
    /// The event arguments for the RequestBuyPotion event.
    /// </summary>
    public sealed class RequestBuyPotionEventArgs : GameEventArgs
    {
        public RequestBuyPotionEventArgs(PotionType potionType)
        {
            PotionType = potionType;
        }

        public RequestBuyPotionEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PopulateWithArgs(stringArgs);
        }

        public PotionType PotionType { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs.Length >= 1);
            PotionType = (PotionType)Enum.ToObject(typeof(PotionType), int.Parse(stringArgs[0]));
        }

        public override string ToString()
        {
            return ((int)PotionType).ToString();
        }
    }
}
