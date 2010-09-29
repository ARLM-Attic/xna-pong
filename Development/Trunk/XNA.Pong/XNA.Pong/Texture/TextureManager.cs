using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong.Texture
{
    public class TextureManager:GameComponent, ITextureManager
    {
        #region Fields

        private readonly Dictionary<string, ITexture> _items;

        #endregion


        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureManager"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="items">The items.</param>
        public TextureManager(Microsoft.Xna.Framework.Game game) : base(game)
        {
            _items = new Dictionary<string, ITexture>(TextureConfigurationHandler.Instance.Textures.Count);
        }

        #endregion

        #region Members

        /// <summary>
        /// Reference page contains code sample.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            UnloadContent();

            foreach (TextureConfigurationSection textureConfigurationSection in TextureConfigurationHandler.Instance.Textures)
            {
                AddTexture(textureConfigurationSection.AssetName);
            }
        }

        /// <summary>
        /// Unloads the content.
        /// </summary>
        public void UnloadContent()
        {
            foreach (KeyValuePair<string, ITexture> dictionaryEntry in _items)
            {
                dictionaryEntry.Value.TextureBase.Dispose();
            }
            _items.Clear();
        }

        public ITextureManager Instance
        {
            get { return Game.Services.GetService(typeof (ITextureManager)) as ITextureManager; }
        }

        /// <summary>
        /// Adds the texture.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddTexture(string assetName)
        {
            ITexture texture = new GameTexture(Game, assetName);
            texture.LoadContent();
            _items.Add(assetName, texture);
        }

        /// <summary>
        /// Determines whether [is valid texture] [the specified asset name].
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid texture] [the specified asset name]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidTexture(string assetName)
        {
            return !string.IsNullOrEmpty(assetName) && _items.ContainsKey(assetName);
        }

        /// <summary>
        /// Removes the texture.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void RemoveTexture(string assetName)
        {
            if( !IsValidTexture(assetName) )
            {
                return;
            }

            _items[assetName].UnloadContent();
            _items.Remove(assetName);
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <returns></returns>
        public Microsoft.Xna.Framework.Graphics.Texture GetTexture(string assetName)
        {
            if (!IsValidTexture(assetName) )
            {
                return null;
            }

            return _items[assetName].TextureBase;
        }

        /// <summary>
        /// Loads the texture.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="entity">The entity.</param>
        public void LoadTexture(string assetName, IEntity entity)
        {
            entity.SpriteTexture = GetTexture(assetName) as Texture2D;
            entity.AssetName = assetName;
            entity.Source = new Rectangle(0, 0, entity.SpriteTexture.Width, entity.SpriteTexture.Height);
            entity.Size = new Rectangle(0, 0, (int)(entity.SpriteTexture.Width * entity.Scale), (int)(entity.SpriteTexture.Height * entity.Scale));
        }

        #endregion

    }
}
