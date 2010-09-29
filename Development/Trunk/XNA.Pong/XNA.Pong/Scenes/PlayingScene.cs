using System;
using System.Collections.Generic;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using XNA.Pong.Configuration;
using XNA.Pong.Input;
using XNA.Pong.Texture;

namespace XNA.Pong.Scenes
{
    /// <summary>
    /// 
    /// </summary>
    internal class PlayingScene : SceneBase
    {
        #region Fields

        private IEntity player1;
        private IEntity player2;
        private IEntity ball;
        private IEntity background;
        private SoundEffect ballBounce;
        private ICamera2D camera;
        private IEntity circle;

        private List<IEntity> _entities;
        //private TextureManager _textureManager;

        #endregion

        #region Ctors

        public PlayingScene(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
            _entities = new List<IEntity>();
            camera = new Camera2D(Game);
        }

        #endregion


        #region Methods

        public override void LoadContent()
        {
            //Game.Components.Add((IGameComponent)camera);


            background = EntityFactory.CreateSprite("Background");
            //_entities.Add(background);

            player1 = EntityFactory.CreateSprite("Padel1");
            camera.Focus = player1 as IFocusable;
            _entities.Add(player1);

            player2 = EntityFactory.CreateSprite("Padel2");
            _entities.Add(player2);



            ball = EntityFactory.CreateSprite("Ball");
            _entities.Add(ball);

            circle = EntityFactory.CreateSprite("Circle");
            //_entities.Add(circle);

            ballBounce = Game.Content.Load<SoundEffect>("Bounce");
        }

        public override void UnloadContent()
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            //SpriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.SaveState, camera.Transform);
            SpriteBatch.Begin();
            foreach (IEntity entity in _entities)
            {
                SpriteBatch.Draw(entity.SpriteTexture, entity.Position, entity.Source, entity.Color, entity.Rotation, entity.Origin, entity.Scale, SpriteEffects.None, 0);
            }


            int length = 50;
            float angle = 0.0f;
            float angleStepsize = 0.1f;
            circle.Position = new Vector2(400, 300);
            int x = 0;
            while (angle < 2 * Math.PI)
            {
                circle.Position = new Vector2(angle+50+x, 250+ (float) (length*Math.Sin(angle)));

                SpriteBatch.Draw(circle.SpriteTexture, circle.Position, circle.Source, Color.Black, circle.Rotation, circle.Origin, circle.Scale, SpriteEffects.None, 0);
                angle += angleStepsize;
                x+= 5;
            }


            SpriteBatch.End();
        }


        public override void Update(GameTime gameTime)
        {
            //camera.Focus = ball as IFocusable;

            foreach (IEntity entity in _entities)
            {
                entity.Update(gameTime);
            }
            
            // Perform collisions detection and delegate it
            // entities collision detection

            //for (int i = 0; i < _entities.Count-1; i++)
            //{
            //    _collisionManager.PerformCollisionCheck(_entities[i], _entities[i + 1]);
            //}

            CollisionManager.PerformCollisionCheck(ball, player1);
            CollisionManager.PerformCollisionCheck(ball, player2);

        }
        #endregion
    }
}
