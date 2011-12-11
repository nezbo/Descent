// -----------------------------------------------------------------------
// <copyright file="Marker.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Descent.Model.Board.Marker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

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
            this.name = name;
            this.texture = texture;
            this.movementPoints = movementPoints;
        }

        #endregion 

        #region Methods

        public abstract void PickUp(Hero hero);

        #endregion
    }
}
