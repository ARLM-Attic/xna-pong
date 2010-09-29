using System;
using System.Collections.Generic;
using System.Linq;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using XNA.Pong.GameState;
using XNA.Pong.Scenes;
using XNA.Pong.Texture;
using IGameComponent = Microsoft.Xna.Framework.IGameComponent;
using IGameState = Game.Base.IGameState;

namespace XNA.Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PongGame : GameBase
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private CollisionManager _collisionManager;
        private IEntityFactory _entityFactory;
        private GameStateManager _gameStateManager;
        //private TextureManager _textureManager;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _collisionManager = new CollisionManager();
            _entityFactory = new EntityFactory(this);
            Content.RootDirectory = "Content";
            _gameStateManager = new GameStateManager(this);
            //_textureManager = new TextureManager(this);

            //_gameStateManager.AddGameState(new PlayingGameState(this));
            _gameStateManager.AddGameState(new InitializingGameState(this));
            

            //Components.Add(_textureManager);
            Components.Add(_gameStateManager);


            //Services.AddService(typeof(ITextureManager), _textureManager);
            Services.AddService(typeof(IEntityFactory), _entityFactory);
            Services.AddService(typeof(CollisionManager), _collisionManager);
            Services.AddService(typeof(ContentManager), Content);
            Services.AddService(typeof(GameStateManager), _gameStateManager);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well
        /// </summary>
        protected override void Initialize()
        {
            
            base.Initialize();



        }

        /// <summary>
        /// Handler will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            
            
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }


    }
}
