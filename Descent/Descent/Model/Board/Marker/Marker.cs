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

    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Marker : Drawable
    {

        #region Fields

        private string name;
        private Texture2D texture;

        #endregion

        #region Properties

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
        }

        #endregion

        #region Initialization

        public Marker(string name, Texture2D texture)
        {
            this.name = name;
            this.texture = texture;
        }

        #endregion 

        #region Methods

        #endregion  
    }
}
