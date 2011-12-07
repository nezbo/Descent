namespace Descent.Model.Player.Overlord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <author>
    /// Martin Marcher
    /// </author>
    public abstract class OverlordCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public int PlayPrice { get; private set; }

        public int SellPrice { get; private set; }
    }
}
