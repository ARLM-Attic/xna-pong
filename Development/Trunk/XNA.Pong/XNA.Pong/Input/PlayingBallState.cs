using Game.Base;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public class PlayingBallState : IBallState
    {
        public void Update(IEntity entity, GameTime gameTime, BallInput ballInput)
        {
            if (entity.Position.X <= 0)
            {
                ballInput.State = new Player2ScoredBallState();
                return;
            }

            if (entity.Position.X >= entity.Game.GraphicsDevice.Viewport.Width)
            {
                ballInput.State = new Player1ScoredBallState();
                return;
            }

            if (entity.Position.Y < 0 || entity.Position.Y + entity.Size.Height > 800)
            {
                entity.Velocity = new Vector2(entity.Velocity.X, - entity.Velocity.Y);
                ballInput.PlayBounce();
                return;
            }

            CollisionManager collisionManager = (CollisionManager)entity.Game.Services.GetService(typeof (CollisionManager));
            if (collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(entity),
                                                       new Rectangle(0, 0, entity.Game.GraphicsDevice.Viewport.Width, 0))
                ||
                collisionManager.PerformCollisionCheck(collisionManager.GetBoundingBox(entity),
                                                       new Rectangle(0, entity.Game.GraphicsDevice.Viewport.Height, entity.Game.GraphicsDevice.Viewport.Width, 0)))
            {
                entity.Direction = new Vector2(entity.Direction.X, entity.Direction.Y * -1);
                ballInput.PlayBounce();
                return;
            }
        }
    }
}