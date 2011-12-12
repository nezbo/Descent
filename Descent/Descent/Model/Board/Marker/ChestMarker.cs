
namespace Descent.Model.Board.Marker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A marker of a chest, on the board
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class ChestMarker : Marker
    {
        private EquipmentRarity rarity;

        public ChestMarker(int id, string name, int movementCost, EquipmentRarity rarity, Texture2D texture) : base(id, name, texture, movementCost)
        {
            this.rarity = rarity;
        }

        /// <summary>
        /// Will get a random chest Id and queue the event to open that chest
        /// </summary>
        /// <param name="hero">
        /// The hero that opend the chest
        /// </param>
        public override void PickUp(Hero hero)
        {
            if (Player.Instance.StateManager.GameState.CurrentPlayer == Player.Instance.Id)
            {
                // If I am the current player, I should pick the random chest to open and send the event.
                Player.Instance.EventManager.QueueEvent(EventType.OpenChest, new ChestEventArgs(Player.Instance.StateManager.GameState.GetRandomChestID(rarity)));
            }
        }
    }
}
