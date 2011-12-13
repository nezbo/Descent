namespace Descent.Model.Board.Marker
{
    using System.Diagnostics.Contracts;

    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Either rubble, water og pit, that can be on a square.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class OtherMarkers : Marker
    {
        public OtherMarkers(int id, string name, Texture2D texture, int movementPoints)
            : base(id, name, texture, movementPoints)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            Contract.Requires(movementPoints >= 0);
        }

        public override void PickUp(Hero hero)
        {
            return;
        }
    }
}
