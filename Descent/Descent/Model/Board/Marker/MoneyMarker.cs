namespace Descent.Model.Board.Marker
{
    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A type of marker, that has money on it
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class MoneyMarker : Marker
    {
        public MoneyMarker(int id, string name, Texture2D texture, int movementPoints)
            : base(id, name, texture, movementPoints)
        {
        }

        /// <summary>
        /// Gives all heroes 100 coins
        /// </summary>
        /// <param name="hero">
        /// The hero standing on the marker
        /// </param>
        public override void PickUp(Hero hero)
        {
            foreach (Hero h in Player.Instance.HeroParty.AllHeroes)
            {
                h.Coins += 100;
            }

            if (Player.Instance.IsServer)
            {
                Player.Instance.EventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs("All heroes received 100 coins."));
            }
        }
    }
}
