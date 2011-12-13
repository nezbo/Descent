namespace Descent.Model.Board.Marker
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A glyph is a portal and a valid starting point.
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class GlyphMarker : Marker
    {
        public bool Open { get; private set; }

        private Texture2D openTexture;

        public GlyphMarker(int id, string name, Texture2D texture, int movementPoints, bool open, Texture2D openTexture)
            : base(id, name, texture, movementPoints)
        {
            this.Open = open;
            if (open) this.Texture = openTexture;
            this.openTexture = openTexture;
        }

        public override void PickUp(Hero hero)
        {
            if (Open) return;
            Player.Player.Instance.HeroParty.AddConquestTokens(3);
            Open = !Open;
            Texture = openTexture;
        }
    }
}
