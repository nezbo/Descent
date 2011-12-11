// -----------------------------------------------------------------------
// <copyright file="ChestMarker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board.Marker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Descent.Messaging.Events;
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
            Player.Player.Instance.EventManager.QueueEvent(
                EventType.OpenChest, 
                new ChestEventArgs(Player.Player.Instance.StateManager.GameState.GetRandomChestID(rarity)));
        }
    }
}
