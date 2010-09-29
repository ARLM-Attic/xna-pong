using System;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Configuration;
using XNA.Pong.Entities;
using XNA.Pong.Input;

namespace XNA.Pong
{
    internal sealed class EntityFactory : IEntityFactory
    {

        #region Ctors

        public EntityFactory(Microsoft.Xna.Framework.Game game)
        {
            Game = game;

        }

        #endregion

        #region Properties

        private Microsoft.Xna.Framework.Game Game { get; set; }

        private CollisionManager _collisionManager;
        /// <summary>
        /// Gets the collision manager.
        /// </summary>
        /// <value>The collision manager.</value>
        public CollisionManager CollisionManager
        {
            get
            {
                return _collisionManager ?? (_collisionManager = (CollisionManager)Game.Services.GetService(typeof(CollisionManager)));
            }
        }

        #endregion

        /// <summary>
        /// Creates the sprite.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IEntity CreateSprite(string type)
        {
            IEntity entity = null;
            if (type == "Padel1")
            {
                entity = CreatePadel();

                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                //entity.SpriteTexture = _textureManager.GetTexture("PlanetBeam");
                entity.LoadContent(padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                entity.Input = new Player1KeyboardInput();
                entity.Name = "Player1";
            }

            if (type == "Padel2")
            {
                entity = CreatePadel();
                PadelConfiguration padelConfiguration = Game.Content.Load<PadelConfiguration>("Padel.Config");
                entity.LoadContent(padelConfiguration.AssetName);
                entity.Scale = padelConfiguration.Scale;
                entity.Position = new Vector2(Game.GraphicsDevice.Viewport.Width - entity.Size.Width - padelConfiguration.Position, (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                entity.Input = new Player2KeyboardInput();
                entity.Name = "Player2";
            }

            if (type == "Ball")
            {
                entity = CreateBall();
                BallConfiguration ballConfiguration = Game.Content.Load<BallConfiguration>("Ball.Config");
                entity.LoadContent(ballConfiguration.AssetName);
                entity.Scale = ballConfiguration.Scale;
                entity.Color = Color.Black;
                entity.Position = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - (entity.Size.Width / 2), (Game.GraphicsDevice.Viewport.Height / 2) - (entity.Size.Height / 2));
                BallInput input = new BallInput(new StartBallState());
                CollisionManager.Collision += new CollisionEventHandler(input.BallInput_Collision);
                entity.Input = input;
            }

            if (type == "Background")
            {
                entity = CreateBackground();
                entity.LoadContent("Grass");
                entity.Size = new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            }

            if( type=="Circle")
            {
                entity = new CircleDebugEntity(new NullInput(), new NullGraphics(), Game);
                entity.LoadContent("Pixel");
                entity.Name = "Circle";
            }

            return entity;
        }

        private IEntity CreatePadel()
        {
            return new Entity(new NullInput(), new NullGraphics(), Game);
        }

        private IEntity CreateBall()
        {
            return new Entity(new NullInput(), new NullGraphics(), Game);
        }
        private IEntity CreateBackground()
        {
            return new Entity(new NullInput(), new NullGraphics(), Game);
        }

        private IEntity CreateDefault()
        {
            return new Entity(new NullInput(), new NullGraphics(), Game);
        }
        
    }
}

  