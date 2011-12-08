// -----------------------------------------------------------------------
// <copyright file="EventCard.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Player.Overlord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EventCard : OverlordCard
    {

        public EventCard(int id, string name, string description, int playPrice, int sellPrice)
            : base(id, name, description, playPrice, sellPrice)
        {
            
        }

        public override void PlayCard()
        {
            // TODO: Play card
        }
    }
}
