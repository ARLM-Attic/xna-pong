using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBase : IUpdateable, IEntity
    {
        #region Fields

        private Rectangle _size;
        private Rectangle _source;
        private float _scale = 1.0f;

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="game">The game.</param>
        protected EntityBase(IInput input, IGraphic graphics, Microsoft.Xna.Framework.Game game)
        {
            Input = input;
            Graphics = graphics;
            Color = Color.White;
            Game = game;
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Draws the specified sprite batch.
        /// 
        /// Calls the assigned concreat IGraphics Draw() method.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Draw(this);
        }
        
        /// <summary>
        /// Updates the specified game time.
        ///
        /// Calls the assigned concreat Input Update() method.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void IEntity.Update(GameTime gameTime)
        {
            Input.Update(this, gameTime);
        }

        private bool _enabled = true;
        public bool Enabled
        {
            get { return _enabled; }
        }

        public int UpdateOrder
        {
            get { return 1; }
        }

        public event EventHandler EnabledChanged;
        public event EventHandler UpdateOrderChanged;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            
        }

        ITextureManager TextureManager
        {
            get { return Game.Services.GetService(typeof(ITextureManager)) as ITextureManager; }
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public virtual void LoadContent(string assetName)
        {
            TextureManager.LoadTexture(assetName, this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>The name of the asset.</value>
        public string AssetName
        {
            get; set; 
        }
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public Vector2 Direction
        {
            get; set; 
        }

        /// <summary>
        /// Gets or sets the sprite texture.
        /// </summary>
        /// <value>The sprite texture.</value>
        public Texture2D SpriteTexture { get; set; }
        

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector2 Position{ get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public Rectangle Source
        {
            get { return _source; }
            set
            {
                _source = value;
                Size = new Rectangle(0,0, (int)(_source.Width * Scale), (int)(_source.Height* Scale) );
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Rectangle Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public float Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                Size = new Rectangle(0, 0, (int)(Source.Width * Scale), (int)(Source.Height * Scale));
            }
        }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// Gets or sets the velocity.
        /// </summary>
        /// <value>The velocity.</value>
        public Vector2 Velocity { get; set; }

        public float Rotation { get; set; }

        public Microsoft.Xna.Framework.Game Game
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the content manager.
        /// </summary>
        /// <value>The content manager.</value>
        public ContentManager ContentManager {
            get { return (ContentManager) Game.Services.GetService(typeof (ContentManager)); }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get; set; 
        }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        public IInput Input { get; set; }

        /// <summary>
        /// Gets or sets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public IGraphic Graphics { get; set; }

        #endregion

        #region Implementation of IUpdateable

        /// <summary>
        /// Called when the game component should be updated.
        /// </summary>
        /// <param name="gameTime">Snapshot of the game's timing state.</param>
        public virtual void Update(GameTime gameTime)
        {
            Input.Update(this, gameTime);
        }

        #endregion
    }
}