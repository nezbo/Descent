namespace Descent.Model.Board.Marker
{
    using System.Diagnostics.Contracts;

    using Descent.GUI;
    using Descent.Model.Player.Figure;

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// A generic marker that is on the board, that can be picked up and used
    /// </summary>
    /// <author>
    /// Jonas Breindahl (jobre@itu.dk)
    /// </author>
    public abstract class Marker : Drawable
    {
        #region Fields

        private int id;
        private string name;
        private Texture2D texture;
        private int movementPoints;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the unique id of the marker
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the name of the marker
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets or sets the texture of the marker
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return texture;
            }

            protected set
            {
                texture = value;
            }
        }

        /// <summary>
        /// Gets the number of movementpoints it costs to pick up/interact with the marker
        /// </summary>
        public int MovementPoints
        {
            get
            {
                return movementPoints;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="Marker"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique id of the marker
        /// </param>
        /// <param name="name">
        /// The name of the marker
        /// </param>
        /// <param name="texture">
        /// The texture of the marker
        /// </param>
        /// <param name="movementPoints">
        /// The movement points that it costs to interact with it
        /// </param>
        public Marker(int id, string name, Texture2D texture, int movementPoints)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            Contract.Requires(movementPoints >= 0);
            this.name = name;
            this.texture = texture;
            this.movementPoints = movementPoints;
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Picks up, or interacts with, the marker
        /// </summary>
        /// <param name="hero">
        /// The hero, standing on the marker
        /// </param>
        public abstract void PickUp(Hero hero);

        /// <summary>
        /// The cost of interacting is always larger or equal to zero
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(movementPoints >= 0);
        }

        #endregion
    }
}
