﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base
{
    public class GameTexture:ITexture, IGame
    {
        public GameTexture(Microsoft.Xna.Framework.Game game, string assetName)
        {
            AssetName = assetName;
            Game = game;
        }

        #region Members

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent()
        {
            if(!string.IsNullOrEmpty(AssetName))
            {
                ContentManager contentManager = (ContentManager)Game.Services.GetService(typeof (ContentManager));
                TextureBase = contentManager.Load<Texture2D>(AssetName);
            }
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            TextureBase.Dispose(); ;
        }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>The game.</value>
        public Microsoft.Xna.Framework.Game Game
        {
            get; set;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name of the asset.</value>
        public string AssetName { get; set; }

        /// <summary>
        /// Gets or sets the texture base.
        /// </summary>
        /// <value>The texture base.</value>
        public Texture TextureBase { get; private set; }

        #endregion



    }
}
