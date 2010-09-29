using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA.Pong.Scenes
{
    public abstract class SceneBase:IScene,IGame
    {
        public SceneBase(Microsoft.Xna.Framework.Game game)
        {
            Game = game;
        }

        private SpriteBatch _spriteBatch;
        /// <summary>
        /// Gets the sprite batch.
        /// </summary>
        /// <value>The sprite batch.</value>
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch ?? (_spriteBatch = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch))); }
        }

        private CollisionManager _collisionManager;
        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public CollisionManager CollisionManager
        {
            get {
                return _collisionManager ?? (_collisionManager = (CollisionManager) Game.Services.GetService(typeof (CollisionManager)));
            }
        }

        private IEntityFactory _entityFactory;
        /// <summary>
        /// Gets the entity factory.
        /// </summary>
        /// <value>The entity factory.</value>
        public IEntityFactory EntityFactory
        {
            get {
                return _entityFactory ?? (_entityFactory = (IEntityFactory) Game.Services.GetService(typeof (IEntityFactory)));
            }
        }

        #region Implementation of IGame

        public Microsoft.Xna.Framework.Game Game
        {
            get; set; }

        #endregion

        #region Implementation of IScene

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTimet);

        #endregion
    }
}