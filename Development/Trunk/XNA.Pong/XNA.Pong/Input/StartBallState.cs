using Game.Base;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public class StartBallState : IBallState
    {

        public void Update(IEntity entity, GameTime gameTime, BallInput ballInput)
        {
            entity.Position = new Vector2(400, 300);
            entity.Direction = new Vector2(-0.5f, -0.3f);
            entity.Velocity = new Vector2(600, 600);
            ballInput.State = new PlayingBallState();
        }

    }
}