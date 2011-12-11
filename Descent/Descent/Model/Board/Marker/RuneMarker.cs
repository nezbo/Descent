// -----------------------------------------------------------------------
// <copyright file="RuneMarker.cs" company="">
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

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
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
            this.color = color;
        }

        public override void PickUp(Hero hero)
        {
            Player.Player.Instance.HeroParty.AddRuneKey(color);
        }
    }
}
