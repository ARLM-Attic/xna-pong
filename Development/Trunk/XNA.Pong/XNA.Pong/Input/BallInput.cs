using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace XNA.Pong.Input
{
    public class BallInput:IInput
    {
        private SoundEffect ballScored;
        private SoundEffect ballBounce;
        internal enum BallStates
        {
            Start,
            Playing,
            Score
        }

        private IEntity _entity;
        private GameTime _gametime;

        public BallInput(IBallState ballState)
        {
            State = ballState;
        }

        public void Update(IEntity entity, GameTime gameTime)
        {
            State.Update(entity, gameTime, this);
            _entity = entity;
            _gametime = gameTime;
            
            MoveBall();
            
            // Move this code somewhere
            if( ballScored == null )
            {
                ballScored = entity.Game.Content.Load<SoundEffect>("Supporters");
                ballBounce = entity.Game.Content.Load<SoundEffect>("Bounce");
            }
        }

        public void PlayScored()
        {
            ballScored.Play();
        }

        public void PlayBounce()
        {
            ballBounce.Play();
        }
        
        public void BallInput_Collision(object sender, CollisionEventArgs collisionEventArgs)
        {
            if( collisionEventArgs.CollisionWithEntity.Name == "Player1" || collisionEventArgs.CollisionWithEntity.Name == "Player2" )
            {
                _entity.Direction = new Vector2(_entity.Direction.X*-1, _entity.Direction.Y);
                ballBounce.Play();
                return;
            }
        }

        protected CollisionManager CollisionManager
        {
            get { return (CollisionManager) _entity.Game.Services.GetService(typeof (CollisionManager)); }
        }

        public IBallState State
        {
            get; set; 
        }

        private void MoveBall()
        {
            _entity.Position += _entity.Direction * _entity.Velocity * (float)_gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
