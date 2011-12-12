namespace Descent.Model.Board.Marker
{
    using Descent.Model.Player.Figure;
    using Descent.Model.Player.Figure.HeroStuff;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A potion marker, that can be on a board
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public class PotionMarker : Marker
    {
        #region Fields

        private Equipment potion;
        
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="PotionMarker"/> class.
        /// </summary>
        /// <param name="id">
        /// The id of the marker
        /// </param>
        /// <param name="name">
        /// The name of the marker
        /// </param>
        /// <param name="texture">
        /// The texture of the marker
        /// </param>
        /// <param name="movementPoints">
        /// The movement points it costs to pickup the marker
        /// </param>
        /// <param name="potion">
        /// The potion that a hero will gain by picking it up
        /// </param>
        public PotionMarker(int id, string name, Texture2D texture, int movementPoints, Equipment potion)
            : base(id, name, texture, movementPoints)
        {
            this.potion = potion;
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Picks up the potion
        /// </summary>
        /// <param name="hero">
        /// The hero.
        /// </param>
        public override void PickUp(Hero hero)
        {
            hero.Inventory.EquipPotion(potion);
        }
        
        #endregion
    }
}
