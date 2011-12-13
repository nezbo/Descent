namespace Descent.Model.Board.Marker
{
    using System.Diagnostics.Contracts;

    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A type of marker, that has a rune key on it
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class RuneMarker : Marker
    {
        private RuneKey color;

        /// <summary>
        /// A Rune, that will make the heroes able to open rune doors of that color
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        /// <param name="movementPoints"></param>
        /// <param name="color"></param>
        public RuneMarker(int id, string name, Texture2D texture, int movementPoints, RuneKey color)
            : base(id, name, texture, movementPoints)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            Contract.Requires(movementPoints >= 0);
            Contract.Requires(color != RuneKey.None);

            this.color = color;
        }

        /// <summary>
        /// Adds the runes color to the hero party
        /// </summary>
        /// <param name="hero">
        /// The hero standing on the marker
        /// </param>
        public override void PickUp(Hero hero)
        {
            Player.Instance.HeroParty.AddRuneKey(color);

            if (Player.Instance.IsServer)
            {
                Player.Instance.EventManager.QueueEvent(EventType.ChatMessage, new ChatMessageEventArgs("The hero party collected a " + color.ToString().ToLower() + " rune."));
            }
        }
    }
}
