using Game.Base;
using Microsoft.Xna.Framework;

namespace XNA.Pong.Input
{
    public class Player2ScoredBallState : IBallState
    {
        public void Update(IEntity entity, GameTime gameTime, BallInput ballInput)
        {
            ballInput.PlayScored();
            entity.Position = new Vector2(500, 500);
            entity.Direction = new Vector2(-0.5f, -0.3f);
            ballInput.State = new PlayingBallState();
        }
    }
}